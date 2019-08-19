using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binary_Patcher
{
    public partial class MainWindow : Form
    {
        private int bytesToChange = 1;
        private FileStream fileStream;
        
        public MainWindow()
        {
            InitializeComponent();
            bytesCombo.SelectedIndex = 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fileStream != null)
                fileStream.Close();
        }

        private void fileOpenButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (fileStream != null)
                fileStream.Close();

            this.Activate();
            openedFileName.Text = openFileDialog1.FileName;
            fileStream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.ReadWrite);

            if (fileStream.Length == 0)
            {
                MessageBox.Show("File can not be empty (ad least 1 byte size is required)", "File is empty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                fileStream.Close();
                openedFileName.Text = "";
                return;
            }

            if (bytesToChange > fileStream.Length)
            {
                bytesToChange = 1;
                bytesCombo.SelectedIndex = 0;
            }

            maxOffsetLabel.Text = "Max offset: " + (fileStream.Length - bytesToChange).ToString();

            updateDataAtOffsetField();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox obj = (ComboBox)sender;

            switch (obj.SelectedIndex)
            {
                case 0: bytesToChange =  1; break;
                case 1: bytesToChange =  2; break;
                case 2: bytesToChange =  4; break;
                case 3: bytesToChange =  8; break;
                case 4: bytesToChange = 16; break;
            }

            if (fileStream != null)
            {
                if (bytesToChange > fileStream.Length)
                {
                    bytesToChange = 1;
                    bytesCombo.SelectedIndex = 0;
                }

                maxOffsetLabel.Text = "Max offset: " + (fileStream.Length - bytesToChange).ToString();

                updateDataAtOffsetField();
            }
        }

        private void applyPatch_Click(object sender, EventArgs e)
        {
            if (fileStream == null || !fileStream.CanWrite)
            {
                MessageBox.Show("You didn't open a file to modify or it is unnable to modify chosen file", "No write access", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            byte[] newData;
            try
            {
                newData = convertFromString(newPatchData.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }

            if (newData.Length != bytesToChange)
            {
                MessageBox.Show("The length of data in \"New Data\" field have another length that was chosen.\nChanges will not be applied.", "Incorrect data length", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                Int64 offset = Convert.ToInt64(fileOffset.Text);
                fileStream.Seek(offset, SeekOrigin.Begin);

                if (Convert.ToInt64(fileOffset.Text) > fileStream.Length - bytesToChange)
                {
                    MessageBox.Show("Do you try to cheat me?\nI don't know how, but offset is to high", "???", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
                else if (Convert.ToInt64(fileOffset.Text) < 0)
                {
                    MessageBox.Show("Do you try to cheat me?\nI don't know how, but offset is negative", "???", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Do you try to cheat me?\nThe offset is wrong. You know?", "???", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            fileStream.Write(newData, 0, bytesToChange);
            fileStream.Flush();

            dataAtOffset.Text = newPatchData.Text;
        }

        private void fileOffset_TextChanged(object sender, EventArgs e)
        {
            TextBox obj = (TextBox)sender;

            if (fileStream != null)
            {
                try
                {
                    if (Convert.ToInt64(obj.Text) > fileStream.Length - bytesToChange)
                        obj.Text = (fileStream.Length - bytesToChange).ToString();
                    else if (Convert.ToInt64(obj.Text) < 0)
                        obj.Text = "0";
                }
                catch (FormatException)
                {
                    MessageBox.Show("Offset have to be a numeric value in between 0-Max offset", "Not numeric offset", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    obj.Text = "0";
                }
                catch (OverflowException)
                {
                    MessageBox.Show("Other exception");
                }

                updateDataAtOffsetField();
            }
        }

        private void dataRadio_CheckedChanged(object sender, EventArgs e)
        {
            updateDataAtOffsetField();
        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                fileOffset.Text = (Convert.ToInt64(fileOffset.Text) + (bytesScrollBar.Value * -1) * bytesToChange).ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Did you know, that file offset have to be a decimal number?");
                return;
            }

            bytesScrollBar.Value = 0;

            updateDataAtOffsetField();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                fileOffset.Text = (Convert.ToInt64(fileOffset.Text) + singleByteScrollBar.Value).ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Did you know, that file offset have to be a decimal number?");
                return;
            }

            singleByteScrollBar.Value = 0;

            updateDataAtOffsetField();
        }

        private void updateDataAtOffsetField()
        {
            if (fileStream != null && fileStream.CanRead && fileStream.CanSeek)
            {
                try
                {
                    if (Convert.ToInt64(fileOffset.Text) > fileStream.Length - bytesToChange)
                        fileOffset.Text = (fileStream.Length - bytesToChange).ToString();
                    else if (Convert.ToInt64(fileOffset.Text) < 0)
                        fileOffset.Text = "0";

                    fileStream.Seek(Convert.ToInt64(fileOffset.Text), SeekOrigin.Begin);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Do you try to cheat me?");
                    return;
                }

                byte[] data = new byte[bytesToChange];
                fileStream.Read(data, 0, bytesToChange);
                dataAtOffset.Text = convertToString(data);
            }
        }

        private string convertToString(byte[] data)
        {
            if (dataHEX.Checked)
                return convertToString(data, 0);
            else if (dataDEC.Checked)
                return convertToString(data, 1);
            else
                return convertToString(data, 2);

        }

        //types: 0=HEX; 1=DEC; 2=ASCII
        private string convertToString(byte[] data, byte type)
        {
            string returnData = "";

            if (type == 2)
            {
                return Encoding.ASCII.GetString(data);
            }
            else
            {
                foreach (byte b in data)
                {
                    switch (type)
                    {
                        case 0:
                            {
                                if (Convert.ToString(b, 16).Length == 1)
                                    returnData += "0";

                                returnData += Convert.ToString(b, 16).ToUpper();
                                break;
                            }
                        case 1: returnData += b.ToString() + ","; break;
                    }
                }

                if (type == 1)
                    returnData = returnData.Remove(returnData.Length - 1);
            }

            return returnData;
        }

        private byte[] convertFromString(string data)
        {
            if (dataHEX.Checked)
                return convertFromString(data, 0);
            else if (dataDEC.Checked)
                return convertFromString(data, 1);
            else
                return convertFromString(data, 2);
        }

        //types: 0=HEX; 1=DEC; 2=ASCII
        private byte[] convertFromString(string data, byte type)
        {
            byte[] returnData;

            if (type == 0)
            {
                if ((data.Length % 2) != 0)
                {
                    throw new FormatException("The length of string must be even (each HEX value length must be 2)");
                }
                returnData = new byte[(int)Math.Ceiling((double)data.Length / 2)];

                int tabPos = 0;
                for (int i = 0; i < data.Length; i += 2)
                {
                    try
                    {
                        returnData[tabPos++] = Convert.ToByte(data.Substring(i, 2), 16);
                    }
                    catch (FormatException)
                    {
                        throw new FormatException("One or more values are not porper HEX numbers");
                    }
                }
            }
            else if (type == 1)
            {
                string[] bytes = data.Split(new Char[] { ',' });
                returnData = new byte[bytes.Length];

                int tabPos = 0;
                foreach (string singleDEC in bytes)
                {
                    try
                    {
                        if (singleDEC.Length == 0 || Convert.ToInt32(singleDEC) > 255)
                        {
                            throw new OverflowException("One or more decimal numbers are not in 0-255 bounds");
                        }
                    }
                    catch (System.FormatException)
                    {
                        throw new FormatException("One or more values are not a proper number");
                    }

                    returnData[tabPos++] = Convert.ToByte(singleDEC);
                }
            }
            else
            {
                returnData = new byte[data.Length];

                for (int i = 0; i < data.Length; i += 1)
                {
                    returnData[i] = (byte)data[i];
                }
            }

            return returnData;
        }
    }
}

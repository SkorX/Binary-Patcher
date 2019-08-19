namespace Binary_Patcher
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.fileOpenButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.openedFileName = new System.Windows.Forms.TextBox();
            this.maxOffsetLabel = new System.Windows.Forms.Label();
            this.bytesCombo = new System.Windows.Forms.ComboBox();
            this.fileOffset = new System.Windows.Forms.TextBox();
            this.dataAtOffset = new System.Windows.Forms.TextBox();
            this.newPatchData = new System.Windows.Forms.TextBox();
            this.dataHEX = new System.Windows.Forms.RadioButton();
            this.dataDEC = new System.Windows.Forms.RadioButton();
            this.dataASCII = new System.Windows.Forms.RadioButton();
            this.applyPatch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.singleByteScrollBar = new System.Windows.Forms.NumericUpDown();
            this.bytesScrollBar = new System.Windows.Forms.VScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.singleByteScrollBar)).BeginInit();
            this.SuspendLayout();
            // 
            // fileOpenButton
            // 
            this.fileOpenButton.Location = new System.Drawing.Point(12, 6);
            this.fileOpenButton.Name = "fileOpenButton";
            this.fileOpenButton.Size = new System.Drawing.Size(75, 23);
            this.fileOpenButton.TabIndex = 0;
            this.fileOpenButton.Text = "Open File";
            this.toolTip1.SetToolTip(this.fileOpenButton, "Opens a file that you want to modify");
            this.fileOpenButton.UseVisualStyleBackColor = true;
            this.fileOpenButton.Click += new System.EventHandler(this.fileOpenButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "NES ROM (*.nes)|*.nes|All files (*.*)|*.*";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Tooltip";
            // 
            // openedFileName
            // 
            this.openedFileName.Location = new System.Drawing.Point(93, 9);
            this.openedFileName.Name = "openedFileName";
            this.openedFileName.ReadOnly = true;
            this.openedFileName.Size = new System.Drawing.Size(279, 20);
            this.openedFileName.TabIndex = 0;
            this.openedFileName.TabStop = false;
            this.toolTip1.SetToolTip(this.openedFileName, "Displays a path of opened file");
            // 
            // maxOffsetLabel
            // 
            this.maxOffsetLabel.AutoSize = true;
            this.maxOffsetLabel.Location = new System.Drawing.Point(12, 40);
            this.maxOffsetLabel.Name = "maxOffsetLabel";
            this.maxOffsetLabel.Size = new System.Drawing.Size(59, 13);
            this.maxOffsetLabel.TabIndex = 1;
            this.maxOffsetLabel.Text = "Max offset:";
            this.toolTip1.SetToolTip(this.maxOffsetLabel, "Tells you how high possible offset you can patch (offset is in range 0-Max)");
            // 
            // bytesCombo
            // 
            this.bytesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bytesCombo.FormattingEnabled = true;
            this.bytesCombo.Items.AddRange(new object[] {
            "1 byte",
            "2 bytes",
            "4 bytes",
            "8 bytes",
            "16 bytes"});
            this.bytesCombo.Location = new System.Drawing.Point(287, 35);
            this.bytesCombo.Name = "bytesCombo";
            this.bytesCombo.Size = new System.Drawing.Size(65, 21);
            this.bytesCombo.TabIndex = 1;
            this.toolTip1.SetToolTip(this.bytesCombo, "Select how many bytes you want to update at once");
            this.bytesCombo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // fileOffset
            // 
            this.fileOffset.Location = new System.Drawing.Point(59, 62);
            this.fileOffset.Name = "fileOffset";
            this.fileOffset.Size = new System.Drawing.Size(300, 20);
            this.fileOffset.TabIndex = 2;
            this.fileOffset.Text = "0";
            this.toolTip1.SetToolTip(this.fileOffset, "Contains an offset at which data will be applied");
            this.fileOffset.TextChanged += new System.EventHandler(this.fileOffset_TextChanged);
            // 
            // dataAtOffset
            // 
            this.dataAtOffset.Location = new System.Drawing.Point(92, 88);
            this.dataAtOffset.Name = "dataAtOffset";
            this.dataAtOffset.ReadOnly = true;
            this.dataAtOffset.Size = new System.Drawing.Size(280, 20);
            this.dataAtOffset.TabIndex = 6;
            this.dataAtOffset.TabStop = false;
            this.toolTip1.SetToolTip(this.dataAtOffset, "Shows what data is already at selected offset in chosen file");
            // 
            // newPatchData
            // 
            this.newPatchData.Location = new System.Drawing.Point(76, 137);
            this.newPatchData.Name = "newPatchData";
            this.newPatchData.Size = new System.Drawing.Size(296, 20);
            this.newPatchData.TabIndex = 4;
            this.toolTip1.SetToolTip(this.newPatchData, "Text that represents data to apply as chosen type (have to be the same length as " +
        "chosen on dropdown list)");
            // 
            // dataHEX
            // 
            this.dataHEX.AutoSize = true;
            this.dataHEX.Checked = true;
            this.dataHEX.Location = new System.Drawing.Point(76, 114);
            this.dataHEX.Name = "dataHEX";
            this.dataHEX.Size = new System.Drawing.Size(47, 17);
            this.dataHEX.TabIndex = 3;
            this.dataHEX.TabStop = true;
            this.dataHEX.Text = "HEX";
            this.toolTip1.SetToolTip(this.dataHEX, "Indicates that applying data will be given as HEX values");
            this.dataHEX.UseVisualStyleBackColor = true;
            this.dataHEX.CheckedChanged += new System.EventHandler(this.dataRadio_CheckedChanged);
            // 
            // dataDEC
            // 
            this.dataDEC.AutoSize = true;
            this.dataDEC.Location = new System.Drawing.Point(129, 114);
            this.dataDEC.Name = "dataDEC";
            this.dataDEC.Size = new System.Drawing.Size(47, 17);
            this.dataDEC.TabIndex = 3;
            this.dataDEC.Text = "DEC";
            this.toolTip1.SetToolTip(this.dataDEC, "Indicates that applying data will be given as decimal values (every value must be" +
        " comma-separated)");
            this.dataDEC.UseVisualStyleBackColor = true;
            this.dataDEC.CheckedChanged += new System.EventHandler(this.dataRadio_CheckedChanged);
            // 
            // dataASCII
            // 
            this.dataASCII.AutoSize = true;
            this.dataASCII.Location = new System.Drawing.Point(182, 114);
            this.dataASCII.Name = "dataASCII";
            this.dataASCII.Size = new System.Drawing.Size(52, 17);
            this.dataASCII.TabIndex = 3;
            this.dataASCII.Text = "ASCII";
            this.toolTip1.SetToolTip(this.dataASCII, "Indicates that applying data will be given as ASCII characters");
            this.dataASCII.UseVisualStyleBackColor = true;
            this.dataASCII.CheckedChanged += new System.EventHandler(this.dataRadio_CheckedChanged);
            // 
            // applyPatch
            // 
            this.applyPatch.Location = new System.Drawing.Point(284, 163);
            this.applyPatch.Name = "applyPatch";
            this.applyPatch.Size = new System.Drawing.Size(88, 23);
            this.applyPatch.TabIndex = 5;
            this.applyPatch.Text = "Apply Patch";
            this.toolTip1.SetToolTip(this.applyPatch, "Applies data to the file");
            this.applyPatch.UseVisualStyleBackColor = true;
            this.applyPatch.Click += new System.EventHandler(this.applyPatch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Offset: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Data at offset:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "New Data:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Input type:";
            // 
            // singleByteScrollBar
            // 
            this.singleByteScrollBar.Location = new System.Drawing.Point(356, 62);
            this.singleByteScrollBar.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.singleByteScrollBar.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.singleByteScrollBar.Name = "singleByteScrollBar";
            this.singleByteScrollBar.Size = new System.Drawing.Size(16, 20);
            this.singleByteScrollBar.TabIndex = 7;
            this.toolTip1.SetToolTip(this.singleByteScrollBar, "Changes offset by 1");
            this.singleByteScrollBar.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // bytesScrollBar
            // 
            this.bytesScrollBar.AllowDrop = true;
            this.bytesScrollBar.LargeChange = 1;
            this.bytesScrollBar.Location = new System.Drawing.Point(355, 32);
            this.bytesScrollBar.Maximum = 1;
            this.bytesScrollBar.Minimum = -1;
            this.bytesScrollBar.Name = "bytesScrollBar";
            this.bytesScrollBar.Size = new System.Drawing.Size(17, 27);
            this.bytesScrollBar.TabIndex = 8;
            this.toolTip1.SetToolTip(this.bytesScrollBar, "Changes offset by a number of chosen bytes to update");
            this.bytesScrollBar.ValueChanged += new System.EventHandler(this.vScrollBar1_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 193);
            this.Controls.Add(this.bytesScrollBar);
            this.Controls.Add(this.singleByteScrollBar);
            this.Controls.Add(this.applyPatch);
            this.Controls.Add(this.dataASCII);
            this.Controls.Add(this.dataDEC);
            this.Controls.Add(this.dataHEX);
            this.Controls.Add(this.newPatchData);
            this.Controls.Add(this.dataAtOffset);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fileOffset);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bytesCombo);
            this.Controls.Add(this.maxOffsetLabel);
            this.Controls.Add(this.openedFileName);
            this.Controls.Add(this.fileOpenButton);
            this.MaximumSize = new System.Drawing.Size(400, 232);
            this.MinimumSize = new System.Drawing.Size(400, 232);
            this.Name = "Form1";
            this.Text = "Binary Patcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.singleByteScrollBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button fileOpenButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox openedFileName;
        private System.Windows.Forms.Label maxOffsetLabel;
        private System.Windows.Forms.ComboBox bytesCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fileOffset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dataAtOffset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox newPatchData;
        private System.Windows.Forms.RadioButton dataHEX;
        private System.Windows.Forms.RadioButton dataDEC;
        private System.Windows.Forms.RadioButton dataASCII;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button applyPatch;
        private System.Windows.Forms.NumericUpDown singleByteScrollBar;
        private System.Windows.Forms.VScrollBar bytesScrollBar;
    }
}

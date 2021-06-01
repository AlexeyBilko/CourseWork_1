namespace Chess_Sample
{
    partial class ChessWindow
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
            this.ClearSelectionButton = new System.Windows.Forms.Button();
            this.LoadFromFile = new System.Windows.Forms.Button();
            this.filename_label = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ClearBoardButton = new System.Windows.Forms.Button();
            this.comboBox_FigureName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_Y = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_X = new System.Windows.Forms.NumericUpDown();
            this.AddFigureButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SaveInFile = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_X_R = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown_Y_R = new System.Windows.Forms.NumericUpDown();
            this.RemoveFigure = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_X)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_X_R)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Y_R)).BeginInit();
            this.SuspendLayout();
            // 
            // ClearSelectionButton
            // 
            this.ClearSelectionButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClearSelectionButton.FlatAppearance.BorderSize = 0;
            this.ClearSelectionButton.Location = new System.Drawing.Point(16, 21);
            this.ClearSelectionButton.Name = "ClearSelectionButton";
            this.ClearSelectionButton.Size = new System.Drawing.Size(129, 35);
            this.ClearSelectionButton.TabIndex = 0;
            this.ClearSelectionButton.Text = "Clear Selection";
            this.ClearSelectionButton.UseVisualStyleBackColor = false;
            this.ClearSelectionButton.Click += new System.EventHandler(this.ClearCanMove_Click);
            // 
            // button2
            // 
            this.LoadFromFile.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LoadFromFile.Location = new System.Drawing.Point(212, 21);
            this.LoadFromFile.Name = "button2";
            this.LoadFromFile.Size = new System.Drawing.Size(113, 46);
            this.LoadFromFile.TabIndex = 1;
            this.LoadFromFile.Text = "Load File (.txt)";
            this.LoadFromFile.UseVisualStyleBackColor = false;
            this.LoadFromFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // filename_label
            // 
            this.filename_label.AutoSize = true;
            this.filename_label.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filename_label.Location = new System.Drawing.Point(24, 34);
            this.filename_label.Name = "filename_label";
            this.filename_label.Size = new System.Drawing.Size(19, 24);
            this.filename_label.TabIndex = 2;
            this.filename_label.Text = "-";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.filename_label);
            this.groupBox1.Controls.Add(this.LoadFromFile);
            this.groupBox1.Location = new System.Drawing.Point(665, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 78);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load from File";
            // 
            // ClearBoardButton
            // 
            this.ClearBoardButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClearBoardButton.Location = new System.Drawing.Point(185, 21);
            this.ClearBoardButton.Name = "ClearBoardButton";
            this.ClearBoardButton.Size = new System.Drawing.Size(129, 35);
            this.ClearBoardButton.TabIndex = 4;
            this.ClearBoardButton.Text = "Clear board";
            this.ClearBoardButton.UseVisualStyleBackColor = false;
            this.ClearBoardButton.Click += new System.EventHandler(this.ClearBoard_Click);
            // 
            // comboBox_FigureName
            // 
            this.comboBox_FigureName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBox_FigureName.FormattingEnabled = true;
            this.comboBox_FigureName.Location = new System.Drawing.Point(16, 37);
            this.comboBox_FigureName.Name = "comboBox_FigureName";
            this.comboBox_FigureName.Size = new System.Drawing.Size(127, 24);
            this.comboBox_FigureName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Coordinate Y:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Coordinate X:";
            // 
            // numericUpDown_Y
            // 
            this.numericUpDown_Y.BackColor = System.Drawing.Color.WhiteSmoke;
            this.numericUpDown_Y.Location = new System.Drawing.Point(260, 22);
            this.numericUpDown_Y.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDown_Y.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Y.Name = "numericUpDown_Y";
            this.numericUpDown_Y.Size = new System.Drawing.Size(54, 22);
            this.numericUpDown_Y.TabIndex = 8;
            this.numericUpDown_Y.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_X
            // 
            this.numericUpDown_X.BackColor = System.Drawing.Color.WhiteSmoke;
            this.numericUpDown_X.Location = new System.Drawing.Point(260, 50);
            this.numericUpDown_X.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDown_X.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_X.Name = "numericUpDown_X";
            this.numericUpDown_X.Size = new System.Drawing.Size(54, 22);
            this.numericUpDown_X.TabIndex = 9;
            this.numericUpDown_X.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // AddFigureButton
            // 
            this.AddFigureButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.AddFigureButton.Location = new System.Drawing.Point(100, 98);
            this.AddFigureButton.Name = "AddFigureButton";
            this.AddFigureButton.Size = new System.Drawing.Size(140, 35);
            this.AddFigureButton.TabIndex = 10;
            this.AddFigureButton.Text = "Add Figure";
            this.AddFigureButton.UseVisualStyleBackColor = false;
            this.AddFigureButton.Click += new System.EventHandler(this.AddFigure_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_FigureName);
            this.groupBox2.Controls.Add(this.AddFigureButton);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.numericUpDown_X);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.numericUpDown_Y);
            this.groupBox2.Location = new System.Drawing.Point(665, 198);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(331, 152);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add Figure";
            // 
            // button5
            // 
            this.SaveInFile.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SaveInFile.Location = new System.Drawing.Point(116, 30);
            this.SaveInFile.Name = "button5";
            this.SaveInFile.Size = new System.Drawing.Size(113, 46);
            this.SaveInFile.TabIndex = 12;
            this.SaveInFile.Text = "Save to File (.txt)";
            this.SaveInFile.UseVisualStyleBackColor = false;
            this.SaveInFile.Click += new System.EventHandler(this.SaveInFile_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.SaveInFile);
            this.groupBox3.Location = new System.Drawing.Point(665, 498);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(331, 98);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Controls.Add(this.ClearBoardButton);
            this.groupBox4.Controls.Add(this.ClearSelectionButton);
            this.groupBox4.Location = new System.Drawing.Point(665, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(331, 73);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.RemoveFigure);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.numericUpDown_X_R);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.numericUpDown_Y_R);
            this.groupBox5.Location = new System.Drawing.Point(665, 372);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(331, 107);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Remove Figure";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Coordinate X:";
            // 
            // numericUpDown_X_R
            // 
            this.numericUpDown_X_R.BackColor = System.Drawing.Color.WhiteSmoke;
            this.numericUpDown_X_R.Location = new System.Drawing.Point(116, 58);
            this.numericUpDown_X_R.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDown_X_R.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_X_R.Name = "numericUpDown_X_R";
            this.numericUpDown_X_R.Size = new System.Drawing.Size(54, 22);
            this.numericUpDown_X_R.TabIndex = 13;
            this.numericUpDown_X_R.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Coordinate Y:";
            // 
            // numericUpDown_Y_R
            // 
            this.numericUpDown_Y_R.BackColor = System.Drawing.Color.WhiteSmoke;
            this.numericUpDown_Y_R.Location = new System.Drawing.Point(116, 30);
            this.numericUpDown_Y_R.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDown_Y_R.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Y_R.Name = "numericUpDown_Y_R";
            this.numericUpDown_Y_R.Size = new System.Drawing.Size(54, 22);
            this.numericUpDown_Y_R.TabIndex = 12;
            this.numericUpDown_Y_R.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button6
            // 
            this.RemoveFigure.BackColor = System.Drawing.Color.WhiteSmoke;
            this.RemoveFigure.Location = new System.Drawing.Point(203, 28);
            this.RemoveFigure.Name = "button6";
            this.RemoveFigure.Size = new System.Drawing.Size(102, 52);
            this.RemoveFigure.TabIndex = 14;
            this.RemoveFigure.Text = "Remove figure";
            this.RemoveFigure.UseVisualStyleBackColor = false;
            this.RemoveFigure.Click += new System.EventHandler(this.RemoveFigure_Click);
            // 
            // listBox
            // 
            this.listBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 16;
            this.listBox.Location = new System.Drawing.Point(1016, 21);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(297, 452);
            this.listBox.TabIndex = 16;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // ChessWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 608);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Chess_Sample.Properties.Settings.Default, "ChessApp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Name = "ChessWindow";
            this.Text = global::Chess_Sample.Properties.Settings.Default.ChessApp;
            this.Load += new System.EventHandler(this.ChessWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_X)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_X_R)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Y_R)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ClearSelectionButton;
        private System.Windows.Forms.Button LoadFromFile;
        private System.Windows.Forms.Label filename_label;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ClearBoardButton;
        private System.Windows.Forms.ComboBox comboBox_FigureName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_Y;
        private System.Windows.Forms.NumericUpDown numericUpDown_X;
        private System.Windows.Forms.Button AddFigureButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button SaveInFile;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button RemoveFigure;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_X_R;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown_Y_R;
        private System.Windows.Forms.ListBox listBox;
    }
}


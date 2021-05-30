namespace Chess_Sample
{
    partial class Cell
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.image = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // image
            // 
            this.image.Location = new System.Drawing.Point(-1, -1);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(78, 78);
            this.image.TabIndex = 0;
            this.image.TabStop = false;
            // 
            // Cell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.image);
            this.MaximumSize = new System.Drawing.Size(77, 77);
            this.MinimumSize = new System.Drawing.Size(77, 77);
            this.Name = "Cell";
            this.Size = new System.Drawing.Size(77, 77);
            this.Load += new System.EventHandler(this.Cell_Load);
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public  System.Windows.Forms.PictureBox image;
    }
}

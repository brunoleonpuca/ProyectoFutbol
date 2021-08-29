namespace ProyectoFutbolUIAlfa
{

    partial class PoyectoFutbolUI
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
            this.LeaguesListBox = new System.Windows.Forms.ListBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LeaguesListBox
            // 
            this.LeaguesListBox.FormattingEnabled = true;
            this.LeaguesListBox.ItemHeight = 16;
            this.LeaguesListBox.Location = new System.Drawing.Point(42, 103);
            this.LeaguesListBox.Name = "LeaguesListBox";
            this.LeaguesListBox.Size = new System.Drawing.Size(225, 292);
            this.LeaguesListBox.TabIndex = 0;
            this.LeaguesListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(42, 26);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(107, 33);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Get Leagues";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // PoyectoFutbolUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.LeaguesListBox);
            this.Name = "PoyectoFutbolUI";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LeaguesListBox;
        private System.Windows.Forms.Button searchButton;
    }
}


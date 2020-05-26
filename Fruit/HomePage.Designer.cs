namespace Fruit
{
    partial class HomePage
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
            this.BtAdmin = new System.Windows.Forms.Button();
            this.BtOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtAdmin
            // 
            this.BtAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtAdmin.Location = new System.Drawing.Point(53, 125);
            this.BtAdmin.Name = "BtAdmin";
            this.BtAdmin.Size = new System.Drawing.Size(322, 170);
            this.BtAdmin.TabIndex = 0;
            this.BtAdmin.Text = "ADMIN";
            this.BtAdmin.UseVisualStyleBackColor = true;
            this.BtAdmin.Click += new System.EventHandler(this.Button1_Click);
            // 
            // BtOrder
            // 
            this.BtOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtOrder.Location = new System.Drawing.Point(381, 125);
            this.BtOrder.Name = "BtOrder";
            this.BtOrder.Size = new System.Drawing.Size(322, 170);
            this.BtOrder.TabIndex = 1;
            this.BtOrder.Text = "ORDER";
            this.BtOrder.UseVisualStyleBackColor = true;
            this.BtOrder.Click += new System.EventHandler(this.BtOrder_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 404);
            this.Controls.Add(this.BtOrder);
            this.Controls.Add(this.BtAdmin);
            this.Name = "HomePage";
            this.Text = "HomePage";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtAdmin;
        private System.Windows.Forms.Button BtOrder;
    }
}
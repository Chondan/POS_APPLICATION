namespace Fruit
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BtLoad = new System.Windows.Forms.Button();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.BtAdd = new System.Windows.Forms.Button();
            this.BtUpdate = new System.Windows.Forms.Button();
            this.BtDel = new System.Windows.Forms.Button();
            this.BtClear = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(348, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(552, 293);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            // 
            // BtLoad
            // 
            this.BtLoad.Location = new System.Drawing.Point(348, 343);
            this.BtLoad.Name = "BtLoad";
            this.BtLoad.Size = new System.Drawing.Size(552, 77);
            this.BtLoad.TabIndex = 1;
            this.BtLoad.Text = "LOAD";
            this.BtLoad.UseVisualStyleBackColor = true;
            this.BtLoad.Click += new System.EventHandler(this.BtLoad_Click);
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(127, 44);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(195, 20);
            this.textBoxID.TabIndex = 2;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(127, 70);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(195, 20);
            this.textBoxName.TabIndex = 3;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(127, 96);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(195, 20);
            this.textBoxPrice.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "FRUIT_ID";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "FRUIT_NAME";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "FRUIT_PRICE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "FRUIT_QUANTITY";
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(127, 121);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(195, 20);
            this.textBoxQuantity.TabIndex = 8;
            // 
            // BtAdd
            // 
            this.BtAdd.Location = new System.Drawing.Point(25, 174);
            this.BtAdd.Name = "BtAdd";
            this.BtAdd.Size = new System.Drawing.Size(298, 57);
            this.BtAdd.TabIndex = 10;
            this.BtAdd.Text = "ADD";
            this.BtAdd.UseVisualStyleBackColor = true;
            this.BtAdd.Click += new System.EventHandler(this.BtAdd_Click);
            // 
            // BtUpdate
            // 
            this.BtUpdate.Location = new System.Drawing.Point(26, 237);
            this.BtUpdate.Name = "BtUpdate";
            this.BtUpdate.Size = new System.Drawing.Size(298, 57);
            this.BtUpdate.TabIndex = 11;
            this.BtUpdate.Text = "UPDATE";
            this.BtUpdate.UseVisualStyleBackColor = true;
            this.BtUpdate.Click += new System.EventHandler(this.BtUpdate_Click);
            // 
            // BtDel
            // 
            this.BtDel.Location = new System.Drawing.Point(26, 300);
            this.BtDel.Name = "BtDel";
            this.BtDel.Size = new System.Drawing.Size(298, 57);
            this.BtDel.TabIndex = 12;
            this.BtDel.Text = "DELETE";
            this.BtDel.UseVisualStyleBackColor = true;
            this.BtDel.Click += new System.EventHandler(this.BtDel_Click);
            // 
            // BtClear
            // 
            this.BtClear.Location = new System.Drawing.Point(25, 363);
            this.BtClear.Name = "BtClear";
            this.BtClear.Size = new System.Drawing.Size(298, 57);
            this.BtClear.TabIndex = 13;
            this.BtClear.Text = "CLEAR";
            this.BtClear.UseVisualStyleBackColor = true;
            this.BtClear.Click += new System.EventHandler(this.BtClear_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "FRUIT_CATEGORY";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(127, 147);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(195, 21);
            this.comboBox1.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 472);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtClear);
            this.Controls.Add(this.BtDel);
            this.Controls.Add(this.BtUpdate);
            this.Controls.Add(this.BtAdd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxQuantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.BtLoad);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BtLoad;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.Button BtAdd;
        private System.Windows.Forms.Button BtUpdate;
        private System.Windows.Forms.Button BtDel;
        private System.Windows.Forms.Button BtClear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}


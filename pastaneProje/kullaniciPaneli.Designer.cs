namespace pastaneProje
{
    partial class kullaniciPaneli
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
            button1 = new Button();
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            txtfiyat = new TextBox();
            label3 = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(12, 328);
            button1.Name = "button1";
            button1.Size = new Size(572, 63);
            button1.TabIndex = 0;
            button1.Text = "SİPARİŞ VER";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(154, 101);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(282, 39);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(50, 106);
            label1.Name = "label1";
            label1.Size = new Size(95, 31);
            label1.TabIndex = 2;
            label1.Text = "Urun İd:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(78, 183);
            label2.Name = "label2";
            label2.Size = new Size(67, 31);
            label2.TabIndex = 3;
            label2.Text = "Fiyat:";
            // 
            // txtfiyat
            // 
            txtfiyat.Enabled = false;
            txtfiyat.Location = new Point(151, 181);
            txtfiyat.Name = "txtfiyat";
            txtfiyat.Size = new Size(285, 38);
            txtfiyat.TabIndex = 4;
            txtfiyat.TextChanged += txtfiyat_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 29);
            label3.Name = "label3";
            label3.Size = new Size(133, 31);
            label3.TabIndex = 5;
            label3.Text = "Kullanıcı ID:";
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Location = new Point(151, 22);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(285, 38);
            textBox1.TabIndex = 6;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // kullaniciPaneli
            // 
            AutoScaleDimensions = new SizeF(13F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PeachPuff;
            ClientSize = new Size(596, 502);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(txtfiyat);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.Blue;
            Margin = new Padding(5);
            Name = "kullaniciPaneli";
            Text = "kullaniciPaneli";
            Load += kullaniciPaneli_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private TextBox txtfiyat;
        private Label label3;
        private TextBox textBox1;
    }
}
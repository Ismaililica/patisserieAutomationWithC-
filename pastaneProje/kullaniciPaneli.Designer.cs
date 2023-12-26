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
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(130, 17);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(282, 39);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(95, 31);
            label1.TabIndex = 2;
            label1.Text = "Urun İd:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(40, 115);
            label2.Name = "label2";
            label2.Size = new Size(67, 31);
            label2.TabIndex = 3;
            label2.Text = "Fiyat:";
            // 
            // txtfiyat
            // 
            txtfiyat.Enabled = false;
            txtfiyat.Location = new Point(127, 112);
            txtfiyat.Name = "txtfiyat";
            txtfiyat.Size = new Size(285, 38);
            txtfiyat.TabIndex = 4;
            txtfiyat.TextChanged += txtfiyat_TextChanged;
            // 
            // kullaniciPaneli
            // 
            AutoScaleDimensions = new SizeF(13F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PeachPuff;
            ClientSize = new Size(596, 502);
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
    }
}
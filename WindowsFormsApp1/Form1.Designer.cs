namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.demodbDataSet = new WindowsFormsApp1.DemodbDataSet();
            this.demodbDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.text_quiz = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.text_final = new System.Windows.Forms.TextBox();
            this.text_vize = new System.Windows.Forms.TextBox();
            this.ara = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.text_ara = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.combo_dersadi = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.text_no = new System.Windows.Forms.TextBox();
            this.text_soyad = new System.Windows.Forms.TextBox();
            this.text_ad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.demodbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.demodbDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // demodbDataSet
            // 
            this.demodbDataSet.DataSetName = "DemodbDataSet";
            this.demodbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // demodbDataSetBindingSource
            // 
            this.demodbDataSetBindingSource.DataSource = this.demodbDataSet;
            this.demodbDataSetBindingSource.Position = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(3, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(749, 598);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_RowEnter_1);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.DataGridView1_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PowderBlue;
            this.panel1.Controls.Add(this.text_quiz);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.text_final);
            this.panel1.Controls.Add(this.text_vize);
            this.panel1.Controls.Add(this.ara);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.text_ara);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.combo_dersadi);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.text_no);
            this.panel1.Controls.Add(this.text_soyad);
            this.panel1.Controls.Add(this.text_ad);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(749, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(326, 598);
            this.panel1.TabIndex = 5;
            // 
            // text_quiz
            // 
            this.text_quiz.BackColor = System.Drawing.Color.Thistle;
            this.text_quiz.Location = new System.Drawing.Point(107, 391);
            this.text_quiz.Name = "text_quiz";
            this.text_quiz.Size = new System.Drawing.Size(179, 22);
            this.text_quiz.TabIndex = 7;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Crimson;
            this.label17.Location = new System.Drawing.Point(20, 384);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 29);
            this.label17.TabIndex = 33;
            this.label17.Text = "Quiz :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Navy;
            this.label16.Location = new System.Drawing.Point(102, 457);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 29);
            this.label16.TabIndex = 32;
            this.label16.Text = "placeholder";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Navy;
            this.label15.Location = new System.Drawing.Point(102, 428);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 29);
            this.label15.TabIndex = 31;
            this.label15.Text = "placeholder";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Crimson;
            this.label14.Location = new System.Drawing.Point(20, 457);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 29);
            this.label14.TabIndex = 30;
            this.label14.Text = "Harf :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Crimson;
            this.label13.Location = new System.Drawing.Point(20, 428);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 29);
            this.label13.TabIndex = 29;
            this.label13.Text = "Sonuc :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Crimson;
            this.label6.Location = new System.Drawing.Point(20, 355);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 29);
            this.label6.TabIndex = 28;
            this.label6.Text = "Final :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Crimson;
            this.label4.Location = new System.Drawing.Point(20, 327);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 29);
            this.label4.TabIndex = 27;
            this.label4.Text = "Vize :";
            // 
            // text_final
            // 
            this.text_final.BackColor = System.Drawing.Color.Thistle;
            this.text_final.Location = new System.Drawing.Point(107, 358);
            this.text_final.Name = "text_final";
            this.text_final.Size = new System.Drawing.Size(179, 22);
            this.text_final.TabIndex = 6;
            // 
            // text_vize
            // 
            this.text_vize.BackColor = System.Drawing.Color.Thistle;
            this.text_vize.Location = new System.Drawing.Point(107, 330);
            this.text_vize.Name = "text_vize";
            this.text_vize.Size = new System.Drawing.Size(179, 22);
            this.text_vize.TabIndex = 5;
            // 
            // ara
            // 
            this.ara.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ara.Font = new System.Drawing.Font("Dubai", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ara.Location = new System.Drawing.Point(203, 127);
            this.ara.Name = "ara";
            this.ara.Size = new System.Drawing.Size(83, 31);
            this.ara.TabIndex = 24;
            this.ara.Text = "Ara";
            this.ara.UseVisualStyleBackColor = false;
            this.ara.Click += new System.EventHandler(this.Ara_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Teal;
            this.label12.Location = new System.Drawing.Point(15, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 29);
            this.label12.TabIndex = 23;
            this.label12.Text = "Isim giriniz :";
            // 
            // text_ara
            // 
            this.text_ara.BackColor = System.Drawing.Color.Ivory;
            this.text_ara.Location = new System.Drawing.Point(18, 131);
            this.text_ara.Name = "text_ara";
            this.text_ara.Size = new System.Drawing.Size(179, 22);
            this.text_ara.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(98, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 29);
            this.label11.TabIndex = 21;
            this.label11.Text = "placeholder isim";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(98, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 29);
            this.label10.TabIndex = 20;
            this.label10.Text = "placeholder isim";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(97, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 34);
            this.label9.TabIndex = 19;
            this.label9.Text = "Profili Goruntule";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(18, 12);
            this.button1.MaximumSize = new System.Drawing.Size(133, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 74);
            this.button1.TabIndex = 18;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Azure;
            this.button5.Font = new System.Drawing.Font("Dubai", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(154, 555);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(132, 31);
            this.button5.TabIndex = 17;
            this.button5.Text = "Temizle";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Teal;
            this.label5.Location = new System.Drawing.Point(20, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 29);
            this.label5.TabIndex = 13;
            this.label5.Text = "Ders Adi :";
            // 
            // combo_dersadi
            // 
            this.combo_dersadi.BackColor = System.Drawing.Color.Ivory;
            this.combo_dersadi.FormattingEnabled = true;
            this.combo_dersadi.Items.AddRange(new object[] {
            "Programlama Dilleri I ",
            "Elektronik Devreleri",
            "Veritabanı Yönetimi",
            "Programlama Dilleri II ",
            "Biçimsel Diller ve Otomatlar ",
            "Sayısal Çözümleme"});
            this.combo_dersadi.Location = new System.Drawing.Point(107, 184);
            this.combo_dersadi.Name = "combo_dersadi";
            this.combo_dersadi.Size = new System.Drawing.Size(179, 24);
            this.combo_dersadi.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button4.Font = new System.Drawing.Font("Dubai", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(19, 518);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(129, 31);
            this.button4.TabIndex = 8;
            this.button4.Text = "Güncelle";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.Button4_Click_1);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.IndianRed;
            this.button3.Font = new System.Drawing.Font("Dubai", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(154, 518);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(134, 31);
            this.button3.TabIndex = 7;
            this.button3.Text = "Sil";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Button3_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button2.Font = new System.Drawing.Font("Dubai", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(20, 555);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 31);
            this.button2.TabIndex = 6;
            this.button2.Text = "Yeni Kisi Ekle";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // text_no
            // 
            this.text_no.BackColor = System.Drawing.Color.Ivory;
            this.text_no.Location = new System.Drawing.Point(107, 281);
            this.text_no.Name = "text_no";
            this.text_no.Size = new System.Drawing.Size(179, 22);
            this.text_no.TabIndex = 4;
            // 
            // text_soyad
            // 
            this.text_soyad.BackColor = System.Drawing.Color.Ivory;
            this.text_soyad.Location = new System.Drawing.Point(107, 253);
            this.text_soyad.Name = "text_soyad";
            this.text_soyad.Size = new System.Drawing.Size(179, 22);
            this.text_soyad.TabIndex = 3;
            // 
            // text_ad
            // 
            this.text_ad.BackColor = System.Drawing.Color.Ivory;
            this.text_ad.Location = new System.Drawing.Point(107, 225);
            this.text_ad.Name = "text_ad";
            this.text_ad.Size = new System.Drawing.Size(179, 22);
            this.text_ad.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.Location = new System.Drawing.Point(20, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Numara :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(20, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Soyad : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(20, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ad :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 598);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.demodbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.demodbDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource demodbDataSetBindingSource;
        private DemodbDataSet demodbDataSet;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox text_no;
        private System.Windows.Forms.TextBox text_soyad;
        private System.Windows.Forms.TextBox text_ad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox combo_dersadi;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox text_ara;
        private System.Windows.Forms.Button ara;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox text_final;
        private System.Windows.Forms.TextBox text_vize;
        private System.Windows.Forms.TextBox text_quiz;
        private System.Windows.Forms.Label label17;
    }
}


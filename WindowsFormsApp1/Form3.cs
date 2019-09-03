using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        SqlConnection connection { get; set; }
        SqlCommand command;

  
        private void Form3_Load(object sender, EventArgs e)
        {
            String connectionString = @"Data Source=DESKTOP-C13A3K3\SQLEXPRESS;Initial Catalog=Demodb;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }

        private void Button2_Click(object sender, EventArgs e) // geri goturen dugme
        {

            this.Hide();
            Form form = new frmLogin();
            form.Show();

        }

        private void Button1_Click(object sender, EventArgs e) // kayit ekleme dugmesi
        {


            failsafe();

            connection.Open();
            String ekle = "insert into login_1 (kadi, ksifre, ad, soyad, numara ,cinsiyet, dtarihi, dyeri, telno, bitistarihi)" +
                "values (@kadi, @ksifre, @ad, @soyad, @numara ,@cinsiyet, @dtarihi, @dyeri, @telno, @bitistarihi)";

            String vdtarih = DateTime.Parse(date_dtarihi.Text).ToString("yyyy-MM-dd"); // burada hata aliyorum
            String bttarih = DateTime.Parse(date_bitistarihi.Text).ToString("yyyy-MM-dd");


            if (text_sifre.Text.Length > 3)
            {

                command = new SqlCommand(ekle, connection);

                try
                {
                    using (command)
                    {

                        command.Parameters.AddWithValue("@kadi", text_kadi.Text);
                            command.Parameters.AddWithValue("@ksifre", text_sifre.Text);
                        command.Parameters.AddWithValue("@ad", text_ad1.Text);
                            command.Parameters.AddWithValue("@soyad", text_soyad1.Text);
                        command.Parameters.AddWithValue("@numara", text_numara.Text);
                            command.Parameters.AddWithValue("@cinsiyet", combo_cinsiyet.Text);
                        command.Parameters.AddWithValue("@dtarihi", vdtarih);
                            command.Parameters.AddWithValue("@dyeri", text_dyeri.Text);
                        command.Parameters.AddWithValue("@telno", text_telno.Text);
                            command.Parameters.AddWithValue("@bitistarihi", bttarih);

                        

                        command.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Kayit Basarili! " +
                            "Lütfen ogretmeninizin kaydetmesini bekleyin");

                        text_kadi.Clear();
                            text_sifre.Clear();
                        text_ad1.Clear();
                            text_soyad1.Clear();
                        text_dyeri.Clear();
                            text_telno.Clear();
                        text_numara.Clear();

                    }

                }
 
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                MessageBox.Show("Sifre en az 4 karakerli olmalidir!");
                connection.Close();
            }

        }

        private void failsafe() // hata aliyorum
        {

            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            string sql = "select count(*) from login_1 where kadi = @kadi";
            command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@kadi", text_kadi.Text);

            bool sonuc = Convert.ToBoolean(command.ExecuteScalar());
            if(sonuc == true)
            {
                MessageBox.Show("Bu kullanici adi daha once alinmistir!");
                this.Close();
            }
         
            connection.Close();

        }





       
    }
}

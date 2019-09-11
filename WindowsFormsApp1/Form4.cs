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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        SqlConnection connection { get; set; }
        SqlCommand cmd;
        public int ogrId;
        private bool pass;
        public int i;
        public String[] drs1 = new String[6];

        private void Form4_Load(object sender, EventArgs e)
        {
            String connectionString = @"Data Source=DESKTOP-C13A3K3\SQLEXPRESS;Initial Catalog=Demodb;Integrated Security=True";
            connection = new SqlConnection(connectionString);


            getID();
        

        } 

        private void getID()
        {

            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            string kadi = frmLogin.nameholder;
            kullanici_adi.Text = kadi;
            string sql_id = "select o.o_id " +
                "from ogrenciler o " +
                "inner join login_1 l on o.l_id = l.l_id " +
                "where l.kadi=@kadi ";

            cmd = new SqlCommand(sql_id, connection);
            cmd.Parameters.AddWithValue("@kadi", kadi);
            ogrId = Convert.ToInt32(cmd.ExecuteScalar());

            kullanici_ID.Text = ogrId.ToString();

            connection.Close();
            
        }

        private void getNumber()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sql_check = "select ders_adi from dersler where  d_id=@d_id";
            cmd = new SqlCommand(sql_check, connection);
            string check_credits;
            string sql_ekle = "insert into secilen_ders(o_id,d_id) values (@o_id,@d_id)";
            string sql_kontrol = "select count(*) d_id from secilen_ders " +
                   "where d_id = @d_id and o_id = @o_id ";

                int sayi = i;

                int check;
               
                cmd = new SqlCommand(sql_kontrol, connection);
                cmd.Parameters.AddWithValue("@d_id", sayi);
                cmd.Parameters.AddWithValue("@o_id", ogrId);

                check = Convert.ToInt32(cmd.ExecuteScalar());
                if (check < 1)
                {
                    pass = true;
                }
                else
                {
                    pass = false;
                }
                if (pass == true)
                {
                    using (cmd = new SqlCommand(sql_ekle, connection))
                    {
                        cmd.Parameters.AddWithValue("@o_id", ogrId);
                        cmd.Parameters.AddWithValue("@d_id", sayi);

                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                else if (pass == false)
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }                          
                    check_credits = Convert.ToString(cmd.ExecuteScalar());
                    MessageBox.Show("Bu derse daha once kaydiniz vardir :" + check_credits);
                    connection.Close();
                }
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }    
        }

        private void dersEkle()
        {
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
           
            if (prog1.Checked)
            {
                i = 1;
                getNumber();
            }
            if (elektronik.Checked)
            {
                i = 2;
                getNumber();
            }
            if (veritabanı.Checked)
            {
                i = 3;
                getNumber();
            }
            if (prog2.Checked)
            {
                i = 4;
                getNumber();
            }
            if (otomat.Checked)
            {
                i = 5;
                getNumber();
            }
            if (sayisal.Checked)
            {
                i = 6;
                getNumber();
            }
            if (bilgisayar_aglari.Checked)
            {
                i = 7;
                getNumber();
            }
            if (bilgisayar_mimarisi.Checked)
            {
                i = 8;
                getNumber();
            }
            if (yazilim_muhendisligi.Checked)
            {
                i = 9;
                getNumber();
            }
            if (sistem_programlama.Checked)
            {
                i = 10;
                getNumber();
            }
            if (goruntu_isleme.Checked)
            {
                i = 11;
                getNumber();
            }
            if (mobil_programlama.Checked)
            {
                i = 12;
                getNumber();
            }
            if (mikroislemciler.Checked)
            {
                i = 13;
                getNumber();
            }
            if (veri_iletisimi.Checked)
            {
                i = 14;
                getNumber();
            }
            if (isletim_sistemleri.Checked)
            {
                i = 15;
                getNumber();
            }
            if (web_teknolojileri.Checked)
            {
                i = 16;
                getNumber();
            }
            if (veri_madenciligi.Checked)
            {
                i = 17;
                getNumber();
            }
            if (optimizasyon.Checked)
            {
                i = 18;
                getNumber();
            }
            connection.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            int credits = 0;
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            
            if(prog1.Checked)
            {
                credits = credits + 7;
                creditcounter.Text = credits.ToString();
            }
            if(elektronik.Checked)
            {
                credits = credits + 5;
                creditcounter.Text = credits.ToString();
            }
            if (veritabanı.Checked)
            {
                credits = credits + 5;
                creditcounter.Text = credits.ToString();
            }
            if (prog2.Checked)
            {
                credits = credits + 7;
                creditcounter.Text = credits.ToString();
            }
            if (otomat.Checked)
            {
                credits = credits + 4;
                creditcounter.Text = credits.ToString();
            }
            if (sayisal.Checked)
            {
                credits = credits + 4;
                creditcounter.Text = credits.ToString();
            }
            if (bilgisayar_aglari.Checked)
            {
                credits = credits + 7;
                creditcounter.Text = credits.ToString();
            }
            if (bilgisayar_mimarisi.Checked)
            {
                credits = credits + 5;
                creditcounter.Text = credits.ToString();
            }
            if (yazilim_muhendisligi.Checked)
            {
                credits = credits + 5;
                creditcounter.Text = credits.ToString();
            }
            if (sistem_programlama.Checked)
            {
                credits = credits + 4;
                creditcounter.Text = credits.ToString();
            }
            if (goruntu_isleme.Checked)
            {
                credits = credits + 4;
                creditcounter.Text = credits.ToString();
            }
            if (mobil_programlama.Checked)
            {
                credits = credits + 5;
                creditcounter.Text = credits.ToString();
            }
            if (mikroislemciler.Checked)
            {
                credits = credits + 5;
                creditcounter.Text = credits.ToString();
            }
            if (veri_iletisimi.Checked)
            {
                credits = credits + 7;
                creditcounter.Text = credits.ToString();
            }
            if (isletim_sistemleri.Checked)
            {
                credits = credits + 7;
                creditcounter.Text = credits.ToString();
            }
            if (web_teknolojileri.Checked)
            {
                credits = credits + 4;
                creditcounter.Text = credits.ToString();
            }
            if (veri_madenciligi.Checked)
            {
                credits = credits + 4;
                creditcounter.Text = credits.ToString();
            }
            if (optimizasyon.Checked)
            {
                credits = credits + 5;
                creditcounter.Text = credits.ToString();
            }
            connection.Close();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            int credits = 0;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            if (prog1.Checked)
            {
                credits = credits + 7;
            }
            else if (elektronik.Checked)
            {
                credits = credits + 5;
            }
            else if (veritabanı.Checked)
            {
                credits = credits + 5;
            }
            else if (prog2.Checked)
            {
                credits = credits + 7;
            }
            else if (otomat.Checked)
            {
                credits = credits + 4;
            }
            else if (sayisal.Checked)
            {
                credits = credits + 4;
            }
            else if (bilgisayar_aglari.Checked)
            {
                credits = credits + 7;
            }
            else if (bilgisayar_mimarisi.Checked)
            {
                credits = credits + 5;
            }
            else if (yazilim_muhendisligi.Checked)
            {
                credits = credits + 5;
            }
            else if (sistem_programlama.Checked)
            {
                credits = credits + 4;
            }
            else if (goruntu_isleme.Checked)
            {
                credits = credits + 4;
            }
            else if (mobil_programlama.Checked)
            {
                credits = credits + 5;
            }
            else if (mikroislemciler.Checked)
            {
                credits = credits + 5;
            }
            else if (veri_iletisimi.Checked)
            {
                credits = credits + 7;
            }
            else if (isletim_sistemleri.Checked)
            {
                credits = credits + 7;
            }
            else if (web_teknolojileri.Checked)
            {
                credits = credits + 4;
            }
            else if (veri_madenciligi.Checked)
            {
                credits = credits + 4;
            }
            else if (optimizasyon.Checked)
            {
                credits = credits + 5;
            }
            dersEkle();
            MessageBox.Show("Kayidiniz yapilmistir");
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new Form1();
            form.Show();
        }
    }
}


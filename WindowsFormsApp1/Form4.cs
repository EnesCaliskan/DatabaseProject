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
        public int sayi = 0;
        private bool pass;
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

        private void kafayiyicem()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sql_ekle = "insert into secilen_ders(o_id,d_id) values (@o_id,@d_id)";
            using (cmd = new SqlCommand(sql_ekle, connection))
            {
                cmd.Parameters.AddWithValue("@o_id", ogrId);
                cmd.Parameters.AddWithValue("@d_id", sayi);

                cmd.ExecuteNonQuery();

            }

            connection.Close();

        }

        private void kontrol()
        {
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            int check;
            string sql_kontrol = "select count(*) d_id from secilen_ders " +
                "where d_id = @d_id and o_id = @o_id ";

            cmd = new SqlCommand(sql_kontrol, connection);
            cmd.Parameters.AddWithValue("@d_id", sayi);
            cmd.Parameters.AddWithValue("@o_id", ogrId);

            check = Convert.ToInt32(cmd.ExecuteScalar());

            if(check < 1)
            {
                pass = true;
            }
            else
            {
                pass = false;
            }

            connection.Close();

        }

        private void dersEkle()
        {
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
           
            if (prog1.Checked)
            {
                sayi = 1;
                kontrol();
                if(pass == true)
                {
                    kafayiyicem();
                }
                else if(pass == false)
                {
                    MessageBox.Show("Bu derse daha once kayidiniz vardir: " + prog1.Text);
                }
                
            }
            if (elektronik.Checked)
            {
                sayi = 2;
                kontrol();
                if (pass == true)
                {
                    kafayiyicem();
                }
                else if (pass == false)
                {
                    MessageBox.Show("Bu derse daha once kayidiniz vardir: " + elektronik.Text);
                }
            }
            if (veritabanı.Checked)
            {
                sayi = 3;
                kontrol();
                if (pass == true)
                {
                    kafayiyicem();
                }
                else if (pass == false)
                {
                    MessageBox.Show("Bu derse daha once kayidiniz vardir: " + veritabanı.Text);
                }
            }
            if (prog2.Checked)
            {
                sayi = 4;
                kontrol();
                if (pass == true)
                {
                    kafayiyicem();
                }
                else if (pass == false)
                {
                    MessageBox.Show("Bu derse daha once kayidiniz vardir: " + prog2.Text);
                }
            }
            if (otomat.Checked)
            {
                sayi = 5;
                kontrol();
                if (pass == true)
                {
                    kafayiyicem();
                }
                else if (pass == false)
                {
                    MessageBox.Show("Bu derse daha once kayidiniz vardir: " + otomat.Text);
                }
            }
            if (sayisal.Checked)
            {
                sayi = 6;
                kontrol();
                if (pass == true)
                {
                    kafayiyicem();
                }
                else if (pass == false)
                {
                    MessageBox.Show("Bu derse daha once kayidiniz vardir : " + sayisal.Text);
                }

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

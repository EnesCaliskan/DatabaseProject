using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Profile : Form
    {

        SqlConnection connection { get; set; }
        int ogrId = Form1.ID;

        public Profile()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e) // geriye donduren dugme
        {
            this.Hide();
            Form form = new Form1();
            form.Show();

        }

        private void Profile_Load(object sender, EventArgs e)
        {
            String connectionString = @"Data Source=DESKTOP-C13A3K3\SQLEXPRESS;Initial Catalog=Demodb;Integrated Security=True";
            connection = new SqlConnection(connectionString);

            getContacts();
            getScores();
                   
        }

        private void getContacts() // Profil bilgileri kisminda bilgileri databaseden getirir.
        {

            string kullaniciadi = frmLogin.nameholder;

            string sql1; 
            String[] array = new String[10];

            array[0] = "I_id";
                array[1] = "kadi";
            array[2] = "ksifre";
                array[3] = "ad";
            array[4] = "soyad";
                array[5] = "cinsiyet";
            array[6] = "dtarihi";
                array[7] = "dyeri";
            array[8] = "telno";
                array[9] = "bitistarihi";

            String[] contacts = new String[10];

            for (int i = 0; i < 10; i++)
            {

                connection.Open();

                sql1 = "select " + array[i] + " from login where kadi ='" + kullaniciadi + "'";
                SqlCommand command_contacts = new SqlCommand(sql1, connection);

                contacts[i]  = Convert.ToString(command_contacts.ExecuteScalar());

                connection.Close();

            }
        
            label_kadi.Text = contacts[1];
                label_ksifre.Text = contacts[2];
            label_ad.Text = contacts[3];
                label_soyad.Text = contacts[4];
            label_cinsiyet.Text = contacts[5];
                label_dtarihi.Text = contacts[6];
            label_dyeri.Text = contacts[7];
                label_telno.Text = contacts[8];
            label_bitis.Text = contacts[9];

        }
        
        //*----ogrencinin notlarini getirir, hiç bişey getirdiği yokaq----*
        private void getScores()
        {

            try
            {
                if(connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                ArrayList id_list = new ArrayList();

                string sql = "select o_id from ogrenciler where ad=@ad and soyad=@soyad";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@ad", label_ad.Text);
                cmd.Parameters.AddWithValue("@soyad", label_soyad.Text);



                using(SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while(rdr.Read())
                    {

                        var myString = rdr.GetInt32(0);
                        id_list.Add(myString);
                     
                    }

                }

                string mysql = "select o.ad, o.soyad, o.numara, d.ders_adi, n.vize, n.final, n.quiz, n.sonuc, n.harf " +
                    "from ogrenciler o " +
                    "inner join notlar n ON o.o_id = n.o_id " +
                    "inner join dersler d ON d.d_id = n.d_id " +
                    "where o.ad='" + label_ad.Text + "' and o.soyad='" + label_soyad.Text + "' ";


                SqlDataAdapter adp = new SqlDataAdapter(mysql, connection);       
                DataSet ds = new DataSet();
                adp.Fill(ds);
                this.dataGridView1.DataSource = ds.Tables[0].DefaultView;
                dataGridView1.Refresh();

                
                






                connection.Close();

            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void Profile_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

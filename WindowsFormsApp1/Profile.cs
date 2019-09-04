using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Profile : Form
    {

        SqlConnection connection { get; set; }
        SqlCommand cmd;
        int ogrId = Form1.ID;
        List<string> lessons = new List<string>();

        List<Dictionary<string, string>> rows = new List<Dictionary<string, string>>();
        Dictionary<string, string> column;

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
            getSelectedLessons();

            combo_secilen.DataSource = lessons;

        }

        private void getContacts() // Profil bilgileri kisminda bilgileri databaseden getirir.
        {

            string kullaniciadi = frmLogin.nameholder;

            string sql1; 
            String[] array = new String[11];

            array[0] = "l_id";
                array[1] = "kadi";
            array[2] = "ksifre";
                array[3] = "ad";
            array[4] = "soyad";
                array[5] = "numara";
            array[6] = "cinsiyet";
                array[7] = "dtarihi";
            array[8] = "dyeri";
                array[9] = "telno";
            array[10] = "bitistarihi";
            

            String[] contacts = new String[11];

            for (int i = 0; i < 11; i++)
            {

                connection.Open();

                sql1 = "select " + array[i] + " from login_1 where kadi ='" + kullaniciadi + "'";
                SqlCommand command_contacts = new SqlCommand(sql1, connection);

                contacts[i]  = Convert.ToString(command_contacts.ExecuteScalar());

                connection.Close();

            }

                label_LID.Text = contacts[0];
            label_kadi.Text = contacts[1];
                label_ksifre.Text = contacts[2];
            label_ad.Text = contacts[3];
                label_soyad.Text = contacts[4];
            label_numara.Text = contacts[5];
                label_cinsiyet.Text = contacts[6];
            label_dtarihi.Text = contacts[7];
                label_dyeri.Text = contacts[8];
            label_telno.Text = contacts[9];
                label_bitis.Text = contacts[10];

        }
        
        //*----ogrencinin notlarini getirir----*
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

        public void getSelectedLessons()
        {
            

            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }


            string sql_id = "select o_id from ogrenciler o " +
                "inner join login_1 l on l.l_id = o.l_id " +
                "where l.kadi = @kadi";
            cmd = new SqlCommand(sql_id, connection);
            cmd.Parameters.AddWithValue("@kadi", label_kadi.Text);
            int o_id = Convert.ToInt32(cmd.ExecuteScalar());

            string sql_finder = "select ders_adi from dersler d " +
                "inner join secilen_ders s on s.d_id = d.d_id " +
                "inner join ogrenciler o on o.o_id = s.o_id " +
                "where o.o_id = @ogrId";

            

            cmd = new SqlCommand(sql_finder, connection);
            cmd.Parameters.AddWithValue("@ogrId", o_id);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                column = new Dictionary<string, string>();

                column["ders_adi"] = reader["ders_adi"].ToString();
                rows.Add(column);
                

            }

            foreach (Dictionary<string, string> column in rows)
            {
                lessons.Add(column["ders_adi"]);
            }

            connection.Close();

        }

        private void Profile_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

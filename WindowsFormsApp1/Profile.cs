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
    public partial class Profile : Form
    {

        SqlConnection connection { get; set; }

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
            setLabel();

        }

        private void getContacts() // Profil bilgileri kisminda bilgileri databaseden getirir.
        {

            string kullaniciadi = frmLogin.nameholder;

            string sql1; 
            String[] array = new String[10];

            array[0] = "id";
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

        private void setLabel()
        {

            ders1.Text = Form1.notlar[0];
                ders2.Text = Form1.notlar[1];
                    ders3.Text = Form1.notlar[2];
                ders4.Text = Form1.notlar[3];
                ders5.Text = Form1.notlar[4];
            ders6.Text = Form1.notlar[5];





        }


    }
}

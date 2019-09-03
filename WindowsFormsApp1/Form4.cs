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

        private void Form4_Load(object sender, EventArgs e)
        {
            String connectionString = @"Data Source=DESKTOP-C13A3K3\SQLEXPRESS;Initial Catalog=Demodb;Integrated Security=True";
            connection = new SqlConnection(connectionString);

            

        }

        private void getCredits()
        {







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


        }

        private void Button2_Click(object sender, EventArgs e)
        {

            int credits = 0;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            else if (prog1.Checked)
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

             if(credits < 31)
            {
                
                // biseyler 
                    // biseyler
                        // biseyler



            }
            else
            {
                MessageBox.Show("Toplam kredi 30'dan fazla olamaz!");
            }










        }
    }
}

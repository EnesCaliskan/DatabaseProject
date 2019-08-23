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
    public partial class frmLogin : Form
    {
        SqlConnection connection { get; set; }
        SqlCommand cmd;

        public static string nameholder; // kullanici adini tutan degisken
        
        public frmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            String connectionString = @"Data Source=DESKTOP-C13A3K3\SQLEXPRESS;Initial Catalog=Demodb;Integrated Security=True";
            connection = new SqlConnection(connectionString);

        }      

        //*----Kayıt ekleme----*
        private void Button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form form = new Form3();
            form.Show();

        }

        //*----Login Yapma----*
        private void Button1_Click(object sender, EventArgs e) 
        {

            try
            {

                nameholder = text_kadi.Text; // textbox daki texti nameholdera sabitledik

                connection.Open();
                cmd = new SqlCommand("select count(*) from login where kadi=@aadi and ksifre=@ssifre", connection);

                cmd.Parameters.Add("@aadi", SqlDbType.VarChar).Value = text_kadi.Text;
                cmd.Parameters.Add("@ssifre", SqlDbType.VarChar).Value = text_ksifre.Text;


                bool result = Convert.ToBoolean( cmd.ExecuteScalar());
                connection.Close();
                if (result) // eger kullanici adi ve sifre dogruysa, ana ekrana goturur
                {

                    this.Hide();
                    Form frm = new Form1();
                    frm.Show();

                }
                else
                {
                    MessageBox.Show("Kullanici adi yada sifre yanlis");
                }

            }
            catch (Exception ex)
            {

               throw;
            }
         
        }

        
    }
}

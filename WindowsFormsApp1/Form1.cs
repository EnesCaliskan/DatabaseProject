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
    public partial class Form1 : Form
    {

        int ID;
        int rowIndex;

        SqlConnection cnn { get; set; }
        string connectionString { get; set; }
        SqlCommand cmd;

      
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            connectionString = @"Data Source=DESKTOP-C13A3K3\SQLEXPRESS;Initial Catalog=Demodb;Integrated Security=True";
            cnn = new SqlConnection(connectionString);

            string ae;
            ae = frmLogin.nameholder;
           


            label10.Text = ae;



            getList();
        }
     
        private void getList()
        {
            cnn.Open();

            String sql = "";
            sql = "select * from ogrenciler";

            // *----listeleme----*

            SqlDataAdapter adp = new SqlDataAdapter(sql, cnn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            this.dataGridView1.DataSource = ds.Tables[0].DefaultView;

            cnn.Close();
        }

        // *----ekleme----*
        private void Button2_Click(object sender, EventArgs e)  
        {

            try
            {
                cnn.Open();

                String addquery = "insert into ogrenciler(ad, soyad, numara, cinsiyet, sehir, bolum) values (@first, @last, @no, @gender, @city, @major)";


                using (SqlCommand cmd = new SqlCommand(addquery, cnn))
                {

                    cmd.Parameters.AddWithValue("@first", text_ad.Text);
                        cmd.Parameters.AddWithValue("@last", text_soyad.Text);
                    cmd.Parameters.AddWithValue("@no", text_no.Text);
                        cmd.Parameters.AddWithValue("@gender", combo_bolum.Text);
                    cmd.Parameters.AddWithValue("@city", text_sehir.Text);
                        cmd.Parameters.AddWithValue("@major", combo_bolum.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Eklendi!");

                }

                cnn.Close();
                getList();

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
                cmd = new SqlCommand("delete ogrenciler where id=@id", cnn);


                using (cmd)
                {
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    getList();           
                }


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();

                cmd = new SqlCommand("update ogrenciler set ad=@ad,soyad=@soyad,numara=@no,cinsiyet=@cinsiyet,sehir=@sehir,bolum=@bolum" +
               " where id=@id", cnn);


                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@ad", text_ad.Text);
                cmd.Parameters.AddWithValue("@soyad", text_soyad.Text);
                cmd.Parameters.AddWithValue("@no", text_no.Text);
                cmd.Parameters.AddWithValue("@cinsiyet", combo_cinsiyet.Text);
                cmd.Parameters.AddWithValue("@sehir", text_sehir.Text);
                cmd.Parameters.AddWithValue("@bolum", combo_bolum.Text);

                cmd.ExecuteNonQuery();
                cnn.Close();
                getList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void DataGridView1_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            ID = (int)dataGridView1.Rows[e.RowIndex].Cells["id"].Value;
            rowIndex = e.RowIndex;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (rowIndex >= 0)
            {

                DataGridViewRow row = this.dataGridView1.Rows[rowIndex];

                text_ad.Text = row.Cells["ad"].Value.ToString();
                text_soyad.Text = row.Cells["soyad"].Value.ToString();
                text_no.Text = row.Cells["numara"].Value.ToString();
                combo_cinsiyet.Text = row.Cells["cinsiyet"].Value.ToString();
                text_sehir.Text = row.Cells["sehir"].Value.ToString();
                combo_bolum.Text = row.Cells["bolum"].Value.ToString();
                label8.Text = row.Cells["id"].Value.ToString();
                //this.button2.Enabled = false;

            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {

            text_ad.Clear();
            text_soyad.Clear();
            text_no.Clear();            
            text_sehir.Clear();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new Profile();
            form.Show();

        }
    }
}

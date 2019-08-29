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
    
        public static String[] notlar = new String[6];



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

            combo_dersadi.Items.CopyTo(notlar, 0);
    

            getList();
            authentication();
            adminornot();

        }

        public DataTable GetData()
        {
            cnn.Open();
            string query = "SELECT * FROM table4";
            SqlCommand cmd = new SqlCommand(query, cnn);

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            cnn.Close();
            return dt;
        }

        public void loadTable()
        {

            try
            {
                cnn.Open();

                string load = "insert into table4(ad,soyad,numara,ders_adi,vize,final,quiz) " +
                    "select o.ad, o.soyad, o.numara, d.ders_adi, n.vize, n.final, n.quiz " +
                    "from ogrenciler o " +
                    "inner join notlar n ON n.o_id = o.o_id " +
                    "inner join dersler d ON d.d_id = n.d_id";

                cmd = new SqlCommand(load, cnn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        //*----listeleme----*
        private void getList()
        {
           
            String sql = "";
            sql = "select " +
                        "n.n_id,o.o_id,d.d_id," +
                        "o.ad,o.soyad,o.numara,d.ders_adi,n.vize,n.final,n.quiz " +
                "from notlar n " +
                "left outer join ogrenciler o on o.o_id = n.o_id " +
                "left outer join dersler d on d.d_id = n.d_id";

            SqlDataAdapter adp = new SqlDataAdapter(sql, cnn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            this.dataGridView1.DataSource = ds.Tables[0].DefaultView;
            dataGridView1.Refresh();
          
            cnn.Close();

        }

        // *----ekleme----*
        private void Button2_Click(object sender, EventArgs e)  
        {
            SqlTransaction trans = null;

            try
            {
                if (cnn.State == ConnectionState.Closed) cnn.Open();
                trans = cnn.BeginTransaction();
                

                string ogrekle = "insert into ogrenciler(ad, soyad, numara) values (@ad,@soyad,@numara) select scope_identity()";
                string notekle = "insert into notlar(vize,final,quiz,o_id,d_id) values (@vize,@final,@quiz,@o_id,@d_id)";

                //*----o_id dondurur----*
                string o_arama = "select o_id from ogrenciler where ad=@name AND soyad=@surname AND numara=@number";
                    cmd = new SqlCommand(o_arama, cnn,trans);
                        cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = text_ad.Text;
                        cmd.Parameters.Add("@surname", SqlDbType.VarChar).Value = text_soyad.Text;
                    cmd.Parameters.Add("@number", SqlDbType.Int).Value = Convert.ToInt32(text_no.Text);
                int o_idnum = Convert.ToInt32(cmd.ExecuteScalar());
                //*----d_id dondurur-----*
                string d_arama = "select d_id from dersler where ders_adi=@lessonname";
                    cmd = new SqlCommand(d_arama, cnn, trans);
                    cmd.Parameters.Add("@lessonname", SqlDbType.VarChar).Value = combo_dersadi.SelectedItem.ToString();
                int d_idnum = Convert.ToInt32(cmd.ExecuteScalar());
                //*----------------------*

                int ogrId;
                using (SqlCommand cmd = new SqlCommand(ogrekle, cnn, trans))
                {

                    cmd.Parameters.Add("@ad", SqlDbType.VarChar).Value = text_ad.Text;
                        cmd.Parameters.Add("@soyad", SqlDbType.VarChar).Value = text_soyad.Text;
                    cmd.Parameters.Add("@numara", SqlDbType.Int).Value = text_no.Text;

                    ogrId = Convert.ToInt32(cmd.ExecuteScalar());

                }


                using (SqlCommand cmd = new SqlCommand(notekle, cnn, trans))
                {

                    cmd.Parameters.Add("@vize", SqlDbType.Int).Value = text_vize.Text;
                        cmd.Parameters.Add("@final", SqlDbType.Int).Value = text_final.Text;
                            cmd.Parameters.Add("@quiz", SqlDbType.Int).Value = text_quiz.Text;
                        cmd.Parameters.Add("@o_id", SqlDbType.Int).Value = ogrId;
                    cmd.Parameters.Add("@d_id", SqlDbType.Int).Value = d_idnum;

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Eklendi!");

                }

                trans.Commit();

                cnn.Close();
                getList();
                //loadTable();

            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show(ex.Message.ToString()); 
            }

        }

        //*----silme islemi yapar----*
        private void Button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
                cmd = new SqlCommand("delete from ogrenciler where o_id=@ogrId " +
                                     "delete from notlar where o_id=@ogrId", cnn);

                using (cmd)
                {
                    cmd.Parameters.AddWithValue("@ogrId", ID);
                        cmd.ExecuteNonQuery();                 
                        cnn.Close();
                    getList();           
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //*----guncelleme islemi yapar----*
        private void Button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();

                cmd = new SqlCommand("update ogrenciler " +
                                     "set ad=@ad, soyad=@soyad, numara=@numara " +
                                     "where o_id=@ogrId ", cnn);

                    cmd.Parameters.AddWithValue("@ad", text_ad.Text);
                cmd.Parameters.AddWithValue("@soyad", text_soyad.Text);
                    cmd.Parameters.AddWithValue("@numara", text_no.Text);
                cmd.Parameters.AddWithValue("@ogrId", ID);

                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("update notlar " +
                                     "set vize=@vize, final=@final, quiz=@quiz " +
                                     "where o_id = @ogrId");

                    cmd.Parameters.AddWithValue("@vize", text_vize);
                cmd.Parameters.AddWithValue("@final", text_final);
                    cmd.Parameters.AddWithValue("@quiz", text_quiz);
                cmd.Parameters.AddWithValue("@ogrId", ID);


                cnn.Close();
                getList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //*----basilan kutucugun id numarasini geri dondurur----*
        private void DataGridView1_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                ID = (int)dataGridView1.Rows[e.RowIndex].Cells["o_id"].Value;
                rowIndex = e.RowIndex;
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //*----tablodan bir kutuya cift tiklandiginda, sagda bilgileri getirir----*
        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (rowIndex >= 0)
            {

                DataGridViewRow row = this.dataGridView1.Rows[rowIndex];

                text_ad.Text = row.Cells["ad"].Value.ToString();
                    text_soyad.Text = row.Cells["soyad"].Value.ToString();
                        text_no.Text = row.Cells["numara"].Value.ToString();
                            combo_dersadi.Text = row.Cells["ders_adi"].Value.ToString();
                        text_vize.Text = row.Cells["vize"].Value.ToString();
                    text_final.Text = row.Cells["final"].Value.ToString();
                text_quiz.Text = row.Cells["quiz"].Value.ToString();
                //label8.Text = row.Cells["id"].Value.ToString();              

            }
        }

        //*----temizle butonudur. basildiginda textboxlari temizler----*
        private void Button5_Click(object sender, EventArgs e)
        {

            text_ad.Clear();
                text_soyad.Clear();
                    text_no.Clear();            
                    text_vize.Clear();
                text_final.Clear();
            text_quiz.Clear();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new Profile();
            form.Show();

        }

        //*----admin ise ekler,siler,gunceller ama kullanici ise butonlar kapalidir----*
        private void authentication()
        {
            cnn.Open();
            string test = "admin";
            
            cmd = new SqlCommand("select count(*) from admingiris where adminad=@adminad and auth=@test", cnn);
            cmd.Parameters.AddWithValue("@adminad", label10.Text);
            cmd.Parameters.AddWithValue("@test", test);

            bool result = Convert.ToBoolean(cmd.ExecuteScalar());

            

            if(result == false)
            {
                button2.Enabled = false;
                    button3.Enabled = false;
                button4.Enabled = false;
                    button5.Enabled = false;

                text_ad.Enabled = false;
                    text_soyad.Enabled = false;
                text_no.Enabled = false;
                    text_vize.Enabled = false;
                text_final.Enabled = false;
                    combo_dersadi.Enabled = false;
                text_quiz.Enabled = false;


            }
            cnn.Close();
        }

        //*----kullanicinin admin olup olmadigini kontrol eder ve label'a yazdirir----*
        private void adminornot()
        {
            cnn.Open();
            cmd = new SqlCommand("select auth from admingiris where adminad=@adminadd", cnn);
            cmd.Parameters.AddWithValue("@adminadd", label10.Text);

            string auth = Convert.ToString(cmd.ExecuteScalar());
            cnn.Close();
            label11.Text = auth;

            if(auth == "")
            {
                label11.Text = "Ogrenci";
            }
             
        }

        //*----Programdan cikis----*
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //*----isme gore filtreleme----*
        private void Ara_Click(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = "[ad] Like '%" + text_ara.Text + "%'";
            dataGridView1.DataSource = bs;
        }
    }
}

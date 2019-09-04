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

        public static int ID;
        int rowIndex;
        public static int sonuc;
        public static string harf = "";
        public static bool harc;
        public static int l_id;

        List<string> lessons = new List<string>();

        List<Dictionary<string, string>> rows = new List<Dictionary<string, string>>();
        Dictionary<string, string> column;


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
            harckontrol();
            getl_id();
            getLessons();
            


        }

        //*----basilan kutucugun id numarasini geri dondurur----*
        private void DataGridView1_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                ID = (int)dataGridView1.Rows[e.RowIndex].Cells["o_id"].Value;
                rowIndex = e.RowIndex;

                label_ID.Text = ID.ToString();

            }
        }

        public void getl_id()
        {
            if(cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }

            string sql_select = "select l_id from login_1 where kadi=@kadi ";
            cmd = new SqlCommand(sql_select, cnn);
            cmd.Parameters.AddWithValue("@kadi", label10.Text);

            l_id = Convert.ToInt32(cmd.ExecuteScalar());
            label_lid.Text = l_id.ToString();

            cnn.Close();

        }


        public DataTable GetData()
        {

            if(cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }

            string query = "SELECT * FROM table4";
            SqlCommand cmd = new SqlCommand(query, cnn);

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            cnn.Close();
            return dt;
        }

        //*----listeleme----*
        private void getList()
        {
           
            if(cnn.State == ConnectionState.Closed)
            {
                cnn.Close();
            }

            String sql = "";
            sql = "select " +
                        "n.n_id,o.o_id,d.d_id," +
                        "o.ad,o.soyad,o.numara,d.ders_adi,n.vize,n.final,n.quiz,n.sonuc,n.harf " +
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

                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }

                trans = cnn.BeginTransaction();
                

                string ogrekle = "insert into ogrenciler(l_id, ad, soyad, numara) values (@l_id,@ad,@soyad,@numara) select scope_identity()";
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

                        cmd.Parameters.Add("l_id", SqlDbType.VarChar).Value = text_LID.Text;
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
                notHesapla();
                

            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show(ex.Message.ToString());
                cnn.Close();
            }

        }

        //*----silme islemi yapar----*
        private void Button3_Click_1(object sender, EventArgs e)
        {
            if(cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }

            try
            {
                cmd = new SqlCommand("delete from ogrenciler where o_id=@ogrId " +
                                     "delete from notlar where o_id=@ogrId " +
                                     "delete from harc where o_id=@ogrId", cnn);

                using (cmd)
                {
                    cmd.Parameters.AddWithValue("@ogrId", ID);
                        cmd.ExecuteNonQuery();                 
                        cnn.Close();
                    getList();           
                }

                cnn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                cnn.Close();
            }
        }

        //*----guncelleme islemi yapar----*
        private void Button4_Click_1(object sender, EventArgs e)
        {

            try
            {

                if(cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }

                
                cmd = new SqlCommand("update ogrenciler " +
                                     "set l_id=@l_id, ad=@ad, soyad=@soyad, numara=@numara " +
                                     "where o_id=@ogrId ", cnn);

                cmd.Parameters.AddWithValue("@l_id", text_LID.Text);
                    cmd.Parameters.AddWithValue("@ad", text_ad.Text);
                cmd.Parameters.AddWithValue("@soyad", text_soyad.Text);
                    cmd.Parameters.AddWithValue("@numara", text_no.Text);
                cmd.Parameters.AddWithValue("@ogrId", ID);

                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("update notlar " +
                                     "set vize=@vize, final=@final, quiz=@quiz " +
                                     "where o_id = @ogrId", cnn);

                    cmd.Parameters.AddWithValue("@vize", text_vize.Text);
                cmd.Parameters.AddWithValue("@final", text_final.Text);
                    cmd.Parameters.AddWithValue("@quiz", text_quiz.Text);

                cmd.Parameters.AddWithValue("@ogrId", ID);

                cmd.ExecuteNonQuery();

                notHesapla();




                cnn.Close();
                getList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                cnn.Close();
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
                    label_sonuc.Text = row.Cells["sonuc"].Value.ToString();
                label_harf.Text = row.Cells["harf"].Value.ToString();

            }
        }

        //*----temizle butonudur. basildiginda textboxlari temizler----*
        private void Button5_Click(object sender, EventArgs e)
        {

            text_LID.Clear();
                text_ad.Clear();
                    text_soyad.Clear();
                        text_no.Clear();            
                    text_vize.Clear();
                text_final.Clear();
            text_quiz.Clear();

        }
        
        //*----Profil sayfasina gecis butonudur----*
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
                    check_harc.Enabled = false;
                text_LID.Enabled = false;


            }
            else
            {
                button1.Enabled = false;
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

            if (auth == "")
            {
                label11.Text = "Ogrenci";
                ders_secimi.Visible = true;
                harc_kaydet.Visible = false;

            }
            else
            {
                ders_secimi.Visible = false; // eger sadece ogrenciyse bu tusu goster
                harc_kaydet.Visible = true;
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


        //*----sonuc ve harf hesaplar----*
        private void notHesapla()
        {

            try
            {

                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }

                decimal vize = Convert.ToDecimal(text_vize.Text) * Convert.ToDecimal(0.4);
                decimal final = Convert.ToDecimal(text_final.Text) * Convert.ToDecimal(0.5);
                decimal quiz = Convert.ToDecimal(text_quiz.Text) * Convert.ToDecimal(0.1);

                decimal x = vize + final + quiz;
                decimal.Floor(x);
                sonuc = Convert.ToInt32(x);


                if (sonuc > 0 && sonuc < 35)
                {
                    harf = "FF";
                }
                else if (sonuc > 35 && sonuc < 40)
                {
                    harf = "DD";
                }
                else if (sonuc > 40 && sonuc < 45)
                {
                    harf = "DC";
                }
                else if (sonuc > 45 && sonuc < 55)
                {
                    harf = "CC";
                }
                else if (sonuc > 55 && sonuc < 65)
                {
                    harf = "CB";
                }
                else if (sonuc > 65 && sonuc < 75)
                {
                    harf = "BB";
                }
                else if (sonuc > 75 && sonuc < 85)
                {
                    harf = "BA";
                }
                else if (sonuc > 85 && sonuc < 101)
                {
                    harf = "AA";
                }
                else
                {
                    MessageBox.Show("Hata!");
                }
                
                
                string ogrId = "select o_id from ogrenciler where l_id=@l_id and ad=@name and soyad=@surname and numara=@no";
                cmd = new SqlCommand(ogrId, cnn);

                cmd.Parameters.AddWithValue("@l_id", text_LID.Text);
                    cmd.Parameters.AddWithValue("@name", text_ad.Text);
                cmd.Parameters.AddWithValue("@surname", text_soyad.Text);
                    cmd.Parameters.AddWithValue("@no", text_no.Text);
                string oid = Convert.ToString(cmd.ExecuteScalar());

                string sqlekle = "update notlar set sonuc=@result, harf=@letter where o_id=@student";

                    cmd = new SqlCommand(sqlekle, cnn);
                cmd.Parameters.AddWithValue("@result", sonuc);
                    cmd.Parameters.AddWithValue("@letter", harf);
                cmd.Parameters.AddWithValue("@student", oid);
           

                cmd.ExecuteNonQuery();

                label_sonuc.Text = sonuc.ToString();
                label_harf.Text = harf;

                cnn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                cnn.Close();
            }

        } // end of the notHesapla

        //*----login ekranina donus----*
        private void Button6_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form form = new frmLogin();
            form.Show();

        }

        //*----admin tarafından belirtilen ogrencinin harc kayiti yaptirilir----*
        private void Harc_kaydet_Click(object sender, EventArgs e)
        {

            int test;

            string sqlchecked_add = "insert into harc(o_id,harc_durumu) values(@o_id,@harc)";
                string sqlunchecked_add = "insert into harc(o_id,harc_durumu) values (@o_id,@harc)";

            string sqlarama = "select count(*) from harc where o_id = @ogrId";

            string sqlchecked_update = "update harc set harc_durumu = 1 where o_id = @ogrId ";
                string sqlunchecked_update = "update harc set harc_durumu = 0 where o_id = @ogrId ";

            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }

            cmd = new SqlCommand(sqlarama, cnn);
                cmd.Parameters.AddWithValue("@ogrId", ID);
          
                test = Convert.ToInt32(cmd.ExecuteScalar());

            if (check_harc.Checked)
            {
               
                if(test > 0)
                {

                    cmd = new SqlCommand(sqlchecked_update, cnn);
                        cmd.Parameters.AddWithValue("@ogrId", ID);
               
                        cmd.ExecuteNonQuery();

                }
                else
                {
                   
                    cmd = new SqlCommand(sqlchecked_add, cnn);
                        cmd.Parameters.AddWithValue("@o_id", ID);
                    cmd.Parameters.AddWithValue("@harc", 1);

                    cmd.ExecuteNonQuery();

                }         

                MessageBox.Show("Harc Kaydedildi!");

            }
            else
            {
                if (test > 0)
                {

                    cmd = new SqlCommand(sqlunchecked_update, cnn);
                        cmd.Parameters.AddWithValue("@ogrId", ID);
                        cmd.ExecuteNonQuery();

                }
                else
                {

                    cmd = new SqlCommand(sqlunchecked_add, cnn);
                        cmd.Parameters.AddWithValue("@o_id", ID);
                    cmd.Parameters.AddWithValue("@harc", 0);

                    cmd.ExecuteNonQuery();

                }

                MessageBox.Show("Harc Kaydedildi!");

            }

            cnn.Close();

        }

        //*----Harc kontrolu yapar. Eger harc yatirilmissa ders secimi acik olur----*
        public void harckontrol()
        {

            int tutoglum;
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }

            string ogrIdYakala = "select o_id from ogrenciler o " +
                "inner join login_1 l on o.l_id = l.l_id " +
                "where l.kadi = @kadi ";

            cmd = new SqlCommand(ogrIdYakala, cnn);
                cmd.Parameters.AddWithValue("@kadi", label10.Text);

            tutoglum = Convert.ToInt32(cmd.ExecuteScalar());

                string sqlKontrol = "select harc_durumu from harc where o_id =@o_id";
            cmd = new SqlCommand(sqlKontrol, cnn);
                cmd.Parameters.AddWithValue("@o_id", tutoglum);

            bool control = Convert.ToBoolean(cmd.ExecuteScalar());

            if (control == true)
            {
                ders_secimi.Enabled = true;
            }
            else
            {
                ders_secimi.Enabled = false;
            }

            cnn.Close();

        }

        //*----Ders seçimi ekranına geçiş yapar----*
        private void Ders_secimi_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new Form4();
            form.Show();

        }

        private void getLessons()
        {
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }

            string sql_finder = "select ders_adi from dersler d " +
                "inner join secilen_ders s on s.d_id = d.d_id " +
                "inner join ogrenciler o on o.o_id = s.o_id " +
                "where o.o_id = @ogrId";

            cmd = new SqlCommand(sql_finder, cnn);
            cmd.Parameters.AddWithValue("@ogrId", ID);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                column = new Dictionary<string, string>();

                column["ders_adi"] = reader["ders_adi"].ToString();
                rows.Add(column);


            }

            foreach (Dictionary<string, string> column in rows)
            {
                lessons.Add(column["ders_adi"]);
                comboBox1.DataSource = lessons;
            }

            cnn.Close();

        }


    }

}

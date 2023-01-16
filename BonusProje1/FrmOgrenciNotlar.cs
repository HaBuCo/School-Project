using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace BonusProje1
{
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=HARUNBURAK;Initial Catalog=BonusOkul;Integrated Security=True");
        public string numara;
        
        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select dersad,sınav1,sınav2,sınav3,proje,ortalama,durum from TBLNOTLAR inner join TBLDERSLER on TBLNOTLAR.DERSID=TBLDERSLER.DERSID where OGRID=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            //this.Text = numara.ToString();

            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select OGRAD,OGRSOYAD from TBLOGRENCILER where OGRID=@a1", baglanti);
            komut2.Parameters.AddWithValue("@a1",numara);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while(dr2.Read())
            {
                this.Text = dr2[0] + " " + dr2[1];
            }
            baglanti.Close();

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

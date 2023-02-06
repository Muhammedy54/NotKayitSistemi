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

namespace Not_Kayit_Sistemi
{
    public partial class FrmOgreniDetay : Form
    {
        public FrmOgreniDetay()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=MUHAMMEDYILMAZ\SQLEXPRESS;Initial Catalog=DbNotKayıt;Integrated Security=True");

        public string numara;
        //Data Source = MUHAMMEDYILMAZ\SQLEXPRESS;Initial Catalog = DbNotKayıt; Integrated Security = True
        private void FrmOgreniDetay_Load(object sender, EventArgs e)
        {

            
            LblNumara.Text = numara;

            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Select * FROM TBLDERS WHERE OGRNUMARA=@P1",baglanti);
            cmd.Parameters.AddWithValue("@P1", numara);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[2].ToString() + " " + dr[3].ToString();
                LblSinav1.Text = dr[4].ToString();
                LblSinav2.Text = dr[5].ToString();
                LblSinav3.Text = dr[6].ToString();
                LblOrtalama.Text = dr[7].ToString();
                LblDurum.Text = dr[8].ToString();
            }
            baglanti.Close();
            if (LblDurum.Text == "True")
            {
                LblDurum.Text = "Geçti";
            }
            else if (LblDurum.Text == "False")
            {
                LblDurum.Text = "Kaldı";
            }
        }
    }
}

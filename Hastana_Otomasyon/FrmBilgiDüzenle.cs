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

namespace Hastana_Otomasyon
{
    public partial class FrmBilgiDuzenle : Form
    {
        public FrmBilgiDuzenle()
        {
            InitializeComponent();
        }

        public string tcno;
        sqlbaglantisi bgl = new sqlbaglantisi();
        
        private void FrmBilgiDuzenle_Load(object sender, EventArgs e)
        {
            mskTC.Text = tcno;
            SqlCommand komut = new SqlCommand("Select * From Tbl_Hastalar Where HastaTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtad.Text = dr[1].ToString();
                txtsoyad.Text = dr[2].ToString();
                msktelfon.Text = dr[4].ToString();  
                txtsifre.Text = dr[5].ToString();
                cmbcinsiyet.Text = dr[6].ToString();
            }
            bgl.baglanti().Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand konut1 = new SqlCommand("update Tbl_Hastalar set HastaAd=@p1, HastaSoyad=@p2, HastaTelefon=@p3, HastaSifre=@p4,HastaCinsiyet=@p5 Where HastaTC=@p6", bgl.baglanti());
            konut1.Parameters.AddWithValue("@p1", txtad.Text);
            konut1.Parameters.AddWithValue("@p2", txtsoyad.Text);
            konut1.Parameters.AddWithValue("@p3", msktelfon.Text);
            konut1.Parameters.AddWithValue("@p4", txtsifre.Text);
            konut1.Parameters.AddWithValue("@p5", cmbcinsiyet.Text);
            konut1.Parameters.AddWithValue("@p6", mskTC.Text);
            konut1.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}

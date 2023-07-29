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
namespace _17.ProjePetrolAkartakıtıstasyonuAPP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-1DQCP20\SQLEXPRESS;Initial Catalog=18.projePetrol&Akaryakıt;Integrated Security=True");
      //kURSUNSUZ95
        void fiyatlistesi()
        {
            //kURSUNSUZ95
            connection.Open();
            SqlCommand command = new SqlCommand("select * from TBLBENZIN WHERE PETROLTUR='Kurşunsuz95'", connection);
            SqlDataReader DR = command.ExecuteReader();
            while (DR.Read())
            {
                lbl95.Text = DR[3].ToString();
                bunifuCircleProgressbar1.Value = int.Parse(DR[4].ToString());
                lbl95litre.Text = DR[4].ToString();
            }
            connection.Close();
            //kURSUNSUZ97
            connection.Open();
            SqlCommand command2 = new SqlCommand("select * from TBLBENZIN WHERE PETROLTUR='Kurşunsuz97'", connection);
            SqlDataReader DR2 = command2.ExecuteReader();
            while (DR2.Read())
            {
                lbl97.Text = DR2[3].ToString();
                bunifuCircleProgressbar2.Value = int.Parse(DR2[4].ToString());
                lbl97Litre.Text = DR2[4].ToString();
            }
            connection.Close();
            //EuroDizel10
            connection.Open();
            SqlCommand command3 = new SqlCommand("select * from TBLBENZIN WHERE PETROLTUR='EuroDizel10'", connection);
            SqlDataReader DR3 = command3.ExecuteReader();
            while (DR3.Read())
            {
                lblEuro.Text = DR3[3].ToString();
                bunifuCircleProgressbar3.Value = int.Parse(DR3[4].ToString());
                lblEuorLitre.Text = DR3[4].ToString();
            }
            connection.Close();
            //YeniProDizel
            connection.Open();
            SqlCommand command4 = new SqlCommand("select * from TBLBENZIN WHERE PETROLTUR='YeniProDizel'", connection);
            SqlDataReader DR4 = command4.ExecuteReader();
            while (DR4.Read())
            {
                lblYeni.Text = DR4[3].ToString();
                bunifuCircleProgressbar4.Value = int.Parse(DR4[4].ToString());
                LblYeniLitre.Text = DR4[4].ToString();
            }
            connection.Close();
            //Gaz
            connection.Open();
            SqlCommand command5 = new SqlCommand("select * from TBLBENZIN WHERE PETROLTUR='GAZ'", connection);
            SqlDataReader DR5 = command5.ExecuteReader();
            while (DR5.Read())
            {
                lblGaz.Text = DR5[3].ToString();
                bunifuCircleProgressbar5.Value = int.Parse(DR5[4].ToString());
                lblGazLitre.Text = DR5[4].ToString();
            }
            connection.Close();
        }
        void kasa()
        {
            connection.Open();
            SqlCommand command = new SqlCommand("select * from TBLKASA",connection);
            SqlDataReader DR = command.ExecuteReader();
            while (DR.Read())
            {
                LBLKASA.Text = DR[0].ToString();
            }
            connection.Close();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            fiyatlistesi();
            kasa();

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz95, litre, tutar;
            kursunsuz95 = Convert.ToDouble(lbl95.Text);
            litre = Convert.ToDouble(numericUpDown1.Value);
            tutar = kursunsuz95 * litre;
            txt95fiyat.Text =tutar.ToString();

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            double kusunsuz97, tutar;
            int litree;
            kusunsuz97 = Convert.ToDouble(lbl97.Text);
            litree = Convert.ToInt16(numericUpDown2.Value);
            tutar = litree * kusunsuz97;
            txt97fiyat.Text = tutar.ToString();

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            double Euro, tutar, litra;
            Euro = Convert.ToDouble(lblEuro.Text);
            litra = Convert.ToDouble(numericUpDown3.Value);
            tutar = Euro * litra;
            txtEurofiyat.Text = tutar.ToString();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            double Yeni, litre, tutar;
            Yeni = Convert.ToDouble(lblYeni.Text);
            litre = Convert.ToDouble(numericUpDown4.Value);
            tutar = Yeni * litre;
           textYenifiyat.Text = tutar.ToString();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            double gaz, litre, tutar;
            gaz = Convert.ToDouble(lblGaz.Text);
            litre = Convert.ToDouble(numericUpDown5.Value);
            tutar = gaz * litre;
            textGazfiyat.Text = tutar.ToString();
        }

        private void btnDepoDoldur_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != 0)
            {
                connection.Open();
                SqlCommand command = new SqlCommand("insert into TBLHAREKET (PLAKA,BENZINTURU,LITRE, FIYAT) VALUES (@P1,@P2,@P3,@P4)",connection);
                command.Parameters.AddWithValue("@P1",txtPlaka.Text);
                command.Parameters.AddWithValue("@P2","Kurşunsuz 95");
                command.Parameters.AddWithValue("@P3",numericUpDown1.Value);
                command.Parameters.AddWithValue("@P4",Convert.ToDecimal(txt95fiyat.Text));
                command.ExecuteNonQuery();
                connection.Close();

                connection.Open();
                SqlCommand command3 = new SqlCommand("update TBLKASA set MIKTAR = MIKTAR + @P1", connection);
                command3.Parameters.AddWithValue("@P1", Convert.ToDecimal(txt95fiyat.Text));
                command3.ExecuteNonQuery();
                connection.Close();

                connection.Open();
                SqlCommand command2 = new SqlCommand("update TBLBENZIN SET STOK =STOK-@P1 WHERE PETROLTUR='Kurşunsuz95'", connection);
                command2.Parameters.AddWithValue("@p1", numericUpDown1.Value);
                command2.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Satış Gerçekleşti");
                fiyatlistesi();
            }
            if (numericUpDown2.Value != 0)
            {
                connection.Open();
                SqlCommand command = new SqlCommand("insert into TBLHAREKET (PLAKA ,BENZINTURU,LITRE,FIYAT) VALUES (@P1,@P2,@P3,@P4)", connection);
                command.Parameters.AddWithValue("@P1", txtPlaka.Text);
                command.Parameters.AddWithValue("@P2", "Kurşunsuz 97");
                command.Parameters.AddWithValue("@P3",numericUpDown2.Value);
                command.Parameters.AddWithValue("@P4", Convert.ToDecimal(txt97fiyat.Text));
                command.ExecuteNonQuery();
                connection.Close();

                connection.Open();
                SqlCommand command3 = new SqlCommand("update TBLKASA set MIKTAR = MIKTAR + @P1", connection);
                command3.Parameters.AddWithValue("@P1", Convert.ToDecimal(txt97fiyat.Text));
                command3.ExecuteNonQuery();
                connection.Close();

                connection.Open();
                SqlCommand command2 = new SqlCommand("update TBLBENZIN SET STOK =STOK-@P1 WHERE PETROLTUR='Kurşunsuz97'", connection);
                command2.Parameters.AddWithValue("@p1", numericUpDown2.Value);
                command2.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Satış Gerçekleşti");
                fiyatlistesi();
            }
            if (numericUpDown3.Value != 0)
            {
                connection.Open();
                SqlCommand command = new SqlCommand("insert into TBLHAREKET (PLAKA, BENZINTURU, LITRE, FIYAT) values (@P1,@P2,@P3,@P4)", connection);
                command.Parameters.AddWithValue("@P1", txtPlaka.Text);
                command.Parameters.AddWithValue("@P2", "EuroDizel10");
                command.Parameters.AddWithValue("@p3", numericUpDown3.Value);
                command.Parameters.AddWithValue("@P4",Convert.ToDecimal(txtEurofiyat.Text));
                command.ExecuteNonQuery();
                connection.Close();

                connection.Open();
                SqlCommand command3 = new SqlCommand("update TBLKASA set MIKTAR = MIKTAR + @P1", connection);
                command3.Parameters.AddWithValue("@P1", Convert.ToDecimal(txtEurofiyat.Text));
                command3.ExecuteNonQuery();
                connection.Close();

                connection.Open();
                SqlCommand command2 = new SqlCommand("update TBLBENZIN SET STOK =STOK-@P1 WHERE PETROLTUR='EuroDizel10'", connection);
                command2.Parameters.AddWithValue("@p1", numericUpDown3.Value);
                command2.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Satış Gerçekleşti");
                fiyatlistesi();

            }
            if (numericUpDown4.Value != 0)
            {
                connection.Open();
                SqlCommand command = new SqlCommand("insert into TBLHAREKET (PLAKA, BENZINTURU, LITRE, FIYAT) values (@p1,@p2,@p3,@p4)", connection);
                command.Parameters.AddWithValue("@P1", txtPlaka.Text);
                command.Parameters.AddWithValue("@P2", "YeniProDizel");
                command.Parameters.AddWithValue("@P3", numericUpDown4.Value);
                command.Parameters.AddWithValue("@P4", Convert.ToDecimal(textYenifiyat.Text));
                command.ExecuteNonQuery();
                connection.Close();

                connection.Open();
                SqlCommand command3 = new SqlCommand("update TBLKASA set MIKTAR = MIKTAR + @P1", connection);
                command3.Parameters.AddWithValue("@P1",Convert.ToDecimal(textYenifiyat.Text));
                command3.ExecuteNonQuery();
                connection.Close();
               
                connection.Open();
                SqlCommand command2 = new SqlCommand("update TBLBENZIN SET STOK =STOK-@P1 WHERE PETROLTUR='YeniProDizel'", connection);
                command2.Parameters.AddWithValue("@p1",numericUpDown4.Value);
                command2.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Satış Gerçekleşti");
                fiyatlistesi();
            }
            if (numericUpDown5.Value != 0)
            {
                connection.Open();
                SqlCommand command = new SqlCommand("insert into TBLHAREKET (PLAKA, BENZINTURU, LITRE, FIYAT) values (@P1,@P2,@P3,@P4)", connection);
                command.Parameters.AddWithValue("@P1", txtPlaka.Text);
                command.Parameters.AddWithValue("@P2", "Gaz");
                command.Parameters.AddWithValue("@p3", numericUpDown5.Value);
                command.Parameters.AddWithValue("@P4", Convert.ToDecimal(textGazfiyat.Text));
                command.ExecuteNonQuery();
                connection.Close();

               
                connection.Open();
                SqlCommand command3 = new SqlCommand("update TBLKASA set MIKTAR = MIKTAR + @P1", connection);
                command3.Parameters.AddWithValue("@P1", Convert.ToDecimal(textGazfiyat.Text));
                command3.ExecuteNonQuery();
                connection.Close();

                connection.Open();
                SqlCommand command2 = new SqlCommand("update TBLBENZIN SET STOK =STOK-@P1 WHERE PETROLTUR='Gaz'", connection);
                command2.Parameters.AddWithValue("@p1", numericUpDown5.Value);
                command2.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Satış Gerçekleşti");
                fiyatlistesi();
               


            }
            kasa();
        }
    }
}

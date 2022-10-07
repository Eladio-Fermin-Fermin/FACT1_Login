using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FACT1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //static string mycon = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        public static string ut;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form1 FRM = new Form1();
            //FRM.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if(txtun.Text=="" || txtpw.Text == "")
            {
                MessageBox.Show("Proporcionar nombre de usuario y contraseña Animal");
                return;
            }
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9PHK9TI;Initial Catalog=FACTU1;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("Select Usertype from user_table where Username like'"+txtun.Text+"'COLLATE SQL_Latin1_General_CP1_CS_AS and Password like '"+txtpw.Text+"'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(dt.Rows.Count==1)
                {
                    ut = dt.Rows[0][0].ToString();
                    if(ut=="ADMIN")
                    {
                        ADM FRM = new ADM();
                        FRM.Show();
                        this.Hide();
                    }
                    else if(ut=="USER")
                    {
                        userform FRM = new userform();
                        FRM.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Comprobar nombre de usuario y contraseña");
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtpw.UseSystemPasswordChar = false;
            }
            else
            {
                txtpw.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;


 
namespace AdminTRUE
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        const string pathAdmin = @"D:\AntWork\AdminTRUE\admins.xml";
        List<Admins> admins = new List<Admins>();

        private void ButtonEnter_Click(object sender, EventArgs e)
        {
            

            Form New = new Main();
            New.Show();
            
    
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
            Admins s = admins.Find((admin) => admin.Login == LoginEnter.Text);
            if (LoginEnter.Text == "" ||  PassEnter.Text == "")
            {
                EnetLogorPass.Visible = true;
                Citata.Visible = false;
            }
            if (s == null) 
            {
                EnetLogorPass.Visible = true;
                Citata.Visible = false;

            } else
            if (s.Pass == PassEnter.Text)
            {
                RealAdmin.FIO = s.Fio;
                RealAdmin.Org = s.Organization;
                EnetLogorPass.Visible = false;
                ErrorTxt.Visible = false;
                Form New = new Main();
                New.Show();
                this.Hide();
            }
            else
            {
                EnetLogorPass.Visible = false;
                ErrorTxt.Visible = true;
                Citata.Visible = false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            panelReg.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelReg_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            panelReg.Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)

        {
            try
            {
                Admins admin = new Admins(LoginTxt.Text, PassTxt.Text, FIOTxt.Text, OrTXT.Text, Emailtxt.Text);
                admins.Add(admin);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Admins>));

                StreamWriter writer = new StreamWriter(pathAdmin);
                serializer.Serialize(writer, admins);
                writer.Close();
                LoginTxt.Clear();
                PassTxt.Clear();
                FIOTxt.Clear();
                OrTXT.Clear();
                Emailtxt.Clear();
                MessageBox.Show("Вы зарегистрированы");
                panelReg.Visible = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XmlSerializer serializer1 = new XmlSerializer(typeof(List<Admins>));
            StreamReader reader1 = new StreamReader(pathAdmin);
            admins = (List<Admins>)serializer1.Deserialize(reader1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("При поддержке ИП-КрИво");
        }
    }
    public static class RealAdmin
    {
        public static string FIO;
        public static string Org;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using Amazon.S3;
using Amazon.S3.Transfer;



namespace AdminTRUE
{
    
    public partial class CodeForm : Form
    {
        public CodeForm()
        {
            InitializeComponent();
        }

        const string PathCode = @"D:\AntWork\AdminTRUE\Code.xml";
        const string pathIf = @"D:\AntWork\AdminTRUE\IfOnWork.xml";
        List<IfOnWork> onWorks = new List<IfOnWork>();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            label2.Visible = true;
            PassText.Visible = true;

            CodeGen pass = new CodeGen(CodeGen.Pass());
            XmlSerializer serializer = new XmlSerializer(typeof(CodeGen));
            StreamWriter writer = new StreamWriter(PathCode);
            serializer.Serialize(writer, pass);
            writer.Close();


            XmlSerializer serializer1 = new XmlSerializer(typeof(CodeGen));
            StreamReader reader = new StreamReader(PathCode);
            CodeGen input = (CodeGen)serializer.Deserialize(reader);
            reader.Close();
            PassText.Text = input.Code;


            AmazonUpload amazonS3 = new AmazonUpload();
            amazonS3.UploadFile("missions69", "code.xml", "D:\\AntWork\\AdminTRUE\\code.xml");
            amazonS3.DownloadFile();
          



        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            PassText.Visible = true;
          
            CodeGen pass = new CodeGen(CodeGen.Pass());
            XmlSerializer serializer = new XmlSerializer(typeof(CodeGen));
            StreamWriter writer = new StreamWriter(PathCode);
            serializer.Serialize(writer, pass);
            writer.Close();


//////////////////////////////////////////////////////////////////////////////////////////////////////

            XmlSerializer serializer1 = new XmlSerializer(typeof(CodeGen));
            StreamReader reader = new StreamReader(PathCode);

            CodeGen input = (CodeGen)serializer.Deserialize(reader);
            reader.Close();
            PassText.Text = input.Code;
        }

        private void label22_Click(object sender, EventArgs e)
        {

            listBox1.Visible = true;
            listBox1.Items.Clear();
            AmazonUpload amazonS3 = new AmazonUpload();
            amazonS3.TestDownloadFile(@"D:\AntWork\AdminTRUE\IfOnWork.xml", "IfOnWork");

            XmlSerializer serializer = new XmlSerializer(typeof(List<IfOnWork>));

            StreamReader reader = new StreamReader(pathIf);
            onWorks = (List<IfOnWork>)serializer.Deserialize(reader);

            foreach (IfOnWork work in onWorks)
            {
                
                listBox1.Items.Add(work.Login + " " + work.Date);
            }


            reader.Close();


        }

        private void label22_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listBox1.Visible = false;

        }
    }
}

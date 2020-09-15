using System;
using System.Xml.Linq;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Amazon.S3;
using Amazon.S3.Transfer;



namespace AdminTRUE
{
    public partial class Main : Form
    {
        private const string bucketName = "missions69";
        private const string keyName = "*** provide a name for the uploaded object ***";
        private const string filePath = "*** provide the full path name of the file to upload ***";
        // Specify your bucket region (an example region is shown).
        S3Region region = S3Region.EUW2;
        private static IAmazonS3 s3Client;
        const string path = @"D:\AntWork\AdminTRUE\missions69.xml";
        const string pathId = @"D:\AntWork\AdminTRUE\id.xml";
        const string pathWorker = @"D:\AntWork\AdminTRUE\Workers.xml";
        const string pathGraf = @"D:\AntWork\AdminTRUE\Graf.xml";

        int idMis = 0;
        int IsDone = 0;

        List<Schedule> schedules = new List<Schedule>();
        List<Mission> missions = new List<Mission>();
        List<Workers> workers = new List<Workers>();


        public Main()
        {
            InitializeComponent();

        }


        private void Main_Load(object sender, EventArgs e)
        {



            

                ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                panel1.Visible = true;
                Graficpan.Visible = false;
                XmlSerializer serializer = new XmlSerializer(typeof(List<Mission>));

                StreamReader reader = new StreamReader(path);
                missions = (List<Mission>)serializer.Deserialize(reader);
                reader.Close();
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                XmlSerializer serializer1 = new XmlSerializer(typeof(List<Workers>));
                StreamReader reader1 = new StreamReader(pathWorker);
                workers = (List<Workers>)serializer1.Deserialize(reader1);
                reader1.Close();

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                XmlSerializer serializer3 = new XmlSerializer(typeof(List<Schedule>));
                StreamReader reader2 = new StreamReader(pathGraf);
                schedules = (List<Schedule>)serializer3.Deserialize(reader2);
                /////////////////////////////////////////////////////////////////////////////////////////////////////
                XmlSerializer serializer4 = new XmlSerializer(typeof(Id));
                StreamReader reader3 = new StreamReader(pathId);
                idMis = ((Id)serializer4.Deserialize(reader3)).Num;
            reader3.Close();    
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            namerab.Visible = true;
            about.Visible = true;
            tem.Visible = true;
            rate.Visible = true;
            rabBox1.Visible = true;
            rabBox2.Visible = true;
            rabBox3.Visible = true;
            rabBox4.Visible = true;
            Send.Visible = true;
            ButtonSend.Visible = true;
            date.Visible = true;
            rabbox5.Visible = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            namerab.Visible = true;
            about.Visible = true;
            tem.Visible = true;
            rate.Visible = true;
            rabBox1.Visible = true;
            rabBox2.Visible = true;
            rabBox3.Visible = true;
            rabBox4.Visible = true;
            Send.Visible = true;
            ButtonSend.Visible = true;
        }

        private void Send_Click(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
            
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { }
        class DataTable
        {
            public DataTable(string col1, string col2)
            {
                this.Col1 = col1;
                this.Col2 = col2;
            }
            public string Col1 { get; set; }
            public string Col2 { get; set; }
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {

        }

        private void Send_MouseDown(object sender, MouseEventArgs e)
        {

            ButtonSend.Visible = false;
            Button_nazh.Visible = true;

        }

        private void Send_MouseUp(object sender, MouseEventArgs e)
        {

            ButtonSend.Visible = true;
            Button_nazh.Visible = false;

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

            panel1.Visible = false;
            Graficpan.Visible = true;
            label7.Visible = true;
            Workers.Visible = false;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {



        }

        private void label11_Click(object sender, EventArgs e)
        {
            try
            {
                idMis++;
                Id id = new Id(idMis);
                XmlSerializer serializer2 = new XmlSerializer(typeof(Id));
                StreamWriter writer = new StreamWriter(pathId);
                serializer2.Serialize(writer, id);
                writer.Close();
                Mission mission = new Mission(idMis, rabBox1.Text, rabBox2.Text, rabBox3.Text, Convert.ToDouble(rabBox4.Text), DateTime.Parse(rabbox5.Text), IsDone);
                missions.Add(mission);
               

                XmlSerializer serializer = new XmlSerializer(typeof(List<Mission>));
                StreamWriter writer2 = new StreamWriter(path);
                serializer.Serialize(writer2, missions);
                writer.Close();
                dataGridView1.Rows.Add(rabBox1.Text, rabBox2.Text, rabBox3.Text, rabBox4.Text, rabbox5.Text);
                writer2.Close();

            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void AddMission_Click(object sender, EventArgs e)
        {

            AddMission.Visible = false;
            minus.Visible = true;
            namerab.Visible = true;
            about.Visible = true;
            tem.Visible = true;
            rate.Visible = true;
            rabBox1.Visible = true;
            rabBox2.Visible = true;
            rabBox3.Visible = true;
            rabBox4.Visible = true;
            Send.Visible = true;
            ButtonSend.Visible = true;
            rabbox5.Visible = true;
            date.Visible = true;
            AddButton.Visible = true;
            pictureBox3.Visible = true;

        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            Workers.Visible = false;
            Graficpan.Visible = false;
            panel1.Visible = true;


        }

        private void label1_Click(object sender, EventArgs e)
        {
            Workers.Visible = true;
            Graficpan.Visible = false;
            panel1.Visible = false;


        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form New = new CodeForm();
            New.Show();
            Workers.Visible = false;
            Graficpan.Visible = false;
            panel1.Visible = false;
            


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label11_Click_1(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {


            //   CodeGen code = new CodeGen(rabBox1.Text(rabbox5.Text));
            //   CodeGen.Add(code);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Mission>));
            StreamWriter writer = new StreamWriter(path);
            serializer.Serialize(writer, missions);
            writer.Close();
            dataGridView1.Rows.Add(rabBox1.Text);




        }

        private void Code_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Graficpan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AllMissionsGrid.Visible = true;
            dataGridView1.Visible = false;

            textBox1.Visible = true;
            labedelete1.Visible = true;
            label19.Visible = true;
            linkLabel4.Visible = false;
            AllMiss.Visible = true;

            pictureBox18.Visible = true;
            pictureBox11.Visible = true;
            pictureBox9.Visible = true;
            AllMiss.Visible = true;
            linkLabel4.Visible = false;
            pictureBox2.Visible = false;
            label6.Visible = false;
            linkLabel1.Visible = true;

            AllMissionsGrid.Rows.Clear();


            XmlSerializer serializer = new XmlSerializer(typeof(List<Mission>));

            StreamReader reader = new StreamReader(path);
            missions = (List<Mission>)serializer.Deserialize(reader);

            foreach (Mission mission in missions)
            {
                AllMissionsGrid.Rows.Add(mission.Login, mission.Topic, mission.About, mission.Rate, mission.Date_Miss);
            }


            AllMissionsGrid.Visible = true;
            reader.Close();

        }

        public void UploadFileAsync()
        {
            try
            {
                var fileTransferUtility =
                    new TransferUtility(s3Client);

                // Option 1. Upload a file. The file name is used as the object key name.
                fileTransferUtility.UploadAsync(path, bucketName);
                Console.WriteLine("Upload 1 completed");

                /*// Option 2. Specify object key name explicitly.
                await fileTransferUtility.UploadAsync(filePath, bucketName, keyName);
                Console.WriteLine("Upload 2 completed");

                // Option 3. Upload data from a type of System.IO.Stream.
                using (var fileToUpload =
                    new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    await fileTransferUtility.UploadAsync(fileToUpload,
                                               bucketName, keyName);
                }
                Console.WriteLine("Upload 3 completed");

                // Option 4. Specify advanced settings.
                var fileTransferUtilityRequest = new TransferUtilityUploadRequest
                {
                    BucketName = bucketName,
                    FilePath = filePath,
                    StorageClass = S3StorageClass.StandardInfrequentAccess,
                    PartSize = 6291456, // 6 MB.
                    Key = keyName,
                    CannedACL = S3CannedACL.PublicRead
                };
                fileTransferUtilityRequest.Metadata.Add("param1", "Value1");
                fileTransferUtilityRequest.Metadata.Add("param2", "Value2");

                await fileTransferUtility.UploadAsync(fileTransferUtilityRequest);
                Console.WriteLine("Upload 4 completed");*/
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            /* catch (Exception e)
             {
                 Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
             }*/

        }

        private async void Send_Click_1(object sender, EventArgs e)
        {
            AmazonUpload amazonS3 = new AmazonUpload();
            amazonS3.UploadFile("missions69", "mission69.xml", "D:\\AntWork\\AdminTRUE\\missions69.xml");
            amazonS3.DownloadFile();
          
            MessageBox.Show("Отправлено");
        }

        private void minus_Click(object sender, EventArgs e)
        {
            minus.Visible = false;
            namerab.Visible = false;
            about.Visible = false;
            tem.Visible = false;
            rate.Visible = false;
            rabBox1.Visible = false;
            rabBox2.Visible = false;
            rabBox3.Visible = false;
            rabBox4.Visible = false;
            Send.Visible = false;
            ButtonSend.Visible = false;
            rabbox5.Visible = false;
            date.Visible = false;
            AddButton.Visible = true;
            pictureBox3.Visible = false;
            AddButton.Visible = false;
            AddMission.Visible = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            try {
                string varint = "";

                if (radioButton4.Checked)
                {
                    varint = "6/1";
                }
                else if (radioButton2.Checked)
                {
                    varint = "5/2";
                }
                else if (radioButton3.Checked)
                {
                    varint = "4/3";
                }
                else if (radioButton4.Checked)
                {
                    varint = "2/2";
                }
                else if (radioButton5.Checked)
                {
                    varint = "Свободный";
                }

                Schedule schedule = new Schedule(LoginforGraf.Text, varint, Convert.ToInt32(FWorkTimeTxt.Text), Convert.ToInt32(FWorkDay.Text), datetxt.Text);
                schedules.Add(schedule);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Schedule>));
                StreamWriter writer = new StreamWriter(pathGraf);
                serializer.Serialize(writer, schedules);
                writer.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        private void Workers_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TabelAllWorkers.Visible = true;
            TabelNewWorkers.Visible = false;
            label20.Visible = true;
            label18.Visible = true;
            pictureBox14.Visible = true;
            textBox2.Visible = true;
            pictureBox13.Visible = true;
            label20.Visible = true;
            AllWorker.Visible = true;
            linkAllWorker.Visible = false;
            pictureBox16.Visible = true;
            NewWorkersLabel.Visible = false;
            pictureBox15.Visible = false;
            linkNewWorkers.Visible = true;
            TabelAllWorkers.Rows.Clear();
            /////////////////////////////////////////////////////////////////////////////////////////////
            ///

            XmlSerializer serializer = new XmlSerializer(typeof(List<Workers>));

            StreamReader reader = new StreamReader(pathWorker);
            workers = (List<Workers>)serializer.Deserialize(reader);

            foreach (Workers worker in workers)
            {
                TabelAllWorkers.Rows.Add(worker.Login, worker.Pass, worker.Fio, worker.Function, worker.Organization, worker.Tel, worker.Reiting);
            }

            TabelAllWorkers.Visible = true;
            reader.Close();

        }

        private void linkNewWorkers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TabelNewWorkers.Visible = true;
            TabelAllWorkers.Visible = false;
           


            label20.Visible = false;
            label18.Visible = false;
            pictureBox14.Visible = false;
            textBox2.Visible = false;
            pictureBox13.Visible = false;
            linkAllWorker.Visible = true;
            AllWorker.Visible = false;

            linkAllWorker.Visible = true;
            pictureBox16.Visible = false;
            NewWorkersLabel.Visible = true;
            pictureBox15.Visible = true;
            linkNewWorkers.Visible = false;
           
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            work1.Visible = true;
            work2.Visible = true;
            work3.Visible = true;
            work4.Visible = true;
            work5.Visible = true;
            work6.Visible = true;
            work7.Visible = true;

            textwork1.Visible = true;
            textwork2.Visible = true;
            textwork3.Visible = true;
            textwork4.Visible = true;
            textwork5.Visible = true;
            textwork6.Visible = true;
            textwork7.Visible = true;

            TabelNewWorkers.Visible = true;
            TabelAllWorkers.Visible = false;
            SendLabel.Visible = true;
            SendPic.Visible = true;
            AddLabelpic.Visible = true;
            pictureBoxAdd.Visible = true;
            MinusBox13.Visible = true;
            AddBox14.Visible = false;
        }

        private void MinusBox13_Click(object sender, EventArgs e)
        {
            work1.Visible = false;
            work2.Visible = false;
            work3.Visible = false;
            work4.Visible = false;
            work5.Visible = false;
            work6.Visible = false;
            work7.Visible = false;

            textwork1.Visible = false;
            textwork2.Visible = false;
            textwork3.Visible = false;
            textwork4.Visible = false;
            textwork5.Visible = false;
            textwork6.Visible = false;
            textwork7.Visible = false;

            SendLabel.Visible = false;
            SendPic.Visible = false;
            AddLabelpic.Visible = false;
            pictureBoxAdd.Visible = false;
            MinusBox13.Visible = false;
            AddBox14.Visible = true;
        }

        private void AddLabelpic_Click(object sender, EventArgs e)
        {
            try
            {
                TabelNewWorkers.Visible = true;
                TabelAllWorkers.Visible = false;
                Workers worker = new Workers(textwork1.Text, textwork2.Text, textwork3.Text, textwork4.Text, textwork5.Text, textwork6.Text, Convert.ToDouble(textwork7.Text));
                workers.Add(worker);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Workers>));

                StreamWriter writer = new StreamWriter(pathWorker);
                serializer.Serialize(writer, workers);
                writer.Close();
                TabelNewWorkers.Rows.Add(textwork1.Text, textwork2.Text, textwork3.Text, textwork4.Text, textwork5.Text, textwork6.Text, textwork7.Text);
                TabelNewWorkers.Visible = true;
                TabelAllWorkers.Visible = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


        }

        private void pictureBoxAdd_Click(object sender, EventArgs e)
        {
            Mission mission = new Mission(idMis, rabBox1.Text, rabBox2.Text, rabBox3.Text, Convert.ToDouble(rabBox4.Text), DateTime.Parse(rabbox5.Text), IsDone);
            missions.Add(mission);
            idMis++;

            XmlSerializer serializer = new XmlSerializer(typeof(List<Mission>));
            StreamWriter writer = new StreamWriter(path);
            serializer.Serialize(writer, missions);
            writer.Close();
            dataGridView1.Rows.Add(rabBox1.Text);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Mission mission = new Mission(idMis, rabBox1.Text, rabBox2.Text, rabBox3.Text, Convert.ToDouble(rabBox4.Text), DateTime.Parse(rabbox5.Text), IsDone);
            missions.Add(mission);
            idMis++;

            XmlSerializer serializer = new XmlSerializer(typeof(List<Mission>));
            StreamWriter writer = new StreamWriter(path);
            serializer.Serialize(writer, missions);
            writer.Close();
            dataGridView1.Rows.Add(rabBox1.Text);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            LoginforGraf.Clear();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SendLabel_Click(object sender, EventArgs e)
        {
            AmazonUpload amazonS3 = new AmazonUpload();
            amazonS3.UploadFile("missions69", "workers.xml", "D:\\AntWork\\AdminTRUE\\workers.xml");
            amazonS3.DownloadFile();
            MessageBox.Show("Отправлено");
        }

        private void label11_Click_2(object sender, EventArgs e)
        {
            AmazonUpload amazonS3 = new AmazonUpload();
            amazonS3.UploadFile("missions69", "graf.xml", "D:\\AntWork\\AdminTRUE\\graf.xml");
            amazonS3.DownloadFile();
            MessageBox.Show("Отправлено");

        }

        private void datetxt_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void WorkTimeTxt_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_2(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dataGridView1.Visible = true;
            AllMissionsGrid.Visible = false;
            pictureBox9.Visible = false;
            AllMiss.Visible = false;
            linkLabel1.Visible = false;
            pictureBox2.Visible = true;
            label6.Visible = true;
            linkLabel4.Visible = true;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {
            AllMissionsGrid.Rows.Clear();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Mission>));

            StreamReader reader = new StreamReader(path);
            missions = (List<Mission>)serializer.Deserialize(reader);

            foreach (Mission mission in missions)
            {
                AllMissionsGrid.Rows.Add(mission.Login, mission.Topic, mission.About, mission.Rate, mission.Date_Miss);
            }
            reader.Close();
        }

        private void Main_Leave(object sender, EventArgs e)
        {

        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label19_Click(object sender, EventArgs e)
        {


            Mission s = missions.Find((mis) => mis.Login == textBox1.Text);


            if (s.Login == textBox1.Text)
            {
                AllMissionsGrid.Rows.Clear();
                AllMissionsGrid.Rows.Add(s.Login, s.Topic, s.About, s.Rate, s.Date_Miss);


            }

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void labedelete1_Click(object sender, EventArgs e)
        {
           

            Mission s = missions.Find((mis) => mis.Login == textBox1.Text);
            missions.Remove(s);
            MessageBox.Show("Задача успешно удалена");
            AllMissionsGrid.Rows.Clear();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Mission>));
            StreamWriter writer2 = new StreamWriter(path);
            serializer.Serialize(writer2, missions);
            writer2.Close();



            {
                XmlSerializer serializer1 = new XmlSerializer(typeof(List<Mission>));
                StreamReader reader = new StreamReader(path);
                missions = (List<Mission>)serializer1.Deserialize(reader);

                foreach (Mission mission in missions)
                {
                    AllMissionsGrid.Rows.Add(mission.Login, mission.Topic, mission.About, mission.Rate, mission.Date_Miss);
                }
                reader.Close();
            }

        }

        private void AllWorker_Click(object sender, EventArgs e)
        {
            TabelAllWorkers.Rows.Clear();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Workers>));

            StreamReader reader = new StreamReader(pathWorker);
            workers = (List<Workers>)serializer.Deserialize(reader);

            foreach (Workers worker in workers)
            {
                TabelAllWorkers.Rows.Add(worker.Login, worker.Pass, worker.Fio, worker.Function, worker.Organization, worker.Tel, worker.Reiting);
            }
            reader.Close();
        }

        private void label20_Click(object sender, EventArgs e)
        {

            Workers s = workers.Find((work) => work.Login == textBox2.Text);

            if (s.Login == textBox2.Text)
            {
                TabelAllWorkers.Rows.Clear();
                TabelAllWorkers.Rows.Add(s.Login, s.Pass, s.Fio, s.Function, s.Organization, s.Tel, s.Reiting);

            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Clear();
        }

        private void label18_Click_1(object sender, EventArgs e)
        {

            Workers s = workers.Find((work) => work.Login == textBox2.Text);
            workers.Remove(s);
            MessageBox.Show("Работник успешно удален");
            TabelAllWorkers.Rows.Clear();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Workers>));
            StreamWriter writer2 = new StreamWriter(pathWorker);
            serializer.Serialize(writer2, workers);
            writer2.Close();



            {
                XmlSerializer serializer1 = new XmlSerializer(typeof(List<Workers>));
                StreamReader reader = new StreamReader(pathWorker);
                workers = (List<Workers>)serializer1.Deserialize(reader);

                foreach (Workers worker in workers)
                {
                    TabelAllWorkers.Rows.Add(worker.Login, worker.Pass, worker.Fio, worker.Function, worker.Organization, worker.Tel, worker.Reiting);
                }
                reader.Close();
            }
        }

        private void NewWorkersLabel_Click(object sender, EventArgs e)
        {
            TabelNewWorkers.Visible = true;
            AllMissionsGrid.Visible = false;
            
        }

        private void TabelAllWorkers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddMissionTxt_Click(object sender, EventArgs e)
        {

        }

        private void label5_Move(object sender, EventArgs e)
        {
            panel2.Visible = true;

            NameAdmin.Text = RealAdmin.FIO;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;

          
            NameAdmin.Text = RealAdmin.FIO.Replace(' ','\n');
            label21.Text =  RealAdmin.Org;
      
        }

        private void label22_Click(object sender, EventArgs e)
        {
          
        }

        private void label5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            panel2.Visible = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            vipoln.Visible = true;
            AllMissionsGrid.Visible = false;
            dataGridView1.Visible = false;
   

            AmazonUpload amazonS3 = new AmazonUpload();
            amazonS3.TestDownloadFile(@"D:\AntWork\AdminTRUE\Mission69.xml", "mission69.xml");

            XmlSerializer serializer = new XmlSerializer(typeof(List<Mission>));

            StreamReader reader = new StreamReader(path);
            missions = (List<Mission>)serializer.Deserialize(reader);

            
            foreach (Mission work in missions)
            {
                if (work.Done != 0)
                {
                    vipoln.Rows.Add(work.Login, work.Topic, work.About, work.Rate, work.Date_Miss);
                }
            }


            reader.Close();
        }

        private void vipoln_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}



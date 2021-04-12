using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using firstdraft_command_library;

namespace firstdraft_desktop_ui
{
    public partial class FirstdraftConfiguration : Form
    {
        public FirstdraftConfiguration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Initiating Heartbeat");
            sendHeartbeat.heartBeatStart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Stopping Heartbeat");
            sendHeartbeat.heartBeatStop();
        }

        private void FirstdraftConfiguration_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Uploading File");

            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp;*.txt;*.pdf)|*.jpg; *.jpeg; *.gif; *.bmp; *.txt; *.pdf";

            if (open.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            String file_suffix = FirstdraftUiUtility.getSuffix(open.FileName);

            MessageBox.Show("Suffix is " + file_suffix);

            if (file_suffix.Equals("jpg") == true 
                || file_suffix.Equals("jpeg")  == true
                || file_suffix.Equals("gif") == true
                || file_suffix.Equals("bmp") == true)
            {
                // display image in picture box  
                richTextBox1.Hide();
                pictureBox1.Show();
                pictureBox1.Image = new Bitmap(open.FileName);
            }
            else if(file_suffix.Equals("txt") == true)
            {
                string text = File.ReadAllText(open.FileName);
                pictureBox1.Hide();
                richTextBox1.Show();
                richTextBox1.Text = text;
                //richTextBox1.Text = "!..Welcome to FirstDraft..!";
            }
            else //pdf for now
            {
                string text = "Format not supported";
                pictureBox1.Hide();
                richTextBox1.Show();
                richTextBox1.Text = text;
                //richTextBox1.Text = "!..Welcome to FirstDraft..!";
            }

            MessageBox.Show("Filename is " + open.FileName);

            FileHandling.uploadFile(open.FileName);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Downloading File");

            String downloaded_file = FileHandling.downloadFile();

            String file_suffix = FirstdraftUiUtility.getSuffix(downloaded_file);

            MessageBox.Show("Suffix is " + file_suffix);

            if (file_suffix.Equals("jpg") == true
                || file_suffix.Equals("jpeg") == true
                || file_suffix.Equals("gif") == true
                || file_suffix.Equals("bmp") == true)
            {
                // display image in picture box  
                richTextBox1.Hide();
                pictureBox1.Show();
                pictureBox1.Image = new Bitmap(downloaded_file);
            }
            else if (file_suffix.Equals("txt") == true)
            {
                pictureBox1.Hide();
                richTextBox1.Show();
                string text = File.ReadAllText(downloaded_file);
                richTextBox1.Text = text;
                //richTextBox1.Text = "!..Welcome to FirstDraft..!";
            }
            else //pdf for now
            {
                pictureBox1.Hide();
                richTextBox1.Show();
                string text = "Format not supported";
                richTextBox1.Text = text;
                //richTextBox1.Text = "!..Welcome to FirstDraft..!";
            }

            MessageBox.Show("Filename is " + downloaded_file);


            MessageBox.Show("File downloaded");
        }
    }
}

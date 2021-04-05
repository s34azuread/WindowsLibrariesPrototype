﻿using System;
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
    }
}

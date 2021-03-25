using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapInstaller
{
    public partial class Form1 : Form
    {
        private const int MillisecondsTimeout = 1;

        public Form1()
        {
            InitializeComponent();
            label1.Visible = false;
            progressBar1.Visible = false;
            progressBar1.Maximum = 100;
            progressBar1.Minimum = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            label1.Visible = true;
            progressBar1.Visible = true;
            progressBar1.Value = 10;
            new Thread(() =>
            {
                while (true)
                {
                    
                }
            }).Start();
            new Thread(() =>
            {
                Console.WriteLine("Download starting!");
                CheckForIllegalCrossThreadCalls = false;
                progressBar1.Value = 20;
                Thread.CurrentThread.IsBackground = true;
                progressBar1.Value = 30;
                if (!System.IO.Directory.Exists(System.IO.Directory.GetCurrentDirectory() + "/MinecraftMapServer"))
                {
                    WebClient client = new WebClient();
                    progressBar1.Value = 40;
                    client.DownloadFile("https://download1514.mediafire.com/a98f53lt2weg/ylx25dczo1ta6gi/server.zip", "server.zip");
                    progressBar1.Value = 100;
                    label1.Text = "Download has now been finished!";
                    progressBar1.Value = 10;
                    label1.Text = "Extracting files...";
                    System.IO.Directory.CreateDirectory(System.IO.Directory.GetCurrentDirectory() + "/MinecraftMapServer");
                    ZipFile.ExtractToDirectory(System.IO.Directory.GetCurrentDirectory() + "/server.zip", System.IO.Directory.GetCurrentDirectory() + "/MinecraftMapServer");
                    Console.WriteLine("Extraction finished!");
                }
                label1.Text = "Server Installed! Running...";
                this.label1.Location = new System.Drawing.Point(130, 79);
                System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory() + "/MinecraftMapServer/START THE SERVER.bat");
                Console.WriteLine("Process started!");
                progressBar1.Value = 100;
            }).Start();
        }
    }
}

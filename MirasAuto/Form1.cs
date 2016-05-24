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


namespace MirasAuto
{
    public partial class Form1 : Form
    {
        string[] config = { "english" };

        public Form1()
        {
            InitializeComponent();
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            CONFIG_Init();
            LANG_Init();
            loading.Text = LANG(config[0], 1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void CONFIG_Init()
        {
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            if (File.Exists(path + "/config.txt") == false)
            {
                FileStream file = new FileStream(path + "/config.txt", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            }
            else
            {
                string line = "english";
                int line_count = File.ReadLines(path + "/config.txt").Count();
                System.IO.StreamReader file = new System.IO.StreamReader(path + "/config.txt");
                for (int i = 0; i < line_count; i++)
                {
                    line = file.ReadLine();
                    if (line != null)
                    {
                        var parameter = line.Split('=');
                        config[i] = parameter[1];
                    }
                }
            }
        }

        public void LANG_Init()
        {
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            if (!Directory.Exists(path + "/lang")) Directory.CreateDirectory(path + "/lang");
        }

        public string LANG(string lg, int id)
        {
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            if ((Directory.Exists(path + "/lang") == true) && (File.Exists(path + "/lang/" + lg + ".txt")))
            {
                string line = "???";
                System.IO.StreamReader file = new System.IO.StreamReader(path + "/lang/" + lg + ".txt");
                for (int i = 0; i < id; i++) line = file.ReadLine();

                if (line != null) return line;
            }
            return "???";
        }
    }
}

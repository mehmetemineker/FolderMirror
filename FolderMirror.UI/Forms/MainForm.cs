using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderMirror.UI.Forms
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            //Github test
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FileSystemWatcher fileSystemWatcher1 = new FileSystemWatcher();
            fileSystemWatcher1.Path = @"D:\Test1";
            fileSystemWatcher1.IncludeSubdirectories = true;
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.Changed += fileSystemWatcher1_Changed;
            fileSystemWatcher1.Created += fileSystemWatcher1_Created;

            FileSystemWatcher fileSystemWatcher2 = new FileSystemWatcher();
            fileSystemWatcher2.Path = @"D:\Test2";
            fileSystemWatcher2.IncludeSubdirectories = true;
            fileSystemWatcher2.EnableRaisingEvents = true;
            //fileSystemWatcher2.Changed += fileSystemWatcher1_Changed;
        }

        private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            File.Copy(e.FullPath, @"D:\Test2\" + e.Name);
        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            File.Copy(e.FullPath, @"D:\Test2\" + e.Name, true);
        }


    }
}

using FolderMirror.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderMirror.UI.Forms
{
    //Deleted olduğunda klasör yada dosya silinecek
    //Changed yada Created olduğunda kopyalama yapılacak
    //Renamed olduğunda isim değişecek
    public partial class MainForm : Form
    {
        MirrorFileSystemWatcher mfswL;
        MirrorFileSystemWatcher mfswR;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> listPaths = new Dictionary<string, string>();
            listPaths.Add("D:\\Test1", "D:\\Test2");

            foreach (KeyValuePair<string, string> path in listPaths)
            {
                mfswL = new MirrorFileSystemWatcher(path.Key);
                mfswR = new MirrorFileSystemWatcher(path.Value);

                listBox1.Items.Add(path);
            }

            mfswL.Trigger += MfswL_EventHandler;
            mfswR.Trigger += MfswL_EventHandler;
        }

        private void MfswL_EventHandler(object sender, EventOutput e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            if (e.OldChangedFullPath != null)
            {
                listBox2.Items.Add(e.Event + " - " + e.ChangedFullPath + " - " + e.OldChangedFullPath + " - " + DateTime.Now);
            }
            else
            {
                listBox2.Items.Add(e.Event + " - " + e.ChangedFullPath + " - " + DateTime.Now);
            }
            Control.CheckForIllegalCrossThreadCalls = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KeyValuePair<string, string> item = (KeyValuePair<string, string>)listBox1.SelectedItem;
            
        }
    }
}

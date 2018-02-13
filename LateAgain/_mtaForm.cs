using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using ProtoBuf;
using transit_realtime;
using System.Threading;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Text.RegularExpressions;

namespace LateAgain
{
    public partial class _mtaForm : Form
    {
        public _mtaForm()
        {
            InitializeComponent();
            mainForm = this;
            mainForm.TopMost = true;
            _Railroad = new Railroad();
            lateCommuter = new BackgroundWorker();
            lateCommuter.DoWork += new System.ComponentModel.DoWorkEventHandler(lateCommuter_DoWork);
            lateCommuter.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(lateCommuter_RunWorkerCompleted);
            lateCommuter.RunWorkerAsync();
        }

        private BackgroundWorker lateCommuter;
        private Form mainForm = null;
        private Railroad _Railroad = null;
        
        private void lateCommuter_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_Railroad.xmlFetcher.IsRunning) { Thread.Sleep(5000); }
            if (_Railroad.xmlFetcher.ElapsedMilliseconds >= 10000) { _Railroad.parseXML(_Railroad.DestinationUrl); }
            if(_Railroad.TrainStation.Count == 0) { _Railroad.parseXML(_Railroad.DestinationUrl); }
            
        }
        private void lateCommuter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            updateGUI();
            lateCommuter.RunWorkerAsync();
        }
        private void updateGUI()
        {
            if (_Railroad.TrainStation.Count > 0)
            {
                Railroad.TrainData td = _Railroad.TrainStation.ElementAt(_Railroad.trainToDisplay);
                txt_summary.Text = td.Summary + "\n \n";
                txt_affected.Clear();
                int _affects = 0;
                foreach (Tuple<string, string> affect in td.AffectedLines)
                {
                    txt_affected.AppendText(affect.Item1 + " : " + affect.Item2 + "\n \n");
                    _affects++;
                }
                txt_consequences.Clear();
                foreach (Tuple<string, string> tuple in td.Consequences)
                {
                    for (int i = 1; i <= _affects; i++) { txt_consequences.AppendText("=> " + tuple.Item1 + "\n \n"); }
                }
                if(_Railroad.trainToDisplay >= _Railroad.TrainStation.Count-1) { _Railroad.trainToDisplay = 0; }
                else { _Railroad.trainToDisplay++; }
            }else
            {
                txt_summary.Text = "Everything is on time.";
                txt_affected.Clear();
                txt_consequences.Clear();
            }
        }

        private void _mtaForm_Load(object sender, EventArgs e)
        {
            int y = Screen.PrimaryScreen.WorkingArea.Top+10;
            int x = (Screen.PrimaryScreen.WorkingArea.Right/2) - (this.Width/2);
            this.Location = new Point(x, y);
            
        }

        private void qUITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

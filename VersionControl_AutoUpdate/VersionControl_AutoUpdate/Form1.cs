using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace VersionControl_AutoUpdate
{
    public partial class Form1 : Form
    {
        double hardcodedVersion = 1.02;
        public Form1()
        {
            
            InitializeComponent();
            toolStripVersionDisplay.Text = "build " + hardcodedVersion;
        }

        private void doVersionCheck()
        {
            try
            {
                AutoUpdate.AutoUpdate outdated = new AutoUpdate.AutoUpdate(hardcodedVersion);

                if (outdated.IsOutDated())
                {
                    MessageBox.Show("Program is outdated (v " + hardcodedVersion +"). Updating application to version (v" + outdated.getNewVersion() +")");
                    ApplicationUpdater.Updater updater = new ApplicationUpdater.Updater(); //update program
                }
                else
                {
                    MessageBox.Show("Program is running as a beta program or an updated version.");
                }
            } catch (Exception e)
            {
                MessageBox.Show("Unable to update. e:" + e.ToString());
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            doVersionCheck();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("File exists at location: " + System.Environment.CurrentDirectory);
            try {
                ApplicationUpdater.Updater updater = new ApplicationUpdater.Updater(); //launch download and file replace
                //MessageBox.Show("File in relative directory updated or added.");
                MessageBox.Show("Updated, please relaunch.");
            }
            catch (Exception error) { MessageBox.Show("Unable to complete update. " + error.ToString()); }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Adding a new feature with update.");
        }
    }
}

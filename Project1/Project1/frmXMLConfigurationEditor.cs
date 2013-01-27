using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NUnit;


namespace Project1
{
    public partial class frmXMLConfigurationEditor : Form
    {
        XMLManager xmlManager = new XMLManager();
        public frmXMLConfigurationEditor()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string data = xmlManager.GetXMLFileData();
            txtXMLEdit.Text = data;
        }

        private void validateXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xmlManager.ValidateXML(txtXMLEdit.Text);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string saveStatus = "";
            if (xmlManager.ValidateXML(txtXMLEdit.Text))
            {
                try
                {
                    //Save the file
                    xmlManager.SaveTextToXML(txtXMLEdit.Text);
                    saveStatus = "Save Successful.";
                }
                catch (Exception ex)
                {
                    saveStatus = "Error attempting to save: " + ex.Message;
                }
                finally
                {
                    MessageBox.Show(saveStatus);
                }
                
            }
        }

        private void runTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NUnitTests myTestFixture = new NUnitTests();

                
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


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


            //File.OpenText("data.xml");
            //file.
            //// Add a price element.
            //XmlElement newElem = doc.CreateElement("price");
            //newElem.InnerText = "10.95";
            //doc.DocumentElement.AppendChild(newElem);

            //// Save the document to a file and auto-indent the output.
            //XmlTextWriter writer = new XmlTextWriter("data.xml", null);
            //writer.Formatting = Formatting.Indented;
            //doc.Save(writer);
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
    }
}
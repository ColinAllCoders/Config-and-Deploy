﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;
using System.IO;

namespace Project1
{
    public class XMLManager
    {

        string mySchema = "myXSD.xsd";
        /// <summary>
        /// Opens file dialog to find an XML file, reads data into string.
        /// </summary>
        /// <returns>String containing file data.</returns>
        public string GetXMLFileData()
        {
            string data = "";
            string status = "";
            try
            {
                // Create the XmlDocument.
                XmlDocument doc = new XmlDocument();
                //doc.LoadXml("<item><name>wrench</name></item>");
                OpenFileDialog fileFinder = new OpenFileDialog();
                fileFinder.Filter = "XML Files |*.xml|All Files |*.*";
                fileFinder.FilterIndex = 1;
                fileFinder.ShowDialog();
                doc.Load(fileFinder.FileName);
                StreamReader reader = new StreamReader("data.xml");
                data = reader.ReadToEnd();
                reader.Close();
                status = "Load Successful";
            }
            catch (Exception ex)
            {
                status = "Load Failed...\n " + ex.Message;
            }
            finally
            {
                MessageBox.Show(status);
            }

            return data;
        }

        /// <summary>
        /// Check to see if the text given is of validate XML format, as well as follows the XML Schema loaded to XMLManager
        /// </summary>
        /// <param name="xmlData">XML file in string format</param>
        public void ValidateXML(string xmlData)
        {
            string status = "";
            try
            {
                Xml
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlData);
                status = "Data is valid! You may save.";
            }
            catch (Exception ex)
            {
                status = "Data is of invalid XML Format...\n" + ex.Message;
            }
            finally
            {
                MessageBox.Show(status);
            }
            
        }
    }
}

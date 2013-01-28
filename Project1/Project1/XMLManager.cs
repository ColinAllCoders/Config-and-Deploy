using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Data.SqlClient;
using System.IO;

namespace Project1
{
    /// <summary>
    /// Management of functions used to Load, Save, and Validate XML files.
    /// </summary>
    public class XMLManager
    {
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
                OpenFileDialog fileFinder = new OpenFileDialog();
                //Set up filters for the dialog
                fileFinder.Filter = "XML Files |*.xml|All Files |*.*";
                fileFinder.FilterIndex = 1;
                fileFinder.ShowDialog();

                StreamReader reader = new StreamReader(fileFinder.FileName);    //Open the file chosen
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

        // Using these in global because my ValidationEventHandler cannot receive additional parameters...
        private string mySchema = "myXSD.xsd";  //Schema File Name
        private string validationStatus = "";   //Status message to be printed in message box
        private bool bIsValidAgainstSchema = true;

        /// <summary>
        /// Check to see if the text given is of validate XML format, as well as follows the XML Schema loaded to XMLManager
        /// </summary>
        /// <param name="xmlData">XML file in string format</param>
        public bool ValidateXML(string xmlData)
        {
            XmlDocument doc = new XmlDocument();
            bool bIsValidXML = true;

            try
            {
                doc.LoadXml(xmlData);   // Will throw exception if invalid XML format
                validationStatus = "Data is of valid XML format.";
            }
            catch (Exception ex)
            {
                validationStatus = "Data is of invalid XML Format...\n" + ex.Message;
                bIsValidXML = false;
            }

            if (bIsValidXML)
            {
                bIsValidAgainstSchema = true;   // Assume true...
                try
                {
                    doc.Schemas.Add(null, mySchema);
                    ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEventHandler);   //Set up validation event handle

                    doc.Validate(eventHandler);
                }
                catch (Exception ex)
                {
                    validationStatus += "\n " + ex.Message; //Probably schema load error
                }
            }
            else
                bIsValidAgainstSchema = false;
            
            MessageBox.Show(validationStatus);

            return bIsValidAgainstSchema;            
        }

        public bool SaveTextToXML(string data)
        {
            bool bSaved = false;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(data);
            SaveFileDialog fileSaver = new SaveFileDialog();
            fileSaver.Filter = "XML Files |*.xml|All Files |*.*";
            fileSaver.FilterIndex = 1;
            fileSaver.ShowDialog();
            doc.Save(fileSaver.FileName);

            return bSaved;
        }

        /// <summary>
        /// Void event handle for XML's Validate()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            //If we are inside this function at all, we know the XML is invalid against the schema provided.
            bIsValidAgainstSchema = false;
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    validationStatus += ("\nHowever, Schema Error: " + e.Message);
                    break;
                case XmlSeverityType.Warning:
                    validationStatus += ("\nHowever, Schema Warning: " + e.Message);
                    break;
            }
            validationStatus += "\nYou may not save.";

        }
    }
}

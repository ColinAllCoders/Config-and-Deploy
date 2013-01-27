using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Extensions.Forms;

namespace Project1
{
    [TestFixture]
    public class NUnitTests : NUnitFormTest
    {
        
        public NUnitTests()
        {
            base.init();
            frmXMLConfigurationEditor myXMLEditor = new frmXMLConfigurationEditor();
            myXMLEditor.Show();

            TestOpen(myXMLEditor);

            TestSave(myXMLEditor);

            TestValidate(myXMLEditor);

            TestExit(myXMLEditor);
        }

        [Test]
        public void TestOpen(frmXMLConfigurationEditor myXMLEditor)
        {
            ExpectFileDialog(dialogHandler);
            ToolStripMenuItemTester menuTester = new ToolStripMenuItemTester("openToolStripMenuItem", myXMLEditor);
            menuTester.Click();
        }

        [Test]
        public void TestSave(frmXMLConfigurationEditor myXMLEditor)
        {
            ExpectFileDialog(dialogHandler);
            ToolStripMenuItemTester menuTester = new ToolStripMenuItemTester("saveToolStripMenuItem", myXMLEditor);
            menuTester.Click();
        }

        [Test]
        public void TestValidate(frmXMLConfigurationEditor myXMLEditor)
        {
            ExpectFileDialog(dialogHandler);
            ToolStripMenuItemTester menuTester = new ToolStripMenuItemTester("validateToolStripMenuItem", myXMLEditor);
            menuTester.Click();
        }

        [Test]
        public void TestExit(frmXMLConfigurationEditor myXMLEditor)
        {
            //ExpectFileDialog(openHandler);
            ToolStripMenuItemTester menuTester = new ToolStripMenuItemTester("exitToolStripMenuItem", myXMLEditor);
            menuTester.Click();
        }

        public void dialogHandler()
        {
            FileDialogTester dialogTester = new FileDialogTester("Open");

            dialogTester.ClickCancel();
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace UsingJavaScriptFunctionInCSharp
{
    [ComVisible(true)]
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler (webBrowser1_DocumentCompleted);

            //if you want to call the c# code (method) in java script function then write this code
            webBrowser1.ObjectForScripting = this;
            webBrowser1.ScriptErrorsSuppressed = false;

            //if you want to disable right click on web browser control then write this code 
            webBrowser1.IsWebBrowserContextMenuEnabled = false;
            webBrowser1.AllowWebBrowserDrop = false;
        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // in below written code you have to get the current directory of this application
            string CurrentDirectory = Directory.GetCurrentDirectory();
            // here you have to call HTML page using navigate metod. Its mandatory to call navigate mehtod when you have to fire web 
            // browser Document completed event 
            webBrowser1.Navigate(Path.Combine(CurrentDirectory, "HTMLPageForJavaScript.html"));
        }


        private void Report ()
        {
            // here i have to get HTML page div from id of DIV.
            HtmlElement div = webBrowser1.Document.GetElementById("reportContent");

            // here create a simple html content 
            StringBuilder sb = new StringBuilder();
            sb.Append("<table>");
            sb.Append("<tr><tr><B> Hi this is my report demo </B></td></tr>");
            sb.Append("</table>");

            // here i have to assign content to the HTML page div which is display which is display on browser control
            div.InnerHtml = sb.ToString();

        }


        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // when the from is load cursor focus on the web browser control
            webBrowser1.Focus();

            // here i have to call report method which contain the report content
            Report();

        }

        public void PrintReport()
        {
            // i am simply showing print dialouge and call print mehtod of web browser control.
            DialogResult dr = printDialog1.ShowDialog();

            if(dr.ToString() == "OK")
            {
                webBrowser1.Print();
            }
            else
            {
                return;
            }
        }
    }
}

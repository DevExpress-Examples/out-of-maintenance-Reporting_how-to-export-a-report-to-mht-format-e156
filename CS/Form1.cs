using System;
using System.Windows.Forms;

using System.Drawing;
using System.Diagnostics;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
// ...


namespace ExportToMhtCS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // A path to export a report.
            string reportPath = "c:\\Test.mht";

            // Create a report instance.
            XtraReport1 report = new XtraReport1();

            // Get its MHT export options.
            MhtExportOptions mhtOptions = report.ExportOptions.Mht;

            // Set MHT-specific export options.
            mhtOptions.CharacterSet = "UTF-8";
            mhtOptions.RemoveSecondarySymbols = false;
            mhtOptions.Title = "Test Title";

            // Set the pages to be exported, and page-by-page options.
            mhtOptions.ExportMode = HtmlExportMode.SingleFilePageByPage;
            mhtOptions.PageRange = "1, 3-5";
            mhtOptions.PageBorderColor = Color.Blue;
            mhtOptions.PageBorderWidth = 3;

            // Export the report to MHT.
            report.ExportToMht(reportPath);

            // Show the result.
            StartProcess(reportPath);
        }

        // Use this method if you want to automaically open
        // the created MHT file in the default program.
        public void StartProcess(string path)
        {
            Process process = new Process();
            try
            {
                process.StartInfo.FileName = path;
                process.Start();
                process.WaitForInputIdle();
            }
            catch { }
        }
    }
}
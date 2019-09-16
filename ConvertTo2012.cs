using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ReportSync
{
    public partial class ConvertTo2012 : Form
    {
        string fileName;
        string sourceFilePath;
        XDocument reportContent;

        public ConvertTo2012()
        {
            InitializeComponent();

        }

        private void btnLoadConvert_Click(object sender, EventArgs e)
        {
            var res = ofdConvert.ShowDialog();

            if (res == DialogResult.OK)
            {
                sourceFilePath = ofdConvert.FileName;
                btnConvert.Enabled = true;
                txtConvertFileName.Text = ofdConvert.FileName;
                fileName = ofdConvert.SafeFileName;
                txtConvertProgress.Text = $"Loaded {fileName}";
            }

        }

        private enum ConvertProgress
        {
            Loaded,
            AutoRefresh,
            DataSources,
            DataSets,
            ReportSections,
            ReportParameters,
            ReportParametersLayout,
            EmbeddedImages,
            Language,
            ReportUnitType,
            ReportServerUrl,
            ReportID,
            Namespace,
            Altered,
            Completed
        }


        private void AddProgress(string line)
        {
            txtConvertProgress.Text += Environment.NewLine + line;
        }

        private void AbortConversion(string line)
        {
            txtConvertProgress.Text += Environment.NewLine + line;
            btnConvert.Enabled = false;
            MessageBox.Show(line, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                AddProgress("Starting...");
                if (!CheckSourceFileIntegrity())
                {
                    AbortConversion("Source File Integrity Check failed");
                    return;
                }

                Remove2016Nodes();
                UpdateNamespace();
                SaveConvertedReport();

            }
            catch (Exception)
            {
                AbortConversion("Conversion failed");
            }

        }

        private bool CheckSourceFileIntegrity()
        {
            var xml = XElement.Load(sourceFilePath);

            XDocument document = XDocument.Parse(xml.ToString());

            var list = xml.Elements().ToList();

            var types = list.Select(x => x.Name.LocalName).ToList();

            if (!types.Contains("ReportID")) return false;
           

            //Add sections if needed to check

            var sections = new List<string>() { "AutoRefresh",
                                                "DataSources",
                                                "DataSets",
                                                "ReportSections",
                                                "ReportParameters",
                                                "ReportParametersLayout",
                                                "EmbeddedImages",
                                                "Language",
                                                "ReportUnitType",
                                                "ReportServerUrl",
                                                "ReportID"
                                                };

            foreach (var section in sections)
            {
                if (list.Count(y => y.Name.LocalName == section) == 1)
                {
                    AddProgress($"found {section} section");
                }
            }


            return true;
        }

        private bool Remove2016Nodes()
        {
            try
            {
                var xml = XElement.Load(sourceFilePath);
                xml.Elements().Where(x => x.Name.LocalName == "ReportParametersLayout").Remove();

                reportContent = XDocument.Parse(xml.ToString());
            }
            catch (Exception ex)
            {

                throw;
            }
            return true;
        }

        private bool UpdateNamespace()
        {
            try
            {
                var raw = reportContent.ToString();
                raw = raw.Replace("reporting/2016", "reporting/2010");


                reportContent = XDocument.Parse(raw);

            }
            catch (Exception ex)
            {

                throw;
            }
            return true;
        }

        public void SaveConvertedReport()
        {
            try
            {

                var fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(sourceFilePath);

                SaveFileDialog dialog = new SaveFileDialog();
                dialog.FileName = fileNameWithoutExtension + "_converted_to_2012.rdl";
                dialog.Title = "Save New Report";
                dialog.Filter = "Report File|*.rdl";
                dialog.ShowDialog();

                if (!string.IsNullOrEmpty(dialog.FileName))
                {
                    File.WriteAllText(dialog.FileName, reportContent.ToString());

                    MessageBox.Show("Report has been successfully converted.", "Conversion Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AddProgress($"Conversion Complete: {fileName} created");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}


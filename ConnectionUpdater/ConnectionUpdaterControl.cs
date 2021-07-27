using ConnectionUpdater.Helpers;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace ConnectionUpdater
{
    public partial class ConnectionUpdaterControl : PluginControlBase
    {
        public ConnectionUpdaterControl()
        {
            InitializeComponent();
        }

        private void ConnectionUpdaterControl_Load(object sender, EventArgs e)
        {
            ShowErrorNotification("This tool can only be used for connection with type 'OnlineFederation'.", new Uri("https://www.xrmtoolbox.com"));
        }

        private void btn_folder_selector_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    tb_folder_path.Text = fbd.SelectedPath;
                }
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_folder_path.Text))
            {
                MessageBox.Show("Please select a folder first!");
                return;
            }

            ClearLog();

            WriteLineLog("");


            string[] connectionFiles = GetConnectionFiles(tb_folder_path.Text);
            ListConnectionFiles(connectionFiles);

            if (MessageBox.Show("Are you sure you want to continue?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            foreach (string connectionFile in connectionFiles)
            {
                var backupPath = Path.Combine(
                    Path.GetDirectoryName(connectionFile),
                    $"{Path.GetFileNameWithoutExtension(connectionFile)}_{DateTime.Now.ToFileTime()}.backup"
                );
                File.Copy(connectionFile, backupPath);

                WriteLineLog(connectionFile);
                WriteLineLog("================");
                string contentXml = File.ReadAllText(connectionFile);

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(contentXml);
                XmlNodeList connectionDetails = xmlDoc.SelectNodes("descendant::ConnectionDetail[AuthType='OnlineFederation']");

                if (connectionDetails.Count == 0)
                {
                    WriteLineLog("No connections to update");
                }
                else
                {
                    for (int i = 0; i < connectionDetails.Count; i++)
                    {
                        XmlNode connectionDetail = connectionDetails[i];
                        WriteLog($"{connectionDetail["ConnectionName"].InnerText}... ");

                        //Change attributes
                        connectionDetail = connectionDetail.RemoveNodeIfExists("ClientSecret");
                        connectionDetail = connectionDetail.RemoveNodeIfExists("ConnectionString");
                        connectionDetail = connectionDetail.RemoveNodeIfExists("HomeRealmUrl");
                        connectionDetail = connectionDetail.RemoveNodeIfExists("RefreshToken");
                        connectionDetail = connectionDetail.RemoveNodeIfExists("ReplyUrl ");
                        connectionDetail = connectionDetail.RemoveNodeIfExists("S2SClientSecret ");

                        var originalDataService = connectionDetail["OrganizationDataServiceUrl"].InnerText;
                        var newDataService = originalDataService.Replace("/XRMServices/2011/OrganizationData.svc", "/api/data/v9.2/");
                        connectionDetail["OrganizationDataServiceUrl"].InnerText = newDataService;


                        WriteLineLog("OK");
                    }

                    xmlDoc.Save(connectionFile);
                }
                WriteLineLog("");
            }
        }

        private void ListConnectionFiles(string[] connectionFiles)
        {
            WriteLineLog("Connection Files");
            WriteLineLog("================");

            foreach (string connectionFile in connectionFiles)
            {
                WriteLineLog(Path.GetFileName(connectionFile));
            }
        }

        private string[] GetConnectionFiles(string folderPath)
        {
            return Directory.GetFiles(folderPath, "*.xml", SearchOption.AllDirectories);
        }

        private void ClearLog()
        {
            tb_logging.Text = string.Empty;
        }


        private void WriteLog(string log)
        {
            tb_logging.Text += log;
        }

        private void WriteLineLog(string log)
        {
            tb_logging.Text += log;
            tb_logging.Text += Environment.NewLine;
        }
    }
}
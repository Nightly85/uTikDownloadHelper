using System;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Linq;
using Semver;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Diagnostics;

namespace uTikDownloadHelper
{
    class Program
    {
        public static ExtractedResources ResourceFiles = new ExtractedResources();
        public static MultiFormContext FormContext = new MultiFormContext();
        

        [STAThread]
        static void Main(string[] args)
        {

            try
            {
                System.Version version = Assembly.GetExecutingAssembly().GetName().Version;
                SemVersion currentVersion = new SemVersion(version.Major, version.Minor, version.Build);
                HttpWebRequest request = WebRequest.Create("https://api.github.com/repos/DanTheMan827/uTikDownloadHelper/releases") as HttpWebRequest;
                request.UserAgent = "uTikDownloadHelper " + currentVersion;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new System.IO.StreamReader(response.GetResponseStream(), ASCIIEncoding.UTF8);

                dynamic json = JArray.Parse(reader.ReadToEnd());

                SemVersion newestVersion = SemVersion.Parse(((String)json[0].tag_name).Substring(1));

                if (newestVersion > currentVersion)
                {
                    if (MessageBox.Show(String.Format("v{0} is now available, you have v{1}.\r\n\r\nDo you want to visit the download page?", newestVersion.ToString(), currentVersion.ToString()), "New Version", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Process.Start((String)json[0].html_url);
                        return;
                    }
                }
            }
            catch (Exception ex) { }

            Directory.CreateDirectory(Common.TicketsPath);
            if (Common.Settings.ticketWebsite == null) Common.Settings.ticketWebsite = "";

            if (args.Length == 0)
            {
                using (frmList frm = new frmList())
                {
                    FormContext.AddForm(frm);
                    Application.Run(FormContext);
                }
                return;
            }

            if (args[0].ToLower().EndsWith(".tmd"))
            {
                if (File.Exists(args[0]))
                {
                    frmDownload.DownloadMissing(args[0], true);
                    Application.Run(FormContext);
                }

                return;
            }
            
            string ticketInputPath = args[0];

            Byte[] ticket = { };

            if (ticketInputPath.ToLower().StartsWith("http"))
            {
                try
                {
                    ticket = (new System.Net.WebClient()).DownloadData(ticketInputPath);
                } catch (Exception e)
                {
                    MessageBox.Show(e.Message.ToString(), "Error Downloading Ticket");
                    return;
                }
            } else
            {
                ticket = File.ReadAllBytes(ticketInputPath);
            }

            if (ticket.Length < 848)
            {
                MessageBox.Show("Invalid Ticket");
            }

            using (var frm = new frmDownload()){
                string hexID = HelperFunctions.getTitleIDFromTicket(ticket);
                TitleInfo info = new TitleInfo(hexID, "", hexID, "", "", true);
                info.ticket = ticket;
                frm.TitleQueue.Add(info);
                FormContext.AddForm(frm);
                Application.Run(FormContext);
            }
        }
    }
}

using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSLauncher.ResourceDownloader;

namespace CSLauncher.Forms {
    public partial class DownloadForm : Form {
        public DownloadForm() {
            InitializeComponent();
        }

        private void DownloadForm_Load(object sender, EventArgs e) {
            Show();
            lblStatus.Text = "Downloading Resources...";

            var rc = new ResourceCreator();
            rc.GetResourcesAsync(new Progress<ProgressReport>(UpdateProgress));
        }

        private delegate void _upProg(ProgressReport report);

        private void UpdateProgress(ProgressReport report) {
            if (InvokeRequired) {
                Invoke(new _upProg(UpdateProgress), report);
                return;
            }
            
            lblStatus.Text = report.Message;
            progressBar1.Maximum = report.Max;
            progressBar1.Value = report.Current;
            progressBar1.Text = "HELLO THERE!";

            if (report.Complete) {
                Close();
            }
        }
    }
}

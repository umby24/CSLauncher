using System;
using System.Linq;
using System.Windows.Forms;
using CSLauncher.Launcher;
using CSLauncher.Services;

namespace CSLauncher.Forms {
    public partial class ListForm : Form {
        private readonly ClassicubeServer[] _servers;
        private ClassicubeServer[] _filtered;
        private readonly ClassicubeService _service;
        private readonly ListViewColumnSorter _lvwColumnSorter;

        public ListForm(ClassicubeServer[] servers, ClassicubeService classicube) {
            InitializeComponent();
            _servers = servers;
            _filtered = servers;
            _service = classicube;

            _lvwColumnSorter = new ListViewColumnSorter();
            listView1.ListViewItemSorter = _lvwColumnSorter;
        }

        private void ListForm_Load(object sender, EventArgs e) {
            PopulateList();
            Program.SetWatermark(txtSearch, "Search...");
            Program.SetWatermark(txtServerUrl, "Server URL");
        }

        private void PopulateList() {
            listView1.Items.Clear();

            foreach (var server in _filtered) {
                string[] row = { server.Name, server.OnlinePlayers + "/" + server.MaxPlayers, (server.Uptime / 60).ToString(), server.Software };
                listView1.Items.Add(new ListViewItem(row));
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) {
            _filtered = _servers.Where(a => a.Name.IndexOf(txtSearch.Text, 0, StringComparison.CurrentCultureIgnoreCase) != -1).ToArray();
            PopulateList();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e) {
            if (listView1.SelectedIndices.Count == 0)
                return;

            if (listView1.SelectedIndices[0] > _filtered.Count() - 1)
                return;

            txtServerUrl.Text = "www.classicube.net/server/play/" + _filtered[listView1.SelectedIndices[0]].Hash;
        }

        private void btnPrefs_Click(object sender, EventArgs e) {
            var prefs = new PreferencesForm();
            prefs.ShowDialog();
        }

        private void btnConnect_Click(object sender, EventArgs e) {
            LaunchSelected();
        }

        private void btnChangeUser_Click(object sender, EventArgs e) {
            Close();
        }

        private void LaunchSelected() {
            if (listView1.SelectedIndices.Count == 0)
                return;

            if (listView1.SelectedIndices[0] > _filtered.Count() - 1)
                return;

            var selected = _filtered[listView1.SelectedIndices[0]];
            var info = new ConnectionInfo {
                Mppass = selected.Mppass,
                Ip = selected.Ip,
                Port = selected.Port,
                Username = _service.Username
            };

            ClassicalSharp.Launch(info);

            if (Preferences.Settings.Launcher.RememberServers) {
                Preferences.Settings.Launcher.ResumeUrl = string.Format("mc://{0}:{1}/{2}/{3}", info.Ip, info.Port,
                    info.Username, info.Mppass);

                Preferences.Save();
            }

            if (!Preferences.Settings.Launcher.KeepLauncherOpen)
                Application.Exit();
        }

        private void listView1_DoubleClick(object sender, EventArgs e) {
            LaunchSelected();
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e) {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == _lvwColumnSorter.SortColumn) {
                // Reverse the current sort direction for this column.
                _lvwColumnSorter.Order = _lvwColumnSorter.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            } else {
                // Set the column number that is to be sorted; default to ascending.
                _lvwColumnSorter.SortColumn = e.Column;
                _lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            listView1.Sort();
        }
    }
}

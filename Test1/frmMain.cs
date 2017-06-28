using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace Test1
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        int ItemDownloadNum = 0;
        string FolderCreate = "";
        string[] LinkDownload = new string[500];
        bool AlertFolderCreate = false;
        void ResetDefault()
        {
            ItemDownloadNum = 0;
            AlertFolderCreate = false;
        }
        delegate void SetTextCallback(string text);
        private Thread demoThread = null;
        private System.ComponentModel.IContainer components = null;

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtLog.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txtLog.AppendText(text);
            }
        }
        string NoiDungAddLog;
        private void ThreadProcSafe()
        {
            this.SetText(NoiDungAddLog);
        }
        private void AddLog(string NoiDung) {
            NoiDungAddLog = NoiDung;
            this.demoThread =
                new Thread(new ThreadStart(this.ThreadProcSafe));

			this.demoThread.Start();
        }
        public string getHTML(string url)
        {
            //Create request for given url
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Headers["referrer"]= "http://truyentranh8.net/conan-chap-895/";
            //Create response-object
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Take response stream
            StreamReader sr = new StreamReader(response.GetResponseStream());

            //Read response stream (html code)
            string html = sr.ReadToEnd();

            //Close streamreader and response
            sr.Close();
            response.Close();

            //return source
            return html;
        }
        string[] GetMangaIMG(string Source)
        {
            try { 
                int pFrom = Source.IndexOf("var slides_page_url_path = ")+"var slides_page_url_path = ".Length;
                int pTo = Source.IndexOf("if (slides_page_url_path.length");
                string a = Source.Substring(pFrom, pTo - pFrom);
                pFrom = Source.IndexOf("[\"") + "[\"".Length;
                pTo = Source.IndexOf("\"];");
                a = Source.Substring(pFrom, pTo - pFrom);
                a = a.Replace("\n", "");
                string[] IMG = Regex.Split(a, "\",\"");

                // Get title

                pFrom = Source.IndexOf("<title>") + "<title>".Length;
                pTo = Source.IndexOf("</title>");
                FolderCreate = Source.Substring(pFrom, pTo - pFrom);
                return IMG;
            }
            catch
            {
                MessageBox.Show("Đường dẫn không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        string strPage = "";
        private void btnLayTruyen_Click(object sender, EventArgs e)
        {
            DownloadbyList = false;
            txtLog.Text = "";
            if(txtFolder.Text== "" ) {
                MessageBox.Show("Chưa chọn thư mục chứa!");
                btnChangeFolder_Click(sender, e);
                return;
            }
            if (txtLink.Text == "")
            {
                MessageBox.Show("Chưa nhập đường dẫn!");
                txtLink.Focus();
                return;
            }
            strPage = getHTML(txtLink.Text);
            lvwIMG.Items.Clear();
            int i=0;
            if (GetMangaIMG(strPage) != null)
                foreach (string IMGItem in GetMangaIMG(strPage))
                {
                    ListViewItem lvi = new ListViewItem();
                    i++;
                    lvi.Text = i.ToString();
                    LinkDownload[i - 1] = IMGItem;
                    lvi.SubItems.Add(IMGItem);
                    lvi.SubItems.Add("Đang chờ");

                    lvwIMG.Items.Add(lvi);
                }
            else
                return;
            backgroundWorker1.RunWorkerAsync();
        }
        private string GetFileName(string hrefLink)
        {
            string[] parts = hrefLink.Split('/');
            string fileName = "";

            if (parts.Length > 0)
                fileName = parts[parts.Length - 1];
            else
                fileName = hrefLink;
            if (fileName.IndexOf("?") >= 0)
                fileName = fileName.Substring(0, fileName.IndexOf("?"));
            return fileName;
        }
        bool ContinousDownload = true;
        bool OneClick = false;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ContinousDownload = true;
            Thread.Sleep(1000);
            if (lvwIMG.Items.Count == 0) return;
            if (Directory.Exists(txtFolder.Text + "\\" + FolderCreate))
            {
                if (AlertFolderCreate == false) { 
                    DialogResult a = new DialogResult();
                    if (OneClick == true)
                        a = DialogResult.Yes;
                    else
                        a = MessageBox.Show("Đã tồn tại: \n " + txtFolder.Text + "\\" + FolderCreate + "\nBạn có muốn tạo Folder khác? Yes sẽ tạo folder được đánh số, No sẽ tải vào folder đã tồn tại,Cancel sẽ hủy bỏ việc tải về!", "Thông báo", MessageBoxButtons.YesNoCancel);
                    if (a == DialogResult.Yes) { 
                        int i=0;
                        while (Directory.Exists(txtFolder.Text + "\\" + FolderCreate + "_" + i))
                            i++;
                        FolderCreate = FolderCreate + "_" + i;
                        Directory.CreateDirectory(txtFolder.Text + "\\" + FolderCreate);
                        AddLog(Environment.NewLine + "Tạo folder: " + txtFolder.Text + "\\" + FolderCreate);
                        AlertFolderCreate = true;
                        OneClick = true;
                    }
                    else if (a == DialogResult.Cancel)
                    {
                        AlertFolderCreate = false;
                        AddLog(Environment.NewLine + "Hủy bỏ tải về!");ContinousDownload=false;
                        return;
                    }
                    else
                    {
                        AlertFolderCreate = true;
                        OneClick = true;
                    }
                }
            }
            else {
                if (OneClick == true || MessageBox.Show("Để tải file về bạn cần phải tạo folder: \n " + txtFolder.Text + "\\" + FolderCreate + "\nBạn có muốn tạo? Cancel sẽ hủy bỏ việc tải về!", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Thread.Sleep(1000);
                    AddLog(Environment.NewLine + "Tạo folder: " + txtFolder.Text + "\\" + FolderCreate + "");
                    Directory.CreateDirectory(txtFolder.Text + "\\" + FolderCreate);
                    AlertFolderCreate = true;
                    OneClick = true;
                }
                else
                {
                    AddLog(Environment.NewLine + "Hủy bỏ tải về!");ContinousDownload=false;
                    AlertFolderCreate = false;
                    return;
                }
            }
            // the URL to download the file from
            string sUrlToReadFileFrom = LinkDownload[ItemDownloadNum];
            // the path to write the file to
            string sFilePathToWriteFileTo = txtFolder.Text + "\\" + FolderCreate + "\\" + (chkSTT.Checked?ItemDownloadNum.ToString()+".jpg": GetFileName(LinkDownload[ItemDownloadNum]));

            // first, we need to get the exact size (in bytes) of the file we are downloading
            Uri url = new Uri(sUrlToReadFileFrom);
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
            response.Close();
            // gets the size of the file in bytes
            Int64 iSize = response.ContentLength;

            // keeps track of the total bytes downloaded so we can update the progress bar
            Int64 iRunningByteTotal = 0;

            // use the webclient object to download the file
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                // open the file at the remote URL for reading
                using (System.IO.Stream streamRemote = client.OpenRead(new Uri(sUrlToReadFileFrom)))
                {
                    // using the FileStream object, we can write the downloaded bytes to the file system
                    using (Stream streamLocal = new FileStream(sFilePathToWriteFileTo, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        // loop the stream and get the file into the byte buffer
                        int iByteSize = 0;
                        byte[] byteBuffer = new byte[iSize];
                        while ((iByteSize = streamRemote.Read(byteBuffer, 0, byteBuffer.Length)) > 0)
                        {
                            // write the bytes to the file system at the file path specified
                            streamLocal.Write(byteBuffer, 0, iByteSize);
                            iRunningByteTotal += iByteSize;

                            // calculate the progress out of a base "100"
                            double dIndex = (double)(iRunningByteTotal);
                            double dTotal = (double)byteBuffer.Length;
                            double dProgressPercentage = (dIndex / dTotal);
                            int iProgressPercentage = (int)(dProgressPercentage * 100);

                            // update the progress bar
                            backgroundWorker1.ReportProgress(iProgressPercentage);
                        }

                        // clean up the file stream
                        streamLocal.Close();
                    }

                    // close the connection to the remote server
                    streamRemote.Close();
                }
            }
            
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try { 
                lvwIMG.Items[ItemDownloadNum].SubItems[2].Text = e.ProgressPercentage+"%";
            }
            catch
            {
                return;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ContinousDownload == false)
            {
                ResetDefault();
                btnChangeFolder.Enabled = true;
                btnLayTruyen.Enabled = true;
                chkSTT.Enabled = true;
                return;
            }
            ItemDownloadNum++;
            txtLog.Text += Environment.NewLine + "File có số thứ tự "+(ItemDownloadNum)+" đã tải về!";
            lvwIMG.EnsureVisible(ItemDownloadNum-1);

            if (ItemDownloadNum >= lvwIMG.Items.Count)
            {
                AddLog(Environment.NewLine + "Đã download xong chapter!");
                ResetDefault();
                if (DownloadbyList == true)
                {
                    ItemDanhSach++;
                    if (ItemDanhSach >= fm.txtDanhSach.Lines.Length)
                    {
                        AddLog(Environment.NewLine + "Đã download xong danh sách!");
                        btnChangeFolder.Enabled = true;
                        btnLayTruyen.Enabled = true;
                        btnTaiTheoDS.Enabled = true;
                        btnHienDS.Enabled = true;
                        chkSTT.Enabled = true;
                        DownloadbyList = false;
                        return;
                    }
                    else
                    {
                        while (fm.txtDanhSach.Lines[ItemDanhSach].Trim() == "") ItemDanhSach++;
                        txtLink.Text = fm.txtDanhSach.Lines[ItemDanhSach];
                        DownloadbyList = true;
                        txtLink.Text = fm.txtDanhSach.Lines[ItemDanhSach];

                        txtLog.Text = "";
                        if (txtFolder.Text == "")
                        {
                            MessageBox.Show("Chưa chọn thư mục chứa!");
                            btnChangeFolder_Click(sender, e);
                            return;
                        }
                        while (txtLink.Text.Trim() == "")
                        {
                            ItemDanhSach++;
                            txtLink.Text = fm.txtDanhSach.Lines[ItemDanhSach];
                        }
                        strPage = getHTML(txtLink.Text);
                        lvwIMG.Items.Clear();
                        int i = 0;
                        if (GetMangaIMG(strPage) != null)
                            foreach (string IMGItem in GetMangaIMG(strPage))
                            {
                                ListViewItem lvi = new ListViewItem();
                                i++;
                                lvi.Text = i.ToString();
                                LinkDownload[i - 1] = IMGItem;
                                lvi.SubItems.Add(IMGItem);
                                lvi.SubItems.Add("Đang chờ");

                                lvwIMG.Items.Add(lvi);
                            }
                        else
                            return;
                        backgroundWorker1.RunWorkerAsync();
                    }
                }
                else
                {
                    btnChangeFolder.Enabled = true;
                    btnLayTruyen.Enabled = true;
                    chkSTT.Enabled = true;
                }

                return;
            }
            backgroundWorker1.RunWorkerAsync();
            btnChangeFolder.Enabled = false;
            btnLayTruyen.Enabled = false;
            chkSTT.Enabled = false;
        }

        private void btnChangeFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dia = new FolderBrowserDialog();
            dia.SelectedPath = txtFolder.Text;
            dia.Description = "Chọn thư mục chứa chapter!";
            dia.ShowDialog();
            txtFolder.Text = dia.SelectedPath;
            Properties.Settings.Default["FolderPath"] = txtFolder.Text;
            Properties.Settings.Default.Save();
        }

        private void txtLog_TextChanged(object sender, EventArgs e)
        {
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtFolder.Text = Properties.Settings.Default["FolderPath"].ToString();
            txtLink.Text   = Properties.Settings.Default["LastLink"].ToString();
            
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            txtFolder.Enabled = true;
            Properties.Settings.Default["FolderPath"] = txtFolder.Text;
            Properties.Settings.Default.Save();
            Properties.Settings.Default["LastLink"] = txtLink.Text;
            Properties.Settings.Default.Save();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try { 
                backgroundWorker1.CancelAsync();
            }
            catch
            {
                return;
            }
        }

        private void txtLink_Click(object sender, EventArgs e)
        {
            txtLink.SelectAll();
        }
        frmDanhSach fm = new frmDanhSach();
        int ItemDanhSach = 0;
        bool DownloadbyList = false;
        private void btnHienDS_Click(object sender, EventArgs e)
        {
            fm.ShowDialog();
        }

        private void btnTaiTheoDS_Click(object sender, EventArgs e)
        {
            if (fm.txtDanhSach.Text.Trim() != "" && fm.txtDanhSach.Lines.Length>0)
            {
                DownloadbyList = true;
                txtLink.Text = fm.txtDanhSach.Lines[ItemDanhSach];

                txtLog.Text = "";
                if (txtFolder.Text == "")
                {
                    MessageBox.Show("Chưa chọn thư mục chứa!");
                    btnChangeFolder_Click(sender, e);
                    return;
                }
                if (txtLink.Text == "")
                {
                    MessageBox.Show("Chưa nhập đường dẫn!");
                    txtLink.Focus();
                    return;
                }
                btnHienDS.Enabled = false;
                btnTaiTheoDS.Enabled = false;
                btnChangeFolder.Enabled = false;
                btnLayTruyen.Enabled = false;
                chkSTT.Enabled = false;
                strPage = getHTML(txtLink.Text);
                lvwIMG.Items.Clear();
                int i = 0;
                if (GetMangaIMG(strPage) != null)
                    foreach (string IMGItem in GetMangaIMG(strPage))
                    {
                        ListViewItem lvi = new ListViewItem();
                        i++;
                        lvi.Text = i.ToString();
                        LinkDownload[i - 1] = IMGItem;
                        lvi.SubItems.Add(IMGItem);
                        lvi.SubItems.Add("Đang chờ");

                        lvwIMG.Items.Add(lvi);
                    }
                else
                    return;

                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void thoastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout fa = new frmAbout();
            fa.ShowDialog();
        }
    }
}

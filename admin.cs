// Decompiled with JetBrains decompiler
// Type: DVTA.Admin
// Assembly: DVTA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6397275E-3082-406A-A289-EF4607C10E7B
// Assembly location: C:\Users\SUDEEPA\Downloads\dvta_modified\Release\DVTA.exe

using DBAccess;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace DVTA
{
  public class Admin : Form
  {
    private string ftpserver = ConfigurationManager.AppSettings["FTPSERVER"].ToString();
    private string pathtodownload;
    private string time;
    private IContainer components;
    private Label label1;
    private Button btnFtp;
    private Label ftptext;

    public Admin() => this.InitializeComponent();

    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void btnFtp_Click(object sender, EventArgs e)
    {
      this.ftptext.Text = "Please wait while uploading your data";
      new Thread((ThreadStart) (() =>
      {
        DBAccessClass dbAccessClass = new DBAccessClass();
        dbAccessClass.openConnection();
        DataTable expensesOfAll = dbAccessClass.getExpensesOfAll();
        this.pathtodownload = Path.GetTempPath();
        this.pathtodownload += "ftp-";
        Console.WriteLine(this.pathtodownload);
        string filePath = this.pathtodownload + "admin.csv";
        expensesOfAll.WriteToCsvFile(filePath);
        string str = this.pathtodownload + "admin.csv";
        dbAccessClass.closeConnection();
        Admin.Upload("ftp://" + this.ftpserver, "dvta", "p@ssw0rd", this.pathtodownload + "admin.csv");
        Console.WriteLine(this.pathtodownload + "admin.csv");
      })).Start();
    }

    private static void Upload(
      string ftpServer,
      string userName,
      string password,
      string filename)
    {
      using (WebClient webClient = new WebClient())
      {
        try
        {
          webClient.Credentials = (ICredentials) new NetworkCredential(userName, password);
          webClient.UploadFile(ftpServer + "/" + new FileInfo(filename).Name, "STOR", filename);
          int num = (int) MessageBox.Show("Success");
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show("Looks like this file already exists on the server");
          Console.WriteLine((object) ex);
        }
      }
    }

    private void label2_Click(object sender, EventArgs e)
    {
    }

    private void Admin_Load(object sender, EventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Admin));
      this.label1 = new Label();
      this.btnFtp = new Button();
      this.ftptext = new Label();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(174, 55);
      this.label1.Name = "label1";
      this.label1.Size = new Size(84, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Welcome Admin";
      this.label1.Click += new EventHandler(this.label1_Click);
      this.btnFtp.Location = new Point(122, 125);
      this.btnFtp.Name = "btnFtp";
      this.btnFtp.Size = new Size(179, 23);
      this.btnFtp.TabIndex = 1;
      this.btnFtp.Text = "Backup Data to FTP Server";
      this.btnFtp.UseVisualStyleBackColor = true;
      this.btnFtp.Click += new EventHandler(this.btnFtp_Click);
      this.ftptext.AutoSize = true;
      this.ftptext.Location = new Point(119, 186);
      this.ftptext.Name = "ftptext";
      this.ftptext.Size = new Size(0, 13);
      this.ftptext.TabIndex = 2;
      this.ftptext.Click += new EventHandler(this.label2_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(410, 262);
      this.Controls.Add((Control) this.ftptext);
      this.Controls.Add((Control) this.btnFtp);
      this.Controls.Add((Control) this.label1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (Admin);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (Admin);
      this.Load += new EventHandler(this.Admin_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}

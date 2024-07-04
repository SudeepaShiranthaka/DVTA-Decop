// Decompiled with JetBrains decompiler
// Type: DVTA.Login
// Assembly: DVTA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6397275E-3082-406A-A289-EF4607C10E7B
// Assembly location: C:\Users\SUDEEPA\Downloads\dvta_modified\Release\DVTA.exe

using DBAccess;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DVTA
{
  public class Login : Form
  {
    private IContainer components;
    private Label lgnusername;
    private TextBox txtLgnUsername;
    private Label lgnpassword;
    private TextBox txtLgnPass;
    private Button btnlogin;
    private Button btnregister;
    private Label label3;
    private Button configserver;
    private TextBox servertext;

    public Login()
    {
      this.InitializeComponent();
      if (this.IsBeingDebugged())
        Environment.Exit(1);
      if (this.isServerConfigured())
      {
        int num = (int) MessageBox.Show("This application is usable only after configuring the server");
      }
      else
        this.configserver.Enabled = false;
    }

    private bool isServerConfigured() => false;

    private bool IsBeingDebugged() => Debugger.IsAttached;

    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
      string clientusername = this.txtLgnUsername.Text.Trim();
      string clientpassword = this.txtLgnPass.Text.Trim();
      if (clientusername == string.Empty || clientpassword == string.Empty)
      {
        int num1 = (int) MessageBox.Show("Please enter all the fields!");
      }
      else
      {
        DBAccessClass dbAccessClass = new DBAccessClass();
        dbAccessClass.openConnection();
        SqlDataReader sqlDataReader = dbAccessClass.checkLogin(clientusername, clientpassword);
        if (sqlDataReader.HasRows)
        {
          int num2 = 0;
          while (sqlDataReader.Read())
          {
            string str1 = sqlDataReader.GetString(1);
            string str2 = sqlDataReader.GetString(2);
            string str3 = sqlDataReader.GetString(3);
            num2 = (int) sqlDataReader.GetValue(4);
            if (str1 != "admin")
            {
              RegistryKey subKey = Registry.CurrentUser.CreateSubKey("dvta");
              subKey.SetValue("username", (object) str1);
              subKey.SetValue("password", (object) str2);
              subKey.SetValue("email", (object) str3);
              subKey.SetValue("isLoggedIn", (object) "true");
              subKey.Close();
            }
          }
          this.txtLgnUsername.Text = "";
          this.txtLgnPass.Text = "";
          if (num2 != 1)
          {
            this.Close();
            int num3 = (int) new Main().ShowDialog();
            Application.Exit();
          }
          else
          {
            this.Hide();
            int num4 = (int) new Admin().ShowDialog();
            Application.Exit();
          }
        }
        else
        {
          int num5 = (int) MessageBox.Show("Invalid Login");
          this.txtLgnUsername.Text = "";
          this.txtLgnPass.Text = "";
          dbAccessClass.closeConnection();
        }
      }
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
    }

    private void btnlgnregister(object sender, EventArgs e)
    {
      this.Hide();
      int num = (int) new Register().ShowDialog();
      Application.Exit();
    }

    private void Login_Load(object sender, EventArgs e)
    {
    }

    private void button1_Click(object sender, EventArgs e)
    {
      string text = this.servertext.Text;
      string str = text + "\\SQLEXPRESS";
      System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
      if (configuration.AppSettings.Settings["DBSERVER"] == null)
        configuration.AppSettings.Settings.Add("DBSERVER", str);
      else
        configuration.AppSettings.Settings["DBSERVER"].Value = str;
      if (configuration.AppSettings.Settings["FTPSERVER"] == null)
        configuration.AppSettings.Settings.Add("FTPSERVER", text);
      else
        configuration.AppSettings.Settings["FTPSERVER"].Value = text;
      configuration.Save(ConfigurationSaveMode.Modified);
      this.servertext.Text = "";
      int num = (int) MessageBox.Show("Server successfully configured");
    }

    private void textBox1_TextChanged_1(object sender, EventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Login));
      this.lgnusername = new Label();
      this.txtLgnUsername = new TextBox();
      this.lgnpassword = new Label();
      this.txtLgnPass = new TextBox();
      this.btnlogin = new Button();
      this.btnregister = new Button();
      this.label3 = new Label();
      this.configserver = new Button();
      this.servertext = new TextBox();
      this.SuspendLayout();
      this.lgnusername.AutoSize = true;
      this.lgnusername.Location = new Point(133, 88);
      this.lgnusername.Name = "lgnusername";
      this.lgnusername.Size = new Size(55, 13);
      this.lgnusername.TabIndex = 0;
      this.lgnusername.Text = "Username";
      this.lgnusername.Click += new EventHandler(this.label1_Click);
      this.txtLgnUsername.Location = new Point(225, 88);
      this.txtLgnUsername.Name = "txtLgnUsername";
      this.txtLgnUsername.Size = new Size(154, 20);
      this.txtLgnUsername.TabIndex = 1;
      this.txtLgnUsername.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.lgnpassword.AutoSize = true;
      this.lgnpassword.Location = new Point(133, 135);
      this.lgnpassword.Name = "lgnpassword";
      this.lgnpassword.Size = new Size(53, 13);
      this.lgnpassword.TabIndex = 2;
      this.lgnpassword.Text = "Password";
      this.txtLgnPass.Location = new Point(225, 135);
      this.txtLgnPass.Name = "txtLgnPass";
      this.txtLgnPass.Size = new Size(154, 20);
      this.txtLgnPass.TabIndex = 3;
      this.txtLgnPass.UseSystemPasswordChar = true;
      this.btnlogin.Location = new Point(225, 206);
      this.btnlogin.Name = "btnlogin";
      this.btnlogin.Size = new Size(75, 23);
      this.btnlogin.TabIndex = 4;
      this.btnlogin.Text = nameof (Login);
      this.btnlogin.UseVisualStyleBackColor = true;
      this.btnlogin.Click += new EventHandler(this.btnLogin_Click);
      this.btnregister.Location = new Point(134, 248);
      this.btnregister.Name = "btnregister";
      this.btnregister.Size = new Size(245, 23);
      this.btnregister.TabIndex = 5;
      this.btnregister.Text = "Dont have an account yet? Register Here";
      this.btnregister.UseVisualStyleBackColor = true;
      this.btnregister.Click += new EventHandler(this.btnlgnregister);
      this.label3.AutoSize = true;
      this.label3.ForeColor = SystemColors.Desktop;
      this.label3.Location = new Point(222, 28);
      this.label3.Name = "label3";
      this.label3.Size = new Size(59, 13);
      this.label3.TabIndex = 6;
      this.label3.Text = "Login Here";
      this.configserver.Enabled = false;
      this.configserver.Location = new Point((int) byte.MaxValue, 363);
      this.configserver.Name = "configserver";
      this.configserver.Size = new Size(191, 23);
      this.configserver.TabIndex = 7;
      this.configserver.Text = "Configure Server";
      this.configserver.UseVisualStyleBackColor = true;
      this.configserver.Click += new EventHandler(this.button1_Click);
      this.servertext.BackColor = SystemColors.ScrollBar;
      this.servertext.Location = new Point(90, 364);
      this.servertext.Name = "servertext";
      this.servertext.Size = new Size(159, 20);
      this.servertext.TabIndex = 8;
      this.servertext.TextChanged += new EventHandler(this.textBox1_TextChanged_1);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = SystemColors.ControlLight;
      this.ClientSize = new Size(526, 399);
      this.Controls.Add((Control) this.servertext);
      this.Controls.Add((Control) this.configserver);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.btnregister);
      this.Controls.Add((Control) this.btnlogin);
      this.Controls.Add((Control) this.txtLgnPass);
      this.Controls.Add((Control) this.lgnpassword);
      this.Controls.Add((Control) this.txtLgnUsername);
      this.Controls.Add((Control) this.lgnusername);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (Login);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (Login);
      this.Load += new EventHandler(this.Login_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: DVTA.Register
// Assembly: DVTA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6397275E-3082-406A-A289-EF4607C10E7B
// Assembly location: C:\Users\SUDEEPA\Downloads\dvta_modified\Release\DVTA.exe

using DBAccess;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DVTA
{
  public class Register : Form
  {
    private IContainer components;
    private Label label1;
    private TextBox txtRegUsername;
    private Label txtUsername;
    private Label txtPassword;
    private TextBox txtRegPass;
    private Label txtCfmPassword;
    private TextBox txtRegCfmPass;
    private TextBox txtRegEmail;
    private Button button1;
    private Button button2;
    private Label txtEmail;

    public Register() => this.InitializeComponent();

    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void label3_Click(object sender, EventArgs e)
    {
    }

    private void label5_Click(object sender, EventArgs e)
    {
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
    }

    private void btnRegLogin_Click(object sender, EventArgs e)
    {
      this.Hide();
      int num = (int) new Login().ShowDialog();
    }

    private void btnReg_Click(object sender, EventArgs e)
    {
      string clientusername = this.txtRegUsername.Text.Trim();
      string clientpassword = this.txtRegPass.Text.Trim();
      string str = this.txtRegCfmPass.Text.Trim();
      string clientemailid = this.txtRegEmail.Text.Trim();
      if (clientusername == string.Empty || clientpassword == string.Empty || str == string.Empty || clientemailid == string.Empty)
      {
        int num1 = (int) MessageBox.Show("Please enter all the fields!");
      }
      else if (clientpassword != str)
      {
        int num2 = (int) MessageBox.Show("Passwords do not match");
      }
      else
      {
        DBAccessClass dbAccessClass = new DBAccessClass();
        dbAccessClass.openConnection();
        if (dbAccessClass.RegisterUser(clientusername, clientpassword, clientemailid))
        {
          this.txtRegUsername.Text = "";
          this.txtRegPass.Text = "";
          this.txtRegCfmPass.Text = "";
          this.txtRegEmail.Text = "";
          int num3 = (int) MessageBox.Show("Registration Success");
        }
        else
        {
          int num4 = (int) MessageBox.Show("Registration Failed");
        }
        dbAccessClass.closeConnection();
      }
    }

    private void txtRegPass_TextChanged(object sender, EventArgs e)
    {
    }

    private void Register_Load(object sender, EventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Register));
      this.label1 = new Label();
      this.txtRegUsername = new TextBox();
      this.txtUsername = new Label();
      this.txtPassword = new Label();
      this.txtRegPass = new TextBox();
      this.txtCfmPassword = new Label();
      this.txtRegCfmPass = new TextBox();
      this.txtRegEmail = new TextBox();
      this.button1 = new Button();
      this.button2 = new Button();
      this.txtEmail = new Label();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(220, 42);
      this.label1.Name = "label1";
      this.label1.Size = new Size(72, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Register Here";
      this.label1.Click += new EventHandler(this.label1_Click);
      this.txtRegUsername.Location = new Point(249, 91);
      this.txtRegUsername.Name = "txtRegUsername";
      this.txtRegUsername.Size = new Size(142, 20);
      this.txtRegUsername.TabIndex = 1;
      this.txtRegUsername.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.txtUsername.AutoSize = true;
      this.txtUsername.Location = new Point(136, 98);
      this.txtUsername.Name = "txtUsername";
      this.txtUsername.Size = new Size(55, 13);
      this.txtUsername.TabIndex = 2;
      this.txtUsername.Text = "Username";
      this.txtPassword.AutoSize = true;
      this.txtPassword.Location = new Point(136, 131);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.Size = new Size(53, 13);
      this.txtPassword.TabIndex = 3;
      this.txtPassword.Text = "Password";
      this.txtPassword.Click += new EventHandler(this.label3_Click);
      this.txtRegPass.Location = new Point(249, 128);
      this.txtRegPass.Name = "txtRegPass";
      this.txtRegPass.Size = new Size(142, 20);
      this.txtRegPass.TabIndex = 4;
      this.txtRegPass.UseSystemPasswordChar = true;
      this.txtRegPass.TextChanged += new EventHandler(this.txtRegPass_TextChanged);
      this.txtCfmPassword.AutoSize = true;
      this.txtCfmPassword.Location = new Point(136, 171);
      this.txtCfmPassword.Name = "txtCfmPassword";
      this.txtCfmPassword.Size = new Size(91, 13);
      this.txtCfmPassword.TabIndex = 5;
      this.txtCfmPassword.Text = "Confirm Password";
      this.txtRegCfmPass.Location = new Point(249, 171);
      this.txtRegCfmPass.Name = "txtRegCfmPass";
      this.txtRegCfmPass.Size = new Size(142, 20);
      this.txtRegCfmPass.TabIndex = 6;
      this.txtRegCfmPass.UseSystemPasswordChar = true;
      this.txtRegEmail.Location = new Point(249, 209);
      this.txtRegEmail.Name = "txtRegEmail";
      this.txtRegEmail.Size = new Size(142, 20);
      this.txtRegEmail.TabIndex = 7;
      this.button1.Location = new Point(235, 276);
      this.button1.Name = "button1";
      this.button1.Size = new Size(142, 23);
      this.button1.TabIndex = 8;
      this.button1.Text = nameof (Register);
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.btnReg_Click);
      this.button2.Location = new Point(154, 276);
      this.button2.Name = "button2";
      this.button2.Size = new Size(58, 23);
      this.button2.TabIndex = 9;
      this.button2.Text = "Login";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.btnRegLogin_Click);
      this.txtEmail.AutoSize = true;
      this.txtEmail.Location = new Point(136, 209);
      this.txtEmail.Name = "txtEmail";
      this.txtEmail.Size = new Size(46, 13);
      this.txtEmail.TabIndex = 10;
      this.txtEmail.Text = "Email ID";
      this.txtEmail.Click += new EventHandler(this.label5_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = SystemColors.ControlLight;
      this.ClientSize = new Size(524, 375);
      this.Controls.Add((Control) this.txtEmail);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.txtRegEmail);
      this.Controls.Add((Control) this.txtRegCfmPass);
      this.Controls.Add((Control) this.txtCfmPassword);
      this.Controls.Add((Control) this.txtRegPass);
      this.Controls.Add((Control) this.txtPassword);
      this.Controls.Add((Control) this.txtUsername);
      this.Controls.Add((Control) this.txtRegUsername);
      this.Controls.Add((Control) this.label1);
      this.ForeColor = SystemColors.Desktop;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (Register);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (Register);
      this.Load += new EventHandler(this.Register_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}

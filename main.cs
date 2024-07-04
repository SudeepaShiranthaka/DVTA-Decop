// Decompiled with JetBrains decompiler
// Type: DVTA.Main
// Assembly: DVTA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6397275E-3082-406A-A289-EF4607C10E7B
// Assembly location: C:\Users\SUDEEPA\Downloads\dvta_modified\Release\DVTA.exe

using DBAccess;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DVTA
{
  public class Main : Form
  {
    private DataTable returnvalue;
    private IContainer components;
    private Label welcome;
    private Label userLoggedIn;
    private Button btnMainLogout;
    private Button btnAdd;
    private Button btnEdit;
    private Button btnDelete;
    private Button btnProfile;
    private DataGridView dataGridView1;
    private Button btnExcel;

    public Main()
    {
      this.InitializeComponent();
      RegistryKey subKey = Registry.CurrentUser.CreateSubKey("dvta");
      string str1 = (string) subKey.GetValue("username", (object) "null");
      string str2 = (string) subKey.GetValue("isLoggedIn", (object) "null");
      if (str1 == "null" || str2 == "false")
      {
        this.Hide();
        int num = (int) new Login().ShowDialog();
        this.Close();
        Application.Exit();
      }
      else
        this.userLoggedIn.Text = str1;
      subKey.Close();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }

    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
    {
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
      RegistryKey subKey = Registry.CurrentUser.CreateSubKey("dvta");
      subKey.SetValue("username", (object) "null");
      subKey.SetValue("password", (object) "null");
      subKey.SetValue("email", (object) "null");
      subKey.SetValue("isLoggedIn", (object) "false");
      subKey.Close();
      this.Hide();
      int num = (int) new Login().ShowDialog();
    }

    private void userLoggedIn_Click(object sender, EventArgs e)
    {
    }

    private void btnProfile_Click(object sender, EventArgs e)
    {
      RegistryKey subKey = Registry.CurrentUser.CreateSubKey("dvta");
      int num = (int) MessageBox.Show("Username: " + (string) subKey.GetValue("username", (object) null) + "\nEmail ID: " + (string) subKey.GetValue("email", (object) null));
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      int num = (int) new addExpenses().ShowDialog();
    }

    private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
    {
    }

    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
    }

    private void btnView_Click(object sender, EventArgs e)
    {
      DBAccessClass dbAccessClass = new DBAccessClass();
      dbAccessClass.openConnection();
      string emailid = (string) Registry.CurrentUser.CreateSubKey("dvta").GetValue("email", (object) "null");
      this.returnvalue = dbAccessClass.viewExpenses(emailid);
      this.dataGridView1.DataSource = (object) this.returnvalue;
      dbAccessClass.closeConnection();
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Do you want to clear all your expenses?", "Caution", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        DBAccessClass dbAccessClass = new DBAccessClass();
        dbAccessClass.openConnection();
        if (dbAccessClass.clearExpenses((string) Registry.CurrentUser.CreateSubKey("dvta").GetValue("email", (object) "null")))
        {
          int num1 = (int) MessageBox.Show("Success");
        }
        else
        {
          int num2 = (int) MessageBox.Show("Failed");
        }
        dbAccessClass.closeConnection();
      }
      else
        Console.WriteLine("User chose not to clear the expenses");
    }

    private void btnExcel_Click(object sender, EventArgs e)
    {
      try
      {
        this.returnvalue.WriteToCsvFile(Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads" + "\\expenses.csv");
        int num = (int) MessageBox.Show("Success!  Check your Downloads folder");
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Click View Expenses before doing this");
        Console.WriteLine((object) ex);
      }
    }

    private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
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
      DataGridViewCellStyle gridViewCellStyle = new DataGridViewCellStyle();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Main));
      this.welcome = new Label();
      this.userLoggedIn = new Label();
      this.btnMainLogout = new Button();
      this.btnAdd = new Button();
      this.btnEdit = new Button();
      this.btnDelete = new Button();
      this.btnProfile = new Button();
      this.dataGridView1 = new DataGridView();
      this.btnExcel = new Button();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.SuspendLayout();
      this.welcome.AutoSize = true;
      this.welcome.BackColor = SystemColors.Control;
      this.welcome.Location = new Point(49, 34);
      this.welcome.Name = "welcome";
      this.welcome.Size = new Size(58, 13);
      this.welcome.TabIndex = 0;
      this.welcome.Text = "Welcome..";
      this.welcome.Click += new EventHandler(this.label1_Click);
      this.userLoggedIn.AutoSize = true;
      this.userLoggedIn.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.userLoggedIn.Location = new Point(113, 32);
      this.userLoggedIn.Name = "userLoggedIn";
      this.userLoggedIn.Size = new Size(0, 16);
      this.userLoggedIn.TabIndex = 1;
      this.userLoggedIn.Click += new EventHandler(this.userLoggedIn_Click);
      this.btnMainLogout.Location = new Point(650, 25);
      this.btnMainLogout.Name = "btnMainLogout";
      this.btnMainLogout.Size = new Size(75, 23);
      this.btnMainLogout.TabIndex = 2;
      this.btnMainLogout.Text = "Logout";
      this.btnMainLogout.UseVisualStyleBackColor = true;
      this.btnMainLogout.Click += new EventHandler(this.btnLogout_Click);
      this.btnAdd.Location = new Point(510, 114);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new Size(186, 23);
      this.btnAdd.TabIndex = 3;
      this.btnAdd.Text = "Add  Expenses";
      this.btnAdd.UseVisualStyleBackColor = true;
      this.btnAdd.Click += new EventHandler(this.btnAdd_Click);
      this.btnEdit.Location = new Point(510, 162);
      this.btnEdit.Name = "btnEdit";
      this.btnEdit.Size = new Size(186, 23);
      this.btnEdit.TabIndex = 4;
      this.btnEdit.Text = "View Expenses";
      this.btnEdit.UseVisualStyleBackColor = true;
      this.btnEdit.Click += new EventHandler(this.btnView_Click);
      this.btnDelete.Location = new Point(510, 215);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new Size(186, 23);
      this.btnDelete.TabIndex = 5;
      this.btnDelete.Text = "Clear Expenses";
      this.btnDelete.UseVisualStyleBackColor = true;
      this.btnDelete.Click += new EventHandler(this.btnClear_Click);
      this.btnProfile.Location = new Point(569, 25);
      this.btnProfile.Name = "btnProfile";
      this.btnProfile.Size = new Size(75, 23);
      this.btnProfile.TabIndex = 7;
      this.btnProfile.Text = "View Profile";
      this.btnProfile.UseVisualStyleBackColor = true;
      this.btnProfile.Click += new EventHandler(this.btnProfile_Click);
      gridViewCellStyle.ForeColor = System.Drawing.Color.Black;
      this.dataGridView1.AlternatingRowsDefaultCellStyle = gridViewCellStyle;
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
      this.dataGridView1.BackgroundColor = SystemColors.ControlLight;
      this.dataGridView1.BorderStyle = BorderStyle.None;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.EnableHeadersVisualStyles = false;
      this.dataGridView1.GridColor = SystemColors.Control;
      this.dataGridView1.Location = new Point(86, 114);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.RightToLeft = RightToLeft.No;
      this.dataGridView1.Size = new Size(386, 188);
      this.dataGridView1.TabIndex = 8;
      this.dataGridView1.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
      this.btnExcel.Location = new Point(510, 265);
      this.btnExcel.Name = "btnExcel";
      this.btnExcel.Size = new Size(186, 23);
      this.btnExcel.TabIndex = 9;
      this.btnExcel.Text = "Backup Data to Excel";
      this.btnExcel.UseVisualStyleBackColor = true;
      this.btnExcel.Click += new EventHandler(this.btnExcel_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = SystemColors.ControlLight;
      this.ClientSize = new Size(758, 386);
      this.Controls.Add((Control) this.btnExcel);
      this.Controls.Add((Control) this.dataGridView1);
      this.Controls.Add((Control) this.btnProfile);
      this.Controls.Add((Control) this.btnDelete);
      this.Controls.Add((Control) this.btnEdit);
      this.Controls.Add((Control) this.btnAdd);
      this.Controls.Add((Control) this.btnMainLogout);
      this.Controls.Add((Control) this.userLoggedIn);
      this.Controls.Add((Control) this.welcome);
      this.ForeColor = SystemColors.MenuText;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (Main);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (Main);
      this.Load += new EventHandler(this.Form1_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: DVTA.addExpenses
// Assembly: DVTA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6397275E-3082-406A-A289-EF4607C10E7B
// Assembly location: C:\Users\SUDEEPA\Downloads\dvta_modified\Release\DVTA.exe

using DBAccess;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DVTA
{
  public class addExpenses : Form
  {
    private IContainer components;
    private ComboBox textItem;
    private DateTimePicker textDate;
    private Label label1;
    private Label item;
    private Label Date;
    private TextBox textPrice;
    private Label label4;
    private Button btnSave;
    private Button Cancel;

    public addExpenses() => this.InitializeComponent();

    private void label3_Click(object sender, EventArgs e)
    {
    }

    private void textDate_ValueChanged(object sender, EventArgs e)
    {
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      string addemail = (string) Registry.CurrentUser.CreateSubKey("dvta").GetValue("email", (object) "null");
      string addDt = this.textDate.Text.Trim();
      string additem = this.textItem.Text.Trim();
      string addprice = this.textPrice.Text.Trim();
      string addTime = DateTime.Now.ToString("T");
      if (addDt == string.Empty || additem == string.Empty || addprice == string.Empty || addemail == string.Empty || addTime == string.Empty)
      {
        int num1 = (int) MessageBox.Show("Please enter all the fields!");
      }
      else
      {
        DBAccessClass dbAccessClass = new DBAccessClass();
        dbAccessClass.openConnection();
        if (dbAccessClass.addExpenses(addDt, additem, addprice, addemail, addTime))
        {
          this.textDate.Text = "";
          this.textItem.Text = "";
          this.textPrice.Text = "";
          int num2 = (int) MessageBox.Show("Data saved succesfully");
        }
        else
        {
          int num3 = (int) MessageBox.Show("Failed");
        }
        dbAccessClass.closeConnection();
      }
    }

    public string Dat { get; set; }

    private void Cancel_Click(object sender, EventArgs e) => this.Hide();

    private void textPrice_TextChanged(object sender, EventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (addExpenses));
      this.textItem = new ComboBox();
      this.textDate = new DateTimePicker();
      this.label1 = new Label();
      this.item = new Label();
      this.Date = new Label();
      this.textPrice = new TextBox();
      this.label4 = new Label();
      this.btnSave = new Button();
      this.Cancel = new Button();
      this.SuspendLayout();
      this.textItem.FormattingEnabled = true;
      this.textItem.Items.AddRange(new object[9]
      {
        (object) "Grocery",
        (object) "Clothes",
        (object) "Footwear",
        (object) "cosmetics",
        (object) "HouseRent",
        (object) "Education",
        (object) "Travelling",
        (object) "HospitalFee",
        (object) "Furniture"
      });
      this.textItem.Location = new Point(209, 135);
      this.textItem.Name = "textItem";
      this.textItem.Size = new Size(200, 21);
      this.textItem.TabIndex = 0;
      this.textDate.Location = new Point(209, 95);
      this.textDate.Name = "textDate";
      this.textDate.Size = new Size(200, 20);
      this.textDate.TabIndex = 1;
      this.textDate.ValueChanged += new EventHandler(this.textDate_ValueChanged);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(117, 185);
      this.label1.Name = "label1";
      this.label1.Size = new Size(31, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Price";
      this.item.AutoSize = true;
      this.item.Location = new Point(118, 143);
      this.item.Name = "item";
      this.item.Size = new Size(27, 13);
      this.item.TabIndex = 3;
      this.item.Text = "Item";
      this.Date.AutoSize = true;
      this.Date.Location = new Point(118, 102);
      this.Date.Name = "Date";
      this.Date.Size = new Size(30, 13);
      this.Date.TabIndex = 4;
      this.Date.Text = "Date";
      this.Date.Click += new EventHandler(this.label3_Click);
      this.textPrice.Location = new Point(209, 178);
      this.textPrice.Name = "textPrice";
      this.textPrice.Size = new Size(200, 20);
      this.textPrice.TabIndex = 5;
      this.textPrice.TextChanged += new EventHandler(this.textPrice_TextChanged);
      this.label4.AutoSize = true;
      this.label4.Location = new Point(206, 39);
      this.label4.Name = "label4";
      this.label4.Size = new Size(75, 13);
      this.label4.TabIndex = 6;
      this.label4.Text = "Add Expenses";
      this.btnSave.Location = new Point(207, 229);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(75, 23);
      this.btnSave.TabIndex = 7;
      this.btnSave.Text = "save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new EventHandler(this.btnSave_Click);
      this.Cancel.Location = new Point(322, 229);
      this.Cancel.Name = "Cancel";
      this.Cancel.Size = new Size(75, 23);
      this.Cancel.TabIndex = 11;
      this.Cancel.Text = "Cancel";
      this.Cancel.Click += new EventHandler(this.Cancel_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(519, 347);
      this.Controls.Add((Control) this.Cancel);
      this.Controls.Add((Control) this.btnSave);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.textPrice);
      this.Controls.Add((Control) this.Date);
      this.Controls.Add((Control) this.item);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.textDate);
      this.Controls.Add((Control) this.textItem);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (addExpenses);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = nameof (addExpenses);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}

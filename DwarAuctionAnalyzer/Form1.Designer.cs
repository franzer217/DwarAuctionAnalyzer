﻿namespace DwarAuctionAnalyzer
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.button1 = new System.Windows.Forms.Button();
      this.webBrowser1 = new Awesomium.Windows.Forms.WebControl(this.components);
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.button2 = new System.Windows.Forms.Button();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.button3 = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(24, 95);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(206, 42);
      this.button1.TabIndex = 2;
      this.button1.Text = "Войти";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // webBrowser1
      // 
      this.webBrowser1.Location = new System.Drawing.Point(285, 12);
      this.webBrowser1.Size = new System.Drawing.Size(620, 474);
      this.webBrowser1.Source = new System.Uri("http://w1.dwar.ru/", System.UriKind.Absolute);
      this.webBrowser1.TabIndex = 4;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.button3);
      this.groupBox1.Controls.Add(this.button2);
      this.groupBox1.Controls.Add(this.textBox1);
      this.groupBox1.Controls.Add(this.button1);
      this.groupBox1.Location = new System.Drawing.Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(260, 227);
      this.groupBox1.TabIndex = 5;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "groupBox1";
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(24, 45);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(206, 44);
      this.button2.TabIndex = 4;
      this.button2.Text = "Обновить таблицу категорий";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(24, 19);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(206, 20);
      this.textBox1.TabIndex = 3;
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(24, 143);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(206, 44);
      this.button3.TabIndex = 5;
      this.button3.Text = "Пройтись по страницам";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.button3_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(972, 456);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.webBrowser1);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load_1);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button button1;
    private Awesomium.Windows.Forms.WebControl webBrowser1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;

  }
}


using Awesomium.Core;
using Awesomium.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DwarAuctionAnalyzer
{
  public partial class Form1 : Form
  {

    public Form1()
    {
      API.InitializeAwesomium();

      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      API.login(webBrowser1);
    }

    private void Form1_Load_1(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Maximized;

      webBrowser1.Width = this.Width - groupBox1.Width - 50;
      webBrowser1.Height = this.Height - 100;

      //var customPostRequester = new CustomPostRequester();
      //WebCore.ResourceInterceptor = customPostRequester;

      //webBrowser1.Source = new System.Uri("http://w1.dwar.ru/login.php");
    }

    private void button2_Click(object sender, EventArgs e)
    {

      API.copyAuctionCategories(webBrowser1);
    }

    private void button3_Click(object sender, EventArgs e)
    {
      API.analyze(webBrowser1);
    }
  }

  public class CustomPostRequester : IResourceInterceptor
  {
    public ResourceResponse OnRequest(ResourceRequest request)
    {
      string login = "ganton217%40gmail.com";
      string password = "ee34nf3o";
      string data = @"_filter%5Btitle%5D=&_filter%5Bcount_min%5D=&_filter%5Bcount_max%5D=&_filter%5Blevel_min%5D=&_filter%5Blevel_max%5D=&_filter%5Bkind%5D=g1_12&_filter%5Bquality%5D=-1&_filterapply=%D0%9E%D0%BA";
      request.Method = @"POST";
      request.AppendUploadBytes(data, (uint)data.Length);
      request.AppendExtraHeader("Content-Type", "application/x-www-form-urlencoded");
      return null;
    }

    public bool OnFilterNavigation(NavigationRequest test)
    {
      return false;
    }
  }

 
}

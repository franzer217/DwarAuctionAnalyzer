using Awesomium.Core;
using Awesomium.Windows.Forms;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using MyAwesomeParser;
using System.Collections.Generic;
using MySql.Data.MySqlClient;


namespace DwarAuctionAnalyzer
{
  public class API
  {
    static string xmlFilePath = Application.StartupPath + @"\DwarAuctionAnalyzer.xml";
    static string connectionString = @"server=localhost;userid=root;password=ee34nf3o;Database=test";

    #region Внутренние функции
    private static string getMyJavascript()
    {
      StreamReader reader = File.OpenText(@"D:\Programming\Projects\DwarAuctionAnalyzer\DwarAuctionAnalyzer\JSFunctions.js");
      string jsLib = "";
      while(!reader.EndOfStream)
      {
        jsLib += reader.ReadLine();
      }
      return jsLib;
    }

    private static void addCategoryData(JSValue[] categoryName, JSValue[] browserValue)
    {
      MySqlConnection con = new MySqlConnection(connectionString);
      string dbCommand = String.Empty;
      MySqlCommand comm = new MySqlCommand(dbCommand, con);
      con.Open();
      for(int i = 0; i < categoryName.Length; i++)
      {
        dbCommand = "INSERT INTO categories (categoryName, browserValue) VALUES ('" + (string)categoryName[i] + "', '" +
        (string)browserValue[i] + "')";
        comm.CommandText = dbCommand;
        comm.ExecuteNonQuery();
      }
      con.Close();
    }

    private static void addItemData(JSValue item)
    {

    }

    /// <summary>
    /// Настраивает фильтр аукциона на определенную категорию
    /// </summary>
    /// <param name="wc">Браузер</param>
    /// <param name="browserValue">Уникальное название категории</param>
    private static void selectCategory(WebControl wc, string browserValue)
    {
      //Выбираем элемент option с названием нужной категории предмета, затем наживаем кнопку OK на форме
      string jsFunction = "$('[value=\"" + browserValue + "\"]')[0].selected=true;$('[name=\"_filterapply\"]')[0].click();";
      wc.ExecuteJavascript(jsFunction);
    }

    public static string[] getItems(WebControl wc)
    {
      string[] results = new string[10];
      string jsFunction = @"function hui(){var scriptTags = $(""script"", document.body.table);
					var results = [];
					for(var i = 0; i < scriptTags.length; i++)
					{
						if(scriptTags[i].innerText.substring(0, 7) == ""art_alt"")
						{
							results.push(scriptTags[i].innerText);		
						}
					}
          return results;} hui();";
      JSValue itemStrings = wc.ExecuteJavascriptWithResult(jsFunction);
      JSValue[] itemStringsArray = (JSValue[])itemStrings;
      //foreach
      return results;
    }

    public static void analyzeItem(string itemString)
    {
      Dictionary<string, string> item;
      item.Add("");
    }

    public static bool turnToNextPage()
    {
      return false;
    }

    private static void analyzeCategory(WebControl wc, string browserValue)
    {
      selectCategory(wc, browserValue);
      do
      {
        string[] itemStrings = getItems(wc);
        foreach (string itemString in itemStrings)
          analyzeItem(itemString);
      } while (turnToNextPage());
    }

    #endregion

    #region Внешние функции

    public static void analyze(WebControl wc)
    {
      List<string> browserValues = new List<string>();
      string dbCommand = @"SELECT browserValue FROM categories";
      MySqlConnection con = new MySqlConnection(connectionString);
      MySqlCommand comm = new MySqlCommand(dbCommand, con);
      MySqlDataReader reader;
      con.Open();
      reader = comm.ExecuteReader();
      while(reader.Read())
      {
        browserValues.Add((string)reader[0]);
      }
      con.Close();
      foreach(string category in browserValues)
      {
        analyzeCategory(wc, category);
      }
    }

    public static void copyAuctionCategories(WebControl wc)
    {
      string jsLib = getMyJavascript();
      try
      {
        //Создание таблицы categories, если таковой еще нет
        MySqlConnection con = new MySqlConnection(connectionString);
        string dbCommand = "CREATE TABLE IF NOT EXISTS categories (browserValue VARCHAR(15) PRIMARY KEY, categoryName VARCHAR(50));";
        MySqlCommand comm = new MySqlCommand(dbCommand, con);
        con.Open();
        comm.ExecuteNonQuery();
        con.Close();
        
        //Функции javascript
        JSValue categoryData = wc.ExecuteJavascriptWithResult(jsLib);
        JSValue[] records;
        records = (JSValue[])categoryData;
        JSValue[] catName = (JSValue[])records[0];
        JSValue[] browVal = (JSValue[])records[1];
        addCategoryData(catName, browVal);
      }
      catch(Exception exception)
      {
        MessageBox.Show(exception.Message);
      }
    }

    public static void login(WebControl wc)
    {
      try
      {
        dynamic document = (JSObject)wc.ExecuteJavascriptWithResult("document");
        if (document == null)
          throw new Exception("document has null value");
        dynamic element = document.getElementById("userEmail");
        if (element == null)
          throw new Exception("email has null value");
        element.value = "ganton217@gmail.com";
        element = document.getElementById("userPassword");
        element.value = "ee34nf3o";

        element = document.getElementsByTagName("input");
        element[0].click();
        Thread.Sleep(2000);
        wc.Source = new Uri("http://w1.dwar.ru/area_auction.php");
      }
      catch(Exception exception)
      {
        MessageBox.Show(exception.Message);
      }    
    }

    public static void InitializeAwesomium()
    {
      WebConfig config = new WebConfig();
      config.HomeURL = new Uri("http://w1.dwar.ru");
      WebCore.Initialize(config);

      WebPreferences preferences = new WebPreferences();
      WebSession session = WebCore.CreateWebSession(preferences);

    }

    #endregion

  }
}

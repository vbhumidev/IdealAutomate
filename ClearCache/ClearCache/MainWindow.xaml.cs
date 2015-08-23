﻿using System.Windows;
using IdealAutomate.Core;
using System;
using System.Collections;

namespace ClearCache {
  /// <summary>
  /// Clear Cache
  /// You have to clear it from 4 places:
  ///It depends on what you have setup in GwOptionsSetup for the company that you are logging in under, but for demo for me it is located at: C:\GTreasury\WebCache\Clients\DEMO
  ///1.	Then, I just delete everything in that folder to clear the cache for the website.
  ///2.	You may also need to delete your clientsession record from the clientsession table.
  ///DELETE FROM [CLB_10_17_5].[dbo].[CLIENTSESSION]
  ///      WHERE OPERINC = 2300 -- this is my operinc - you would use yours
  ///GO
  ///3.	You may also need to clear your cookies. Mine are located at:
  ///C:\Users\wharvey\AppData\Roaming\Microsoft\Windows\Cookies
  ///4.	Delete temporary files, etc. from internet explorer/options
  /// </summary>
  public partial class MainWindow : Window {

    public MainWindow() {

      string[] args = Environment.GetCommandLineArgs();
      ResourceDictionary dictionary = new ResourceDictionary();
      for (int index = 1; index < args.Length - 1; index += 2) {
        dictionary.Add(args[index], args[index + 1]);
      }
      //  dictionary.Add("myParm", "Hello World");
      if (dictionary.Contains("myParm")) {
        MessageBox.Show(dictionary["myParm"].ToString());
      }

      var window = new Window() //make sure the window is invisible
{
  Width = 0,
  Height = 0,
  Left = -2000,
  WindowStyle = WindowStyle.None,
  ShowInTaskbar = false,
  ShowActivated = false,
};
      window.Show();
      InitializeComponent();
      this.Hide();
      IdealAutomate.Core.Methods myActions = new Methods();

      myActions.DebugMode = true;
      int intOperInc = 2300;
      // Alternatives are: SqlServer2008, SqlServer2014
      string strServer = myActions.GetValueByKey("SqlServer2008", "IdealAutomateDB");
      // Alternatives are: ChristysDB, QA6DB
      string strDatabaseName = myActions.GetValueByKey("ChristysDB", "IdealAutomateDB");
      ImageEntity myImage = new ImageEntity();

      string strWindowTitle = myActions.PutWindowTitleInEntity();
      if (strWindowTitle.StartsWith("ClearCache")) {
        myActions.TypeText("%(\" \"n)", 1000); // minimize visual studio
      }
      myActions.Sleep(1000);
      // Open Windows Explorer
      myActions.Run(@"C:\Windows\Explorer.EXE", @"C:\GTreasury\WebCache\Clients\DEMO");
      myActions.TypeText("^(a)", 1000);
      myActions.TypeText("{DELETE}", 1000);
      myActions.TypeText("{ENTER}", 1000);  // confirm delete
      myActions.TypeText("+({F4})", 1000);
      myActions.TypeText("^(a)", 1000);
      myActions.TypeText("{DELETE}", 1000);
      myActions.PutEntityInClipboard(@"C:\Users\wharvey\AppData\Roaming\Microsoft\Windows\Cookies");
      myActions.TypeText("^(v)", 1000);
      myActions.TypeText("{ENTER}", 1000);
      myActions.TypeText("^(a)", 1000);
      myActions.TypeText("{DELETE}", 1000);
      myActions.TypeText("{ENTER}", 1000);  // confirm delete
      myActions.TypeText("%(f)", 1000);  // close windows explorer
      myActions.TypeText("c", 1000);
      myActions.Run(@"c:\Program Files\Internet Explorer\iexplore.exe", "");
      myActions.TypeText("%(t)", 1000);  // tools
      myActions.TypeText("o", 1000);  // options
      myActions.TypeText("%(d)", 1000);  // delete
      myActions.TypeText("%(d)", 1000);  // delete
      myActions.TypeText("{ESC}", 1000);  // escape
      myActions.TypeText("%(f)", 1000);  // close internet explorer
      myActions.TypeText("x", 1000);  // close internet explorer
      string myBigSqlString = "DELETE FROM [dbo].[CLIENTSESSION] WHERE OPERINC = " + intOperInc.ToString();

      bool boolWindowFound = myActions.ActivateWindowByTitle("Microsoft SQL Server Management Studio");
      // If Sql Server Profiler not running, we have a problem
      if (boolWindowFound == false) {
        myActions.Run(@"C:\Program Files (x86)\Microsoft SQL Server\100\Tools\Binn\VSShell\Common7\IDE\SSMS.exe", "-S " + strServer + " -D " + strDatabaseName);
        myActions.Sleep(15000);
      }
      for (int i = 0; i < 10; i++) {
        if (myActions.PutWindowTitleInEntity() == "Microsoft SQL Server Management Studio") {
          // close notepad alt f x
          break;
        }
        myActions.Sleep(500);
      }
      myActions.Sleep(2000);
      myActions.TypeText("%(\" \")x", 1000); // maximize SSMS
      myActions.TypeText("%(f)e", 1000); // file connection explorer
      myActions.TypeText("{DEL}", 500); // file connection explorer
      myActions.TypeText(strServer, 500); // file connection explorer
      myActions.TypeText("{ENTER}", 1000); // select the server
      myActions.TypeText("{DOWN}", 500); // select databases
      // {NUMPADMULT}
      myActions.TypeText("{NUMPADADD}", 1000); // expand databases
      myActions.TypeText("%({F8})", 1000); // open server in object explorer
      myActions.TypeText(strDatabaseName, 1000); // select the database
      myActions.TypeText("{ENTER}", 1000); // open new query window
      myActions.TypeText("^(n)", 1000); // open new query window
      myActions.PutEntityInClipboard(myBigSqlString);
      myActions.TypeText("^(v)", 1000); // put query in window
      //  myActions.TypeText("{F5}", 1000); // run the query
      myActions.TypeText("^(k)", 1000); // put query in window
      myActions.TypeText("^(f)", 1000); // put query in window


      goto myExit;
      myActions.Run(@"C:\SVNIA\trunk\10175Login\10175Login\bin\Debug\10175Login.exe", "");

      myImage.ImageFile = "Images\\Home.PNG";
      myImage.Sleep = 500;
      myImage.Attempts = 10;
      myImage.RelativeX = 10;
      int[,] myArray2 = myActions.PutAll(myImage);
      if (myArray2.Length == 0) {
        myActions.MessageBoxShow("I could not find Home hyperlink (FindUntranslatedAll)");
      }

      myActions.Sleep(2000);
      myActions.TypeText("javascript:GoUrl{(}'http://localhost:80/webcash/ASPX/gl/glJournalList.aspx'{)};", 200);
      myActions.TypeText("{ENTER}", 500);
      myActions.Sleep(5000);
      // myActions.MessageBoxShow("Script completed");
      myActions.Run(@"C:\SVNIA\trunk\FindUntranslated\FindUntranslated\bin\Debug\FindUntranslated.exe", "");

      // todo look for picture script completed and click on it before opening next screen
      myImage = new ImageEntity();
      myImage.ImageFile = "Images\\Script_Completed_OK_Button.PNG";
      myImage.Sleep = 5000;
      myImage.Attempts = 500;
      myImage.RelativeX = 10;
      int[,] myArray3 = myActions.PutAll(myImage);
      if (myArray3.Length == 0) {
        myActions.MessageBoxShow("I could not find Script_Completed_OK_Button.PNG");
      }
    myExit:
      Application.Current.Shutdown();

    }
  }
}

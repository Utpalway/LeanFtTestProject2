using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HP.LFT.SDK;
using HP.LFT.Verifications;
using HP.LFT.SDK.Web;

namespace LeanFtTestProject1
{
    [TestClass]
    public class LeanFtTest : UnitTestClassBase<LeanFtTest>
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            GlobalSetup(context);
        }

        [TestInitialize]
        public void TestInitialize()
        {

        }

        [TestMethod]
        public void TestMethod1()
        {
        // launching browser
            HP.LFT.SDK.Web.IBrowser OBrowser = BrowserFactory.Launch(BrowserType.InternetExplorer);
           
            OBrowser.Navigate("Google.com");  //nevigate to url
            OBrowser.Sync();
            // OBrowser.CloseAllTabs(); close all opened tabs


            OBrowser.Describe<ILink>(new LinkDescription
            {
                TagName = @"A",
                InnerText = @"Gmail"
            });
          


            
        }


        [TestCleanup]
        public void TestCleanup()
        {
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            GlobalTearDown();
        }
    }
}

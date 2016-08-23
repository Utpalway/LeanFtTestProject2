using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HP.LFT.SDK;
using HP.LFT.Verifications;
using HP.LFT.SDK.Web;
using HP.LFT.Report;
using System.Collections.Generic;

namespace LeanFtTestProject1
{
    [TestClass]
    public class LeanFtTest : UnitTestClassBase<LeanFtTest>
    {
        private Status that;
        private string link;
        private readonly string exists;
        private object value;

        public object TAB { get; private set; }

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
           try
            {

            // launching browser
            HP.LFT.SDK.Web.IBrowser browser = BrowserFactory.Launch(BrowserType.InternetExplorer);

            browser.Navigate("Google.com");  //nevigate to url
            browser.Sync();
            Reporter.ReportEvent(" browser Launch", "Browser launch successfully ", HP.LFT.Report.Status.Passed);

            // clicking on gmail link
            var GmailLink = browser.Describe<ILink>(new LinkDescription
            {
                TagName = @"A",
                InnerText = @"Gmail",
                Index = 0
            });

            //var resourceLink = browser.Describe<ILink>(new XPathDescription(@"//DIV[@id=""gbw""]/DIV[1]/DIV[1]/DIV[1]/DIV[1]/A[1]"));

            Boolean doesexits = GmailLink.Exists(5);
            GmailLink.Click();
            Reporter.ReportEvent("gmail link", "gmail link available ", HP.LFT.Report.Status.Passed);

            //entering username
            var resourceWebEdit = browser.Describe<IPage>(new PageDescription()).Describe<IEditField>(new EditFieldDescription
            {
                Type = @"email",
                TagName = @"INPUT",
                Name = @"Email",
                Index = 0
            });
             var id = "ideliver007@gmail.com";
         resourceWebEdit.SetValue(id);           //Type.ToString("sourabh@ideliver-inc.com");
            Reporter.ReportEvent("sign Sign in","sign in into gmail id successfull", HP.LFT.Report.Status.Passed);

            //click on next button
            var button = browser.Describe<IButton>(new ButtonDescription{ButtonType = @"submit",TagName = @"INPUT",Name = @"Next"});
            button.Click();

            //entering password
            var password = browser.Describe<IEditField>(new XPathDescription(@"//INPUT[@id=""Passwd""]"));
                password.SetValue("iDeliver1");

            //click on signin button
            var Signin = browser.Describe<IButton>(new XPathDescription("//INPUT[@id='signIn']"));
                Assert.AreEqual("Sign in", Signin.Name);
               
            Signin.Click();
            Reporter.ReportEvent("sign Sign in", "sign in into gmail id successfull", HP.LFT.Report.Status.Passed);
                browser.Sync();

                //click on signout link
                var SignOutLink = browser.Describe<ILink>(new XPathDescription(@"//DIV[@id=""gb""]/DIV[1]/DIV[1]/DIV[2]/DIV[4]/DIV[1]/A[1]"));
                SignOutLink.Highlight();
                SignOutLink.Click();
                browser.Sync();
                //click on signout button
                var SignOutButton = browser.Describe<IPage>(new PageDescription()).Describe<ILink>(new XPathDescription(@"//DIV[@id=""gb""]/DIV[1]/DIV[1]/DIV[2]/DIV[4]/DIV[2]/DIV[3]/DIV[2]/A[1]"));
                SignOutButton.Highlight();
                SignOutButton.Click();

                Reporter.ReportEvent("sign out", "sign out from gmail id successfull", HP.LFT.Report.Status.Passed);
                //closing current browser
                browser.Close();


            }
            catch (Exception ex)
            {
                throw ex;
            }

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

        private class set
        {
        }
    }
}

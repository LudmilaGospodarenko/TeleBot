using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TeleBot.Pages;
using System.Threading;



namespace TeleBot
{
    [TestFixture]
    public class Initial
    {
        IWebDriver driver;

        [TestCase]
        public void Login()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("user-data-dir=C:/Users/Crazy/AppData/Local/Google/Chrome/User Data/Default");
            driver = new ChromeDriver(options);

            StartPage startPage = new StartPage(driver);
            startPage.GoToUrl();
            //Thread.Sleep(10);
            startPage.OpenChat();
            //startPage.SendMesage("/top");
            //startPage.FindChat();

           // driver.Quit();
        }
    }
}

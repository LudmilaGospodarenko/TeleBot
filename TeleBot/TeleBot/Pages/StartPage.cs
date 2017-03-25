using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Interactions;
using System.Drawing;

namespace TeleBot.Pages
{
    class StartPage
    {
        private IWebDriver driver;
        const string url = "https://web.telegram.org/#/im";
        const string channel = "@ChatWarsBot";
         
        [FindsBy(How = How.XPath, Using = "//*[@class='im_dialogs_search']/input")]
        private IWebElement search;

        [FindsBy(How = How.XPath, Using = "//*[@class='im_dialogs_search_clear tg_search_clear']")]
        private IWebElement clearSearch;

        [FindsBy(How = How.XPath, Using = "//*[@id='ng-app']/body/div[1]/div[2]/div/div[1]/div[2]/div/div[1]/div[2]")]
        private IWebElement foundChannel;

        [FindsBy(How = How.XPath, Using = "//*[@id='ng-app']/body/div[1]/div[2]/div/div[1]/div[2]/div/div[1]/div[3]")]
        private IWebElement nextChannel;

        [FindsBy(How = How.ClassName, Using = "composer_rich_textarea")]
        private IWebElement messageField;


        [FindsBy(How = How.XPath, Using = "//*[text()=’Chat Wars’]")]
        private IWebElement messages;

        //*[@id="ng-app"]/body/div[1]/div[2]/div/div[2]/div[3]/div/div[2]/div[2]/div/div/form/div[2]/div[4]

        public StartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void GoToUrl()
        {
            driver.Navigate().GoToUrl(url);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2000));
            IWebElement title = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='tg_head_btn dropdown-toggle']/i")));
            var par = title.Location;
            Console.WriteLine("title = {0}", par);
        }

        public void OpenChat()
        {
            search.SendKeys(channel);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2000));
            IWebElement title = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='tg_head_btn dropdown-toggle']/i")));
            new Actions(driver).MoveToElement(title).MoveByOffset(10, 140).Click().Perform();
            Point clickedOn = title.Location;
            clickedOn.Offset(10, 210);
            Console.WriteLine("Clicked on = {0}", clickedOn);
            new Actions(driver).MoveToElement(title).MoveByOffset(0, 0).Click().Perform();


            new Actions(driver).MoveToElement(title).MoveByOffset(0, 0).Click().Perform();

            //var selectedArea = foundChannel.Location;
            //Console.WriteLine("Location of found item = {0}", selectedArea);
            // foundChannel.Click();
        }

        public void SendMesage(string message)
        {
            messageField.SendKeys(message);
        }

        //public void FindChat()
        //{
        //    foreach (IWebElement chat in chatList)
        //        if (chat.Text == channel)
        //            chat.Click();
        //        else Console.WriteLine("Element {0} wasn't found", channel);
        //            //Thread.Sleep(10);
        //channelFind.Click();
        //search.SendKeys(channel);
        //clearSearch.Click();
        //search.SendKeys(channel);

        //}
    }
}
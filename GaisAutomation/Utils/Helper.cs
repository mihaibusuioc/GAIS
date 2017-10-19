using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaisAutomation.Utils
{
    public class Helper
    {
        public static string GetRandomString()
        {
            Guid randomGuid = Guid.NewGuid();
            string randomString = randomGuid.ToString();
            randomString = randomString.Replace("-", "");
            randomString = randomString.Substring(0, 12);
            return randomString;
        }

        public static void ScrollToBottomOfPage()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.Instance;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        }

        public static void WaitAndClick(By byLocator)
        {
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(byLocator));
            IWebElement element = Driver.Instance.FindElement(byLocator);
            element.Click();
        }

        public static void WaitAndFillIn(By byLocator, string value)
        {
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(byLocator));
            IWebElement inputBox = Driver.Instance.FindElement(byLocator);
            inputBox.Clear();
            inputBox.SendKeys(value);
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GaisAutomation
{
    public class WelcomePage
    {
        public static string WelcomeText { get; set; }
        public static string GetWelcomeText()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            By byLocator = By.Id("mainHeadline");
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementIsVisible(byLocator));
            IWebElement mainHeader = Driver.Instance.FindElement(byLocator);
            WelcomeText = mainHeader.Text.Replace(Environment.NewLine, "");
            return WelcomeText;
        }
    }
}

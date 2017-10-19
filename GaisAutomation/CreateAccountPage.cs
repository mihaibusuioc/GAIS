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
    public class CreateAccountPage : Utils.Helper
    {
        public static string NewAccountUserName { get; set; }
        public static string NewAccountPassword { get; set; }
        public static string NewAccountFullName { get; set; }

        public static void GoTo()
        {
            // Wait until "Create New Account" link is clickable and click on it
            Thread.Sleep(TimeSpan.FromSeconds(2));
            By byLocator = By.Id("newUserLink");
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(byLocator));
            IWebElement createNewAccountLink = Driver.Instance.FindElement(byLocator);
            createNewAccountLink.Click();
        }

        public static void CreateNewAccount()
        {
            string randomString = Utils.Helper.GetRandomString();
            NewAccountUserName = string.Format("ahmet{0}@gmail.com", randomString);
            NewAccountPassword = string.Format("ahmet{0}", randomString);
            NewAccountFullName = string.Format("Ahmet{0} Mulalic{0}", randomString);

            // Wait until "Username" field is clickable and fill it in
            WaitAndFillIn(By.Id("username"), NewAccountUserName);

            // Wait until "Password" field is clickable and fill it in
            WaitAndFillIn(By.Id("password"), NewAccountPassword);

            // Wait until "Name" field is clickable and fill it in
            WaitAndFillIn(By.Id("name"), NewAccountFullName);

            // Scroll down to the bottom of the page
            ScrollToBottomOfPage();

            // Wait until "Terms" check-box is clickable and check it
            WaitAndClick(By.XPath("//input[@id='termsCheckbox']/preceding-sibling::i"));

            // Wait until "Create Progile" button is clickable and click on it
            WaitAndClick(By.XPath("//span[contains(., 'Opret profil')]/ancestor::div/ancestor::button"));

            // Get text from Welcome page
            WelcomePage.GetWelcomeText();
        }
    }
}

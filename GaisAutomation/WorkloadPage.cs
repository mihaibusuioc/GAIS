using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GaisAutomation
{
    public class WorkloadPage : Utils.Helper
    {
        public static string SubtitleText { get; set; }

        public static void GoTo()
        {
            WaitAndClick(By.Id("choiceMyGAIS"));
            Thread.Sleep(TimeSpan.FromSeconds(2));

            // Get subtitle text
            SubtitleText = GetWorkloadSubtitleTextAboveButton();
        }

        public static string GetWorkloadSubtitleTextAboveButton()
        {
            By byLocator = By.XPath("//div[starts-with(., 'Velkommen. I det følgende')]");
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(byLocator));
            return Driver.Instance.FindElement(byLocator).Text;
        }

        public static string GetSubtitleTextAboveButton(string value)
        {
            By byLocator = By.XPath(string.Format("//span[contains(@class, 'mr1') and contains(., '{0}')]/ancestor::div/ancestor::button/preceding-sibling::p", value));
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(byLocator));
            return Driver.Instance.FindElement(byLocator).Text.Replace(Environment.NewLine, "");
        }

        private static void ClickOnButton(string value)
        {
            WaitAndClick(By.XPath(string.Format("//*[contains(@class, 'mr1') and contains(., '{0}')]/ancestor::div/ancestor::button", value)));
        }

        public class FirstSlide
        {
            public static string SubtitleText { get; set; }
            public static void GoTo()
            {
                // Click on "Continue" button
                ClickOnButton("Fortsæt");

                // Get subtitle text
                SubtitleText = GetSubtitleTextAboveButton("Næste");
            }
        }

        public class SecondSlide
        {
            public static string SubtitleText { get; set; }

            public static void GoTo()
            {
                // Click on "Next" button
                ClickOnButton("Næste");

                // Get subtitle text
                SubtitleText = GetSubtitleTextAboveButton("Næste");
            }
        }

        public class ThirdSlide
        {
            public static string SubtitleText { get; set; }

            public static void GoTo()
            {
                // Click on "Next" button
                ClickOnButton("Næste");

                // Get subtitle text
                SubtitleText = GetSubtitleTextAboveButton("Næste");
            }
        }

        public class FourthSlide
        {
            public static string SubtitleText { get; set; }

            public static void GoTo()
            {
                // Click on "Next" button
                ClickOnButton("Næste");

                // Get subtitle text
                SubtitleText = GetSubtitleTextAboveButton("Næste");
            }
        }

        public class FifthSlide
        {
            public static void GoTo()
            {
                // Click on "Next" button
                ClickOnButton("Næste");
            }

            public static void FillInForm()
            {
                // Fill in "Industry" drop-down box
                FillInDropdownBox("Branche", "Bygge og anlæg");

                // Wait until "Sex" drop-down box is clickable on fifth slide and fill it in
                FillInDropdownBox("Køn", "Mand");

                // Fill in "Age" drop-down box
                FillInDropdownBox("Alder", "30-39 år");
            }

            public static void FillInDropdownBox(string label, string value)
            {
                By byLocator = By.XPath(string.Format("//label[contains(., '{0}')]/following-sibling::div/div[contains(@class, 'dropdown')]", label));
                WaitAndClick(byLocator);

                byLocator = new ByChained(byLocator, By.XPath(string.Format("ul[contains(@class, 'dropdown-menu')]/li[contains(., '{0}')]", value)));
                WaitAndClick(byLocator);
            }
        }

        public class SixthSlide
        {
            public static string SubtitleText { get; set; }
            public static void GoTo()
            {
                // Click on "Next" button
                ClickOnButton("Næste");

                // Get subtitle text
                SubtitleText = GetSubtitleTextAboveButton("Start testen");
            }
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GaisAutomation
{
    public class SurveyPage : Utils.Helper
    {
        public static void GoTo()
        {
            WaitAndClick(By.XPath("//span[contains(@class, 'mr1') and contains(., 'Start testen')]/ancestor::div/ancestor::button"));
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }

        public static void FillInAnswers(List<string> column)
        {
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//div[contains(@class, 'sg-page-title') and contains(., '{0}')]", column[0]))));

            for (int i = 1; i <= column.Count - 1; i++)
            {
                By byLocator = By.XPath(string.Format("//div[contains(@class, 'sg-question-options')]//table/tbody/tr[{0}]/td/following-sibling::td[{1}]/label", i, column[i]));

                if (column[i] == "0")
                {
                    byLocator = By.XPath(string.Format("//div[contains(@class, 'sg-question-options')]//table/tbody/tr[{0}]/td[1]/label", i));
                }

                WaitAndClick(byLocator);
            }
        }

        public static void FillInSurvey()
        {
            List<string> columnA = new List<string>();
            List<string> columnB = new List<string>();
            List<string> columnC = new List<string>();
            List<string> columnD = new List<string>();
            List<string> columnE = new List<string>();
            List<string> columnF = new List<string>();
            List<string> columnG = new List<string>();
            List<string> columnH = new List<string>();
            List<string> columnI = new List<string>();

            string filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            filePath = Directory.GetParent(Directory.GetParent(filePath).FullName).FullName;
            filePath += @"\GaisAutomation\Data\Answers.txt";

            using (var reader = new StreamReader(filePath, Encoding.GetEncoding("UTF-8"), true))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    
                    columnA.Add(values[0]);
                    columnA.RemoveAll(str => string.IsNullOrEmpty(str));

                    columnB.Add(values[1]);
                    columnB.RemoveAll(str => string.IsNullOrEmpty(str));

                    columnC.Add(values[2]);
                    columnC.RemoveAll(str => string.IsNullOrEmpty(str));

                    columnD.Add(values[3]);
                    columnD.RemoveAll(str => string.IsNullOrEmpty(str));

                    columnE.Add(values[4]);
                    columnE.RemoveAll(str => string.IsNullOrEmpty(str));

                    columnF.Add(values[5]);
                    columnF.RemoveAll(str => string.IsNullOrEmpty(str));

                    columnG.Add(values[6]);
                    columnG.RemoveAll(str => string.IsNullOrEmpty(str));

                    columnH.Add(values[7]);
                    columnH.RemoveAll(str => string.IsNullOrEmpty(str));

                    columnI.Add(values[8]);
                    columnI.RemoveAll(str => string.IsNullOrEmpty(str));
                }
            }

            FillInAnswers(columnA);
            WaitAndClick(By.Id("sg_NextButton"));
            Thread.Sleep(TimeSpan.FromSeconds(1));

            FillInAnswers(columnB);
            WaitAndClick(By.Id("sg_NextButton"));
            Thread.Sleep(TimeSpan.FromSeconds(1));

            FillInAnswers(columnC);
            WaitAndClick(By.Id("sg_NextButton"));
            Thread.Sleep(TimeSpan.FromSeconds(1));

            FillInAnswers(columnD);
            WaitAndClick(By.Id("sg_NextButton"));
            Thread.Sleep(TimeSpan.FromSeconds(1));

            FillInAnswers(columnE);
            WaitAndClick(By.Id("sg_NextButton"));
            Thread.Sleep(TimeSpan.FromSeconds(1));

            FillInAnswers(columnF);
            WaitAndClick(By.Id("sg_NextButton"));
            Thread.Sleep(TimeSpan.FromSeconds(1));

            FillInAnswers(columnG);
            WaitAndClick(By.Id("sg_NextButton"));
            Thread.Sleep(TimeSpan.FromSeconds(1));

            FillInAnswers(columnH);
            WaitAndClick(By.Id("sg_NextButton"));
            Thread.Sleep(TimeSpan.FromSeconds(1));

            WaitAndClick(By.XPath(string.Format("//div[contains(@class, 'sg-question-options')]//ul/li/label[starts-with(., '{0}')]", columnI[1])));
            WaitAndClick(By.Id("sg_NextButton"));
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }
    }
}

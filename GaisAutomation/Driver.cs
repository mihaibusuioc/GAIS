using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaisAutomation
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }

        public static void Intialize()
        {
            Instance = new ChromeDriver();

            //DesiredCapabilities capability = DesiredCapabilities.Chrome();
            //capability.SetCapability("browserstack.user", "ahmetmulalic1");
            //capability.SetCapability("browserstack.key", "8gngLczaH8sF3V3sW3qp");
            //Instance = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability);

            Instance.Manage().Window.Maximize();
        }

        public static void Close()
        {
            Instance.Quit();
        }
    }
}

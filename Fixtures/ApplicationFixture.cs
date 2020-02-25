using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Calculator2.Pages;

namespace Calculator2.Fixtures
{
    public class ApplicationFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }
        IWebElement Window => Driver.FindElement(By.ClassName("CalcFrame"));

        public ApplicationFixture()
        {
            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"C:/windows/system32/calc.exe");
            Driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);
        }

        public EventFiringNavigation Navigate()
        {
            return new EventFiringNavigation(Window);
        }

        public void Dispose()
        {
            if (Driver == null) return;
            Driver.Quit();
        }
    }

    public class EventFiringNavigation
    {
        private IWebElement Window { get; set; }

        public EventFiringNavigation(IWebElement window)
        {
            Window = window;
        }

        public void GoToUrl(string url)
        {
            string[] items = url.Split('/');
            IWebElement currentItem = Window.FindElement(By.Id("MenuBar"));;
            foreach (var item in items)
            {
                currentItem = currentItem.FindElement(By.Name(item));
                currentItem.Click();
            }
        }
    }
}

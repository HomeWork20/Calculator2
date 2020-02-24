using OpenQA.Selenium;

namespace Calculator2.Pages
{
    abstract class BasePage
    {
        protected IWebDriver Driver { get; private set; }        
        
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
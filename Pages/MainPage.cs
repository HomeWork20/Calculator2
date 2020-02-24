using OpenQA.Selenium;
using System.Reflection;
using System.Linq;

namespace Calculator2.Pages
{
    class MainPage : BasePage
    {   
        public const string URL = "Вид/Обычный";
        const string BUTTON_PREFIX = "Button";

        public IWebElement Button0 => Driver.FindElement(By.Id("130"));
        public IWebElement Button1 => Driver.FindElement(By.Id("131"));
        public IWebElement Button2 => Driver.FindElement(By.Id("132")); 
        public IWebElement Button3 => Driver.FindElement(By.Id("133"));
        public IWebElement Button4 => Driver.FindElement(By.Id("134"));
        public IWebElement Button5 => Driver.FindElement(By.Id("135")); 
        public IWebElement Button6 => Driver.FindElement(By.Id("136"));
        public IWebElement Button7 => Driver.FindElement(By.Id("137"));
        public IWebElement Button8 => Driver.FindElement(By.Id("138")); 
        public IWebElement Button9 => Driver.FindElement(By.Id("139"));

        public IWebElement ButtonEqually => Driver.FindElement(By.Id("121"));
        public IWebElement ButtonSqrt => Driver.FindElement(By.Id("110"));
        public IWebElement ButtonMultiply => Driver.FindElement(By.Id("92"));
        public IWebElement ButtonS => Driver.FindElement(By.Id("84"));
        public IWebElement TextResult => Driver.FindElement(By.Id("150"));

        public MainPage(IWebDriver driver) : base(driver) 
        {}

        public double GetDoubleResult()
        {
            return double.Parse(TextResult.GetAttribute("Name"));
        }

        public void TypeNumber(double number)
        {
            PropertyInfo[] fields = this.GetType().GetProperties();
            foreach (var chOut in number.ToString())
            {
                var chIn = chOut;
                if(chIn == ',') chIn = 'S';
                ((IWebElement)fields.Where(f => f.Name == BUTTON_PREFIX + chIn).First().GetValue(this)).Click();
            }
        }
    }
}
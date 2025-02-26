using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace TrumpMetamation_Task_Alarm_khushali_k
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            IWebDriver driver;
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://onlinealarmkur.com/en/#05:00");
            Console.WriteLine("Opening the Clock App");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(90);
            driver.Manage().Window.Maximize();
            IWebElement webElement = driver.FindElement(By.XPath("//div/h1"));
            String navigatingToAlarmClock = webElement.Text;
            Assert.That(navigatingToAlarmClock.Contains("Online Alarm Clock"));
            Console.WriteLine("Naigating to the Alarm clock");
            IWebElement element = driver.FindElement(By.XPath("//select[@id='hours']"));
            element.Click();
            SelectElement select = new SelectElement(element);
            select.SelectByValue("09");
            string selectedAlarmTime = element.Text;
            Assert.That(selectedAlarmTime.Contains( "9 AM"));
            Console.WriteLine("Timing is selected as 9am");
            IWebElement alarmSound = driver.FindElement(By.XPath("//select[@id='sound']"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", alarmSound);
            alarmSound.Click();
            SelectElement selectAlarmSound = new SelectElement(alarmSound);
            selectAlarmSound.SelectByValue("rain");
            string alarmsound = alarmSound.Text;
            Assert.That(alarmsound.Contains("Rain"));
            Console.WriteLine("AlarmSound is selected");
            IWebElement setAlarmName = driver.FindElement(By.XPath("//input[@id='alarm-title']"));
           // IJavaScriptExecutor js1 = (IJavaScriptExecutor)driver;
            //js1.ExecuteScript("arguments[0].scrollIntoView(true);", setAlarmName);
            setAlarmName.Clear();
            setAlarmName.SendKeys("Triumpf Metamation - Login Time");
            string getAlarmName = setAlarmName.GetAttribute("value");
            Assert.That(getAlarmName.Contains("Triumpf Metamation - Login Time"));
            Console.WriteLine("Alarmname is set");
            IWebElement setAlarmButton = driver.FindElement(By.XPath("//button[@id='start']"));
            setAlarmButton.Click();
            IWebElement checkAlarmset = driver.FindElement(By.XPath("//h2[contains(text(),'Alarm Clock Data')]"));
            bool check = checkAlarmset.Displayed;
            Assert.That(check.Equals(true),"Alarm is set");
            IWebElement clearButton = driver.FindElement(By.XPath("//button[@id='clear-history']"));
            clearButton.Click();
            IWebElement checkDeleted= driver.FindElement(By.XPath("//h2[contains(text(),'Alarm Clock Data')]"));
            bool deleted = checkDeleted.Displayed;
            Assert.That(deleted.Equals(false), "Alarm is deleted");
            Console.WriteLine("Alarm is deleted");

            driver.Quit();




        }
    }
}
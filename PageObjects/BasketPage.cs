using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TaskCShark.PageObjects
{
    class BasketPage
    {
        private readonly string url = @"https://www.johnlewis.com/basket";
        private readonly IWebDriver driver;
        public BasketPage()
        {
            this.driver = new ChromeDriver();
            PageFactory.InitElements(driver, this);
        }
        //BTN
        [FindsBy(How = How.XPath, Using = "//button[@class='c - button - yMKB7 c - button--primary - 39fbj c - button--inverted - UZv88 c - button--primary - 3tLoH']")]
        public IWebElement AllowCookies { get; set; }
        [FindsBy(How = How.XPath, Using = "//li[@class='navigation - item - item--044d4 navigation - item - item--level0--438a3']/a[text()='Men']")]
        public IWebElement MenButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//button [@data-size='L']")]
        public IWebElement Loc_btnSizeL { get; set; }
        [FindsBy(How = How.XPath, Using = "//li[@id='ciaup8169284672']//button[@class='remove - basket - item - form - button']")]
        public IWebElement Loc_btnRemoveSizeMPink { get; set; }
        [FindsBy(How = How.XPath, Using = "//li[@id='ciaup8169284669']//button[@class='remove - basket - item - form - button']")]
        public IWebElement Loc_btnRemoveSizeLPink { get; set; }
        [FindsBy(How = How.XPath, Using = "//li[@id='ciaup8169284225']//button[@class='remove - basket - item - form - button']")]
        public IWebElement Loc_btnRemoveSizeLSky { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@class='jl-accordion-content']//a[text()='Cookies']")]
        public IWebElement Loc_btnCookies { get; set; }
        //LABEL
        [FindsBy(How = How.XPath, Using = "//div[@class='basket-empty']")]
        public IWebElement Loc_lbBasketIsEmpty { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@class='view - basket - delivery']")]
        public IWebElement Loc_lbBasketSummary { get; set; }


        //Navigate
        public void GoToBasketPage()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }
    }
}

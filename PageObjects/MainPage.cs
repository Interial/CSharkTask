using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace TaskCShark.PageObjects
{
    
    public class MainPage
    {
        private readonly IWebDriver driver;
        private readonly string url = @"https://www.johnlewis.com/";
        public MainPage()
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
        [FindsBy(How = How.XPath, Using = "//button [@data-size='XL']")]
        public IWebElement Loc_btnSizeXL { get; set; }
        [FindsBy(How = How.XPath, Using = "//button [@data-size='M']")]
        public IWebElement Loc_btnSizeM { get; set; }
        [FindsBy(How = How.Id, Using = "minibasket-icon-anchor")]
        public IWebElement Loc_btnBasket { get; set; }
        [FindsBy(How = How.XPath, Using = "//button [@data-cy='add - to - basket - button']")]
        public IWebElement Loc_btnAddToYourBasket { get; set; }
        //LABEL
        [FindsBy(How = How.Id, Using = "//div[@class='container - content--f0162 container - flex - row--5bf1f container - items - start--a424a']//a[text()='Shop Shirts']")]
        public IWebElement ShopShirtLabel { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@id='mobile - search']//button[@type='submit']")]
        public IWebElement MirrorGlass { get; set; }
        [FindsBy(How = How.XPath, Using = "//p[@class='error--3ZwlT']")]
        public IWebElement Loc_ErrlbSelectASize { get; set; }
            [FindsBy(How = How.Id, Using = "confirmation-anchor-desktop")]
        public IWebElement Loc_lbBarbourShortSleeveTartanShirtName { get; set; }
        //INPUT
        [FindsBy(How = How.Id, Using = "mobileSearch")]
        public IWebElement SearchBox { get; set; }
        //IMAGE
        [FindsBy(How = How.Id, Using = "//section [@data-product-id='4885406']//div[@class='product - card_c - product - card__image - container__d5DEN']")]
        public IWebElement Loc_imgBarbourShortSleeveTartanShirtPink { get; set; }
        //Navigate
        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }
        //Stworzyłem funkcję do obsługi Searchera , w razie gdyby miała być potrzebna. Na przykład w razie potrzeby wybrania konkretnych produktów.
        public void Search(string textToType)
        {
            this.SearchBox.Clear();
            this.SearchBox.SendKeys(textToType);
            this.MirrorGlass.Click();
        }
    }
}

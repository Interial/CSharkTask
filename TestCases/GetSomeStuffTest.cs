using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using TaskCShark.PageObjects;


namespace TaskCShark.TestCases
{

    public class GetSomeStuffTest : MainPage
    {
        static void Main(string[] args)
        {
            
        }
        IWebDriver driver;
       
        MainPage MainPage = new MainPage();
        BasketPage BasketPage = new BasketPage();
        [SetUp]
        public void Start_Browser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            
        }
        
        [Test]
        [Order(1)]
        [Description("Accepting Cookies")]
        public void MenageCookies()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            MainPage.Navigate();
            var cookiesVisible = MainPage.AllowCookies.Displayed;
            //Ten if służy temu by w razie gdyby na początku testu Cookie'sy nie były wyczyszczony to wywoła funkcję czyszczącą
            if (cookiesVisible == false)
            { driver.Manage().Cookies.DeleteAllCookies(); }
            MainPage.AllowCookies.Click();
        }

        [Test]
        [Order(2)]
        [Description("browses for any product or product of your choice." +
            " Selecting multiple quantities of specific T-Shirt products and moving them to basket")]
        public void BrowsingForProducts()
        {
            
            //Przejście do sekcji "Men" ,a następnie wybranie sekcji "T-Shirt"
            MainPage.MenButton.Click();
            MainPage.ShopShirtLabel.Click();
            MainPage.Loc_imgBarbourShortSleeveTartanShirtPink.Click();
            //Sprawdzenie czy rzeczywiście dana koszula występuje na tej stronie co potwierdza poprawne przejście do odpowiedniego segmentu
            var isBarbourShortSleeveTartanShirtNameVisible = MainPage.Loc_lbBarbourShortSleeveTartanShirtName.Displayed;
            Assert.IsTrue(isBarbourShortSleeveTartanShirtNameVisible, "Caution! You're not on correct site , check if button works corrctly.");
            //Sprawdzenie czy po przyciśnieciu dodania koszuli do koszyka ,wyświetli się errormsg sygnalizujący brak wybranego rozmiaru
            MainPage.Loc_btnAddToYourBasket.Click();
            var isErrorLabelDisplayed = MainPage.Loc_ErrlbSelectASize.Displayed;
            Assert.IsTrue(isErrorLabelDisplayed,"Caution! There's error message missing ,'Select a Size'");
            //Dodanie 3 sztuk konkretnej koszuli w rozmiarze Large
            MainPage.Loc_btnSizeL.Click();
            MainPage.Loc_btnAddToYourBasket.Click();
            MainPage.Loc_btnAddToYourBasket.Click();
            MainPage.Loc_btnAddToYourBasket.Click();
            //Dodanie 2 sztuk konkretnej koszuli w rozmiarze Medium
            MainPage.Loc_btnSizeM.Click();
            MainPage.Loc_btnAddToYourBasket.Click();
            MainPage.Loc_btnAddToYourBasket.Click();
            //Dodanie 2 sztuk konkretnej koszuli w rozmiarze Ekstra Large
            MainPage.Loc_btnSizeXL.Click();
            MainPage.Loc_btnAddToYourBasket.Click();
            MainPage.Loc_btnAddToYourBasket.Click();
            //Przejście do koszyka
            MainPage.Loc_btnBasket.Click();
            BasketPage.GoToBasketPage();

        }
        [Test]
        [Order(3)]
        [Description("delete all products quantities from the basket")]
        public void ClearTheBucketFromEveryItem()
        {
            //Sprawdzenie czy jesteśmy w koszyku
            var basketSummary = BasketPage.Loc_lbBasketSummary.Displayed;
            Assert.IsTrue(basketSummary,"You are not on Basket Page , please check if Basket Button works properly.");
            //Usunięcie poszeczególnych zaznaczonych pozycji
            BasketPage.Loc_btnRemoveSizeLSky.Click();
            BasketPage.Loc_btnRemoveSizeLPink.Click();
            BasketPage.Loc_btnRemoveSizeMPink.Click();
            //Sprawdzenie czy koszyk jest pusty
            var isBasketEmpty = BasketPage.Loc_lbBasketIsEmpty.Displayed;
            Assert.IsTrue(isBasketEmpty, "Basket is not empty yet, perhaps one of Remove buttons didnt work, or was missed during process");
        }
        [Test]
        [Order(4)]
        [Description("")]
        public void ClearCookies()
        {
           
            //Sprawdzenie czy występuje przycisk przenoszący do Cookies
            var cookiesButton = BasketPage.Loc_btnCookies.Displayed;
            Assert.IsTrue(cookiesButton, "Cookies button is not displayed,therefore cookies werent cleared.");
            BasketPage.Loc_btnCookies.Click();
            //Czyszczenie cookies
            driver.Manage().Cookies.DeleteAllCookies();
        }
        //Teardown
        [TearDown]
        public void Close_Browser()
        {
            driver.Quit();
        }

    }
}

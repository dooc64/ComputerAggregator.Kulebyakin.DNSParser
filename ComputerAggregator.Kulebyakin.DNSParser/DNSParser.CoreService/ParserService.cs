using ApiHandlers;
using DNSParser.CoreDataEntities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Diagnostics;
using System.Net;
using System.Runtime.Intrinsics.Arm;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace DNSParser.CoreService
{
    public class ParserService
    {
        private List<string> GetMicroData(List<string> ids, ChromeDriver driver)
        {
            var result = new List<string>();

            foreach (var element in ids)
            {
                driver.Navigate().GoToUrl($"https://www.dns-shop.ru/product/microdata/" + element);

                var product = driver.PageSource.Substring(driver.PageSource.IndexOf('{'));

                product = product.Substring(0, product.LastIndexOf('}') + 1);

                result.Add(product);
            }

            return result;
        }

        private List<string> GetFullData(List<string> ids, ChromeDriver driver)
        {
            var result = new List<string>();

            foreach (var element in ids)
            {
                driver.Navigate().GoToUrl($"https://www.dns-shop.ru/pwa/pwa/get-product/?id=" + element);

                var product = driver.PageSource.Substring(driver.PageSource.IndexOf('{'));

                product = product.Substring(0, product.LastIndexOf('}') + 1);

                result.Add(product);
            }

            return result;
        }

        public List<BaseItem> ParseDnsPageByName(string name)
        {
            var items = new List<BaseItem>();

            var options = new ChromeOptions();

            options.AddArgument("--disable-blink-features=AutomationControlled");

            var driver = new ChromeDriver(options);

            driver.ExecuteCdpCommand("Page.addScriptToEvaluateOnNewDocument", new Dictionary<string, object>
            {
               { "source", "delete window.cdc_adoQpoasnfa76pfcZLmcfl_Array;\r\ndelete window.cdc_adoQpoasnfa76pfcZLmcfl_Promise;\r\ndelete window.cdc_adoQpoasnfa76pfcZLmcfl_Symbol;" }

            });

            driver.Navigate().GoToUrl($"https://www.dns-shop.ru/search/?q=" + name);
            
            while (driver.Title == "")
            { 

            }            

            var productElements = driver.FindElements(By.ClassName("catalog-product"));

            

            foreach ( var element in productElements )
            {
                var price = string.Empty;
                var item = new BaseItem();

                var itemImageElement = element.FindElements(By.TagName("source"));
                var itemNameElement = element.FindElement(By.ClassName("catalog-product__name"));

                var itemPriceElement = element.FindElement(By.ClassName("product-buy__price"));

                foreach (var number in itemPriceElement.Text)
                {
                    if (number != ' ')
                    {
                        decimal d = 0;
                        var parseResult = decimal.TryParse(number.ToString(), out d);

                        if (parseResult)
                            price += number;
                        else
                            break;
                    }
                }

                item.Name = itemNameElement.Text;
                item.Price = decimal.Parse(price);
                item.Uri = "https://dns_shop.ru" + itemNameElement.GetDomAttribute("href");
                item.LastModifedDate = DateTime.Now;
                item.ImageUrl = itemImageElement[0].GetDomAttribute("srcset");
                items.Add(item);
            }


            var elem = driver.FindElement(By.ClassName("pagination-widget__show-more-btn"));

            while (elem != null)
            {
                Thread.Sleep(TimeSpan.FromSeconds(30));
                elem.Click();
                elem = driver.FindElement(By.ClassName("pagination-widget__show-more-btn"));
            }

            return items;
        }

        private BaseItem GetTargetItem(string name)
        {
            var item = new BaseItem();

            var options = new ChromeOptions();

            options.AddArgument("--disable-blink-features=AutomationControlled");

            var driver = new ChromeDriver(options);

            driver.ExecuteCdpCommand("Page.addScriptToEvaluateOnNewDocument", new Dictionary<string, object>
            {
               { "source", "delete window.cdc_adoQpoasnfa76pfcZLmcfl_Array;\r\ndelete window.cdc_adoQpoasnfa76pfcZLmcfl_Promise;\r\ndelete window.cdc_adoQpoasnfa76pfcZLmcfl_Symbol;" }

            });

            driver.Navigate().GoToUrl($"https://www.dns-shop.ru/search/?q=" + name);

            while (driver.Title == "")
            {

            }

            var productElements = driver.FindElements(By.ClassName("product-card-top"));



            foreach (var element in productElements)
            {
                var price = string.Empty;

                var itemImageElement = element.FindElements(By.TagName("source"));
                var itemNameElement = element.FindElement(By.ClassName("product-card-top__title"));

                var itemPriceElement = element.FindElement(By.ClassName("product-buy__price"));

                foreach (var number in itemPriceElement.Text)
                {
                    if (number != ' ')
                    {
                        decimal d = 0;
                        var parseResult = decimal.TryParse(number.ToString(), out d);

                        if (parseResult)
                            price += number;
                        else
                            break;
                    }
                }

                item.Name = itemNameElement.Text;
                item.Price = decimal.Parse(price);
                item.Uri = driver.Url;
                item.LastModifedDate = DateTime.Now;
                item.ImageUrl = itemImageElement[0].GetDomAttribute("srcset");
            }

            return item;
        }

        private BaseItem test1(string name)
        {
            var item = new BaseItem();

            var options = new ChromeOptions();

            options.AddArgument("--disable-blink-features=AutomationControlled");

            var driver = new ChromeDriver(options);

            driver.ExecuteCdpCommand("Page.addScriptToEvaluateOnNewDocument", new Dictionary<string, object>
            {
               { "source", "delete window.cdc_adoQpoasnfa76pfcZLmcfl_Array;\r\ndelete window.cdc_adoQpoasnfa76pfcZLmcfl_Promise;\r\ndelete window.cdc_adoQpoasnfa76pfcZLmcfl_Symbol;" }

            });

            driver.Navigate().GoToUrl($"https://www.dns-shop.ru/product/microdata/87ef303b-7f67-11ed-9070-00155d8ed209");

            var producl = driver.PageSource.Substring(driver.PageSource.IndexOf('{'));

            producl = producl.Substring(0, producl.LastIndexOf('}')+1);

            while (driver.Title == "")
            {

            }

            var productElements = driver.FindElements(By.ClassName("product-card-top"));



            foreach (var element in productElements)
            {
                var price = string.Empty;

                var itemImageElement = element.FindElements(By.TagName("source"));
                var itemNameElement = element.FindElement(By.ClassName("product-card-top__title"));

                var itemPriceElement = element.FindElement(By.ClassName("product-buy__price"));

                foreach (var number in itemPriceElement.Text)
                {
                    if (number != ' ')
                    {
                        decimal d = 0;
                        var parseResult = decimal.TryParse(number.ToString(), out d);

                        if (parseResult)
                            price += number;
                        else
                            break;
                    }
                }

                item.Name = itemNameElement.Text;
                item.Price = decimal.Parse(price);
                item.Uri = driver.Url;
                item.LastModifedDate = DateTime.Now;
                item.ImageUrl = itemImageElement[0].GetDomAttribute("srcset");
            }

            return item;
        }

        private BaseItem test2(string name)
        {
            var items = new List<BaseItem>();

            var options = new ChromeOptions();

            var lst = new List<string>();

            var ids = new List<string>();

            options.AddArgument("--disable-blink-features=AutomationControlled");

            var driver = new ChromeDriver(options);

            driver.ExecuteCdpCommand("Page.addScriptToEvaluateOnNewDocument", new Dictionary<string, object>
            {
               { "source", "delete window.cdc_adoQpoasnfa76pfcZLmcfl_Array;\r\ndelete window.cdc_adoQpoasnfa76pfcZLmcfl_Promise;\r\ndelete window.cdc_adoQpoasnfa76pfcZLmcfl_Symbol;" }

            });

            driver.Navigate().GoToUrl($"https://www.dns-shop.ru/catalog/17a892f816404e77/noutbuki/?q=%D0%B8%D0%B3%D1%80%D0%BE%D0%B2%D0%BE%D0%B9+%D0%BD%D0%BE%D1%83%D1%82%D0%B1%D1%83%D0%BA&stock=now-today-tomorrow-later&order=6&isSearch=1");

            while (driver.Title == "")
            {

            }

            var productElements = driver.FindElements(By.ClassName("catalog-product"));



            foreach (var element in productElements)
            {
                var price = string.Empty;
                var item = new BaseItem();

                var test = element.GetDomAttribute("data-product");

               /* driver.Navigate().GoToUrl($"https://www.dns-shop.ru/product/microdata/" + test);

                var producl = driver.PageSource.Substring(driver.PageSource.IndexOf('{'));

                producl = producl.Substring(0, producl.LastIndexOf('}') + 1);
               */
                ids.Add(test);
            }

            lst = GetFullData(ids, driver);

            var a = JObject.Parse(lst[0])["data"];

            var it = JsonConvert.DeserializeObject<BaseItem>(a.ToString());

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(it.ImageUrl).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    it.Image = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
                }
            }


            /*
            var elem = driver.FindElement(By.ClassName("pagination-widget__show-more-btn"));

            while (elem != null)
            {
                Thread.Sleep(TimeSpan.FromSeconds(30));
                elem.Click();
                elem = driver.FindElement(By.ClassName("pagination-widget__show-more-btn"));
            }
            */
            return it;
        }


        public BaseItem SearchItem(string name, int searchOption)
        {
            return test2("a");


            try
            {
                return ParseDnsPageByName(name)[0];
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ops");
            }

            try
            {
                return GetTargetItem(name);
            }
            catch (Exception)
            {
                Console.WriteLine("Ops");
            }

            return new BaseItem();
        }
    }
}

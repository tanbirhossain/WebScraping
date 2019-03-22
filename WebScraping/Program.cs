using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebScraping
{

    class Program
    {
        static void Main(string[] args)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://www.yellowpages.com/search?search_terms=software&geo_location_terms=Tokyo%2C+40");
            var list = new List<DataServie>();
            var HeaderNames = doc.DocumentNode.SelectNodes("//a[@class='business-name']").ToList();
            foreach (var item in HeaderNames)
            {
                list.Add(new DataServie { Name = item.InnerText });
                //Console.WriteLine(item.InnerText);
            }
            var PhoneHeaderNames = doc.DocumentNode.SelectNodes("//div[@class='phones phone primary']").ToList();
            Console.WriteLine("--------  Phone -----------");
            //foreach (var item in PhoneHeaderNames)
            //{
            //    Console.WriteLine(item.InnerText);
            //}
            for (int i = 0; i < PhoneHeaderNames.Count; i++)
            {
                list[i].PhoneNo = PhoneHeaderNames[i].InnerText;
            }
            Console.WriteLine(JsonConvert.SerializeObject(list, Formatting.Indented));
            Console.ReadKey();
        }
    }
    public class DataServie
    {
        public string Name { get; set; }
        public string PhoneNo { get; set; }
    }

}


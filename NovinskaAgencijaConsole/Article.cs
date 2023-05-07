using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovinskaAgencijaConsole
{
    public class Article : IPrototype
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public Reporter Reporter { get; set; }

        public Article(string title, string content, string category, DateTime date, double price, Reporter reporter)
        {
            Title = title;
            Content = content;
            Category = category;
            Date = date;
            Price = price;
            Reporter = reporter;
        }

        public IPrototype Clone()
        {
            return this.MemberwiseClone() as IPrototype;
        }
    }
}

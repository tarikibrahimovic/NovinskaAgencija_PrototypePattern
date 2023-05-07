using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovinskaAgencijaConsole
{
    public class Reporter : IPrototype
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Article> Articles { get; set; }

        public Reporter(string id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
            Articles = new List<Article>();
        }

        public IPrototype Clone()
        {
            return this.MemberwiseClone() as IPrototype;
        }
    }
}

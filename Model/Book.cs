using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutorialWebAPI.Model
{
    public class Book
    {
     

        public Book(int v1, string v2, string v3, string v4, string v5, int v6)
        {
            this.id = v1;
            this.title = v2;
            this.ISBN = v3;
            this.author = v4;
            this.price = v5;
            this.pages = v6;
        }

        //public int id { get; set; }
        public string title { get; set; }
        public string ISBN { get; set; }
        public string author { get; set; }
        public string price { get; set; }
        public int pages { get; set; }
    }
}

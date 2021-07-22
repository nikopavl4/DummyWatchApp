using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace QuoteS.Classes
{
    public class QuoteSi
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Message { get; set; }
        public string Number { get; set; }
    }
}

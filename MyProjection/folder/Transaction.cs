using System;
using System.Collections.Generic;
using System.Text;

namespace MyProjection.folder
{
    class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public  decimal Amount { get; set; }
        public DateTime DateofTransaction { get; set; }
           

    }
}

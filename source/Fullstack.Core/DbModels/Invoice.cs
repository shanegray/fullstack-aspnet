using System;

namespace Fullstack.Core.DbModels {
    public class Invoice {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
        public bool Submitted { get; set; }

        public Company Company { get; set; }
    }
}

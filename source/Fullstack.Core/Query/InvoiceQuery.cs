using Fullstack.Core.DbModels;
using Fullstack.Core.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace Fullstack.Core.Query {
    public class InvoiceQuery {
        public List<Invoice> Get() {
            using (var context = new FullstackContext()) {
                return context.Invoice.ToList();
            }
        }
    }
}

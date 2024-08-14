using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseExcel.Model
{
    public class Product:IComparable<Product>
    {
        public string Catalog { get; set; }
        public string Category { get; set; }
        public DateTime? DateExp { get; set; }
        public int? Priority { get; set; }
        public DateTime? DateIn { get; set; }

        public int CompareTo(Product? other)
        {
            if (other == null)
                return 0;

            if (this.DateExp != other.DateExp)
            {
                if (this.DateExp == null) return 1;
                if (other.DateExp == null) return -1;
                var compare = DateTime.Compare((DateTime)this.DateExp, (DateTime)other.DateExp);
                return compare;
            }
            if (this.Priority != other.Priority)
            {
                if (this.Priority == null) return 1;
                if (other.Priority == null) return -1;
                var compare = (this.Priority < other.Priority) ? -1 : 1;
                return compare;
            }

            var compare2 = DateTime.Compare((DateTime)this.DateIn, (DateTime)other.DateIn);
            return compare2;


        }
    }
}

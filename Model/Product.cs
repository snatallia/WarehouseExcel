using System.ComponentModel;

namespace WarehouseExcel.Model
{
    public class Product:IComparable<Product>
    {
        [DisplayName("Каталог")]
        public string Catalog { get; set; }
        
        [DisplayName("Категория")]
        public string Category { get; set; }

        [DisplayName("Срок годности")]
        public DateTime? DateExp { get; set; }

        [DisplayName("Приоритет")]
        public int? Priority { get; set; }
        
        [DisplayName("Время поступления на склад")]
        public DateTime? DateIn { get; set; }

        public int CompareTo(Product? other)
        {
            if (other == null)
                return 0;

            if (this.DateExp != other.DateExp)
            {
                if (!this.DateExp.HasValue) 
                    return 1;
                if (!other.DateExp.HasValue) 
                    return -1;

                return DateTime.Compare((DateTime)this.DateExp, (DateTime)other.DateExp);
            }
            if (this.Priority != other.Priority)
            {
                if (this.Priority == null) 
                    return 1;
                if (other.Priority == null) 
                    return -1;

                return (this.Priority < other.Priority) ? -1 : 1;
            }

            if(!this.DateIn.HasValue)
                return 1;
            if (!other.DateIn.HasValue)
                return -1;

            return DateTime.Compare((DateTime)this.DateIn, (DateTime)other.DateIn);
        }
    }
}

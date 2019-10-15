using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Abstract;

namespace Model.Models
{
    [Table("ProductCategories")]
    public class ProductCategory : Auditable
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Alias { get; set; }

        public string Description { get; set; }
        public string Image { get; set; }
        public int? ParentID { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? HomeFlag { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
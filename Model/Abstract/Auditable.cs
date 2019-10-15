using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Abstract
{
    public class Auditable : IAuditable
    {
        public string MetaKeyword { get; set; }

        [MaxLength(256)]
        public string MetaDescription { get; set; }

        public DateTime? CreateDate { get; set; }

        [MaxLength(256)]
        public string CreateBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [MaxLength(256)]
        public string UpdateBy { get; set; }

        public bool Status { get; set; }
    }
}
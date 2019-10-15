using System;

namespace Model.Abstract
{
    public interface IAuditable
    {
        string MetaKeyword { get; set; }
        string MetaDescription { get; set; }
        DateTime? CreateDate { get; set; }
        string CreateBy { get; set; }
        DateTime? UpdatedDate { get; set; }
        string UpdateBy { get; set; }
        bool Status { get; set; }
    }
}
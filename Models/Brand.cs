//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MaiThiKimHien_2122110261.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Brand
    {
        public int id { get; set; }
        public string brandName { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<bool> showOnHomePage { get; set; }
        public Nullable<int> displayOrder { get; set; }
        public Nullable<bool> deleted { get; set; }
        public Nullable<System.DateTime> createdOnUtc { get; set; }
        public Nullable<System.DateTime> updateOnUtc { get; set; }
        public int ProductCount { get; set; }
    }
}

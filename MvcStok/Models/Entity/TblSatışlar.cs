//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcStok.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblSatışlar
    {
        public int SatısID { get; set; }
        public Nullable<int> Urun { get; set; }
        public Nullable<int> Müşteri { get; set; }
        public Nullable<byte> Adet { get; set; }
        public Nullable<decimal> Fiyat { get; set; }
    
        public virtual TblMusteriler TblMusteriler { get; set; }
        public virtual TblUrunler TblUrunler { get; set; }
    }
}

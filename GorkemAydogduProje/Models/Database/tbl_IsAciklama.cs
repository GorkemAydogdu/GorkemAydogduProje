//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GorkemAydogduProje.Models.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_IsAciklama
    {
        public int Id { get; set; }
        public Nullable<int> Is { get; set; }
        public string Aciklama { get; set; }
        public Nullable<int> Calisan { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public string Durum { get; set; }
    
        public virtual tbl_Calisan tbl_Calisan { get; set; }
        public virtual tbl_Is tbl_Is { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoinJarWebApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CoinJar
    {
        public int Id { get; set; }
        public string CoinType { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> Volume { get; set; }
    }
}

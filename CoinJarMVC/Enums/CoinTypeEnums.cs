using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CoinJarMVC.Enums
{

    public enum CoinType
    {
        [DescriptionAttribute("None")]
        None = 0,
        [DescriptionAttribute("Penny")]   
        Penny = 1,
        [DescriptionAttribute("Nickel")]
        Nickel = 2,
        [DescriptionAttribute("Dime")]
        Dime = 3,
        [DescriptionAttribute("Quarter")]
        Quarter = 4,


    }
}
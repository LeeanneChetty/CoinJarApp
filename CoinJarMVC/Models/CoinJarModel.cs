using CoinJarMVC.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CoinJarMVC.Models
{
    public class CoinJarModel
    {
        public List<Coin> coinlist { get; set; }

        public decimal? selectedCoinType { get; set; }

        public decimal Id { get; set; }

        [Display(Name = "Coin Type")]
        public List<SelectListItem> CoinType { get; set; }

        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        [Display(Name = "Volume")]
        public decimal? Volume { get; set; }

        public bool NewCoinAdded { get; set; }

        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get;  set; }

        public decimal TotalVolume { get; set; }
    }


    public class Coin : ICoinModel
    {
        public decimal Amount { get; set; }
        public decimal Volume { get; set; }

        public string CoinType { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal TotalVolume { get; set; }


    }





}
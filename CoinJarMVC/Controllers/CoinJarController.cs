using CoinJarMVC.Enums;
using CoinJarMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CoinJarMVC.Controllers
{
    public class CoinJarController : Controller
    {
        // GET: CoinJar

       
        
        [HttpGet]
        public ActionResult GetCoinJar(decimal coinType = 0, decimal TotalAmount = 0, decimal TotalVolume = 0, string ErrorMsg = null)
        {
            CoinJarModel model = new CoinJarModel();
         
           
            List<ICoinModel> coin = new List<ICoinModel>();
            coin.Add(new Coin { CoinType = CoinType.None.ToString(), Amount = 0, Volume = 0 });
            coin.Add(new Coin { CoinType = CoinType.Penny.ToString(), Amount = 1, Volume = 0.0122m});
            coin.Add(new Coin { CoinType = CoinType.Nickel.ToString(), Amount = 5, Volume = 0.0243m});
            coin.Add(new Coin { CoinType = CoinType.Dime.ToString(), Amount = 10, Volume = 0.0115m });
            coin.Add(new Coin { CoinType = CoinType.Quarter.ToString(), Amount = 25, Volume = 0.027m });
            

            model.selectedCoinType = coinType;
            model.CoinType = (from CoinType d in Enum.GetValues(typeof(CoinType))
                               select new SelectListItem()
                               {
                                   Value = ((decimal)d).ToString(),
                                   Text = d.ToString()

                               }).ToList();


            string CoinName = ((CoinType)Enum.Parse(typeof(CoinType), (coinType).ToString())).ToString();
        

            foreach (Coin obj in coin.OfType<Coin>().Where(x => x.CoinType.Equals(CoinName)))
            {
                model.Amount = obj.Amount;
                model.Volume = obj.Volume;
            }

            ViewBag.Error = ErrorMsg;
            
            return View(model);
        }

      

        public ActionResult AddCoin(Coin coin)
        {
            
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("CoinJar/PostCoinJar", coin).Result;
     
           
            string Error = null;
            if(coin.TotalVolume <= 32)
            { 
            coin.TotalAmount = GetTotalAmount(coin.Amount, coin.TotalAmount);
            coin.TotalVolume = GetTotalVolume(coin.Volume, coin.TotalVolume);
            }
            else
            {
               Error = "New Coins can not be added! Jar will overflow!";
            }
        

            return RedirectToAction("GetCoinJar", new { TotalAmount = coin.TotalAmount, TotalVolume = coin.TotalVolume, ErrorMsg = Error});
        }

        public decimal GetTotalAmount(decimal Amount, decimal TotalValue)
        {      
            CoinJarModel model = new CoinJarModel();
            model.TotalAmount = TotalValue + Amount;

            return model.TotalAmount;
        }


        public ActionResult Reset()
        {

          Coin coin =  new Coin();
          coin.TotalAmount = 0;

          return RedirectToAction("GetCoinJar", new { TotalAmount = coin.TotalAmount });
        }

        public decimal GetTotalVolume(decimal Volume, decimal TotalValue)
        {
            CoinJarModel model = new CoinJarModel();
            model.TotalVolume = TotalValue + Volume;

            return model.TotalVolume;
        }


    }
}
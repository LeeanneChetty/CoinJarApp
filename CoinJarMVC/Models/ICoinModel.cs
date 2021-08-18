using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinJarMVC.Models
{

    public interface ICoinJar
    {
        void AddCoin(ICoinModel coin);
        decimal GetTotalAmount();
        void Reset();
    }
    public interface ICoinModel
    {
        decimal Amount { get; set;}
        decimal Volume { get; set;}
    }
}

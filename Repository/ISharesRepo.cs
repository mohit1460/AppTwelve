using AppTwelve.Models;
using System.Collections;

namespace AppTwelve.Repository
{
    public interface ISharesRepo
    {

        bool createShares(Shares shares);
        ICollection<Shares> allShares();
    }
}

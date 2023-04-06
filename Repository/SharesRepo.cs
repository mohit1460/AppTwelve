using AppTwelve.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using System.Collections;

namespace AppTwelve.Repository
{
    public class SharesRepo:ISharesRepo
    {
        private readonly ApplicationDBContext _dbContext;

        public SharesRepo(ApplicationDBContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        ICollection<Shares> ISharesRepo.allShares()
        {
            return _dbContext.Shares.OrderBy(a=>a.symbol).ToList();
        }

        public bool save() { 
            return (_dbContext.SaveChanges() >= 0?true:false);
        }

         bool ISharesRepo.createShares(Shares s)
        {
            _dbContext.Shares.Add(s);
            return save();
        }

        
    }
}

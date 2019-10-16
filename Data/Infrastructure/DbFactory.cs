using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private QuoKaNaDbContext dbContext;

        public QuoKaNaDbContext Init()
        {
            return dbContext ?? (dbContext = new QuoKaNaDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}

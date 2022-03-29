using DAL.Repos;
using ReqSystem.DAL.IRepos;
using ReqSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ReqSystem.DAL.Repos
{
    public class ReqUserRepo : IRepos.IReqUserRepo<ReqUser>
    {
        public int Count => throw new NotImplementedException();

        public bool HasChanges => throw new NotImplementedException();

        public int Add(ReqUser entity, bool persist = true)
        {
            throw new NotImplementedException();
        }

        public int AddRange(IEnumerable<ReqUser> entities, bool persist = true)
        {
            throw new NotImplementedException();
        }

        public int Delete(ReqUser entity, bool persist = true)
        {
            throw new NotImplementedException();
        }

        public int Delete(string id, bool persist = true)
        {
            throw new NotImplementedException();
        }

        public int DeleteRange(IEnumerable<ReqUser> entities, bool persist = true)
        {
            throw new NotImplementedException();
        }

        public ReqUser Find(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReqUser> GetRange(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReqUser> Search(Expression<Func<ReqUser, bool>> filter = null, Func<IQueryable<ReqUser>, IOrderedQueryable<ReqUser>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public int Update(ReqUser entity, bool persist = true)
        {
            throw new NotImplementedException();
        }

        public int UpdateRange(IEnumerable<ReqUser> entities, bool persist = true)
        {
            throw new NotImplementedException();
        }
    }
}

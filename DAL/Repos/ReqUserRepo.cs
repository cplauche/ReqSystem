using DAL.IRepos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Models;
using ReqSystem.DAL.IRepos;
using ReqSystem.Data;
using ReqSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repos
{
    public abstract class ReqUserRepo<T> : IDisposable, IReqUserRepo<ReqUser>
    {

        protected readonly ApplicationDbContext Db;
        protected DbSet<ReqUser> Table;
        private UserManager<ReqUser> _UserManager;
        public ApplicationDbContext Context => Db;

        protected ReqUserRepo()
        {
            DbContextOptionsBuilder<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>();
            // Update to get from config
            options.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = [DbName]; Trusted_Connection = True; MultipleActiveResultSets = true");

            Db = new ApplicationDbContext(options.Options);
            Table = Db.Set<ReqUser>();
        }

        protected ReqUserRepo(DbContextOptions<ApplicationDbContext> options)
        {
            Db = new ApplicationDbContext(options);
            Table = Db.Set<ReqUser>();
        }

        public bool HasChanges => Db.ChangeTracker.HasChanges();

        public int Count => Table.Count();
        

        public virtual ReqUser Find(String? id) => Table.Find(id);

        /// <summary>
        /// A way to search/sort and select only certain properties from the collection T
        /// From the Get override in the generic repository at https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
        /// </summary>
        /// <param name="filter">The linq query to filter results on</param>
        /// <param name="orderBy">The field to sort by</param>
        /// <param name="includeProperties">The columns to include</param>
        /// <returns></returns>
        public virtual IEnumerable<ReqUser> Search(
            Expression<Func<ReqUser, bool>> filter = null,
            Func<IQueryable<ReqUser>, IOrderedQueryable<ReqUser>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<ReqUser> query = (IQueryable<ReqUser>)Table;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }


        internal IEnumerable<ReqUser> GetRange(IQueryable<ReqUser> query, int skip, int take)
            => query.Skip(skip).Take(take);

        public virtual IEnumerable<ReqUser> GetRange(int skip, int take)
            => GetRange(Table, skip, take);

        public virtual int Add(ReqUser entity, bool persist = true)
        {
            Table.Add(entity);
            return persist ? SaveChanges() : 0;
        }

        public virtual int AddRange(IEnumerable<ReqUser> entities, bool persist = true)
        {
            Table.AddRange(entities);
            return persist ? SaveChanges() : 0;
        }

        public virtual int Update(ReqUser entity, bool persist = true)
        {
            Table.Update(entity);
            return persist ? SaveChanges() : 0;
        }

        public virtual int UpdateRange(IEnumerable<ReqUser> entities, bool persist = true)
        {
            Table.UpdateRange(entities);
            return persist ? SaveChanges() : 0;
        }

        public virtual int Delete(ReqUser entity, bool persist = true)
        {
            Table.Remove(entity);
            return persist ? SaveChanges() : 0;
        }

        public virtual int DeleteRange(IEnumerable<ReqUser> entities, bool persist = true)
        {
            Table.RemoveRange(entities);
            return persist ? SaveChanges() : 0;
        }
 
        public int SaveChanges()
        {
            try
            {
                return Db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                //A concurrency error occurred
                //Should handle intelligently
                Console.WriteLine(ex);
                throw;
            }
            catch (RetryLimitExceededException ex)
            {
                //DbResiliency retry limit exceeded
                //Should handle intelligently
                Console.WriteLine(ex);
                throw;
            }
            catch (Exception ex)
            {
                //Should handle intelligently
                Console.WriteLine(ex);
                throw;
                //-2146232060
                //throw new Exception($"{ex.HResult}");
            }
        }

        private bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here. 
                //
            }
            Db.Dispose();
            _disposed = true;
        }

        public ReqUser Find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Delete(string id, bool persist = true)
        {
            throw new NotImplementedException();
        }
    }
}

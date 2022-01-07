using Microsoft.EntityFrameworkCore;
using Rehber.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rehber.Api.Data
{
    public class EfRepositoryEntityFramework<TEntity, TContext> : IRepository<TEntity>
        where TEntity: BaseEntity,new()
        where TContext:DbContext,new()
    {
       
        public TEntity Getir(Func<TEntity, bool> filtre=null, params string[] includeList)
        {
          
                using (TContext ctx = new TContext())
                {
                    IQueryable<TEntity> dbSet = ctx.Set<TEntity>();
                    if (includeList.Length > 0)
                    {
                        for (int i = 0; i < includeList.Length; i++)
                        {
                            dbSet = dbSet.Include(includeList[i]);
                        }
                    }

                    return dbSet.Where(x => x.Durum == true).SingleOrDefault(filtre);

                }
           
           
        }

        public void Güncelle(TEntity entity)
        {
             using (TContext ctx = new TContext())
                {
                    entity.GuncellemeTarihi = DateTime.Now;
                    ctx.Entry(entity).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            
           
          
        }

        public TEntity IdGetir(int id, params string[] includeList)
        {
            return Getir(x => x.Id == id, includeList);
        }

        public void Kaydet(TEntity entity)
        {
        
            using (TContext ctx = new TContext())
            {
                    entity.OlusturmaTarihi = DateTime.Now;
                    entity.GuncellemeTarihi = DateTime.Now;
                    entity.Durum = true;
                    ctx.Entry(entity).State = EntityState.Added;
                    ctx.SaveChanges();
            }
        }

        public List<TEntity> Listele(params string[] includeList)
        {
           
                using (TContext ctx = new TContext())
                {
                    IQueryable<TEntity> dbSet = ctx.Set<TEntity>();
                    if (includeList.Length > 0)
                    {
                        for (int i = 0; i < includeList.Length; i++)
                        {
                            dbSet = dbSet.Include(includeList[i]);
                        }
                    }
                    return dbSet.Where(x => x.Durum == true).ToList();
                }
        }

        public List<TEntity> Listele(Func<TEntity, bool> filtre, params string[] includeList)
        {
           
                using (TContext ctx = new TContext())
                {
                    IQueryable<TEntity> dbSet = ctx.Set<TEntity>();
                    if (includeList.Length > 0)
                    {
                        for (int i = 0; i < includeList.Length; i++)
                        {
                            dbSet = dbSet.Include(includeList[i]);
                        }
                    }

                    return dbSet.Where(x => x.Durum == true).Where(filtre).ToList();
                }
          
           
        }

        public void Sil(TEntity entity)
        {
         
                using (TContext ctx = new TContext())
                {
                    entity.Durum = false;
                    ctx.Entry(entity).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
           
           
        }
    }
}

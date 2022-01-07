using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rehber.Api.Data
{
    public interface IRepository<TEntity>
    {
        List<TEntity> Listele(params string[] includeList);
        List<TEntity> Listele(Func<TEntity, bool> filtre, params string[] includeList);
        TEntity IdGetir(int id, params string[] includeList);
        TEntity Getir(Func<TEntity, bool> filtre,params string[] includeList);
        void Kaydet(TEntity entity);
        void Güncelle(TEntity entity);
        void Sil(TEntity entity);

    }
}

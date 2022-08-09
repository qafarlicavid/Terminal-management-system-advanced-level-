using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_management_system.Database.Models.Common;

namespace Terminal_management_system.Database.Repository.Common
{
    public class Repository<TEntity, TId>
        where TEntity : Entity<TId>
    {
        public static List<TEntity> DbContext { get; set; } = new List<TEntity>();

        public TEntity Add(TEntity entry)
        {
            DbContext.Add(entry);
            return entry;
        }

        public List<TEntity> GetAll()
        {
            return DbContext;
        }

        public TEntity GetById(TId id)
        {
            foreach (TEntity entry in DbContext)
            {
                if (Equals(entry.Id, id))
                {
                    return entry;
                }
            }

            return default(TEntity);
        }

        public void Delete(TEntity entry)
        {
            DbContext.Remove(entry);
        }

        //public TEntity Update(TId id, TEntity newEntry)
        //{
        //    TEntity entry = GetById(id);
        //    newEntry.CreatedAt = entry.CreatedAt;
        //    newEntry.Id = entry.Id;
        //    entry = newEntry;

        //    return entry;
        //}
    }
}

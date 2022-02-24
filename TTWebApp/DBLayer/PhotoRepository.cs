using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTWebApp.Models;

namespace TTWebApp.DBLayer
{
    public class PhotoRepository : IRepository<Photo>
    {
        private ApplicationContext context;
        private bool disposed = false;
        public PhotoRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public void Create(Photo item)
        {
            context.Photos.Add(item);
            context.SaveChanges();
        }

        public Photo Delete(int id)
        {
            Photo photo = Get(id);
            if (photo != null)
            {
                context.Photos.Remove(photo);
                context.SaveChanges();
            }
            return photo;
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Photo Get(int id)
        {
            return context.Photos.Find(id);
        }

        public IEnumerable<Photo> GetList()
        {
            return context.Photos;
        }

        public void Save()
        {
            context.SaveChanges();
        }
        
        public void Update(Photo updatedItem)
        {
            context.Entry(updatedItem).State = EntityState.Modified;
            Photo currentPhoto = Get(updatedItem.Id);
            currentPhoto = (Photo)updatedItem.Clone();
            context.Photos.Update(currentPhoto);
            context.SaveChanges();
        }
    }
}

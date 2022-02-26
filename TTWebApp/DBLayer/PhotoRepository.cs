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
            try
            {
                if (photo != null)
                {
                    context.Photos.Remove(photo);
                    context.SaveChanges();
                }
                return photo;
            }
            catch 
            {
                throw;
            }
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
            Photo currentPhoto = Get(updatedItem.Id);
            currentPhoto.AuthorId = updatedItem.AuthorId;
            currentPhoto.Cost = updatedItem.Cost;
            currentPhoto.DateOfCreation = updatedItem.DateOfCreation;
            currentPhoto.Link = updatedItem.Link;
            currentPhoto.Name = updatedItem.Name;
            currentPhoto.NumberOfPurchase = updatedItem.NumberOfPurchase;
            currentPhoto.Size = updatedItem.Size;
            context.Photos.Update(currentPhoto);
            context.SaveChanges();
        }
    }
}

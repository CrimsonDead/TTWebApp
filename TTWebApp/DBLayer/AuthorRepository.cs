using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TTWebApp.DBLayer;
using TTWebApp.Models;

namespace TTWebApp.DBLayer
{
    public class AuthorRepository : IRepository<Author>
    {
        private ApplicationContext context;
        private bool disposed = false;
        public AuthorRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public void Create(Author item)
        {
            context.Authors.Add(item);
            context.SaveChanges();
        }

        public Author Delete(int id)
        {
            Author author = Get(id);
            if (author != null)
            {
                context.Authors.Remove(author);
                context.SaveChanges();
            }
            return author;
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

        public Author Get(int id)
        {
            return context.Authors.Find(id);
        }

        public IEnumerable<Author> GetList()
        {
            return context.Authors;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Author updatedItem)
        {
            context.Entry(updatedItem).State = EntityState.Modified;
            Author currentAuthor = Get(updatedItem.Id);
            currentAuthor = (Author)updatedItem.Clone();
            context.Authors.Update(currentAuthor);
            context.SaveChanges();
        }
    }
}

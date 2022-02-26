using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTWebApp.Models;
using TTWebApp.DBLayer;
using Microsoft.EntityFrameworkCore;

namespace TTWebApp.DBLayer
{
    public class TextRepository : IRepository<Text>
    {
        private ApplicationContext context;
        private bool disposed = false;
        public TextRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public void Create(Text item)
        {
            context.Texts.Add(item);
            context.SaveChanges();
        }

        public Text Delete(int id)
        {
            Text text = Get(id);
            try
            {
                if (text != null)
                {
                    context.Texts.Remove(text);
                    context.SaveChanges();
                }
                return text;
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

        public Text Get(int id)
        {
            return context.Texts.Find(id);
        }

        public IEnumerable<Text> GetList()
        {
            return context.Texts;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Text updatedItem)
        {
            Text currentText = Get(updatedItem.Id);
            currentText.AuthorId = updatedItem.AuthorId;
            currentText.Cost = updatedItem.Cost;
            currentText.DateOfCreation = updatedItem.DateOfCreation;
            currentText.NumberOfPurchase = updatedItem.NumberOfPurchase;
            currentText.Content = updatedItem.Content;
            currentText.Size = updatedItem.Size;
            context.Texts.Update(currentText);
            context.SaveChanges();
        }
    }
}

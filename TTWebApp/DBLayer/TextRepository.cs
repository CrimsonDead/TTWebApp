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
            if (text != null)
            {
                context.Texts.Remove(text);
                context.SaveChanges();
            }
            return text;
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
            context.Entry(updatedItem).State = EntityState.Modified;
            Text currentText = Get(updatedItem.Id);
            currentText = (Text)updatedItem.Clone();
            context.Texts.Update(currentText);
            context.SaveChanges();
        }
    }
}

using DAL.DataContext;
using DAL.Entities;
using DAL.Functions.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Specific
{
    public class Reply_Operations : IReply_Operations
    {
        public async Task<Reply> Create(Reply replyToAdd)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    await context.AddAsync<Reply>(replyToAdd);
                    await context.SaveChangesAsync();
                    return replyToAdd;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<Reply> Read(Int64 replyId)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var result = await context.FindAsync<Reply>(replyId);
                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Reply>> ReadAll()
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var result = await context.Set<Reply>().ToListAsync();
                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<Reply> Update(Reply objectToUpdate, Int64 entityId)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var objectFound = await context.FindAsync<Reply>(entityId);
                    if (objectFound != null)
                    {
                        context.Entry(objectFound).CurrentValues.SetValues(objectToUpdate);
                        await context.SaveChangesAsync();
                    }
                    return objectFound;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Delete(Int64 entityId)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var recordToDelete = await context.FindAsync<Reply>(entityId);
                    if (recordToDelete != null)
                    {
                        context.Remove(recordToDelete);
                        await context.SaveChangesAsync();
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

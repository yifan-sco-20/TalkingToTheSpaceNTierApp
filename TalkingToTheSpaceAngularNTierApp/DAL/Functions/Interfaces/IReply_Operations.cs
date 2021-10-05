using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Functions.Interfaces
{
    public interface IReply_Operations
    {
        Task<Reply> Create(Reply replyToAdd);
        Task<Reply> Read(Int64 replyId);
        Task<List<Reply>> ReadAll();
        Task<Reply> Update(Reply replyToUpdate, Int64 replyId);
        Task<bool> Delete(Int64 replyId);
    }
}

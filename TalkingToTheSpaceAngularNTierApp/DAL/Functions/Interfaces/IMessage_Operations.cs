using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Functions.Interfaces
{
    public interface IMessage_Operations
    {
        Task<Message> Create(Message messageToAdd);
        Task<Message> Read(Int64 messageId);
        Task<List<Message>> ReadAll();
        Task<Message> Update(Message messageToUpdate, Int64 messageId);
        Task<bool> Delete(Int64 messageId);
    }
}

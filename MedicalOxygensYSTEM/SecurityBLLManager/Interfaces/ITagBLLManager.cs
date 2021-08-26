using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.Interfaces
{
    public interface ITagBLLManager
    {
        Task<bool> AddTag(Tag tag);
        Task<bool> UpdateTag(Tag tag);
        Task<bool> DeleteTag(Tag tag);
        Task<Tag> GetById(Tag tag);
        List<Tag> GetAll();
        List<Tag> GetActiveTag();
    }
}

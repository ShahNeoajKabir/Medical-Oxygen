using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.Interfaces
{
    public interface IAttributesBLLManager
    {
        Task<bool> AddAttribute(Attributesss attributesss);
        Task<bool> UpdateAttribute(Attributesss attributesss);
        Task<bool> DeleteAttribute(Attributesss attributesss);
        Task<Attributesss> GetById(Attributesss attributesss);
        List<Attributesss> GetAll();
        List<Attributesss> GetActiveAttribute();
    }
}

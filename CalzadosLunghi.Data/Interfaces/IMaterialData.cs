using CalzadosLunghi.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CalzadosLunghi.Data.Interfaces
{
    public interface IMaterialData
    {
        Material Add(Material material);
        Material GetById(int? id);
        public Material GetByIdWithMaterialType(int? id);
        Material Update(Material material);
        Material Delete(int id);
        IEnumerable<Material> GetAllWithMaterialType();
        IEnumerable<Material> GetAll();
        Task<int> Commit();

    }
}

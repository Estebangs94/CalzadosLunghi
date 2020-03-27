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
        Material GetByIdWithMaterialType(int? id);
        Material GetByIdWithColors(int? id);
        Material Update(Material material);
        Material Delete(int id);
        IEnumerable<Material> DeleteMany(List<Material> materiales);
        IEnumerable<Material> GetAllWithMaterialType();
        IEnumerable<Material> GetMaterialsForMaterialType(int materialTypeId);
        IEnumerable<Material> GetAll();
        Task<int> Commit();

    }
}

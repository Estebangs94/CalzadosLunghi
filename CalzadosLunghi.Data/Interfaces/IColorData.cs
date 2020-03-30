using CalzadosLunghi.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CalzadosLunghi.Data.Interfaces
{
    public interface IColorData
    {
        Color Add(Color color);
        Color Delete(int id);
        IEnumerable<Color> GetAll();
        IEnumerable<Color> GetAllByMaterialId(int materialId);
        Color GetById(int? id);
        void DeleteMany(List<Color> colores);
        Task<int> Commit();
        Color Update(Color color);
    }
}

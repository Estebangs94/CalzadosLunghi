using CalzadosLunghi.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalzadosLunghi.Data.Interfaces
{
    public interface IColorData
    {
        IEnumerable<Color> GetAll();
        IEnumerable<Color> GetAllByMaterialId(int materialId);
    }
}

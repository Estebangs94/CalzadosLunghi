using CalzadosLunghi.Business;
using CalzadosLunghi.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalzadosLunghi.Data
{
    public class SqlColorData : IColorData
    {
        private readonly CalzadosLunghiDbContext _db;

        public SqlColorData(CalzadosLunghiDbContext db)
        {
            _db = db;
        }

        public Color Add(Color color)
        {
            color.EstaActivo = true;
            _db.Add(color);
            return color;
        }

        public async Task<int> Commit()
        {
            return await _db.SaveChangesAsync();
        }

        public void DeleteMany(List<Color> colores)
        {
            foreach (var item in colores)
            {
                item.EstaActivo = false;
            }
            _db.Colores.UpdateRange(colores);
        }

        public IEnumerable<Color> GetAll()
        {
            return _db.Colores.Where(x => x.EstaActivo).ToList();
        }

        public IEnumerable<Color> GetAllByMaterialId(int materialId)
        {
            return _db.Colores.Where(c => c.EstaActivo && materialId == c.MaterialId)
                              .ToList();
        }
    }
}

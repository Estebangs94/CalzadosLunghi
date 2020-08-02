using CalzadosLunghi.Entities;
using CalzadosLunghi.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public Color Delete(int id)
        {
            var color = _db.Colores.First(c => c.ID == id && c.EstaActivo);
            color.EstaActivo = false;


            var entity = _db.Colores.Attach(color);
            entity.State = EntityState.Modified;

            return color;
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
            return _db.Colores.Where(x => x.EstaActivo)
                .Include(m => m.Material)
                .ToList();
        }

        public IEnumerable<Color> GetAllByMaterialId(int materialId)
        {
            return _db.Colores.Where(c => c.EstaActivo && materialId == c.MaterialId)
                              .ToList();
        }

        public Color GetById(int? id)
        {
            return _db.Colores.Include(m => m.Material)
                .FirstOrDefault(c => c.ID == id && c.EstaActivo);
        }

        public Color Update(Color color)
        {
            var entity = _db.Colores.Attach(color);
            entity.State = EntityState.Modified;

            return color;
        }
    }
}

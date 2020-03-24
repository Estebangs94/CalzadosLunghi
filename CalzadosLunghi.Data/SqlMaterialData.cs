using CalzadosLunghi.Business;
using CalzadosLunghi.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalzadosLunghi.Data
{
    public class SqlMaterialData : IMaterialData
    {
        private readonly CalzadosLunghiDbContext _db;

        public SqlMaterialData(CalzadosLunghiDbContext db)
        {
            _db = db;
        }

        public Material Add(Material material)
        {
            material.EstaActivo = true;
            _db.Add(material);
            return material;
        }

        public async Task<int> Commit()
        {
            return await _db.SaveChangesAsync();
        }

        public Material Delete(int id)
        {
            var material = _db.Materiales.First(x => x.ID == id);
            material.EstaActivo = false;
            var entity = _db.Materiales.Attach(material);
            entity.State = EntityState.Modified;

            return material;
        }

        public IEnumerable<Material> GetAll()
        {
            return _db.Materiales.Where(x => x.EstaActivo == true).ToList();
        }

        public IEnumerable<Material> GetAllWithMaterialType()
        {
            return _db.Materiales.Where(m => m.EstaActivo)
                .Include(m => m.TipoMaterial)
                .ToList();
        }

        public Material GetById(int? id)
        {
            var material = _db.Materiales.FirstOrDefault(x => x.ID == id && x.EstaActivo == true);
            return material;
        }

        public Material Update(Material material)
        {
            var entity = _db.Materiales.Attach(material);
            entity.State = EntityState.Modified;

            return material;
        }
    }
}

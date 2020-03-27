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
        private readonly IColorData _colorData;

        public SqlMaterialData(CalzadosLunghiDbContext db, IColorData colorData)
        {
            _db = db;
            _colorData = colorData;
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

        public IEnumerable<Material> DeleteMany(List<Material> materiales)
        {
            foreach (var m in materiales)
            {
                m.EstaActivo = false;
                _colorData.DeleteMany(m.Colores);
            }
            _db.Materiales.UpdateRange(materiales);
            return materiales;
        }

        public IEnumerable<Material> GetAll()
        {
            return _db.Materiales.Where(x => x.EstaActivo).ToList();
        }

        public IEnumerable<Material> GetAllWithMaterialType()
        {
            return _db.Materiales.Where(m => m.EstaActivo)
                .Include(m => m.TipoMaterial)
                .ToList();
        }

        public Material GetById(int? id)
        {
            var material = _db.Materiales.FirstOrDefault(x => x.ID == id && x.EstaActivo);
            return material;
        }

        public Material GetByIdWithColors(int? id)
        {
            var material = _db.Materiales
                .Include(m => m.Colores)
                .FirstOrDefault(m => m.ID == id && m.EstaActivo);

            return material;
        }

        public Material GetByIdWithMaterialType(int? id)
        {
            var material = _db.Materiales
                .Include(m => m.TipoMaterial)
                .FirstOrDefault(x => x.ID == id && x.EstaActivo);
            return material;
        }

        public IEnumerable<Material> GetMaterialsForMaterialType(int materialTypeId)
        {
            var results = _db.Materiales.Where(m => m.EstaActivo && m.TipoMaterialId == materialTypeId);
            return results;
        }

        public Material Update(Material material)
        {
            var entity = _db.Materiales.Attach(material);
            entity.State = EntityState.Modified;

            return material;
        }
    }
}

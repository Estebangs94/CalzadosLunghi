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
            var material = _db.Materiales
                .Include(t => t.TipoMaterial)
                .Include(c => c.Colores)
                .First(x => x.ID == id && x.EstaActivo);

            material.EstaActivo = false;
            //borrado de entidad relacionada delegada a servicio correspondiente
            _colorData.DeleteMany(material.Colores);

            var entity = _db.Materiales.Attach(material);
            entity.State = EntityState.Modified;

            return material;
        }

        public IEnumerable<Material> DeleteMany(List<Material> materiales)
        {
            foreach (var m in materiales)
            {
                m.EstaActivo = false;

                //borrado de entidad relacionada delegada a servicio correspondiente
                _colorData.DeleteMany(m.Colores); 
            }
            _db.Materiales.UpdateRange(materiales);
            return materiales;
        }

        public IEnumerable<Material> GetAll()
        {
            return _db.Materiales.Where(x => x.EstaActivo)
                .Include(c => c.Colores)
                .Include(t => t.TipoMaterial)
                .ToList();
        }

        public Material GetById(int? id)
        {
            var material = _db.Materiales
                .Include(c => c.Colores)
                .Include(t => t.TipoMaterial)
                .FirstOrDefault(x => x.ID == id && x.EstaActivo);
            return material;
        }

        public IEnumerable<Material> GetMaterialsForMaterialType(int materialTypeId)
        {
            var results = _db.Materiales.Where(m => m.EstaActivo && m.TipoMaterialId == materialTypeId)
                .Include(c => c.Colores)
                .Include(t => t.TipoMaterial);
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

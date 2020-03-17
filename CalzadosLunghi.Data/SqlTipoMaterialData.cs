using CalzadosLunghi.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using CalzadosLunghi.Data.Interfaces;

namespace CalzadosLunghi.Data
{
    public class SqlTipoMaterialData : ITipoMaterialData
    {
        private readonly CalzadosLunghiDbContext _db;

        public SqlTipoMaterialData(CalzadosLunghiDbContext db)
        {
            _db = db;
        }

        public TipoMaterial Add(TipoMaterial tipoMaterial)
        {
            tipoMaterial.EstaActivo = true;
            _db.Add(tipoMaterial);
            return tipoMaterial;
        }

        public async Task<int> Commit()
        {
            return await _db.SaveChangesAsync();
        }

        public TipoMaterial Delete(int id)
        {
            var tipoMaterial = _db.TipoMateriales.First(x => x.ID == id);
            tipoMaterial.EstaActivo = false;
            var entity = _db.TipoMateriales.Attach(tipoMaterial);
            entity.State = EntityState.Modified;
            
            return tipoMaterial;
        }

        public IEnumerable<TipoMaterial> GetAll()
        {
            var result = _db.TipoMateriales.Where(x => x.EstaActivo == true)
                .ToList();
            return result;
        }

        public TipoMaterial GetById(int? id)
        {
            var tipoMaterial = _db.TipoMateriales.First(x => x.ID == id && x.EstaActivo == true);
            return tipoMaterial;
        }

        public TipoMaterial Update(TipoMaterial tipoMaterial)
        {
            var entity = _db.TipoMateriales.Attach(tipoMaterial);
            entity.State = EntityState.Modified;
            
            return tipoMaterial;
        }
    }
}

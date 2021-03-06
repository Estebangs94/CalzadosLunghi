﻿using CalzadosLunghi.Entities;
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
        private readonly IMaterialData _materialData;

        public SqlTipoMaterialData(CalzadosLunghiDbContext db, IMaterialData materialData)
        {
            _db = db;
            _materialData = materialData;
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

            //buscamos entidades relacionadas y las eliminamos
            //Materiales..
            var materiales = _db.Materiales
                .Where(m => m.TipoMaterialId == tipoMaterial.ID && m.EstaActivo)
                .Include(m => m.Colores)
                .ToList();

            _materialData.DeleteMany(materiales);
            //Sería mejor invocar un método de IMaterialData que se encargue de hacer la eliminación,
            //ya que puede haber otras entidades relacionadas a Material. Le pasamos la coleccion de materiales

            //Fue implementado el 27/03 

            return tipoMaterial;
        }

        public IEnumerable<TipoMaterial> GetAll()
        {
            var result = _db.TipoMateriales.Where(x => x.EstaActivo)
                .ToList();
            return result;
        }

        public TipoMaterial GetById(int? id)
        {
            var tipoMaterial = _db.TipoMateriales.FirstOrDefault(x => x.ID == id && x.EstaActivo);
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

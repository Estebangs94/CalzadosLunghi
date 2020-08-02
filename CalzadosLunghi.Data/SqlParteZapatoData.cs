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
    public class SqlParteZapatoData : IParteZapatoData
    {
        private readonly CalzadosLunghiDbContext _db;

        public SqlParteZapatoData(CalzadosLunghiDbContext db)
        {
            _db = db;
        }

        public ParteZapato Add(ParteZapato parteZapato)
        {
            parteZapato.EstaActivo = true;
            _db.Add(parteZapato);
            return parteZapato;
        }

        public async Task<int> Commit()
        {
            return await _db.SaveChangesAsync();
        }

        public ParteZapato Delete(int id)
        {
            var parteZapato = _db.ParteZapatos.First(x => x.ID == id);
            parteZapato.EstaActivo = false;
            var entity = _db.ParteZapatos.Attach(parteZapato);
            entity.State = EntityState.Modified;

            return parteZapato;
        }

        public IEnumerable<ParteZapato> GetAll()
        {
            var result = _db.ParteZapatos.Where(x => x.EstaActivo)
                .ToList();
            return result;
        }

        public ParteZapato GetById(int? id)
        {
            var parteZapato = _db.ParteZapatos.FirstOrDefault(x => x.ID == id && x.EstaActivo);
            return parteZapato;
        }

        public ParteZapato Update(ParteZapato parteZapato)
        {
            var entity = _db.ParteZapatos.Attach(parteZapato);
            entity.State = EntityState.Modified;

            return parteZapato;
        }
    }
}

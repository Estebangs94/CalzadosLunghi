using CalzadosLunghi.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CalzadosLunghi.Data.Interfaces
{
    public interface IParteZapatoData
    {
        ParteZapato Add(ParteZapato parteZapato);
        ParteZapato GetById(int? id);
        ParteZapato Update(ParteZapato parteZapato);
        ParteZapato Delete(int id);
        IEnumerable<ParteZapato> GetAll();
        Task<int> Commit();
    }
}

﻿using CalzadosLunghi.Business;
using CalzadosLunghi.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalzadosLunghi.Data
{
    public class SqlColorData : IColorData
    {
        private readonly CalzadosLunghiDbContext _db;

        public SqlColorData(CalzadosLunghiDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Color> GetAll()
        {
            return _db.Colores.Where(x => x.EstaActivo == true).ToList();
        }
    }
}
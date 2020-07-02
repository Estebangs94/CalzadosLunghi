using CalzadosLunghi.API.DTO;
using CalzadosLunghi.Business;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CalzadosLunghi.Data.Interfaces;

namespace CalzadosLunghi.API.Controllers
{
    [ApiController]
    [Route("api/tipomaterial")]
    public class TipoMaterialController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITipoMaterialData _tipoMaterialData;

        public TipoMaterialController(IMapper mapper, ITipoMaterialData tipoMaterialData)
        {
            _mapper = mapper;
            _tipoMaterialData = tipoMaterialData;
        }

        [HttpPost]
        public ActionResult<TipoMaterialDTO> Create(TipoMaterialForCreationDto tipoMaterialForCreation)
        {
            //business logic should be implemented with another layer
            var tipoMaterial = _mapper.Map<TipoMaterial>(tipoMaterialForCreation);

            var result = _tipoMaterialData.Add(tipoMaterial);

            return Ok(_mapper.Map<TipoMaterialDTO>(result));
        }

        public ActionResult<TipoMaterialDTO> Get(int id)
        {
            var tipoMaterial = _tipoMaterialData.GetById(id);

            if(tipoMaterial == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TipoMaterialDTO>(tipoMaterial));
        }
    }
}

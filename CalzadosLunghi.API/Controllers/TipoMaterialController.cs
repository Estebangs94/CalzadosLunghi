﻿using CalzadosLunghi.API.DTO;
using CalzadosLunghi.Entities;
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
        public ActionResult<TipoMaterialDTO> CreateTipoMaterial(TipoMaterialForCreationDto tipoMaterialForCreation)
        {
            //business logic should be implemented with another layer
            var tipoMaterial = _mapper.Map<TipoMaterial>(tipoMaterialForCreation);

            var result = _tipoMaterialData.Add(tipoMaterial);

            return Ok(_mapper.Map<TipoMaterialDTO>(result));
        }

        [HttpGet]
        public ActionResult<TipoMaterialDTO> GetTipoMaterial(int id)
        {
            var tipoMaterial = _tipoMaterialData.GetById(id);

            if(tipoMaterial == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TipoMaterialDTO>(tipoMaterial));
        }

        [HttpPut]
        public ActionResult<TipoMaterialDTO> UpdateTipoMaterial(TipoMaterialForUpdatingDto tipoMaterialForUpdatingDto )
        {
            if(tipoMaterialForUpdatingDto.ID == 0)
            {
                return BadRequest();
            }

            var tipoMaterial = _tipoMaterialData.GetById(tipoMaterialForUpdatingDto.ID);
            if(tipoMaterial == null)
            {
                return NotFound();
            }

            

            return Ok();
        }
    }
}

using AutoMapper;
using CalzadosLunghi.API.Controllers;
using CalzadosLunghi.API.DTO;
using CalzadosLunghi.Entities;
using CalzadosLunghi.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CalzadosLunghi.Tests.Controllers
{
    public class TipoMaterialControllerShould
    {
        private readonly Mock<ITipoMaterialData> _tipoMaterialDataMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly TipoMaterialController _controller;
        private TipoMaterialForCreationDto _tipoMaterialForCreationDto;
        private TipoMaterial _tipoMaterial;
        private TipoMaterialDTO _tipoMaterialDto;

        public TipoMaterialControllerShould()
        {
            _tipoMaterialDataMock = new Mock<ITipoMaterialData>();
            _mapperMock = new Mock<IMapper>();
            _controller = new TipoMaterialController(_mapperMock.Object, _tipoMaterialDataMock.Object);

            SeedMethod();
            SetupMocks();
        }

        [Fact]
        public void CreateNewTipoMaterial()
        {
            // Arrenge                    

            // Act
            var actionResult = _controller.CreateTipoMaterial(_tipoMaterialForCreationDto);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            var value = result.Value as TipoMaterialDTO;

            Assert.NotNull(value);
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(_tipoMaterialForCreationDto.Nombre, value.Nombre);
            Assert.Equal(_tipoMaterialForCreationDto.Codigo, value.Codigo);
        }

        [Fact]
        public void ReturnNotFoundWhenTipoMaterialNotExists()
        {
            //Arrenge
            //If Returns isn's specified, it returns null
            _tipoMaterialDataMock.Setup(x => x.GetById(It.IsAny<int>()));

            //Act
            var actionResult = _controller.GetTipoMaterial(It.IsAny<int>());

            //Assert
            var result = actionResult.Result as NotFoundResult;

            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public void ReturnTipoMaterial()
        {
            //Act
            var actionResult = _controller.GetTipoMaterial(It.IsAny<int>());

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var value = result.Value as TipoMaterialDTO;

            Assert.NotNull(result);
            Assert.NotNull(value);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(_tipoMaterialDto.Codigo, value.Codigo);
            Assert.Equal(_tipoMaterialDto.Nombre, value.Nombre);
        }

        internal void SeedMethod()
        {
            _tipoMaterialForCreationDto = new TipoMaterialForCreationDto
            {
                Nombre = "Cuero Liso",
                Codigo = "COD001"
            };

            _tipoMaterial = new TipoMaterial
            {
                Nombre = "Cuero Liso",
                Codigo = "COD001",
                EstaActivo = true
            };

            _tipoMaterialDto = new TipoMaterialDTO
            {
                Nombre = "Cuero Liso",
                Codigo = "COD001"
            };
        }

        internal void SetupMocks()
        {
            _mapperMock.Setup(x => x.Map<TipoMaterial>(It.IsAny<TipoMaterialForCreationDto>()))
               .Returns(_tipoMaterial);
            _mapperMock.Setup(x => x.Map<TipoMaterialDTO>(It.IsAny<TipoMaterial>()))
                .Returns(_tipoMaterialDto);
            _tipoMaterialDataMock.Setup(x => x.Add(It.IsAny<TipoMaterial>()))
                .Returns(_tipoMaterial);
            _tipoMaterialDataMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(_tipoMaterial);
        }
    }
}

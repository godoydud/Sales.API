using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sales.API.Application.Services;
using Sales.API.Domain.DTOs;
using Sales.API.Domain.Entities;
using Sales.API.Infra.Data.Context;
using Sales.API.Infra.Data.Repositories;

namespace Sales.API.Test.UnitTest.ComissionTest
{
    public class ComissionTestBuilder
    {
        private DbContextOptions<CoreContext>? _dbContextOptions;
        public CoreContext? _coreContext;
        private IMapper? _mapper;
        private ComissionRepository _comissionRepository;
        private ComissionService _comissionService;

        public ComissionTestBuilder WithDbContextOptions(string databaseName)
        {
            _dbContextOptions = new DbContextOptionsBuilder<CoreContext>().UseInMemoryDatabase(databaseName: databaseName).EnableSensitiveDataLogging().Options;
            return this;
        }

        public ComissionTestBuilder WithContext()
        {
            _coreContext = new CoreContext(_dbContextOptions!);
            return this;
        }

        public ComissionTestBuilder WithMapper()
        {
            _mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Comission, ComissionDTO>();
                config.CreateMap<ComissionDTO, Comission>();
            }).CreateMapper();
            return this;
        }

        public ComissionTestBuilder WithRepository()
        {
            _comissionRepository = new ComissionRepository(_coreContext!);
            return this;
        }

        public ComissionTestBuilder WithService()
        {
            _comissionService = new ComissionService(_comissionRepository!, _mapper!);
            return this;
        }

        public ComissionTestBuilder SaveChanges()
        {
            _coreContext!.SaveChanges();
            return this;
        }

        public ComissionService GetService()
        {
            return new ComissionService(_comissionRepository!, _mapper!);
        }
    }
}

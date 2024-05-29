using Microsoft.EntityFrameworkCore;
using POS.Infraestructura.Persistemces.Context;
using POS.Infraestructura.Persistemces.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infraestructura.Persistemces.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AplicationDbContext _dbContext;
        public IProductoRepository ProductoRepository { get; private set; }
        public IPersonaRepository PersonaRepository { get; private set; }
        public UnitOfWork(AplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            ProductoRepository = new ProductoRepository(_dbContext);
            PersonaRepository = new PersonaRepository(_dbContext);
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infraestructura.Persistemces.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        //Declarecion o Matricula de Nuestras Interface a nivel de repository
        IProductoRepository ProductoRepository { get; }
        IPersonaRepository PersonaRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}

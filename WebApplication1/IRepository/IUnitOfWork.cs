using System;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.IRepository
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<Country> Countries { get; }
        IGenericRepository<Club> Clubs { get; }
        Task Save();
    }
}

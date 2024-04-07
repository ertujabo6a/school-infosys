using Microsoft.EntityFrameworkCore;

namespace ICS.DAL.UnitOfWork;

public interface IUnitOfWorkFactory
{
    public IUnitOfWork Create();
}

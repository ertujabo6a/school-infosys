using Microsoft.EntityFrameworkCore;

namespace ICS.DAL.UnitOfWork;

public interface IUnitOfWorkFactory
{
    IUnitOfWork Create();
}

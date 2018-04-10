using Microsoft.EntityFrameworkCore;
namespace Business.Interfaces {
    interface IEntityTable <T> where T : class
    {
        DbSet<T> Table { get; }

    }
}
using System;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Business.Base
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
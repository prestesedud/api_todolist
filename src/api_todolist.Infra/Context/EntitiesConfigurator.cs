using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_todolist.Infra.Context
{
    public static class EntitiesConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new UserMap());

        }
    }
}

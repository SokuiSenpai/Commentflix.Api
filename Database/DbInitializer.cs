using Commentflix.Api.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commentflix.Api.Database
{
    public class DbInitializer
    {
        public static void Initialize(DBConnection context)
        {
            context.Database.EnsureCreated();
        }
    }
}

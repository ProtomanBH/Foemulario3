using Foemulario3.Server.Data;
using System;

namespace Foemulario3.Server.Controllers
{
    internal class ApplicationDbController
    {
        public object Usuarios { get; internal set; }

        public static implicit operator ApplicationDbController(ApplicationDbContext v)
        {
            throw new NotImplementedException();
        }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
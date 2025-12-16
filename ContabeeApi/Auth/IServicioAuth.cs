using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabeeApi.Auth
{
    public interface IServicioAuth
    {
        Task<bool> AsegurarSesionValidaAsync();
    }
}

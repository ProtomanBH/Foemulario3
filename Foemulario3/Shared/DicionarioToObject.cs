using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foemulario3.Shared
{
    public static class DicionarioToObject
    {
        public static Usuario DictionaryToUsuario(Usuario usuario, IDictionary<string, object> value)
        {

            if (usuario == null)
            {
                usuario = new Usuario();
            }

            foreach (string field in value.Keys)
            {
                switch (field)
                {
                    case "Id":
                        usuario.Id = (int)value[nameof(Usuario.Id)];
                        break;
                    
                    case "Nome":
                        usuario.Nome = (string)value[nameof(Usuario.Nome)];
                        break;
                    case "Idade":
                        usuario.Idade = (int)value[nameof(Usuario.Idade)];
                        break;
                    
                }
            }
            return usuario;
        }        
    }
}
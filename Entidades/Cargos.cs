using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecto_Aplicada1.Entidades
{
    public class Cargos
    {
        [Key]
        public int CargosId { get; set; }
        public String Descripcion { get; set; }

        public Cargos()
        {
            CargosId = 0;
            Descripcion = String.Empty;
        }
    }


}

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionDAM.Modelos
{
    public class Emisor
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string nifcif {  get; set; } 

        public string nombreComercial { get; set; }

        public int nextNumFac {  get; set; }

        public Emisor ()
        {
            id = -1;
        }

        public void ActualizarEmisor(BindingSource aBs)
        {
            DataRowView? row = aBs?.Current as DataRowView;

            Debug.Assert(row != null, "El BindingSource no tiene una fila actual válida");

            if (row == null) return;
            {
                nombre = row["nombre"].ToString();
                apellidos = row["apellido"].ToString();
                nifcif = row["nifcif"].ToString();
                nombreComercial = row["nombrecomercial"].ToString();
                nextNumFac = Convert.ToInt32(row["nextnumfac"]);
            }
        }
    }
}

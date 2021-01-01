using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego_DINT
{
    class Pelicula
    {
        string titulo { get; set; }
        string pista { get; set; }
        string imagen { get; set; }
        bool facil { get; set; }
        bool normal { get; set; }
        bool dificil { get; set; }
        string genero { get; set; }

        public Pelicula() { }

        public Pelicula(string titulo, string pista, string imagen, bool facil, bool normal,bool dificil, string genero)
        {
            this.titulo = titulo;
            this.pista = pista;
            this.imagen = imagen;
            this.facil = facil;
            this.normal = normal;
            this.dificil = dificil;
            this.genero = genero;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego_DINT
{
    class Pelicula
    {
        public enum Genero 
        {
            Comedia,Miedo, Accion, Misterio
        }
        string titulo { get; set; }
        string pista { get; set; }
        string imagen { get; set; }
        bool facil { get; set; }
        bool normal { get; set; }
        bool dificil { get; set; }
        Genero genero { get; set; }

        public Pelicula() { }

        public Pelicula(string titulo, string pista, string imagen, bool facil, bool normal,bool dificil, Genero genero)
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

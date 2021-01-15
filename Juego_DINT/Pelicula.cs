using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego_DINT
{
    class Pelicula:INotifyPropertyChanged
    {
        public enum Genero 
        {
            Comedia,Miedo, Accion, Misterio
        }
        string _titulo;
        public string titulo
        {
            get { return this._titulo; }
            set
            {
                if(this._titulo != value)
                {
                    this._titulo = value;
                    this.NotifyPropertychanged("titulo");
                }
            }
        }
        string _pista;
        public string pista
        {
            get { return this._pista; }
            set
            {
                if (this._pista != value)
                {
                    this._pista = value;
                    this.NotifyPropertychanged("pista");
                }
            }
        }
        string _imagen;
        public string imagen
        {
            get { return this._imagen; }
            set
            {
                if (this._imagen != value)
                {
                    this._imagen = value;
                    this.NotifyPropertychanged("imagen");
                }
            }
        }

        bool _facil;
        public bool facil
        {
            get { return this._facil; }
            set
            {
                if (this._facil != value)
                {
                    this._facil = value;
                    this.NotifyPropertychanged("facil");
                }
            }
        }
        bool _normal;
        public bool normal
        {
            get { return this._normal; }
            set
            {
                if (this._normal != value)
                {
                    this._normal = value;
                    this.NotifyPropertychanged("normal");
                }
            }
        }
        bool _dificil;
        public bool dificil
        {
            get { return this._dificil; }
            set
            {
                if (this._dificil != value)
                {
                    this._dificil = value;
                    this.NotifyPropertychanged("dificil");
                }
            }
        }
        Genero _genero;
        public Genero genero
        {
            get { return this._genero; }
            set
            {
                if (this._genero != value)
                {
                    this._genero = value;
                    this.NotifyPropertychanged("genero");
                }
            }
        }
        int _puntuacion;
        public int puntuacion
        {
            get { return this._puntuacion; }
            set
            {
                if (this._puntuacion != value)
                {
                    this._puntuacion = value;
                    this.NotifyPropertychanged("puntuacion");
                }
            }
        }


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

            if (facil == true) puntuacion = 10;
            else if (normal == true) puntuacion = 6;
            else puntuacion = 4;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertychanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }
    }
}

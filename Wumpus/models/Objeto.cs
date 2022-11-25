using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wumpus.models
{
    public class Objeto
    {
        int _tipo;
        int _posx;
        int _posy;
        string _nombre;
        Tipo _tipoEnum= new Tipo();
        Image _image;
        bool _vivo=true;

        public Objeto() { }

        public int Tipo { get => _tipo; set => _tipo = value; }

        public int Posx { get => _posx; set => _posx = value; }
        public int Posy { get => _posy; set => _posy = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public Tipo TipoEnum { get => _tipoEnum; set => _tipoEnum = value; }
        public Image Image { get => _image; set => _image = value; }
        public bool Vivo { get => _vivo; set => _vivo = value; }
    }
}

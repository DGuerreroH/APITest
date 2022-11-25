using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wumpus.models
{
    public class Informacion
    {
        
        List<Objeto> _objList =new List<Objeto>();
        //int _posX;
        //int _posY;
        
        public Informacion() { }

        public List<Objeto> ObjList { get => _objList; set => _objList = value; }
        //public int PosX { get => _posX; set => _posX = value; }
        //public int PosY { get => _posY; set => _posY = value; }
    }
}

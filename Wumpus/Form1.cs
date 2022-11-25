using System.Drawing.Drawing2D;
using Wumpus.models;

namespace Wumpus
{
    public partial class Form1 : Form
    {
        Button[,] button;
        int posX = 0;
        int posY=0;
        int angule = 0;
        int size = 0;
        int vidas = 2;
        int puntos = 0;
        int flechas = 1;
        Informacion info;
        int wumpus = 1;
        int pozos = 1;
        int oro = 3;
        int oro_encontrado=0;
        string pathImage = "";
        public Form1()
        {
            InitializeComponent();
            Console.WriteLine("Iniciando");
            pathImage = Environment.CurrentDirectory + "/resources";
            size = inicialSize();

            

            
            //int ancho, alto;
            int sizeButton =90;
            tableroP.Height= sizeButton*size;
            tableroP.Width = sizeButton * size;                
            button= new Button[size,size];
            info = generate();
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    button[x, y] = new Button();

                    //button[x, y].Text = x + "," + y;
                    button[x, y].Height = sizeButton;
                    button[x, y].Width = sizeButton;
                    button[x, y].Top = x * sizeButton;
                    button[x, y].Left = y * sizeButton;
                    //if (x == posX && y == posY)
                    //{
                    //    button[x, y].BackgroundImage = Image.FromFile(@"C:\Users\diego\OneDrive\Documentos\C# proyects\Wumpus\Wumpus\resources\character.png");
                    //}
                    foreach (Objeto element in info.ObjList)
                    {
                        if (element.Posx == x && element.Posy == y && element.Tipo!=6)
                        {
                            string texto = button[x, y].Text;
                            button[x, y].Text = texto +" "+ element.Nombre;                            

                        }
                        if (x == posX && y == posY)
                        {
                            button[x, y].BackgroundImage = Image.FromFile(pathImage + "/character.png");

                        }
                    }



                    tableroP.Controls.Add(button[x, y]);
                }
            }

            bool isInside=insideMatriz(posX, posY+1);

            

        }
        public int inicialSize() {
            string tablero;
            bool ok;
            int num=0;
            do
            {
                tablero= Microsoft.VisualBasic.Interaction.InputBox(
                "Ingresa numero de tablero",
                "Elige un numero del 5 al 10",
                "");                
                ok=int.TryParse(tablero, out num);
                if (ok) {
                    if ((num >= 5) && (num <= 10))
                    {

                    }
                    else
                    {
                        ok = false;
                    }
                }     

            } while (!ok);
            
            return Convert.ToInt32(tablero);
        }
        public bool insideMatriz(int posx,int posy)
        {
            return posx >= 0 && posx < button.GetLength(0)
                && posy >= 0 && posy < button.GetLength(1);

        }
        public bool checkUnique(int x, int y,int tipo)
        {
            bool ok = true;
            //Chequea que no inicie en donde esta el aventurero
            if (posX == x && posY == y) {
                ok = false;
            }
            foreach(Objeto obj in info.ObjList)
            {
                if(obj.Posx==x && obj.Posy==y)
                {
                    ok = false;                    
                }
            }
            return ok;
        }
        public bool checkComplement(int x, int y, int tipo)
        {
            bool ok = true;
            //Chequea que no inicie en donde esta el aventurero            
            foreach (Objeto obj in info.ObjList)
            {
                if (obj.Posx == x && obj.Posy == y)
                {              
                    if(obj.Tipo==1 || obj.Tipo == 2 || obj.Tipo == 6) {
                        ok = false;
                    }
                    //else {
                    //    ok = true;
                    //}
                }
                //else
                //{
                //    ok = true;
                //}
            }
            return ok;
        }
        public Informacion generate(){
            
            info = new Informacion();
            posX = generateRandomNumber();
            posY = generateRandomNumber();

            Objeto objCharacter = new Objeto();            
            objCharacter.Posx = posX;
            objCharacter.Posy = posY;            
            objCharacter.Nombre = "Personaje";
            objCharacter.TipoEnum = Tipo.Personaje;
            objCharacter.Tipo = 6;
            Image imageCharacter = Image.FromFile(pathImage+"/character.png");
            objCharacter.Image = imageCharacter;
            info.ObjList.Add(objCharacter);

            for (int i=0; i < wumpus; i++) {                
                Objeto obj = new Objeto();
                Tipo tipo = new Tipo();
                bool ok;
                do
                {
                    obj.Posx = generateRandomNumber();
                    obj.Posy = generateRandomNumber();
                    //code block
                    ok = checkUnique(obj.Posx, obj.Posy, 0);

                } while (!ok);
                obj.Nombre = "Wumpus";
                obj.TipoEnum = Tipo.Wumpus;
                obj.Tipo = 1;
                Image image= Image.FromFile(pathImage+"/wumpus.png");
                obj.Image = image;
                info.ObjList.Add(obj);
                

            }
            for (int i = 0; i < pozos; i++)
            {
                
                Objeto obj = new Objeto();
                Tipo tipo = new Tipo();
                bool ok;
                do
                {
                    obj.Posx = generateRandomNumber();
                    obj.Posy = generateRandomNumber();
                    //code block
                    ok = checkUnique(obj.Posx, obj.Posy, 0);

                } while (!ok);
                obj.Nombre = "Pozo";
                obj.Tipo = 2;
                obj.TipoEnum = Tipo.Pozo;
                Image image = Image.FromFile(@"C:\Users\diego\OneDrive\Documentos\C# proyects\Wumpus\Wumpus\resources\hole.jpg");
                obj.Image = image;
                info.ObjList.Add(obj);
                

            }
            //List<Informacion> temp = new List<Informacion>();


            //foreach (Informacion element in info)
            //{
            //    temp.Add(element);

            //}
            int counter = info.ObjList.Count;
            for(int x=0;x<counter;x++)
            {
                if (info.ObjList[x].Tipo == 1)
                {                    
                    addHedor(info.ObjList[x].Posx, info.ObjList[x].Posy);
                }
                if (info.ObjList[x].Tipo == 2)
                {
                    addViento(info.ObjList[x].Posx, info.ObjList[x].Posy);

                }

            }
            //mapeando oros
            for (int x = 0; x < oro; x++)
            {
                Objeto obj2 = new Objeto();
                obj2.Posx = posX - 1;
                obj2.Posy = posY;
                Tipo tipo = new Tipo();
                obj2.Nombre = "Oro";
                obj2.Tipo = 5;
                obj2.TipoEnum = Tipo.Oro;
                Image image2 = Image.FromFile(pathImage+"/gold.png");
                obj2.Image = image2;
                bool ok;
                do
                {
                    obj2.Posx = generateRandomNumber();
                    obj2.Posy = generateRandomNumber();
                    //code block
                    ok = checkComplement(obj2.Posx, obj2.Posy, 0);

                } while (!ok);                
                info.ObjList.Add(obj2);
                

            }





            return info;
        }
        public void addHedor(int posX, int posY)
        {
            bool okarriba = insideMatriz(posX - 1, posY); //arriba
            bool okabajo = insideMatriz(posX + 1, posY); //abajo
            bool okizquierda = insideMatriz(posX, posY - 1); //izquieda
            bool okderecha = insideMatriz(posX, posY + 1); //derecha

            Informacion temp = new Informacion();


            foreach (Objeto element in info.ObjList)
            {
                temp.ObjList.Add(element);

            }
            // arriba
            
            Objeto obj2 = new Objeto();
            obj2.Posx = posX - 1;
            obj2.Posy = posY;
            Tipo tipo = new Tipo();
            obj2.Nombre = "Hedor";
            obj2.Tipo = 3;
            obj2.TipoEnum = Tipo.Hedor;
            Image image2 = Image.FromFile(pathImage+"/poop.png");
            obj2.Image = image2;
            if (checkComplement(obj2.Posx, obj2.Posy,0))
            {
                info.ObjList.Add(obj2);
            }
            
            //abajo
            Objeto obj3 = new Objeto();
            obj3.Posx = posX + 1;
            obj3.Posy = posY;
            Tipo tipo2 = new Tipo();
            obj3.Nombre = "Hedor";
            obj3.Tipo = 3;
            obj3.TipoEnum = Tipo.Hedor;
            Image image3 = Image.FromFile(pathImage+"/poop.png");
            obj3.Image = image3;
        //informacion.ObjList.Add(obj2);
        
            if (checkComplement(obj3.Posx, obj3.Posy, 0))
            {
                info.ObjList.Add(obj3);
            }

            // izquierda
            Objeto obj4 = new Objeto();
            obj4.Posx = posX;
            obj4.Posy = posY - 1;            
            obj4.Nombre = "Hedor";
            obj4.Tipo = 3;
            obj4.TipoEnum = Tipo.Hedor;
            Image image4 = Image.FromFile(pathImage+"/poop.png");
            obj4.Image = image4;
            info.ObjList.Add(obj4);

            if (checkComplement(obj4.Posx, obj4.Posy, 0))
            {
                info.ObjList.Add(obj4);
            }
            //derecha

            Objeto obj5 = new Objeto();
            obj5.Posx = posX;
            obj5.Posy = posY + 1;            
            obj5.Nombre = "Hedor";
            obj5.Tipo = 3;
            obj5.TipoEnum = Tipo.Hedor;
            Image image5 = Image.FromFile(pathImage+"/poop.png");
            obj5.Image = image5;
            info.ObjList.Add(obj5);
            if (checkComplement(obj5.Posx, obj5.Posy, 0))
            {
                info.ObjList.Add(obj5);
            }


            //    }
            //}
            //else
            //{
            //    Informacion informacion = new Informacion();
            //    Objeto obj2 = new Objeto();
            //    obj.Posx = posX - 1;
            //    obj.Posy = posY;
            //    Tipo tipo = new Tipo();
            //    obj2.Nombre = "Hedor";
            //    obj2.Tipo = 3;
            //    obj2.TipoEnum = Tipo.Hedor;
            //    Image image = Image.FromFile(pathImage+"/poop.png");
            //    obj2.Image = image;
            //    info.ObjList.Add(obj2);


            //}
            //    if (element.PosX == posX + 1 && element.PosY == posY)
            //    {
            //        if (obj.Tipo != 2)
            //        {




            //        }

            //    }
            //    else
            //    {
            //        Informacion informacion = new Informacion();
            //        informacion.PosX = posX + 1;
            //        informacion.PosX = element.PosY;
            //        Objeto obj2 = new Objeto();
            //        Tipo tipo = new Tipo();
            //        obj2.Nombre = "Hedor";
            //        obj2.Tipo = 3;
            //        obj2.TipoEnum = Tipo.Hedor;
            //        Image image = Image.FromFile(pathImage+"/poop.png");
            //        obj2.Image = image;
            //        informacion.ObjList.Add(obj2);
            //        info.Add(informacion);
            //    }
            //    if (element.PosX == posX && element.PosY - 1 == posY)
            //    {
            //        if (obj.Tipo != 2)
            //        {
            //            Informacion informacion = new Informacion();
            //            informacion.PosX = posX;
            //            informacion.PosX = element.PosY - 1;
            //            Objeto obj2 = new Objeto();
            //            Tipo tipo = new Tipo();
            //            obj2.Nombre = "Hedor";
            //            obj2.Tipo = 3;
            //            obj2.TipoEnum = Tipo.Hedor;
            //            Image image = Image.FromFile(pathImage+"/poop.png");
            //            obj2.Image = image;
            //            informacion.ObjList.Add(obj2);
            //            info.Add(informacion);

            //        }

            //    }
            //    else
            //    {
            //        Informacion informacion = new Informacion();
            //        informacion.PosX = posX;
            //        informacion.PosX = element.PosY - 1;
            //        Objeto obj2 = new Objeto();
            //        Tipo tipo = new Tipo();
            //        obj2.Nombre = "Hedor";
            //        obj2.Tipo = 3;
            //        obj2.TipoEnum = Tipo.Hedor;
            //        Image image = Image.FromFile(pathImage+"/poop.png");
            //        obj2.Image = image;
            //        informacion.ObjList.Add(obj2);
            //        info.Add(informacion);
            //    }
            //    if (element.PosX == posX && element.PosY + 1 == posY)
            //    {
            //        if (obj.Tipo != 2)
            //        {
            //            Informacion informacion = new Informacion();
            //            informacion.PosX = posX;
            //            informacion.PosX = element.PosY + 1;
            //            Objeto obj2 = new Objeto();
            //            Tipo tipo = new Tipo();
            //            obj2.Nombre = "Hedor";
            //            obj2.Tipo = 3;
            //            obj2.TipoEnum = Tipo.Hedor;
            //            Image image = Image.FromFile(pathImage+"/poop.png");
            //            obj2.Image = image;
            //            informacion.ObjList.Add(obj2);
            //            info.Add(informacion);

            //        }

            //    }
            //    else
            //    {
            //        Informacion informacion = new Informacion();
            //        informacion.PosX = posX;
            //        informacion.PosX = element.PosY + 1;
            //        Objeto obj2 = new Objeto();
            //        Tipo tipo = new Tipo();
            //        obj2.Nombre = "Hedor";
            //        obj2.Tipo = 3;
            //        obj2.TipoEnum = Tipo.Hedor;
            //        Image image = Image.FromFile(pathImage+"/poop.png");
            //        obj2.Image = image;
            //        informacion.ObjList.Add(obj2);
            //        info.Add(informacion);
            //    }


            //}




            Console.WriteLine(info);



            
        }

        public void addViento(int posX, int posY)
        {
            bool okarriba = insideMatriz(posX - 1, posY); //arriba
            bool okabajo = insideMatriz(posX + 1, posY); //abajo
            bool okizquierda = insideMatriz(posX, posY - 1); //izquieda
            bool okderecha = insideMatriz(posX, posY + 1); //derecha

            Informacion temp = new Informacion();

            // arriba

            Objeto obj2 = new Objeto();
            obj2.Posx = posX - 1;
            obj2.Posy = posY;
            Tipo tipo = new Tipo();
            obj2.Nombre = "Viento";
            obj2.Tipo = 4;
            obj2.TipoEnum = Tipo.Viento;
            Image image2 = Image.FromFile(pathImage+"/wind.png");
            obj2.Image = image2;
            if (checkComplement(obj2.Posx, obj2.Posy, 0))
            {
                info.ObjList.Add(obj2);
            }

            //abajo
            Objeto obj3 = new Objeto();
            obj3.Posx = posX + 1;
            obj3.Posy = posY;
            //Tipo tipo2 = new Tipo();
            obj3.Nombre = "Viento";
            obj3.Tipo = 4;
            obj3.TipoEnum = Tipo.Viento;
            Image image3 = Image.FromFile(pathImage+"/wind.png");
            obj3.Image = image3;
            //informacion.ObjList.Add(obj2);

            if (checkComplement(obj3.Posx, obj3.Posy, 0))
            {
                info.ObjList.Add(obj3);
            }

            // izquierda
            Objeto obj4 = new Objeto();
            obj4.Posx = posX;
            obj4.Posy = posY - 1;
            obj4.Nombre = "Viento";
            obj4.Tipo = 4;
            obj4.TipoEnum = Tipo.Viento;
            Image image4 = Image.FromFile(pathImage+"/wind.png");
            obj4.Image = image4;
            info.ObjList.Add(obj4);

            if (checkComplement(obj4.Posx, obj4.Posy, 0))
            {
                info.ObjList.Add(obj4);
            }
            //derecha

            Objeto obj5 = new Objeto();
            obj5.Posx = posX;
            obj5.Posy = posY + 1;
            obj5.Nombre = "Viento";
            obj5.Tipo = 4;
            obj5.TipoEnum = Tipo.Viento;
            Image image5 = Image.FromFile(pathImage+"/wind.png");
            obj5.Image = image5;
            info.ObjList.Add(obj5);
            if (checkComplement(obj5.Posx, obj5.Posy, 0))
            {
                info.ObjList.Add(obj5);
            }


            //    }
            //}
            //else
            //{
            //    Informacion informacion = new Informacion();
            //    Objeto obj2 = new Objeto();
            //    obj.Posx = posX - 1;
            //    obj.Posy = posY;
            //    Tipo tipo = new Tipo();
            //    obj2.Nombre = "Hedor";
            //    obj2.Tipo = 3;
            //    obj2.TipoEnum = Tipo.Hedor;
            //    Image image = Image.FromFile(pathImage+"/poop.png");
            //    obj2.Image = image;
            //    info.ObjList.Add(obj2);


            //}
            //    if (element.PosX == posX + 1 && element.PosY == posY)
            //    {
            //        if (obj.Tipo != 2)
            //        {




            //        }

            //    }
            //    else
            //    {
            //        Informacion informacion = new Informacion();
            //        informacion.PosX = posX + 1;
            //        informacion.PosX = element.PosY;
            //        Objeto obj2 = new Objeto();
            //        Tipo tipo = new Tipo();
            //        obj2.Nombre = "Hedor";
            //        obj2.Tipo = 3;
            //        obj2.TipoEnum = Tipo.Hedor;
            //        Image image = Image.FromFile(pathImage+"/poop.png");
            //        obj2.Image = image;
            //        informacion.ObjList.Add(obj2);
            //        info.Add(informacion);
            //    }
            //    if (element.PosX == posX && element.PosY - 1 == posY)
            //    {
            //        if (obj.Tipo != 2)
            //        {
            //            Informacion informacion = new Informacion();
            //            informacion.PosX = posX;
            //            informacion.PosX = element.PosY - 1;
            //            Objeto obj2 = new Objeto();
            //            Tipo tipo = new Tipo();
            //            obj2.Nombre = "Hedor";
            //            obj2.Tipo = 3;
            //            obj2.TipoEnum = Tipo.Hedor;
            //            Image image = Image.FromFile(pathImage+"/poop.png");
            //            obj2.Image = image;
            //            informacion.ObjList.Add(obj2);
            //            info.Add(informacion);

            //        }

            //    }
            //    else
            //    {
            //        Informacion informacion = new Informacion();
            //        informacion.PosX = posX;
            //        informacion.PosX = element.PosY - 1;
            //        Objeto obj2 = new Objeto();
            //        Tipo tipo = new Tipo();
            //        obj2.Nombre = "Hedor";
            //        obj2.Tipo = 3;
            //        obj2.TipoEnum = Tipo.Hedor;
            //        Image image = Image.FromFile(pathImage+"/poop.png");
            //        obj2.Image = image;
            //        informacion.ObjList.Add(obj2);
            //        info.Add(informacion);
            //    }
            //    if (element.PosX == posX && element.PosY + 1 == posY)
            //    {
            //        if (obj.Tipo != 2)
            //        {
            //            Informacion informacion = new Informacion();
            //            informacion.PosX = posX;
            //            informacion.PosX = element.PosY + 1;
            //            Objeto obj2 = new Objeto();
            //            Tipo tipo = new Tipo();
            //            obj2.Nombre = "Hedor";
            //            obj2.Tipo = 3;
            //            obj2.TipoEnum = Tipo.Hedor;
            //            Image image = Image.FromFile(pathImage+"/poop.png");
            //            obj2.Image = image;
            //            informacion.ObjList.Add(obj2);
            //            info.Add(informacion);

            //        }

            //    }
            //    else
            //    {
            //        Informacion informacion = new Informacion();
            //        informacion.PosX = posX;
            //        informacion.PosX = element.PosY + 1;
            //        Objeto obj2 = new Objeto();
            //        Tipo tipo = new Tipo();
            //        obj2.Nombre = "Hedor";
            //        obj2.Tipo = 3;
            //        obj2.TipoEnum = Tipo.Hedor;
            //        Image image = Image.FromFile(pathImage+"/poop.png");
            //        obj2.Image = image;
            //        informacion.ObjList.Add(obj2);
            //        info.Add(informacion);
            //    }


            //}









        }
        //Coloca la advertencia visible al jugador
        public void navegacion()
        {
            string aviso="";
            
            foreach (Objeto item in info.ObjList)
            {
                if (item.Posx==posX && item.Posy==posY && item.Tipo==3)//Casilla de viento
                {
                    aviso += "Sientes un mal holor...\n";
                    
                }
                else if (item.Posx == posX && item.Posy == posY && item.Tipo == 4)//Casilla de mal olor
                {
                    aviso += "Sientes una brisa...\n";

                }
                else if (item.Posx == posX && item.Posy == posY && item.Tipo == 2)//Casilla de hoyo
                {
                    aviso += "Has caido en el pozo!";
                    MessageBox.Show(aviso);
                    if (vidas > 0) 
                    { 
                        vidas--;
                        txtVidas.Text=vidas.ToString();
                        //generate()
                        if (vidas == 0){
                            MessageBox.Show($"Fin del Juego{Environment.NewLine} Puntaje final: {puntos}");
                            Application.Exit();
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Fin del Juego{Environment.NewLine} Puntaje final: {puntos}");
                        Application.Exit();

                    }

                }
                else if (item.Posx == posX && item.Posy == posY && item.Tipo == 5)//Casilla de oro
                {
                    aviso += "Encontraste oro!";
                    puntos += 500;
                    item.Tipo = 0;
                    oro_encontrado++;
                    if (oro_encontrado == oro)
                    {
                        MessageBox.Show("GANASTE");
                    }


                }
                else if (item.Posx == posX && item.Posy == posY && item.Tipo == 1  && item.Vivo)
                {
                    aviso += $"Has encontrado un Wumpus!";
                    int pelea = generateRandomNumber(101);
                    if (flechas>0&&pelea>49)
                    {
                        aviso += $"Venciste!";
                        puntos += 1200;
                        item.Tipo = 0;

                    }
                    else
                    {
                        aviso += "Has muerto!";
                        if (vidas > 0)
                        {
                            vidas--;
                            txtVidas.Text = vidas.ToString();
                            //InitializeComponent();
                            if (vidas == 0)
                            {
                                MessageBox.Show($"Fin del Juego{Environment.NewLine} Puntaje final: {puntos}");
                                Application.Exit();
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Fin del Juego{Environment.NewLine} Puntaje final: {puntos}");
                            Application.Exit();
                        }
                    }
                }
            }
            txtAviso.Text = aviso;
            txtPunteo.Text = $"Punteo: {puntos}";
        }
        public void disparo()
        {
            if (flechas>0)
            {

            }
        }
        public int generateRandomNumber()
        {
            Random rnd = new Random();
            return rnd.Next(0, size); // returns random integers >= 10 and < 19
            
        }
        public int generateRandomNumber(int max)
        {
            Random rnd = new Random();
            return rnd.Next(0, max);

        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            bool isInside = insideMatriz(posX - 1, posY);
            if (isInside)
            {

                button[posX, posY].BackgroundImage = null;
                button[posX - 1, posY].BackgroundImage = Image.FromFile(pathImage+"/character.png");
                posX--;
                angule = 0;

            }
            else
            {
                MessageBox.Show("Error no te puedes salir");
            }
            navegacion();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {

            bool isInside = insideMatriz(posX + 1, posY );
            if (isInside)
            {

                button[posX, posY].BackgroundImage = null;
                button[posX + 1, posY ].BackgroundImage = Image.FromFile(pathImage+"/character.png");
                posX++;
                angule = 0;

            }
            else
            {
                MessageBox.Show("Error no te puedes salir");
            }
            navegacion();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {

            bool isInside = insideMatriz(posX, posY -1);
            if (isInside)
            {

                button[posX, posY].BackgroundImage = null;
                button[posX, posY -1].BackgroundImage = Image.FromFile(pathImage + "/character.png");
                posY--;
                angule = 0;

            }
            else
            {
                MessageBox.Show("Error no te puedes salir");
            }
            navegacion();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {

            bool isInside = insideMatriz(posX, posY + 1);
            if (isInside)
            {

                button[posX, posY].BackgroundImage = null;
                button[posX, posY + 1].BackgroundImage = Image.FromFile(pathImage+"/character.png");
                posY++;
                angule = 0;

            }
            else
            {
                MessageBox.Show("Error no te puedes salir");
            }
            navegacion();
        }
        public static Image rotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }
        public static Bitmap RotateImg(Bitmap bmp, float angle)

        {

            int w = bmp.Width;

            int h = bmp.Height;

            Bitmap tempImg = new Bitmap(w, h);

            Graphics g = Graphics.FromImage(tempImg);

            g.DrawImageUnscaled(bmp, 1, 1);

            g.Dispose();

            GraphicsPath path = new GraphicsPath();

            path.AddRectangle(new RectangleF(0f, 0f, w, h));

            Matrix mtrx = new Matrix();

            mtrx.Rotate(angle);

            RectangleF rct = path.GetBounds(mtrx);

            Bitmap newImg = new Bitmap(Convert.ToInt32(rct.Width), Convert.ToInt32(rct.Height));

            g = Graphics.FromImage(newImg);

            g.TranslateTransform(-rct.X, -rct.Y);

            g.RotateTransform(angle);

            g.InterpolationMode = InterpolationMode.HighQualityBilinear;

            g.DrawImageUnscaled(tempImg, 0, 0);

            g.Dispose();

            tempImg.Dispose();

            return newImg;

        }
        private void btnRotate_Click(object sender, EventArgs e)
        {
            string path="";
            angule = angule + 90;
            if (angule>359)
            {
                angule = 0;
            }
            if (angule == 90) { path = pathImage+"/character90.png"; }
            if (angule == 180) { path = pathImage+"/character180.png"; }
            if (angule == 270) { path = pathImage+"/character270.png"; }
            if (angule == 0) { path = pathImage+"/character.png"; }
            Image image1 = Image.FromFile(path);
            //Image ima = rotateImage(image1, 75);
            //int da=image1.Height;
            //int fdsf = image1.Width;
            button[posX, posY].BackgroundImage= null;
            button[posX, posY].BackgroundImage = image1;
            
            if (angule == 360) { angule = 0; }
             



        }

        private void btnDisparar_Click(object sender, EventArgs e)
        {
            bool mato = false;
            txtFlecha.Text = "0";
            if (flechas > 0) {
                if (angule == 0 && flechas > 0)
                {
                    int counter = size - (posY);
                    ;
                    foreach (Objeto item in info.ObjList)
                    {
                        if (item.Tipo == 1)
                        {
                            for (int i = 0; i < counter; i++)
                            {

                                if (posY + i == item.Posy && (item.Posx == posX))
                                {
                                    mato = true;
                                    item.Vivo = false;
                                }
                            }
                        }
                    }
                }
                if (angule == 90 && flechas > 0)
                {
                    int counter = posX;
                    ;
                    foreach (Objeto item in info.ObjList)
                    {
                        if (item.Tipo == 1)
                        {
                            for (int i = 0; i < counter; i++)
                            {

                                if (posY == item.Posy && (item.Posx == posX - i))
                                {
                                    mato = true;
                                    item.Vivo = false;
                                }
                            }
                        }
                    }
                }
                if (angule == 180 && flechas > 0)
                {
                    int counter = posY;

                    counter = counter - 1;
                    foreach (Objeto item in info.ObjList)
                    {
                        if (item.Tipo == 1)
                        {
                            for (int i = 0; i < counter; i++)
                            {

                                if (posY - i == item.Posy && (item.Posx == posX))
                                {
                                    mato = true;
                                    item.Vivo = false;
                                }
                            }
                        }
                    }
                }
                if (angule == 270 && flechas > 0)
                {
                    int counter = size - posX;


                    foreach (Objeto item in info.ObjList)
                    {
                        if (item.Tipo == 1)
                        {
                            for (int i = 0; i < counter; i++)
                            {

                                if (posX + i == item.Posx && (item.Posy == posY))
                                {
                                    mato = true;
                                    item.Vivo = false;
                                }
                            }
                        }
                    }
                }
                if (mato)
                {
                    MessageBox.Show("Mato al wumpus");
                }
                else
                {
                    MessageBox.Show("Tiro fallido");
                }
                flechas = 0;
            }
            else
            {
                MessageBox.Show("Ya no tiene flechas");
            }
            
            
            
        }
    }
}
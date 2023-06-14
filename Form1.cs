using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace TrabajoFinalPruebas
{
    public partial class Form1 : Form
    {
        private int casillerosRestantesVerdes;
        int posicionVerdeIndex;
        private Random dadoAleatorio;
        private List<Image> imagenesDado;
        private bool estaGirando;
        private bool movimientoInicio;
        private bool juegoIniciado;


        private List<Point> coordenadasCasillerosAzules = new List<Point>
        {
            new Point(983, 284), //casillero azul
            new Point(912, 284),
            new Point(841, 284),
            new Point(769, 283),
            new Point(698, 284),
            new Point(627, 316),
            new Point(627, 349),
            new Point(628, 382),
            new Point(627, 414),
            new Point(626, 446),
            new Point(626, 479),
            new Point(556, 480),
            new Point(484, 479),
            new Point(481, 447), // casillero amarillo
            new Point(482, 414),
            new Point(482, 382),
            new Point(482, 349),
            new Point(482, 316),
            new Point(412, 283),
            new Point(341, 283),
            new Point(269, 283),
            new Point(197, 283),
            new Point(125, 283),
            new Point(53, 283),
            new Point(53, 251),
            new Point(53, 217),
            new Point(126, 217),  // casillero verde
            new Point(197, 217),
            new Point(269, 217),
            new Point(340, 217),
            new Point(410, 217),
            new Point(482, 185),
            new Point(482, 153),
            new Point(482, 120),
            new Point(482, 87),
            new Point(482, 54),
            new Point(482, 22),
            new Point(553, 21),
            new Point(625, 21),
            new Point(626, 54),
            new Point(626, 87),
            new Point(626, 120),
            new Point(626, 152),
            new Point(626, 184),
            new Point(698, 218),
            new Point(769, 217),
            new Point(842, 218),
            new Point(912, 218),
            new Point(984, 218),
            new Point(1055, 218),
            new Point(1055, 250),
            new Point(983 , 250), // casilleros finales
            new Point(913 , 250),
            new Point(840 , 250),
            new Point(770 , 250),
            new Point(700 , 250),
            new Point(634 , 250), // casillero para sumar puntos
        };

        private List<Point> coordenadasCasillerosAmarillos = new List<Point>
        {
            new Point(481, 447), // casillero amarillo
            new Point(482, 414),
            new Point(482, 382),
            new Point(482, 349),
            new Point(482, 316),
            new Point(412, 283),
            new Point(341, 283),
            new Point(269, 283),
            new Point(197, 283),
            new Point(125, 283),
            new Point(53, 283),
            new Point(53, 251),
            new Point(53, 217),
            new Point(126, 217),  // casillero verde
            new Point(197, 217),
            new Point(269, 217),
            new Point(340, 217),
            new Point(410, 217),
            new Point(482, 185),
            new Point(482, 153),
            new Point(482, 120),
            new Point(482, 87),
            new Point(482, 54),
            new Point(482, 22),
            new Point(553, 21),
            new Point(626, 21),
            new Point(626, 54),
            new Point(626, 87),
            new Point(626, 120),
            new Point(626, 152),
            new Point(626, 184),
            new Point(698, 218),
            new Point(769, 217),
            new Point(842, 218),
            new Point(912, 218),
            new Point(984, 218),
            new Point(1055, 218),
            new Point(1055, 251),
            new Point(1055, 284),
            new Point(983, 284), //casillero azul
            new Point(912, 284),
            new Point(841, 284),
            new Point(769, 283),
            new Point(698, 284),
            new Point(627, 316),
            new Point(627, 349),
            new Point(628, 382),
            new Point(627, 414),
            new Point(626, 446),
            new Point(626, 479),
            new Point(556, 480),
            new Point(556, 446), // recta final
            new Point(556, 414),
            new Point(556, 381),
            new Point(556, 349),
            new Point(556, 316),
            new Point(556, 285),
        };


        private List<Point> coordenadasCasillerosVerdes = new List<Point>
        {
            new Point(125, 217),
            new Point(199, 217),
            new Point(270, 217),
            new Point(342, 217),
            new Point(414, 217),
            new Point(483, 185),
            new Point(483, 151),
            new Point(483, 119),
            new Point(483, 88),
            new Point(483, 54),
            new Point(483, 22),
            new Point(557, 22),
            new Point(624, 22),
            new Point(625, 55),
            new Point(625, 87),
            new Point(625, 120),
            new Point(625, 153),
            new Point(625, 184),
            new Point(699, 219),
            new Point(770, 219),
            new Point(839, 219),
            new Point(912, 219),
            new Point(982, 219),
            new Point(1056, 219),
            new Point(1056, 254),
            new Point(1056, 282),
            new Point(983, 283),
            new Point(912, 283),
            new Point(840, 283),
            new Point(769, 283),
            new Point(700, 283),
            new Point(624, 315),
            new Point(624, 349),
            new Point(624, 381),
            new Point(624, 413),
            new Point(624, 446),
            new Point(627, 479),
            new Point(552, 478),
            new Point(485, 478),
            new Point(485, 446),
            new Point(485, 414),
            new Point(485, 382),
            new Point(485, 348),
            new Point(485, 315),
            new Point(411, 283),
            new Point(341, 283),
            new Point(268, 283),
            new Point(197, 283),
            new Point(128, 283),
            new Point(54, 283),
            new Point(55, 252),
            new Point(126, 252),
            new Point(199, 252),
            new Point(270, 252),
            new Point(342, 252),
            new Point(412, 252),
            new Point(469, 252), // Coordenada final donde debe llegar el boton 
        };

        private List<Point> coordenadasCasillerosRojos = new List<Point>
        {
            new Point(626, 54),
            new Point(626, 87),
            new Point(626, 120),
            new Point(626, 152),
            new Point(626, 184),
            new Point(698, 218),
            new Point(769, 217),
            new Point(842, 218),
            new Point(912, 218),
            new Point(984, 218),
            new Point(1055, 218),
            new Point(1055, 251),
            new Point(1055, 284),
            new Point(983, 284), //casillero azul
            new Point(912, 284),
            new Point(841, 284),
            new Point(769, 283),
            new Point(698, 284),
            new Point(627, 316),
            new Point(627, 349),
            new Point(628, 382),
            new Point(627, 414),
            new Point(626, 446),
            new Point(626, 479),
            new Point(556, 480),
            new Point(484, 479),
            new Point(481, 447), // casillero amarillo
            new Point(482, 414),
            new Point(482, 382),
            new Point(482, 349),
            new Point(482, 316),
            new Point(412, 283),
            new Point(341, 283),
            new Point(269, 283),
            new Point(197, 283),
            new Point(125, 283),
            new Point(53, 283),
            new Point(53, 251),
            new Point(53, 217),
            new Point(126, 217),  // casillero verde
            new Point(197, 217),
            new Point(269, 217),
            new Point(340, 217),
            new Point(410, 217),
            new Point(482, 185),
            new Point(482, 153),
            new Point(482, 120),
            new Point(482, 87),
            new Point(482, 54),
            new Point(482, 22),
            new Point(553, 21),
            new Point(553, 54), // casillero recta final
            new Point(553, 87),
            new Point(553, 119),
            new Point(553, 152),
            new Point(553, 185),
            new Point(553, 217), // casillero donde suma puntaje
        };

        public Form1()
        {
            InitializeComponent();
            IniciarDado();
            estaGirando = false;
            movimientoInicio = false;
            juegoIniciado = false;
            casillerosRestantesVerdes = coordenadasCasillerosVerdes.Count; // Inicializar la cantidad de casilleros restantes al valor total
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Establecer el tamaño del formulario
            this.Size = new Size(1158, 561);

            // Establecemos que los botones arranquen en los casilleros
            btnVerde1.Location = new Point(162, 103);
            btnVerde2.Location = new Point(234, 137);
            btnVerde3.Location = new Point(305, 103);
            btnVerde4.Location = new Point(234, 67);

            btnAmarillo1.Location = new Point(162, 394);
            btnAmarillo2.Location = new Point(234, 431);
            btnAmarillo3.Location = new Point(305, 394);
            btnAmarillo4.Location = new Point(234, 362);

            btnAzul1.Location = new Point(806, 394);
            btnAzul2.Location = new Point(875, 431);
            btnAzul3.Location = new Point(950, 394);
            btnAzul4.Location = new Point(875, 362);

            btnRojo1.Location = new Point(806, 103);
            btnRojo2.Location = new Point(875, 137);
            btnRojo3.Location = new Point(950, 103);
            btnRojo4.Location = new Point(875, 67);
        }

        private void MoverBotonVerde(int cantidadPosiciones)
        {
            if (movimientoInicio)
            {
                // Mover el botón verde al primer casillero después de obtener un 6
                btnVerde1.Location = coordenadasCasillerosVerdes[0];
                posicionVerdeIndex = 0;
                movimientoInicio = false;
            }
            else
            {
                int nuevoIndice = (posicionVerdeIndex + cantidadPosiciones) % coordenadasCasillerosVerdes.Count;
                Point nuevaPosicion = coordenadasCasillerosVerdes[nuevoIndice];

                // ---- CONTROLA QUE NO DE ERROR SI SALE NUMERO MAYOR A LA CANTIDAD DE CASILLEROS RESTANTES ----
                if (posicionVerdeIndex >= coordenadasCasillerosVerdes.Count - 1)
                {
                    // Si ya está en la recta final, no se permite mover más allá de la última posición
                    return;
                }
                if (casillerosRestantesVerdes <= cantidadPosiciones)
                {
                    if (posicionVerdeIndex + casillerosRestantesVerdes == coordenadasCasillerosVerdes.Count - 1)
                    {
                        // Si el número obtenido en el dado es exactamente el necesario para llegar a la última posición en la recta final, el peón gana
                        btnVerde1.Location = coordenadasCasillerosVerdes[coordenadasCasillerosVerdes.Count - 1];
                        btnVerde1.Enabled = false; // Desactivar el botón verde, ya no puede moverse
                        casillerosRestantesVerdes = 0; // Establecer la cantidad de casilleros restantes a cero
                                                       // Realizar las acciones correspondientes para indicar que el peón verde ha ganado
                                                       // ...
                        return;
                    }
                    else
                    {
                        // Si el número obtenido en el dado se pasa de la última posición en la recta final, no se realiza el movimiento
                        return;
                    }
                }
                // ---- HASTA ACA CONTROLA QUE NO DE ERROR SI SE PASA DE LOS CASILLEROS RESTANTES ------

                if (casillerosRestantesVerdes <= cantidadPosiciones)
                {
                    // Estamos en los últimos casilleros antes del final
                    // El jugador se queda en el final
                    btnVerde1.Location = coordenadasCasillerosVerdes[coordenadasCasillerosVerdes.Count]; // - 1
                    btnVerde1.Enabled = false; // Desactivar el botón verde, ya no puede moverse
                    casillerosRestantesVerdes = 0; // Establecer la cantidad de casilleros restantes a cero
                    return;
                }

                btnVerde1.Location = nuevaPosicion;
                posicionVerdeIndex = nuevoIndice;

                casillerosRestantesVerdes -= cantidadPosiciones; // Actualizar la cantidad de casilleros restantes
            }

        }
        private void IniciarDado()
        {
            dadoAleatorio = new Random();
            imagenesDado = new List<Image>()
            {
                Image.FromFile("ImagenesDados/Dado1.png"), // Propiedades copiar en directorio de salida: copiar siempre
                Image.FromFile("ImagenesDados/Dado2.png"),
                Image.FromFile("ImagenesDados/Dado3.png"),
                Image.FromFile("ImagenesDados/Dado4.png"),
                Image.FromFile("ImagenesDados/Dado5.png"),
                Image.FromFile("ImagenesDados/Dado6.png")
            };
        }

        private async void Dado_Click(object sender, EventArgs e)
        {
            if (!estaGirando)
            {
                estaGirando = true;

                // Generar un número aleatorio para el dado
                int num = dadoAleatorio.Next(1, 7);

                // Ejecutar la animación de giro
                await GirarDado();

                // Mostrar la nueva cara del dado
                Dado.Image = imagenesDado[num - 1];

                estaGirando = false;


                if (!juegoIniciado)
                {
                    // Comenzar el juego solo si se obtiene un 6 al inicio
                    if (num == 6)
                    {
                        movimientoInicio = true;
                        juegoIniciado = true;
                        MoverBotonVerde(num);
                    }
                }
                else
                {
                    // Mover el botón verde según el número obtenido en el dado
                    MoverBotonVerde(num);
                }
            }
        }


        private async Task GirarDado()
        {
            int frames = 15; // Cantidad de frames para la animación
            int intervalo = 30; // Intervalo de tiempo en milisegundos entre cada frame
            float anguloPorFrame = 360f / frames;

            for (int i = 0; i < frames; i++)
            {
                Dado.Image = RotarImagenDado(Dado.Image, anguloPorFrame);
                await Task.Delay(intervalo);
            }
        }

        // Método para rotar una imagen
        private Image RotarImagenDado(Image img, float angle)
        {
            Bitmap rotarImagen = new Bitmap(img.Width, img.Height);
            rotarImagen.SetResolution(img.HorizontalResolution, img.VerticalResolution);

            using (Graphics g = Graphics.FromImage(rotarImagen))
            {
                g.TranslateTransform(img.Width / 2, img.Height / 2);
                g.RotateTransform(angle);
                g.TranslateTransform(-img.Width / 2, -img.Height / 2);
                g.DrawImage(img, new Point(0, 0));
            }

            return rotarImagen;
        }

    }
}
//Método GirarDado() que realiza la animación de giro del dado utilizando un bucle for y el método
//RotateImage() para rotar la imagen gradualmente en cada iteración. La animación se logra mediante
//el uso de Task.Delay() para pausar el bucle durante un breve intervalo de tiempo entre cada
//frame.
//Cuando se hace clic en el PictureBox, se inicia la animación llamando al método GirarDado(), y
//después de completar la animación, se establece la nueva imagen del dado en función del número
//aleatorio generado.

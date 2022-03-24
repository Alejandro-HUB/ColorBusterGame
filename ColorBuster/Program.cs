using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorBuster
{
    internal static class Program
    {
        //Game variables
        public static int rows = 6;
        public static int columns = 6;
        public static int matchedTiles = 3;
        public static bool moveAvailable = true;

        //Colors
        public static List<Image> images = new List<Image>();

        //Get all the tiles
        public static List<TileModel> tileList = new List<TileModel>();
        
        //Get matched tiles
        public static List<TileModel> matchTiles = new List<TileModel>();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GameView());
        }
    }
}

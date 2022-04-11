using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ColorBuster
{
    internal class BoardModel
    {
        public static int rows { get; set; } = 6;
        public static int columns { get; set; } = 6;
        public static int matchedTiles { get; set; } = 3;
        public static int score { get; set; } = 0;
        public static int BoardWidth { get; } = 540;
        public static int BoardHeight { get; } = 540;

        //Colors
        public static List<Image> images { get; set; } = new List<Image>();
        //Pop Color Images
        public static List<Image> pop { get; set; } = new List<Image>();
        //Get all the tiles
        public static List<TileModel> tileList { get; set; } = new List<TileModel>();
        //Get matched tiles
        public static List<TileModel> matchTiles { get; set; } = new List<TileModel>();
        //List of tiles to check if there is a move avaialable
        public static List<TileModel> isMoveAvailableTileList { get; set; } = new List<TileModel>();
        //Randomize colors even more
        public static List<int> randomNoDuplicates { get; set; } = new List<int>();
    }
}

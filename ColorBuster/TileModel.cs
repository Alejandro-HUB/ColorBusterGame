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
    public class TileModel
    {
        public string Name { get; set; }
        public int xLocation { get; set; }
        public int yLocation { get; set; }
        public int imageIndex { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public PictureBox control {get; set;}
    }
}

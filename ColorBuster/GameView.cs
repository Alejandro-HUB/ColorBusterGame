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
    public partial class GameView : Form
    {
        public GameView()
        {
            InitializeComponent();
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            initBoard();
        }

        void GameView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void initBoard()
        {
            //Colors
            Program.images.Add(ColorBuster.Properties.Resources.blue);
            Program.images.Add(ColorBuster.Properties.Resources.green);
            Program.images.Add(ColorBuster.Properties.Resources.red);
            Program.images.Add(ColorBuster.Properties.Resources.yellow);

            //Tile info
            int x = 0;
            int y = 0;
            int currentImage = 0;
            int totalTiles = 0;

            Random random = new Random();

            //Make rows
            for (int j = 0; j < Program.columns; j++)
            {
                PictureBox[] tiles = new PictureBox[Program.rows];
                for (int i = 0; i < Program.rows; i++)
                {
                    tiles[i] = new PictureBox();
                    tiles[i].Visible = true;
                    tiles[i].Name = "TileData" + totalTiles.ToString();
                    tiles[i].Left = 10;
                    tiles[i].Width = 540 / Program.rows;
                    tiles[i].Height = 540 / Program.rows;
                    tiles[i].Font = new Font(label1.Font.FontFamily, label1.Font.Size - 2.5f, label1.Font.Style);
                    tiles[i].ForeColor = Color.Black;
                    tiles[i].BorderStyle = BorderStyle.Fixed3D;
                    tiles[i].BackgroundImageLayout = ImageLayout.Stretch;
                    tiles[i].Click += new EventHandler(tile_Click);

                    //Color
                    currentImage = random.Next(0, Program.images.Count);
                    tiles[i].BackgroundImage = Program.images[currentImage];

                    //Location
                    x = ((j - 1) + 1) * tiles[i].Width;
                    y = ((i - 1) + 1) * tiles[i].Height;
                    tiles[i].Location = new Point(x, y);

                    //Store location
                    var tile = new TileModel
                    {
                        Name = tiles[i].Name,
                        xLocation = x,
                        yLocation = y,
                        imageIndex = currentImage,
                    };

                    Program.tileList.Add(tile);
                    totalTiles++;
                }
                for (int k = 0; k < Program.rows; k++)
                {
                    board.Controls.Add(tiles[k]);
                }
            }
        }

        void tile_Click(object sender, EventArgs e)
        {

            foreach (var tile in Program.tileList)
            {
                if (((PictureBox)(sender)).Name == tile.Name)
                {
                    Image test = Program.images[tile.imageIndex];
                    var show = test.Palette.ToString();

                    MessageBox.Show("The tile you clicked is: " + tile.Name);
                }
            }

        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SettingsView settings = new SettingsView();
            settings.Show();
        }

        private void GameView_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(GameView_FormClosed);
            board.Width = 540;
            board.Height = 540;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
    }

}

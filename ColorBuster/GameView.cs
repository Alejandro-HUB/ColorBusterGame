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
            //Reset Board
            Program.score = 0;
            Program.tileList.Clear();
            Program.matchTiles.Clear();
            Program.isMoveAvailableTileList.Clear();
            board.Controls.Clear();
            Program.images.Clear();
            Program.pop.Clear();
            this.label1.Text = "Score: " + Program.score;
            this.Notification.Text = "Game Started";
            Cat.BackgroundImage = ColorBuster.Properties.Resources.Cat_Normal;

            //Colors
            Program.images.Add(ColorBuster.Properties.Resources.blue);
            Program.images.Add(ColorBuster.Properties.Resources.green);
            Program.images.Add(ColorBuster.Properties.Resources.red);
            Program.images.Add(ColorBuster.Properties.Resources.yellow);

            //Pop images
            Program.pop.Add(ColorBuster.Properties.Resources.pop_blue);
            Program.pop.Add(ColorBuster.Properties.Resources.pop_green);
            Program.pop.Add(ColorBuster.Properties.Resources.pop_red);
            Program.pop.Add(ColorBuster.Properties.Resources.pop_yellow);

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
                    currentImage = random.Next(0, 4);
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
                        width = tiles[i].Width,
                        height = tiles[i].Height,
                        control = tiles[i],
                    };

                    Program.tileList.Add(tile);
                    totalTiles++;
                }
                for (int k = 0; k < Program.rows; k++)
                {
                    board.Controls.Add(tiles[k]);
                }
            }
            //Check for is move available
            bool MoveAvailable = IsmoveAvailable();
            if (!MoveAvailable)
            {
                initBoard();
            }
        }

        public void tile_Click(object sender, EventArgs e)
        {

            foreach (var tile in Program.tileList)
            {
                if (((PictureBox)(sender)).Name == tile.Name)
                {
                    //Check if moves are available and get adjecent tiles
                    List<TileModel> tiles = new List<TileModel>();
                    tiles = getAdjecentTiles(tile, false);

                    //Check if there is a move available
                    bool moveAvailable = IsmoveAvailable();

                    //If there are more moves available and matched tiles settings are met start poping tiles
                    if (Program.matchTiles.Count >= Program.matchedTiles && tiles.Count != 0 && moveAvailable)
                    {
                        //Add new tiles to board
                        foreach (var refillBoard in Program.matchTiles)
                        {
                            //Update the score for each tile
                            Program.score += 20;
                            this.label1.Text = "Score: " + Program.score;

                            //Keep old image color
                            var oldImageIndex = refillBoard.imageIndex;

                            //Randomize color of tile
                            Random random = new Random();
                            int currentImage = random.Next(0, 4);
                            if (!Program.randomNoDuplicates.Contains(currentImage) && Program.randomNoDuplicates.Count != 4)
                            {
                                Program.randomNoDuplicates.Add(currentImage);
                            }
                            else
                            {
                                Program.randomNoDuplicates.Clear();
                                currentImage = random.Next(0, 4);
                            }

                            refillBoard.control.BackgroundImage = Program.pop[oldImageIndex];
                            refillBoard.imageIndex = currentImage;

                            //Update list of tiles
                            foreach (var updateTile in Program.tileList)
                            {
                                if (updateTile.xLocation == refillBoard.xLocation && updateTile.yLocation == refillBoard.yLocation)
                                {
                                    updateTile.imageIndex = refillBoard.imageIndex;
                                }
                            }
                        }
                        //Get Current Earned Score
                        var currentScore = Program.matchTiles.Count * 20;
                        Notification.Text = "+" + currentScore + " Points";
                        Notification.Refresh();
                        Cat.BackgroundImage = ColorBuster.Properties.Resources.Cat_Happy;
                        Cat.Refresh();


                        //Show poped tiles
                        board.Refresh();

                        //Wait 1 sec after displaying poped tiles to display new ones
                        System.Threading.Thread.Sleep(1000);
                        foreach (var getNewTileColor in Program.matchTiles)
                        {
                            getNewTileColor.control.BackgroundImage = Program.images[getNewTileColor.imageIndex];
                        }
                        Cat.BackgroundImage = ColorBuster.Properties.Resources.Cat_Normal;
                        board.Refresh();
                       
                        Program.matchTiles.Clear();
                    }
                    else if (tiles.Count == 0 && Program.matchTiles.Count == 0 && moveAvailable)
                    {
                        Notification.Text = "Clicked a tile with no matching tiles";
                        Notification.Refresh();
                        Cat.BackgroundImage = ColorBuster.Properties.Resources.Cat_Surprised;
                        Cat.Refresh();
                        System.Threading.Thread.Sleep(1000);
                        Cat.BackgroundImage = ColorBuster.Properties.Resources.Cat_Normal;
                        Cat.Refresh();
                        Program.matchTiles.Clear();
                    }
                    else if (Program.matchTiles.Count < Program.matchedTiles && moveAvailable)
                    {
                        Notification.Text = "Matched tiles set: " + Program.matchedTiles
                                       + "\nMatched tiles clicked: " + Program.matchTiles.Count;
                        Notification.Refresh();
                        Cat.BackgroundImage = ColorBuster.Properties.Resources.Cat_Mad;
                        Cat.Refresh();
                        System.Threading.Thread.Sleep(1000);
                        Cat.BackgroundImage = ColorBuster.Properties.Resources.Cat_Normal;
                        Cat.Refresh();
                        Program.matchTiles.Clear();
                    }
                    else
                    {
                        Cat.BackgroundImage = ColorBuster.Properties.Resources.Cat_Sad;
                        Cat.Refresh();
                        string message = "No more moves available"
                                        + "\nNew game?";
                        string title = "Game over";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result = MessageBox.Show(message, title, buttons);
                        if (result == DialogResult.Yes)
                        {
                            initBoard();
                            break;
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                }
            }
        }

        public bool IsmoveAvailable()
        {
            //See if there are moves available for each tile in the board
            foreach (var tile in Program.tileList)
            {
                //Check for adjecent tiles for each tile
                getAdjecentTiles(tile, true);


                //If all tiles are checked and moves are possible return true
                if (Program.isMoveAvailableTileList.Count >= Program.matchedTiles)
                {
                    Program.isMoveAvailableTileList.Clear();
                    return true;
                }

                //If it is the last tile and no moves are avialble then return false
                else if (tile == Program.tileList.Last() && Program.isMoveAvailableTileList.Count < Program.matchedTiles)
                {
                    Program.isMoveAvailableTileList.Clear();
                    return false;
                }
                Program.isMoveAvailableTileList.Clear();
            }

            return false;
        }

        public List<TileModel> getAdjecentTiles(TileModel tileToCheck, bool isMoveAvailableCheck)
        {
            //Checks if there are still matched tiles
            List<TileModel> returnTiles = null;
            //Gets populated with adjecent tiles
            List<TileModel> tiles = new List<TileModel>();
            //Contains the adjecent matched tiles
            List<TileModel> tilesToCheck = new List<TileModel>();

            //Change the corresponding list if we are checking for is move available or for poping tiles
            if (isMoveAvailableCheck)
            {
                tilesToCheck = Program.isMoveAvailableTileList;
            }
            else
            {
                tilesToCheck = Program.matchTiles;
            }

            //Add current tile to alredy checked list if not already there
            if (!tilesToCheck.Contains(tileToCheck))
            {
                tilesToCheck.Add(tileToCheck);
            }

            //Locate the tiles next to the current tile
            TileModel northTile = Program.tileList.Where(y => y != null && y.yLocation == tileToCheck.yLocation - tileToCheck.height && y.xLocation == tileToCheck.xLocation).FirstOrDefault();
            TileModel southTile = Program.tileList.Where(y => y != null && y.yLocation == tileToCheck.yLocation + tileToCheck.height && y.xLocation == tileToCheck.xLocation).FirstOrDefault();
            TileModel westTile = Program.tileList.Where(x => x != null && x.xLocation == tileToCheck.xLocation - tileToCheck.width && x.yLocation == tileToCheck.yLocation).FirstOrDefault();
            TileModel eastTile = Program.tileList.Where(x => x != null && x.xLocation == tileToCheck.xLocation + tileToCheck.width && x.yLocation == tileToCheck.yLocation).FirstOrDefault();

            //Get the tiles that have the same color to the current tile
            tiles.Add(northTile);
            tiles.Add(southTile);
            tiles.Add(westTile);
            tiles.Add(eastTile);

            var matchedTiles = tiles.Where(x => x != null && x.imageIndex == tileToCheck.imageIndex);

            while (matchedTiles != null)
            {
                foreach (var tile in matchedTiles)
                {
                    //See if a tile was already checked
                    bool check = tilesToCheck.Contains(tile);
                    if (!check)
                    {
                        tilesToCheck.Add(tile);
                        getAdjecentTiles(tile, isMoveAvailableCheck);
                    }
                }
                returnTiles = matchedTiles.ToList();
                matchedTiles = null;
            }
            //Check if there are moves available by checking if returnTiles.count is 0
            if (returnTiles.Count == 0)
            {
                tilesToCheck.Clear();
            }
            //Change the corresponding list if we are checking for is move available or for poping tiles
            if (isMoveAvailableCheck)
            {
                Program.isMoveAvailableTileList = tilesToCheck;
            }
            else
            {
                Program.matchTiles = tilesToCheck;
            }

            return returnTiles;
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

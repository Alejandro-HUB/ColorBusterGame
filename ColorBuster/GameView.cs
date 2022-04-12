using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

//Made by Alejandro Lopez

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
            resetBoard(ColorBuster.Properties.Resources.Cat_Normal, ("Score: " + BoardModel.score), "Game Started");

            //Colors
            BoardModel.images.Add(ColorBuster.Properties.Resources.blue);
            BoardModel.images.Add(ColorBuster.Properties.Resources.green);
            BoardModel.images.Add(ColorBuster.Properties.Resources.red);
            BoardModel.images.Add(ColorBuster.Properties.Resources.yellow);

            //Pop images
            BoardModel.pop.Add(ColorBuster.Properties.Resources.pop_blue);
            BoardModel.pop.Add(ColorBuster.Properties.Resources.pop_green);
            BoardModel.pop.Add(ColorBuster.Properties.Resources.pop_red);
            BoardModel.pop.Add(ColorBuster.Properties.Resources.pop_yellow);

            //Tile info
            int x = 0;
            int y = 0;
            int currentImage = 0;
            int totalTiles = 0;

            Random random = new Random();

            //Make rows and columns
            for (int j = 0; j < BoardModel.columns; j++)
            {
                PictureBox[] tiles = new PictureBox[BoardModel.rows];
                for (int i = 0; i < BoardModel.rows; i++)
                {
                    tiles[i] = new PictureBox();
                    tiles[i].Visible = true;
                    tiles[i].Name = "TileData" + totalTiles.ToString();
                    tiles[i].Left = 10;
                    tiles[i].Width = BoardModel.BoardWidth / BoardModel.rows;
                    tiles[i].Height = BoardModel.BoardHeight / BoardModel.columns;
                    tiles[i].Font = new Font(ScoreLabel.Font.FontFamily, ScoreLabel.Font.Size - 2.5f, ScoreLabel.Font.Style);
                    tiles[i].ForeColor = Color.Black;
                    tiles[i].BorderStyle = BorderStyle.Fixed3D;
                    tiles[i].BackgroundImageLayout = ImageLayout.Stretch;
                    tiles[i].Click += new EventHandler(tile_Click);

                    //Color
                    currentImage = random.Next(0, 4);
                    tiles[i].BackgroundImage = BoardModel.images[currentImage];

                    //Location
                    x = ((j - 1) + 1) * tiles[i].Width;
                    y = ((i - 1) + 1) * tiles[i].Height;
                    tiles[i].Location = new Point(x, y);

                    //Populate tile model with current tile
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

                    //Add tile to the tile list
                    BoardModel.tileList.Add(tile);
                    totalTiles++;
                }
                //Add tiles to the board
                for (int k = 0; k < BoardModel.rows; k++)
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
            foreach (var tile in BoardModel.tileList)
            {
                if (((PictureBox)(sender)).Name == tile.Name)
                {
                    //Get adjecent tiles
                    List<TileModel> tiles = new List<TileModel>();
                    tiles = getAdjecentTiles(tile, false);

                    //Check if there is a move available
                    bool moveAvailable = IsmoveAvailable();

                    //If there are more moves available and matched tiles settings are met start poping tiles
                    if (BoardModel.matchTiles.Count >= BoardModel.matchedTiles && tiles.Count != 0 && moveAvailable)
                    {
                        //Add new tiles to board
                        foreach (var refillBoard in BoardModel.matchTiles)
                        {
                            //Update the score for each tile
                            BoardModel.score += 20;
                            this.ScoreLabel.Text = "Score: " + BoardModel.score;

                            //Keep old image color
                            var oldImageIndex = refillBoard.imageIndex;

                            //Randomize color of tile
                            Random random = new Random();
                            int currentImage = random.Next(0, 4);
                            if (!BoardModel.randomNoDuplicates.Contains(currentImage) && BoardModel.randomNoDuplicates.Count != 4)
                            {
                                BoardModel.randomNoDuplicates.Add(currentImage);
                            }
                            else
                            {
                                BoardModel.randomNoDuplicates.Clear();
                                currentImage = random.Next(0, 4);
                            }

                            refillBoard.control.BackgroundImage = BoardModel.pop[oldImageIndex];
                            refillBoard.imageIndex = currentImage;

                            //Update list of tiles
                            foreach (var updateTile in BoardModel.tileList)
                            {
                                if (updateTile.xLocation == refillBoard.xLocation && updateTile.yLocation == refillBoard.yLocation)
                                {
                                    updateTile.imageIndex = refillBoard.imageIndex;
                                }
                            }
                        }
                        //Get Current Earned Score
                        var currentScore = BoardModel.matchTiles.Count * 20;
                        Notification.Text = "+" + currentScore + " Points";
                        Notification.Refresh();
                        Cat.BackgroundImage = ColorBuster.Properties.Resources.Cat_Happy;
                        Cat.Refresh();


                        //Show poped tiles
                        board.Refresh();

                        //Wait 1 sec after displaying poped tiles to display new ones
                        System.Threading.Thread.Sleep(1000);
                        foreach (var getNewTileColor in BoardModel.matchTiles)
                        {
                            getNewTileColor.control.BackgroundImage = BoardModel.images[getNewTileColor.imageIndex];
                        }
                        Cat.BackgroundImage = ColorBuster.Properties.Resources.Cat_Normal;
                        board.Refresh();

                        BoardModel.matchTiles.Clear();
                    }
                    else if (tiles.Count == 0 && BoardModel.matchTiles.Count == 0 && moveAvailable)
                    {
                        Notification.Text = "Clicked a tile with no matching tiles";
                        Notification.Refresh();
                        Cat.BackgroundImage = ColorBuster.Properties.Resources.Cat_Surprised;
                        Cat.Refresh();
                        System.Threading.Thread.Sleep(1000);
                        Cat.BackgroundImage = ColorBuster.Properties.Resources.Cat_Normal;
                        Cat.Refresh();
                        BoardModel.matchTiles.Clear();
                    }
                    else if (BoardModel.matchTiles.Count < BoardModel.matchedTiles && moveAvailable)
                    {
                        Notification.Text = "Matched tiles set: " + BoardModel.matchedTiles
                                       + "\nMatched tiles clicked: " + BoardModel.matchTiles.Count;
                        Notification.Refresh();
                        Cat.BackgroundImage = ColorBuster.Properties.Resources.Cat_Mad;
                        Cat.Refresh();
                        System.Threading.Thread.Sleep(1000);
                        Cat.BackgroundImage = ColorBuster.Properties.Resources.Cat_Normal;
                        Cat.Refresh();
                        BoardModel.matchTiles.Clear();
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
                            resetBoard(ColorBuster.Properties.Resources.Cat_Idle, "Score", "Notification");
                            break;
                        }
                    }
                }
            }
        }

        public void resetBoard(Image Cat_Status, string ScoreText, string NotificationText)
        {
            //Reset Board
            BoardModel.score = 0;
            BoardModel.tileList.Clear();
            BoardModel.matchTiles.Clear();
            BoardModel.isMoveAvailableTileList.Clear();
            board.Controls.Clear();
            BoardModel.images.Clear();
            BoardModel.pop.Clear();
            this.ScoreLabel.Text = ScoreText;
            this.Notification.Text = NotificationText;
            Cat.BackgroundImage = Cat_Status;
        }

        public bool IsmoveAvailable()
        {
            //See if there are moves available for each tile in the board
            foreach (var tile in BoardModel.tileList)
            {
                //Check for adjecent tiles for each tile
                getAdjecentTiles(tile, true);


                //If all tiles are checked and moves are possible return true
                if (BoardModel.isMoveAvailableTileList.Count >= BoardModel.matchedTiles)
                {
                    BoardModel.isMoveAvailableTileList.Clear();
                    return true;
                }

                //If it is the last tile and no moves are avialble then return false
                else if (tile == BoardModel.tileList.Last() && BoardModel.isMoveAvailableTileList.Count < BoardModel.matchedTiles)
                {
                    BoardModel.isMoveAvailableTileList.Clear();
                    return false;
                }
                BoardModel.isMoveAvailableTileList.Clear();
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
                tilesToCheck = BoardModel.isMoveAvailableTileList;
            }
            else
            {
                tilesToCheck = BoardModel.matchTiles;
            }

            //Add current tile to alredy checked list if not already there
            if (!tilesToCheck.Contains(tileToCheck))
            {
                tilesToCheck.Add(tileToCheck);
            }

            //Locate the tiles next to the current tile
            TileModel northTile = BoardModel.tileList.Where(y => y != null && y.yLocation == tileToCheck.yLocation - tileToCheck.height && y.xLocation == tileToCheck.xLocation).FirstOrDefault();
            TileModel southTile = BoardModel.tileList.Where(y => y != null && y.yLocation == tileToCheck.yLocation + tileToCheck.height && y.xLocation == tileToCheck.xLocation).FirstOrDefault();
            TileModel westTile = BoardModel.tileList.Where(x => x != null && x.xLocation == tileToCheck.xLocation - tileToCheck.width && x.yLocation == tileToCheck.yLocation).FirstOrDefault();
            TileModel eastTile = BoardModel.tileList.Where(x => x != null && x.xLocation == tileToCheck.xLocation + tileToCheck.width && x.yLocation == tileToCheck.yLocation).FirstOrDefault();

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
                BoardModel.isMoveAvailableTileList = tilesToCheck;
            }
            else
            {
                BoardModel.matchTiles = tilesToCheck;
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
            board.Width = BoardModel.BoardWidth;
            board.Height = BoardModel.BoardHeight;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
    }

}

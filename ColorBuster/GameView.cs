﻿using System;
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
            Program.score = 0;
            board.Controls.Clear();
            this.label1.Text = "Score: " + Program.score;
            initBoard();
        }

        void GameView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void initBoard()
        {
            //Reset Tile List
            Program.score = 0;
            Program.tileList.Clear();
            Program.matchTiles.Clear();
            this.label1.Text = "Score: " + Program.score;

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
        }

        public void tile_Click(object sender, EventArgs e)
        {

            foreach (var tile in Program.tileList)
            {
                if (((PictureBox)(sender)).Name == tile.Name)
                {
                    MessageBox.Show("The tile you clicked is: " + tile.Name
                                   + "\n With coordinates:"
                                   + "\n x: " + tile.xLocation
                                   + "\n y: " + tile.yLocation);

                    //Check if moves are available and get adjecent tiles
                    List<TileModel> tiles = new List<TileModel>();
                    tiles = getAdjecentTiles(tile);

                    //If there are more moves available and matched tiles settings are met start poping tiles
                    if (Program.matchTiles.Count >= Program.matchedTiles && tiles.Count != 0)
                    {
                        //Remove each adjecent tile
                        foreach (var tileToPop in Program.matchTiles)
                        {
                            board.Controls.Remove(tileToPop.control);
                            Program.score += 20;
                            this.label1.Text = "Score: " + Program.score;
                        }
                        //Add new tiles to board
                        foreach (var refillBoard in Program.matchTiles)
                        {
                            //New tile to replace the old one
                            TileModel tileModel = refillBoard;

                            //Randomize color again
                            
                            Random random = new Random();
                            int currentImage = random.Next(0, 4);
                            if (!Program.randomNoDuplicates.Contains(currentImage) && Program.randomNoDuplicates.Count != 4)
                            {
                                Program.randomNoDuplicates.Add(currentImage);
                            }
                            else 
                            {
                                Program.randomNoDuplicates.Clear();
                                currentImage = random.Next(0,4);
                            }

                            tileModel.control.BackgroundImage = Program.images[currentImage];
                            
                            tileModel.imageIndex = currentImage;

                            //Add tile
                            board.Controls.Add(tileModel.control);
                        }
                        Program.matchTiles.Clear();
                    }
                    else if (tiles.Count == 0 && Program.matchTiles.Count == 0)
                    {
                        string message = "No more moves available"
                                        + "\nNew game?";
                        string title = "Game over";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result = MessageBox.Show(message, title, buttons);
                        if (result == DialogResult.Yes)
                        {
                            board.Controls.Clear();
                            Program.score = 0;
                            initBoard();
                            break;
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Matched tiles set: " + Program.matchedTiles
                                       + "\nMatched tiles clicked: " + (Program.matchTiles.Count));
                        Program.matchTiles.Clear();
                    }
                }
            }
        }

        public void IsmoveAvailable()
        {

        }

        public List<TileModel> getAdjecentTiles(TileModel tileToCheck)
        {
            List<TileModel> returnTiles = null;
            List<TileModel> tiles = new List<TileModel>();

            //Add current tile to alredy checked list if not already there
            if (!Program.matchTiles.Contains(tileToCheck))
            {
                Program.matchTiles.Add(tileToCheck);
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
                    bool check = Program.matchTiles.Contains(tile);
                    if (!check)
                    {
                        Program.matchTiles.Add(tile);
                        getAdjecentTiles(tile);
                    }
                }
                returnTiles = matchedTiles.ToList();
                matchedTiles = null;
            }
            //Check if there are moves available by checking if returnTiles.count is 0
            if (returnTiles.Count == 0)
            {
                Program.matchTiles.Clear();
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Minesweeper.Properties;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace Minesweeper
{
    public partial class MinesweeperForm : Form
    {
        private Difficulty difficulty;

        public MinesweeperForm()
        {
            InitializeComponent();
            this.LoadGame(null, null);
            this.tileGrid.TileFlagStatusChange += this.TileFlagStatusChanged;
        }

        private enum Difficulty {  Expert, Intermediate, Beginner}

        private void LoadGame(object sender, EventArgs e)
        {
            int x, y, mines;
            switch (this.difficulty)
            {
                case Difficulty.Beginner:
                    x = y = 9;
                    mines = 10;
                    break;
                case Difficulty.Intermediate:
                    x = y = 16;
                    mines = 40;
                    break;
                case Difficulty.Expert:
                    x = 30;
                    y = 16;
                    mines = 99;
                    break;
                default:
                    throw new InvalidOperationException("Unimplemented difficulty selected");
            }
            this.tileGrid.LoadGrid(new Size(x, y), mines);
            this.MaximumSize = this.MinimumSize = new Size(this.tileGrid.Width + 36, this.tileGrid.Height + 98);
            this.flagCounter.Text = mines.ToString();
            this.flagCounter.ForeColor = Color.Black;
        }

        private void MenuStrip_Game_New_Click(object sender, EventArgs e)
        {
            this.LoadGame(null, null);
        }

        private void MenuStrip_Game_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuStrip_Game_DifficultyChanged(object sender, EventArgs e)
        {
            this.difficulty = (Difficulty)Enum.Parse(typeof(Difficulty), (string)((ToolStripMenuItem)sender).Tag);
            this.LoadGame(null, null);
        }

        private void TileFlagStatusChanged(object sender, TileGrid.TileFlagStatusChangedEventArgs e)
        {
            this.flagCounter.Text = e.Flags.ToString();
            this.flagCounter.ForeColor = e.LabelColour;
        }

        private class TileGrid : Panel
        {
            private static readonly HashSet<Tile> gridSearchBlacklist = new HashSet<Tile>();
            private static readonly Random random = new Random();

            private Size gridSize;
            private int mines;
            private int flags;
            private bool minesGenerated;

            internal event EventHandler<TileFlagStatusChangedEventArgs> TileFlagStatusChange = delegate { };

            private Tile this[Point point] => (Tile)this.Controls[$"Tile_{point.X}_{point.Y}"];

            private void Tile_MouseDown(object sender, MouseEventArgs e)
            {
                Tile tile = (Tile)sender;
                if(!tile.Opened)
                {
                    switch (e.Button)
                    {
                        case MouseButtons.Left when !tile.Flagged:
                            if (!this.minesGenerated)
                            {
                                this.GenerateMines(tile);
                            }

                            if (tile.Mined)
                            {
                                this.DisableTiles(true);
                            }
                            else
                            {
                                tile.TestAdjacentTiles();
                                gridSearchBlacklist.Clear();
                            }
                            break;
                        case MouseButtons.Right :
                            if (tile.Flagged)
                            {
                                tile.Flagged = false;
                                this.flags++;
                            }
                            else if(this.flags > 0)
                            {
                                tile.Flagged = true;
                                this.flags--;
                            }
                            TileFlagStatusChange(this, new TileFlagStatusChangedEventArgs(this.flags, this.flags < this.mines * 0.25 ? Color.Red : Color.Black));
                            break;
                    }
                    this.CheckForWin();
                }
            }

            internal void LoadGrid(Size gridSize, int mines)
            {
                this.minesGenerated = false;
                this.Controls.Clear();
                this.gridSize = gridSize;
                this.mines = this.flags = mines;
                this.Size = new Size(gridSize.Width * Tile.LENGTH, gridSize.Height * Tile.LENGTH);
                for(int i = 0; i < gridSize.Width; i++)
                {
                    for(int j = 0; j < gridSize.Height; j++)
                    {
                        Tile tile = new Tile(i, j);
                        tile.MouseDown += Tile_MouseDown;
                        this.Controls.Add(tile);
                    }
                }
                foreach(Tile tile in this.Controls)
                {
                    tile.SetAdjacentTiles();
                }
            }

            private void GenerateMines(Tile safeTile)
            {
                int safeTilesCount = safeTile.AdjacentTiles.Length + 1;
                Point[] usedPositions = new Point[this.mines+safeTilesCount];
                usedPositions[0] = safeTile.GridPosition;
                for(int i = 1; i < safeTilesCount; i++)
                {
                    usedPositions[i] = safeTile.AdjacentTiles[i - 1].GridPosition;
                }

                for(int i = safeTilesCount; i < usedPositions.Length; i++)
                {
                    Point point = new Point(random.Next(this.gridSize.Width), random.Next(this.gridSize.Height));
                    if (!usedPositions.Contains(point))
                    {
                        this[point].Mine();
                        usedPositions[i] = point;
                    }
                    else
                    {
                        i--;
                    }
                }
                this.minesGenerated = true;
            }

            private void DisableTiles(bool gameLost)
            {
                foreach (Tile tile in this.Controls)
                {
                    tile.MouseDown -= this.Tile_MouseDown;
                    if (gameLost)
                    {
                        tile.Image = !tile.Opened && tile.Mined && !tile.Flagged ? Resources.Mine : tile.Flagged && !tile.Mined ? Resources.FalseFlaggedTile : tile.Image;
                    }
                    
                }
            }

            private void CheckForWin()
            {
                if(this.flags!= 0 || this.Controls.OfType<Tile>().Count(tile =>tile.Opened || tile.Flagged)!= this.gridSize.Width * this.gridSize.Height)
                {
                    return;
                }
                MessageBox.Show("Congratulations,you solved the game!", "Game solved!", MessageBoxButtons.OK);
                this.DisableTiles(false);
            }

            private class Tile : PictureBox
            {
                internal const int LENGTH = 25;
                private static readonly int[][] adjacentCoords =
                {
                    new []{-1,-1}, new[]{0,-1},new[]{1,-1},new[]{-1,0},new[]{0,0},new[]{1,0},new [] {-1,1},new[] {0,1},new[] {1,1}
                };

                private bool flagged;
                internal Tile(int x, int y)
                {
                    this.Name = $"Tile_{x}_{y}";
                    this.Location = new Point(x * LENGTH, y * LENGTH);
                    this.GridPosition = new Point(x, y);
                    this.Size = new Size(LENGTH, LENGTH);
                    this.Image = Resources.Tile;
                    this.SizeMode = PictureBoxSizeMode.Zoom;
                }

                internal Tile[] AdjacentTiles { get; private set; }
                internal Point GridPosition { get; }
                internal bool Opened { get; private set; }
                internal bool Mined { get; private set; }
                internal bool Flagged
                {
                    get => this.flagged;
                    set
                    {
                        this.flagged = value;
                        this.Image = value ? Resources.Flag : Resources.Tile;
                    }
                }

                private int AdjacentMines => this.AdjacentTiles.Count(tile => tile.Mined);

                internal void SetAdjacentTiles()
                {
                    TileGrid tileGrid = (TileGrid)this.Parent;
                    List<Tile> adjacentTiles = new List<Tile>(8);
                    foreach(int[] adjacentCoord in adjacentCoords)
                    {
                        Tile tile = tileGrid[new Point(this.GridPosition.X + adjacentCoord[0], this.GridPosition.Y + adjacentCoord[1])];
                        if (tile != null)
                        {
                            adjacentTiles.Add(tile);
                        }
                    }
                    this.AdjacentTiles = adjacentTiles.ToArray();
                }

                internal void TestAdjacentTiles()
                {
                    if(this.flagged || gridSearchBlacklist.Contains(this))
                    {
                        return;
                    }
                    gridSearchBlacklist.Add(this);
                    if (this.AdjacentMines == 0)
                    {
                        foreach (Tile tile in this.AdjacentTiles)
                        {
                            tile.TestAdjacentTiles();
                        }
                    }
                    this.Open();
                }

                internal void Mine()
                {
                    this.Mined = true;
                }

                private void Open()
                {
                    this.Opened = true;
                    this.Image = (Image)Resources.ResourceManager.GetObject($"EmptyTile_{this.AdjacentMines}");
                }
            }

            internal class TileFlagStatusChangedEventArgs : EventArgs
            {
                internal int Flags { get; }
                internal Color LabelColour { get; }

                internal TileFlagStatusChangedEventArgs(int flags, Color labelColour)
                {
                    this.Flags = flags;
                    this.LabelColour = labelColour;
                }
            }
        }

    }
}

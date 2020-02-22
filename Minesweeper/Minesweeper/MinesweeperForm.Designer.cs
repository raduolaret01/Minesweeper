namespace Minesweeper
{
    partial class MinesweeperForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tileGrid = new Minesweeper.MinesweeperForm.TileGrid();
            this.gameButton = new System.Windows.Forms.PictureBox();
            this.flagCounter = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip_Game = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_Game_New = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_Game_Break1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip_Game_Beginner = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_Game_Intermediate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_Game_Expert = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_Game_Break2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip_Game_Exit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gameButton)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tileGrid
            // 
            this.tileGrid.Location = new System.Drawing.Point(10, 53);
            this.tileGrid.Name = "tileGrid";
            this.tileGrid.Size = new System.Drawing.Size(308, 239);
            this.tileGrid.TabIndex = 0;
            // 
            // gameButton
            // 
            this.gameButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gameButton.BackgroundImage = global::Minesweeper.Properties.Resources.GameButton;
            this.gameButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.gameButton.Location = new System.Drawing.Point(148, 12);
            this.gameButton.Name = "gameButton";
            this.gameButton.Size = new System.Drawing.Size(35, 35);
            this.gameButton.TabIndex = 1;
            this.gameButton.TabStop = false;
            this.gameButton.Click += new System.EventHandler(this.LoadGame);
            // 
            // flagCounter
            // 
            this.flagCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flagCounter.AutoSize = true;
            this.flagCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flagCounter.Location = new System.Drawing.Point(264, 16);
            this.flagCounter.Name = "flagCounter";
            this.flagCounter.Size = new System.Drawing.Size(0, 31);
            this.flagCounter.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStrip_Game});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(330, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip_Game
            // 
            this.menuStrip_Game.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStrip_Game_New,
            this.menuStrip_Game_Break1,
            this.menuStrip_Game_Beginner,
            this.menuStrip_Game_Intermediate,
            this.menuStrip_Game_Expert,
            this.menuStrip_Game_Break2,
            this.menuStrip_Game_Exit});
            this.menuStrip_Game.Name = "menuStrip_Game";
            this.menuStrip_Game.Size = new System.Drawing.Size(50, 20);
            this.menuStrip_Game.Text = "Game";
            // 
            // menuStrip_Game_New
            // 
            this.menuStrip_Game_New.Name = "menuStrip_Game_New";
            this.menuStrip_Game_New.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.menuStrip_Game_New.Size = new System.Drawing.Size(141, 22);
            this.menuStrip_Game_New.Text = "New";
            this.menuStrip_Game_New.Click += new System.EventHandler(this.MenuStrip_Game_New_Click);
            // 
            // menuStrip_Game_Break1
            // 
            this.menuStrip_Game_Break1.Name = "menuStrip_Game_Break1";
            this.menuStrip_Game_Break1.Size = new System.Drawing.Size(138, 6);
            // 
            // menuStrip_Game_Beginner
            // 
            this.menuStrip_Game_Beginner.Name = "menuStrip_Game_Beginner";
            this.menuStrip_Game_Beginner.Size = new System.Drawing.Size(141, 22);
            this.menuStrip_Game_Beginner.Tag = "Beginner";
            this.menuStrip_Game_Beginner.Text = "Beginner";
            this.menuStrip_Game_Beginner.Click += new System.EventHandler(this.MenuStrip_Game_DifficultyChanged);
            // 
            // menuStrip_Game_Intermediate
            // 
            this.menuStrip_Game_Intermediate.Name = "menuStrip_Game_Intermediate";
            this.menuStrip_Game_Intermediate.Size = new System.Drawing.Size(141, 22);
            this.menuStrip_Game_Intermediate.Tag = "Intermediate";
            this.menuStrip_Game_Intermediate.Text = "Intermediate";
            this.menuStrip_Game_Intermediate.Click += new System.EventHandler(this.MenuStrip_Game_DifficultyChanged);
            // 
            // menuStrip_Game_Expert
            // 
            this.menuStrip_Game_Expert.Name = "menuStrip_Game_Expert";
            this.menuStrip_Game_Expert.Size = new System.Drawing.Size(141, 22);
            this.menuStrip_Game_Expert.Tag = "Expert";
            this.menuStrip_Game_Expert.Text = "Expert";
            this.menuStrip_Game_Expert.Click += new System.EventHandler(this.MenuStrip_Game_DifficultyChanged);
            // 
            // menuStrip_Game_Break2
            // 
            this.menuStrip_Game_Break2.Name = "menuStrip_Game_Break2";
            this.menuStrip_Game_Break2.Size = new System.Drawing.Size(138, 6);
            // 
            // menuStrip_Game_Exit
            // 
            this.menuStrip_Game_Exit.Name = "menuStrip_Game_Exit";
            this.menuStrip_Game_Exit.Size = new System.Drawing.Size(141, 22);
            this.menuStrip_Game_Exit.Text = "Exit";
            this.menuStrip_Game_Exit.Click += new System.EventHandler(this.MenuStrip_Game_Exit_Click);
            // 
            // MinesweeperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(330, 304);
            this.Controls.Add(this.flagCounter);
            this.Controls.Add(this.tileGrid);
            this.Controls.Add(this.gameButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MinesweeperForm";
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.Text = "Minesweeper";
            ((System.ComponentModel.ISupportInitialize)(this.gameButton)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TileGrid tileGrid;

        private System.Windows.Forms.PictureBox gameButton;
        private System.Windows.Forms.Label flagCounter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuStrip_Game;
        private System.Windows.Forms.ToolStripMenuItem menuStrip_Game_New;
        private System.Windows.Forms.ToolStripSeparator menuStrip_Game_Break1;
        private System.Windows.Forms.ToolStripMenuItem menuStrip_Game_Beginner;
        private System.Windows.Forms.ToolStripMenuItem menuStrip_Game_Intermediate;
        private System.Windows.Forms.ToolStripMenuItem menuStrip_Game_Expert;
        private System.Windows.Forms.ToolStripSeparator menuStrip_Game_Break2;
        private System.Windows.Forms.ToolStripMenuItem menuStrip_Game_Exit;
    }
}


using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ColorBuster
{
    public partial class SettingsView : Form
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        void SettingsView_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Warning: No new settings applied");
            GameView game = new GameView();
            game.Show();
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            settings row = rowscomboBox.SelectedItem as settings;
            settings column = columnscomboBox.SelectedItem as settings;
            settings matchedTile = matchedcomboBox.SelectedItem as settings;

            if (row.Name != column.Name)
            {
                MessageBox.Show("Error: Rows and Columns need to have the same number");
            }
            else
            {
                Program.columns = Int32.Parse(row.Name.ToString());
                Program.rows = Int32.Parse(column.Name.ToString());
                Program.matchedTiles = Int32.Parse(matchedTile.Name.ToString());
                MessageBox.Show("Applied the following settings:"
                    + "\nColumns: " + Program.columns
                    + "\nRows: " + Program.rows
                    + "\nMatched Tiles: " + Program.matchedTiles);
                this.Hide();
                GameView game = new GameView();
                game.Show();
            }
        }

        private void SettingsView_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(SettingsView_FormClosed);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //Init values for combo boxes
            List<settings> comboBoxValues = new List<settings>();
            comboBoxValues.Add(new settings() { ID = 1, Name = "3" });
            comboBoxValues.Add(new settings() { ID = 2, Name = "4" });
            comboBoxValues.Add(new settings() { ID = 3, Name = "5" });
            comboBoxValues.Add(new settings() { ID = 4, Name = "6" });
            comboBoxValues.Add(new settings() { ID = 5, Name = "7" });
            comboBoxValues.Add(new settings() { ID = 6, Name = "8" });

            //Init row combo box
            List<settings> rows = new List<settings>();
            rows = comboBoxValues.ToList();
            this.rowscomboBox.DataSource = rows;
            this.rowscomboBox.ValueMember = "ID";
            this.rowscomboBox.DisplayMember = "Name";

            //Init column combo box
            List<settings> columns = new List<settings>();
            columns = comboBoxValues.ToList();
            this.columnscomboBox.DataSource = columns;
            this.columnscomboBox.ValueMember="ID";
            this.columnscomboBox.DisplayMember="Name";

            //Init matched tiles combo box
            List<settings> matchedTiles = new List<settings>();
            matchedTiles = comboBoxValues.Where(x => x.ID <= 3).ToList();
            this.matchedcomboBox.DataSource = matchedTiles;
            this.matchedcomboBox.ValueMember = "ID";
            this.matchedcomboBox.DisplayMember = "Name";
        }
    }

    public class settings
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}

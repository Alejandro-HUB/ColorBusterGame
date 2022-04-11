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
            SettingsModel row = rowscomboBox.SelectedItem as SettingsModel;
            SettingsModel column = columnscomboBox.SelectedItem as SettingsModel;
            SettingsModel matchedTile = matchedcomboBox.SelectedItem as SettingsModel;

            if (row.Name != column.Name)
            {
                MessageBox.Show("Error: Rows and Columns need to have the same number");
            }
            else
            {
                BoardModel.columns = Int32.Parse(row.Name.ToString());
                BoardModel.rows = Int32.Parse(column.Name.ToString());
                BoardModel.matchedTiles = Int32.Parse(matchedTile.Name.ToString());
                MessageBox.Show("Applied the following settings:"
                    + "\nColumns: " + BoardModel.columns
                    + "\nRows: " + BoardModel.rows
                    + "\nMatched Tiles: " + BoardModel.matchedTiles);
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
            List<SettingsModel> comboBoxValues = new List<SettingsModel>();
            comboBoxValues.Add(new SettingsModel() { ID = 1, Name = "3" });
            comboBoxValues.Add(new SettingsModel() { ID = 2, Name = "4" });
            comboBoxValues.Add(new SettingsModel() { ID = 3, Name = "5" });
            comboBoxValues.Add(new SettingsModel() { ID = 4, Name = "6" });
            comboBoxValues.Add(new SettingsModel() { ID = 5, Name = "7" });
            comboBoxValues.Add(new SettingsModel() { ID = 6, Name = "8" });

            //Init row combo box
            List<SettingsModel> rows = new List<SettingsModel>();
            rows = comboBoxValues.ToList();
            this.rowscomboBox.DataSource = rows;
            this.rowscomboBox.ValueMember = "ID";
            this.rowscomboBox.DisplayMember = "Name";

            //Init column combo box
            List<SettingsModel> columns = new List<SettingsModel>();
            columns = comboBoxValues.ToList();
            this.columnscomboBox.DataSource = columns;
            this.columnscomboBox.ValueMember="ID";
            this.columnscomboBox.DisplayMember="Name";

            //Init matched tiles combo box
            List<SettingsModel> matchedTiles = new List<SettingsModel>();
            matchedTiles = comboBoxValues.Where(x => x.ID <= 3).ToList();
            this.matchedcomboBox.DataSource = matchedTiles;
            this.matchedcomboBox.ValueMember = "ID";
            this.matchedcomboBox.DisplayMember = "Name";
        }
    }
}

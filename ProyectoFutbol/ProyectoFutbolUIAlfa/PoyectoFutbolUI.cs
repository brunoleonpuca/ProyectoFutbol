namespace ProyectoFutbolUIAlfa
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using ProyectoFutbol.Builders.LeaguesBuilder;
    using ProyectoFutbol.db;

    public partial class PoyectoFutbolUI : Form
    {
        public List<League> leagues = new List<League>();
        public PoyectoFutbolUI()
        {
            InitializeComponent();

            LeaguesListBox.DataSource = leagues;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();


        }
    }
}

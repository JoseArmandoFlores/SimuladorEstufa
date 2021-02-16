using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimuladorEstufa
{
    public partial class MainForm : Form
    {
        public const double LenaSeca = 4.5;//Kilocalorias por gramos (Kcal/Gr) = 1.25Kcal/h
        public const double CascaraSecaArroz = 3.8;
        public const double HojaSeca = 4.5;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}

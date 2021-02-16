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
        public const double LenaSeca = 4500;//Kilocalorias por hora (Kcal/h) = 75 calorias por minuto (cal/m)
        public const double CascaraSecaArroz = 3700;//Kilocalorias por hora (Kcal/h) = 61.67 calorias por minuto (cal/m)

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        public void DeterminarPosicion(PictureBox Pos, PictureBox Estufa)
        {
            Posicion0PictureBox.Visible = false;
            Posicion1PictureBox.Visible = false;
            Posicion2PictureBox.Visible = false;
            Posicion3PictureBox.Visible = false;
            Posicion4PictureBox.Visible = false;
            Posicion5PictureBox.Visible = false;
            Estufa1PictureBox.Visible = false;
            Estufa2PictureBox.Visible = false;
            Estufa3PictureBox.Visible = false;
            Estufa4PictureBox.Visible = false;
            Estufa5PictureBox.Visible = false;
            Pos.Visible = true;
            Estufa.Visible = true;
        }

        private void Posicion0Button_Click(object sender, EventArgs e)
        {
            DeterminarPosicion(Posicion0PictureBox, Estufa0PictureBox);
        }

        private void Posicion1Button_Click(object sender, EventArgs e)
        {
            DeterminarPosicion(Posicion1PictureBox, Estufa1PictureBox);
        }

        private void Posicion2Button_Click(object sender, EventArgs e)
        {
            DeterminarPosicion(Posicion2PictureBox, Estufa2PictureBox);
        }

        private void Posicion3Button_Click(object sender, EventArgs e)
        {
            DeterminarPosicion(Posicion3PictureBox, Estufa3PictureBox);
        }

        private void Posicion4Button_Click(object sender, EventArgs e)
        {
            DeterminarPosicion(Posicion4PictureBox, Estufa4PictureBox);
        }

        private void Posicion5Button_Click(object sender, EventArgs e)
        {
            DeterminarPosicion(Posicion5PictureBox, Estufa5PictureBox);
        }

        private void YucaPictureBox_Click(object sender, EventArgs e)
        {
            RacionLabel.Text = "1.00";
            CarbohidratosLabel.Text = "0.268";
            KilokaloriasLabel.Text = "1.20";
            ProteinasLabel.Text = "0.031";
            GrasasLabel.Text = "0.004";
            AlimentoLabel.Text = "     Yuca      ";
        }

        private void CarnePictureBox_Click(object sender, EventArgs e)
        {
            RacionLabel.Text = "1.00";
            CarbohidratosLabel.Text = "0.00";
            KilokaloriasLabel.Text = "1.56";
            ProteinasLabel.Text = "0.22";
            GrasasLabel.Text = "0.07";
            AlimentoLabel.Text = "Filete de cerdo";
        }

        private void ArrozPictureBox_Click(object sender, EventArgs e)
        {
            RacionLabel.Text = "1.00";
            CarbohidratosLabel.Text = "0.86";
            KilokaloriasLabel.Text = "3.60";
            ProteinasLabel.Text = "0.06";
            GrasasLabel.Text = "0.00";
            AlimentoLabel.Text = "     Arroz     ";
        }

        private void DeseleccionarAlimentoButton_Click(object sender, EventArgs e)
        {
            RacionLabel.Text = "0.00";
            CarbohidratosLabel.Text = "0.00";
            KilokaloriasLabel.Text = "0.00";
            ProteinasLabel.Text = "0.00";
            GrasasLabel.Text = "0.00";
            AlimentoLabel.Text = "---------------";
        }

        private void LenaPictureBox_Click(object sender, EventArgs e)
        {
            CombustibleN2Label.Visible = false;
            CombustibleKcalh2Label.Visible = false;
            CombustibleKcalm2Label.Visible = false;
            
            CombustibleN1Label.Visible = true;
            CombustibleKcalh1Label.Visible = true;
            CombustibleKcalm1Label.Visible = true;
        }

        private void CascaraArrozPictureBox_Click(object sender, EventArgs e)
        {
            CombustibleN1Label.Visible = false;
            CombustibleKcalh1Label.Visible = false;
            CombustibleKcalm1Label.Visible = false;
            
            CombustibleN2Label.Visible = true;
            CombustibleKcalh2Label.Visible = true;
            CombustibleKcalm2Label.Visible = true;
        }

        private void DeseleccionarCombustibleButton_Click(object sender, EventArgs e)
        {
            CombustibleN1Label.Visible = false;
            CombustibleKcalh1Label.Visible = false;
            CombustibleKcalm1Label.Visible = false;

            CombustibleN2Label.Visible = false;
            CombustibleKcalh2Label.Visible = false;
            CombustibleKcalm2Label.Visible = false;
        }

        private void SeleccionarCombustibleButton_Click(object sender, EventArgs e)
        {
            TabControl.SelectedIndex = 1;
        }
    }
}

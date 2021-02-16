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

        private void DeseleccionarButton_Click(object sender, EventArgs e)
        {
            RacionLabel.Text = "0.00";
            CarbohidratosLabel.Text = "0.00";
            KilokaloriasLabel.Text = "0.00";
            ProteinasLabel.Text = "0.00";
            GrasasLabel.Text = "0.00";
            AlimentoLabel.Text = "---------------";
        }
    }
}

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
        public const double HojaSeca = 4800;//Kilocalorias por hora(Kcal/h) = 80 calorias por minuto(cal/m)

        public double KcalCombustible, KcalAlimento, KcalRestantes, KcalQuemadasPorMinuto, KcalQuemadaTotal;
        public int hora = 0, minuto = 0, segundo = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        public void LLenaCampo()
        {
            KcalRestantesTextBox.Text = KcalRestantes.ToString("N2");
            KcalQuemadaTotalTextBox.Text = KcalQuemadaTotal.ToString("N2");
            KcalQuemadaMinutoTextBox.Text = KcalQuemadasPorMinuto.ToString("N2");
        }

        //Combustible
        private void LenaPictureBox_Click(object sender, EventArgs e)
        {
            CombustibleN2Label.Visible = false;
            CombustibleKcalh2Label.Visible = false;
            CombustibleKcalm2Label.Visible = false;

            CombustibleN3Label.Visible = false;
            CombustibleKcalh3Label.Visible = false;
            CombustibleKcalm3Label.Visible = false;

            CombustibleN1Label.Visible = true;
            CombustibleKcalh1Label.Visible = true;
            CombustibleKcalm1Label.Visible = true;
        }

        private void CascaraArrozPictureBox_Click(object sender, EventArgs e)
        {
            CombustibleN1Label.Visible = false;
            CombustibleKcalh1Label.Visible = false;
            CombustibleKcalm1Label.Visible = false;

            CombustibleN3Label.Visible = false;
            CombustibleKcalh3Label.Visible = false;
            CombustibleKcalm3Label.Visible = false;

            CombustibleN2Label.Visible = true;
            CombustibleKcalh2Label.Visible = true;
            CombustibleKcalm2Label.Visible = true;
        }

        private void HojaSecaPictureBox_Click(object sender, EventArgs e)
        {
            CombustibleN1Label.Visible = false;
            CombustibleKcalh1Label.Visible = false;
            CombustibleKcalm1Label.Visible = false;

            CombustibleN2Label.Visible = false;
            CombustibleKcalh2Label.Visible = false;
            CombustibleKcalm2Label.Visible = false;

            CombustibleN3Label.Visible = true;
            CombustibleKcalh3Label.Visible = true;
            CombustibleKcalm3Label.Visible = true;
        }

        private void SeleccionarCombustibleButton_Click(object sender, EventArgs e)
        {
            if (CombustibleN1Label.Visible == true)
            {
                KcalCombustible = LenaSeca / 60;
            }
            else if (CombustibleN2Label.Visible == true)
            {
                KcalCombustible = CascaraSecaArroz / 60;
            }
            else if (CombustibleN3Label.Visible == true)
                KcalCombustible = HojaSeca / 60;
            else
            {
                MessageBox.Show("¡Debe seleccionar un tipo de combustible!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            TabControl.SelectedIndex = 1;
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

        //Alimento
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

        private void SeleccionarAlimentoButton_Click(object sender, EventArgs e)
        {
            KcalAlimento = Convert.ToDouble(KilokaloriasLabel.Text) * (Convert.ToDouble(CantidadAlimentoNumericUpDown.Value) * 453.592);
            KcalRestantes = KcalAlimento;

            if (AlimentoLabel.Text == "---------------")
            {
                MessageBox.Show("¡Debe seleccionar un alimento!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TabControl.SelectedIndex = 2;
            LLenaCampo();
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

        //Estufa
        private void Timer_Tick(object sender, EventArgs e)
        {
            Cocinar();
        }

        private void TimerCronometro_Tick(object sender, EventArgs e)
        {
            if (KcalRestantes > 0)
            {
                segundo++;
                if (segundo == 60)
                {
                    segundo = 0;
                }

                if (minuto == 60)
                {
                    hora++;
                    minuto = 0;
                }

                if (minuto > 9 && segundo > 9)
                    TiempoLabel.Text = "0" + hora + ":" + minuto + ":" + segundo;

                if (minuto > 9 && segundo < 9)
                    TiempoLabel.Text = "0" + hora + ":" + minuto + ":" + "0" + segundo;

                if (segundo > 9 && (minuto >= 0 && minuto <= 9))
                    TiempoLabel.Text = "0" + hora + ":" + "0" + minuto + ":" + segundo;

                if ((segundo >= 0 && segundo <= 9) && (minuto >= 0 && minuto <= 9))
                    TiempoLabel.Text = "0" + hora + ":" + "0" + minuto + ":" + "0" + segundo;
            }
        }

        public void Cocinar()
        {
            minuto++;
            segundo = 0;
            KcalRestantes -= KcalQuemadasPorMinuto;
            KcalQuemadaTotal += KcalQuemadasPorMinuto;

            if (KcalRestantes <= 0)
            {
                DeterminarPosicion(Posicion0PictureBox, Estufa0PictureBox);
                KcalQuemadasPorMinuto = 0;
                Timer.Enabled = false;
                TimerCronometro.Enabled = false;
                EstadoTextBox.Text = "¡Cocinado!";
                KcalRestantes = 0;
                KcalQuemadaTotal = KcalAlimento;
            }

            LLenaCampo();
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
            KcalQuemadasPorMinuto = 0;
            Timer.Enabled = false;
            TimerCronometro.Enabled = false;

            if (KcalRestantes > 0)
                EstadoTextBox.Text = "Quedan " + KcalRestantes.ToString("N2") + " kcal por quemar";
            else if (KcalRestantes == 0)
                EstadoTextBox.Text = "¡Cocinado!";
        }

        private void Posicion1Button_Click(object sender, EventArgs e)
        {
            DeterminarPosicion(Posicion1PictureBox, Estufa1PictureBox);
            KcalQuemadasPorMinuto = KcalCombustible * 0.20;

            if (TimerCronometro.Enabled == false)
            {
                TimerCronometro.Enabled = true;
                Timer.Enabled = true;
            }

            EstadoTextBox.Text = "Cocinando";
        }

        private void Posicion2Button_Click(object sender, EventArgs e)
        {
            DeterminarPosicion(Posicion2PictureBox, Estufa2PictureBox);
            KcalQuemadasPorMinuto = KcalCombustible * 0.40;

            if (TimerCronometro.Enabled == false)
            {
                TimerCronometro.Enabled = true;
                Timer.Enabled = true;
            }

            EstadoTextBox.Text = "Cocinando";
        }

        private void Posicion3Button_Click(object sender, EventArgs e)
        {
            DeterminarPosicion(Posicion3PictureBox, Estufa3PictureBox);
            KcalQuemadasPorMinuto = KcalCombustible * 0.60;

            if (TimerCronometro.Enabled == false)
            {
                TimerCronometro.Enabled = true;
                Timer.Enabled = true;
            }

            EstadoTextBox.Text = "Cocinando";
        }

        private void Posicion4Button_Click(object sender, EventArgs e)
        {
            DeterminarPosicion(Posicion4PictureBox, Estufa4PictureBox);
            KcalQuemadasPorMinuto = KcalCombustible * 0.80;

            if (TimerCronometro.Enabled == false)
            {
                TimerCronometro.Enabled = true;
                Timer.Enabled = true;
            }

            EstadoTextBox.Text = "Cocinando";
        }

        private void Posicion5Button_Click(object sender, EventArgs e)
        {
            DeterminarPosicion(Posicion5PictureBox, Estufa5PictureBox);
            KcalQuemadasPorMinuto = KcalCombustible;

            if (TimerCronometro.Enabled == false)
            {
                TimerCronometro.Enabled = true;
                Timer.Enabled = true;
            }

            EstadoTextBox.Text = "Cocinando";
        }
    }
}

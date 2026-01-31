using System;
using System.Windows.Forms;

namespace formulario_de_estudiante
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            // Validar que no estén vacíos
            if (p1.Text == "" || p2.Text == "" || p3.Text == "" || p4.Text == "")
            {
                MessageBox.Show("Ingrese todas las notas de los periodos");
                return;
            }

            double n1 = Convert.ToDouble(p1.Text);
            double n2 = Convert.ToDouble(p2.Text);
            double n3 = Convert.ToDouble(p3.Text);
            double n4 = Convert.ToDouble(p4.Text);

            double promedio = (n1 + n2 + n3 + n4) / 4;

            lblPromedio.Text = "Promedio: " + promedio.ToString("0.00");
            lblPromedioGeneral.Text = "Promedio general: " + promedio.ToString("0.00");

            // CASO 1: Aprobado directo
            if (promedio >= 70)
            {
                lblEstado.Text = "Estado: APROBADO";
                lblCompletivo.Text = "Completivo: N/A";
                lblExtraordinario.Text = "Extraordinario: N/A";
            }
            // CASO 2: Completivo
            else if (promedio >= 60)
            {
                CajaCompletivo.Enabled = true;

                if (Completivo.Text == "")
                {
                    lblEstado.Text = "Estado: REQUIERE COMPLETIVO";
                    return;
                }

                double notaComp = Convert.ToDouble(Completivo.Text);
                double notaFinal = (promedio + notaComp) / 2;

                lblCompletivo.Text = "Completivo: " + notaComp;
                lblEstado.Text = notaFinal >= 70 ? "Estado: APROBADO" : "Estado: REPROBADO";
            }
            // CASO 3: Extraordinario
            else
            {
                CajaExtraordinario.Enabled = true;

                if (Extraordinario.Text == "")
                {
                    lblEstado.Text = "Estado: REQUIERE EXTRAORDINARIO";
                    return;
                }

                double notaExtra = Convert.ToDouble(Extraordinario.Text);
                lblExtraordinario.Text = "Extraordinario: " + notaExtra;

                lblEstado.Text = notaExtra >= 70 ? "Estado: APROBADO" : "Estado: REPROBADO";
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            p1.Clear();
            p2.Clear();
            p3.Clear();
            p4.Clear();
            Completivo.Clear();
            Extraordinario.Clear();

            lblPromedio.Text = "Promedio:";
            lblPromedioGeneral.Text = "Promedio general:";
            lblCompletivo.Text = "Completivo";
            lblExtraordinario.Text = "Extraordinario:";
            lblEstado.Text = "Estado:";

            CajaCompletivo.Enabled = false;
            CajaExtraordinario.Enabled = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

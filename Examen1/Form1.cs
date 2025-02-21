using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Forms;
using System.Collections;

namespace Examen1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int CalcularEdad(int a, int m, int d)
        {
            DateTime diaH = DateTime.Now;
            DateTime nacimiento = new DateTime(a, m, d);
            int dias = (diaH - nacimiento).Days;
            int años = dias / 365;
            return años;
        }
        public static string sexoM(string sexo)
        {
            if (sexo == "H")
            {
                return "Hombre";
            }
            else
            {
                return "Mujer";
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado = openFileDialog.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                string fp = openFileDialog.FileName;
                try
                {
                    string dato = File.ReadAllText(fp);
                    //ArrayList datos = new ArrayList();
                    List<string[]> datos = new List<string[]>();
                    List<string> renglon = new List<string>();
                    string cad = "";
                    string sexo="";
                    int edad=0;
                    for (int i = 0; i < dato.Length; i++)
                    {
                        char caracter = dato[i];
                        if (caracter != ',' && caracter != '\n')
                            cad += caracter;
                        else
                        {
                            //RINF050111MCLVNRA0
                            renglon.Add(cad);
                            if(cad.Length == 18)
                            {
                                int año = 0;
                                //int año = int.Parse(cad.Substring(4,2));
                                string a = cad.Substring(4, 2);
                                int mes = int.Parse(cad.Substring(6, 2));
                                int dia = int.Parse(cad.Substring(8, 2));
                                if (a[0] == '0')
                                    año = 2000 + int.Parse(a);
                                else
                                    año = 1900 + int.Parse(a);

                                sexo = cad.Substring(10,1);
                                sexo = sexoM(sexo);
                                edad = CalcularEdad(año, mes, dia);
                                
                            }
                            cad = "";
                            if (caracter == '\n')
                            {

                                renglon.Add (edad + "");
                                renglon.Add(sexo);
                                datos.Add(renglon.ToArray());
                                renglon  = new List<string>();
                            }
                        }

                    }
                    foreach (string[] r in datos)
                    {
                        dataGridViewDatos.Rows.Add(r);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }
            }
        }
    }
}

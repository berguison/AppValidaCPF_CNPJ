using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppValidaCPF_CNPJ
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cpf = maskedTextBox1.Text.Replace(",","").Replace("-","");
            if (cpf.Length==11) {
                ValidarCPF(cpf);
            }
            else
            {
                MessageBox.Show("Número do CPF menor que 11 números.","Informação de validação.");
                maskedTextBox1.Clear();
                maskedTextBox1.Focus();
            }
        }

        private void btn_validar_cnpj_Click(object sender, EventArgs e)
        {
            string cnpj = maskedTextBox2.Text.Replace(",","").Replace("/","").Replace("-","");
            if (cnpj.Length == 14)
            {
                ValidarCNPJ(cnpj);
            }
            else
            {
                MessageBox.Show("Número do CNPJ menor que 14 números.", "Informação de validação.");
                maskedTextBox2.Clear();
                maskedTextBox2.Focus();
            }

        }

        private bool ValidarCPF(string nu_cpf)
        {
            bool icStatus = false;
            bool ic_status1 = false;
            bool ic_status2 = false;
            int mult = 0;
            int cont = 10;
            int soma = 0;
            int result = 0;
            string nucpf1 = "";
            string nu_cpf2 = "";
            
            try
            {
                nucpf1 = nu_cpf.Substring(0,9);
                foreach (var item in nucpf1.ToList())
                {

                    mult = int.Parse(item.ToString()) * cont;

                    soma += mult;
                    cont--;
                }

                result = (soma * 10) % 11;
                if (result ==int.Parse(nu_cpf.Substring(9,1)))
                {
                    ic_status1 = true;
                }
             
                cont = 11;

                soma = 0;
                nu_cpf2 = nu_cpf.Substring(0, 10);
                foreach (var item in nu_cpf2.ToList())
                {

                    mult = int.Parse(item.ToString()) * cont;

                    soma += mult;
                    cont--;
                }
                result = (soma * 10) % 11;
                if (result == int.Parse(nu_cpf.Substring(10,1)))
                {
                    ic_status2 = true;
                }

                if (ic_status1==true && ic_status2==true)
                {
                    MessageBox.Show("CPF é válido.", "Informação de validação.");
                }
                else if (ic_status1 == false && ic_status2 == false)
                {
                    MessageBox.Show("CPF é inválido.", "Informação de validação.");
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problema com a validação.", "Informação de validação.");

            }


            return icStatus;
        }

        private bool ValidarCNPJ(string nu_cnpj)
        {
            bool icStatus = false;
            bool ic_status1 = false;
            bool ic_status2 = false;
            int mult = 0;
            int[] multiplicadores01 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadores02 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int posicao = 1;
            int soma = 0;
            int result = 0;
            string nucpf1 = "";
            string nu_cpf2 = "";

            try
            {
                nucpf1 = nu_cnpj.Substring(0, 12);
                foreach (var item in nucpf1.ToList())
                {

                    switch (posicao)
                    {
                        case 1:

                            mult = int.Parse(item.ToString()) * multiplicadores01[0];

                            soma += mult;
                            
                            break;
                        case 2:

                            mult = int.Parse(item.ToString()) * multiplicadores01[1];

                            soma += mult;

                            break;
                        case 3:

                            mult = int.Parse(item.ToString()) * multiplicadores01[2];

                            soma += mult;

                            break;
                        case 4:

                            mult = int.Parse(item.ToString()) * multiplicadores01[3];

                            soma += mult;

                            break;
                        case 5:

                            mult = int.Parse(item.ToString()) * multiplicadores01[4];

                            soma += mult;

                            break;

                        case 6:

                            mult = int.Parse(item.ToString()) * multiplicadores01[5];

                            soma += mult;

                            break;

                        case 7:

                            mult = int.Parse(item.ToString()) * multiplicadores01[6];

                            soma += mult;

                            break;

                        case 8:

                            mult = int.Parse(item.ToString()) * multiplicadores01[7];

                            soma += mult;

                            break;

                        case 9:

                            mult = int.Parse(item.ToString()) * multiplicadores01[8];

                            soma += mult;

                            break;

                        case 10:

                            mult = int.Parse(item.ToString()) * multiplicadores01[9];

                            soma += mult;

                            break;
                        case 11:

                            mult = int.Parse(item.ToString()) * multiplicadores01[10];

                            soma += mult;

                            break;
                        case 12:

                            mult = int.Parse(item.ToString()) * multiplicadores01[11];

                            soma += mult;

                            break;
                       
                        default:
                            break;

                       }
                    posicao++;
                }

                result = soma  % 11;
                int dv1 = int.Parse(nu_cnpj.Substring(12, 1));
                if (result<2 )
                {
                    if(result == dv1)
                    {
                        ic_status1 = true;
                    }
                   
                }
                else if (result >=2)
                {
                    result = 11 - result;
                    if (result == int.Parse(nu_cnpj.Substring(12, 1))) { ic_status1 = true; }
                    
                }


                int dv2 = 0;
                soma = 0;
                posicao = 1;
                nu_cpf2 = nu_cnpj.Substring(0, 13);
                foreach (var item in nu_cpf2.ToList())
                {

                   
                   
                    switch (posicao)
                    {
                        case 1:

                            mult = int.Parse(item.ToString()) * multiplicadores02[0];

                            soma += mult;

                            break;
                        case 2:

                            mult = int.Parse(item.ToString()) * multiplicadores02[1];

                            soma += mult;

                            break;
                        case 3:

                            mult = int.Parse(item.ToString()) * multiplicadores02[2];

                            soma += mult;

                            break;
                        case 4:

                            mult = int.Parse(item.ToString()) * multiplicadores02[3];

                            soma += mult;

                            break;
                        case 5:

                            mult = int.Parse(item.ToString()) * multiplicadores02[4];

                            soma += mult;

                            break;

                        case 6:

                            mult = int.Parse(item.ToString()) * multiplicadores02[5];

                            soma += mult;

                            break;

                        case 7:

                            mult = int.Parse(item.ToString()) * multiplicadores02[6];

                            soma += mult;

                            break;

                        case 8:

                            mult = int.Parse(item.ToString()) * multiplicadores02[7];

                            soma += mult;

                            break;

                        case 9:

                            mult = int.Parse(item.ToString()) * multiplicadores02[8];

                            soma += mult;

                            break;

                        case 10:

                            mult = int.Parse(item.ToString()) * multiplicadores02[9];

                            soma += mult;

                            break;
                        case 11:

                            mult = int.Parse(item.ToString()) * multiplicadores02[10];

                            soma += mult;

                            break;
                        case 12:

                            mult = int.Parse(item.ToString()) * multiplicadores02[11];

                            soma += mult;

                            break;
                        case 13:

                            mult = int.Parse(item.ToString()) * multiplicadores02[12];

                            soma += mult;

                            break;

                        default:
                            break;

                    }
                    posicao +=1;
                }
                result = soma % 11;
                dv2 = int.Parse(nu_cnpj.Substring(13, 1));
                if (result<2)
                {
                    if(result == dv2)
                    ic_status2 = true;
                }
                else if (result >= 2)
                {
                    result = 11 - result;
                    

                    if (result == dv2)
                    {
                        ic_status2 = true;
                    }
                    
                }

                if (ic_status1 == true && ic_status2 == true)
                {
                    MessageBox.Show("CNPJ é valido.","Informação de validação");
                }
                else if (ic_status1 == false && ic_status2 == false)
                {
                    MessageBox.Show("CNPJ é inválido.","Informação de validação");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Problema com a validação.");

            }


            return icStatus;
        }
    }
}

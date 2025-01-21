using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerador_de_Senhas
{
    class GeradorSenha
    {
        // Propriedades que definem as opções de senha
        public int Tamanho { get; set; }
        public bool ApenasNumeros { get; set; }
        public bool ComLetras { get; set; }
        public bool ComEspeciais { get; set; }

        public GeradorSenha(int tamanho, bool apenasNumeros, bool comLetras, bool comEspeciais)
        {
            Tamanho = tamanho;
            ApenasNumeros = apenasNumeros;
            ComLetras = comLetras;
            ComEspeciais = comEspeciais;
        }

        public string GerarSenha()
        {
            StringBuilder senha = new StringBuilder();
            Random rand = new Random();

            string numeros = "0123456789";
            string letrasMinusculas = "abcdefghijklmnopqrstuvwxyz";
            string letrasMaiusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string caracteresEspeciais = "@!#-";

            string conjuntoCaracteres = "";

            if (ApenasNumeros)
            {
                conjuntoCaracteres = numeros;
            }
            else
            {
                if (ComLetras)
                {
                    conjuntoCaracteres += letrasMinusculas + letrasMaiusculas;
                }
                if (ComEspeciais)
                {
                    conjuntoCaracteres += caracteresEspeciais;
                }
            }

            // Gerar a senha com base no conjunto de caracteres escolhido
            for (int i = 0; i < Tamanho; i++)
            {
                int indice = rand.Next(conjuntoCaracteres.Length);
                senha.Append(conjuntoCaracteres[indice]);
            }

            return senha.ToString();
        }
    }
}

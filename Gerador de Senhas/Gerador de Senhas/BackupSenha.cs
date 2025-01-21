using System;
using System.IO;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerador_de_Senhas
{
    class BackupSenha
    {
        private readonly string _caminhoArquivo;

        // Construtor modificado para permitir o caminho personalizado
        public BackupSenha(string caminhoArquivo)
        {
            _caminhoArquivo = caminhoArquivo;  // Atribui o caminho fornecido ao campo de instância
        }

        // Método para salvar uma senha no arquivo (adiciona novas senhas no final)
        public void SalvarSenha(string senha)
        {
            // Verifica se o diretório onde o arquivo será salvo existe
            string diretorio = Path.GetDirectoryName(_caminhoArquivo);
            if (!Directory.Exists(diretorio))
            {
                // Se não existir, cria o diretório
                Directory.CreateDirectory(diretorio);
            }

            // Adiciona a senha ao final do arquivo, separando por uma nova linha
            File.AppendAllText(_caminhoArquivo, senha + Environment.NewLine);
            Console.WriteLine($"Senha salva no arquivo '{_caminhoArquivo}'.");
        }

        // Método para recuperar todas as senhas do arquivo
        public string RecuperarSenhas()
        {
            if (File.Exists(_caminhoArquivo))
            {
                return File.ReadAllText(_caminhoArquivo);  // Retorna todo o conteúdo do arquivo
            }
            else
            {
                return "Nenhuma senha encontrada.";  // Caso o arquivo não exista
            }
        }
    }
}
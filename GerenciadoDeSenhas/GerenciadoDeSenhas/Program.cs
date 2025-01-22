using System;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;


CREATE DATABASE GerenciadorSenhas;

USE GerenciadorSenhas;

CREATE TABLE Senhas (
    id INT AUTO_INCREMENT PRIMARY KEY,
    site VARCHAR(255) NOT NULL,
    login_email VARCHAR(255) NOT NULL,
    senha_hash VARCHAR(255) NOT NULL
);
class Program
{
    static string connectionString = "Server=localhost;Database=GerenciadorSenhas;User ID=root;Password=informaticasenai;";

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Gerenciador de Senhas");
            Console.WriteLine("1. Adicionar nova senha");
            Console.WriteLine("2. Listar senhas armazenadas");
            Console.WriteLine("3. Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            if (opcao == "1")
            {
                AdicionarSenha();
            }
            else if (opcao == "2")
            {
                ListarSenhas();
            }
            else if (opcao == "3")
            {
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
                Console.ReadKey();
            }
        }
    }

    static void AdicionarSenha()
    {
        Console.Clear();
        Console.WriteLine("Adicionar Nova Senha");

        // Coleta as informações do usuário
        Console.Write("Digite o nome do site: ");
        string site = Console.ReadLine();

        Console.Write("Digite o email/login: ");
        string loginEmail = Console.ReadLine();

        Console.Write("Digite a senha: ");
        string senha = Console.ReadLine();

        // Criptografa a senha
        string senhaCriptografada = CriptografarSenha(senha);

        // Salva no banco de dados
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            try
            {
                conn.Open();
                string query = "INSERT INTO Senhas (site, login_email, senha_hash) VALUES (@site, @loginEmail, @senha)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@site", site);
                    cmd.Parameters.AddWithValue("@loginEmail", loginEmail);
                    cmd.Parameters.AddWithValue("@senha", senhaCriptografada);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Senha salva com sucesso!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao conectar ao banco de dados: {ex.Message}");
            }
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static void ListarSenhas()
    {
        Console.Clear();
        Console.WriteLine("Listar Senhas Armazenadas");

        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM Senhas";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Site: {reader["site"]}, Login/Email: {reader["login_email"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao consultar o banco de dados: {ex.Message}");
            }
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static string CriptografarSenha(string senha)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}

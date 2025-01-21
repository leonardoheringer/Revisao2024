using Gerador_de_Senhas;

class Program
{
    static void Main()
    {
        // Caminho onde o arquivo de backup será salvo
        string caminhoArquivo = @"C:\Users\leona\Documentos\Dev\GitHub\Revisao2024\Gerador de Senhas\Gerador de Senhas\backup\bkp.txt";

        // Criar o objeto BackupSenha com o caminho fornecido
        BackupSenha backup = new BackupSenha(caminhoArquivo);

        // Exibir menu de opções
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1 - Gerar uma nova senha");
        Console.WriteLine("2 - Recuperar todas as senhas geradas");
        int opcao = int.Parse(Console.ReadLine());

        if (opcao == 1)
        {
            // Solicitar informações para gerar a senha
            Console.WriteLine("Digite o tamanho da senha:");
            int tamanho = int.Parse(Console.ReadLine());

            Console.WriteLine("A senha deve conter apenas números (S/N)?");
            bool apenasNumeros = Console.ReadLine().ToUpper() == "S";

            Console.WriteLine("A senha deve conter letras (S/N)?");
            bool comLetras = Console.ReadLine().ToUpper() == "S";

            Console.WriteLine("A senha deve conter caracteres especiais como @, !, #, - (S/N)?");
            bool comEspeciais = Console.ReadLine().ToUpper() == "S";

            // Criar o objeto GeradorSenha e gerar a senha
            GeradorSenha gerador = new GeradorSenha(tamanho, apenasNumeros, comLetras, comEspeciais);
            string senha = gerador.GerarSenha();
            Console.WriteLine($"Senha gerada: {senha}");

            // Salvar a senha no arquivo de backup
            backup.SalvarSenha(senha);
        }
        else if (opcao == 2)
        {
            // Recuperar e exibir todas as senhas salvas
            string senhasRecuperadas = backup.RecuperarSenhas();
            Console.WriteLine($"Senhas recuperadas do arquivo:\n{senhasRecuperadas}");
        }
        else
        {
            Console.WriteLine("Opção inválida.");
        }
    }
}









//double seisd, cincod, quatrod;

//Console.WriteLine("-----Sorteio Mega-Sena-----");
//Random randNum = new Random();

//Console.WriteLine("Valor do Premio "); //Solicita ao usuario o valor do premio
//double premio = Double.Parse(Console.ReadLine());

//Console.Write("Quantidade de jogos: "); //Solicita ao usuario a quantidade de jogos que ele deseja
//int jogos = int.Parse(Console.ReadLine());

//Console.Write("Quantidade de dezenas: "); //Solicita ao usuario a quantidade de dezenas dos jogos
//int quantidade = int.Parse(Console.ReadLine());

//if (quantidade >= 6 && quantidade <= 15)//Define o criterio de que deve ter no minimo 6 dezenas e no maximo 15 dezenas
//{
//    for (int j = 1; j <= jogos; j++)//estrutura de repetição
//    {
//        int num = randNum.Next(1, 60);//defini que os valores sejam entre 1 e 60
//        if (num < 10) //declara que se o numero for menor q 10 adicionaria um zero a esquerda do numero
//        {

//            Console.Write($"0{num}  ");
//        }
//        else
//        {

//            Console.Write($"{num}  ");
//        }


//        for (int i = 1; i < quantidade; i++)//estrutura de repetição
//        {
//            num = randNum.Next(1, 60);
//            if (num < 10) //declara que se o numero for menor q 10 adicionaria um zero a esquerda do numero
//            {
//                Console.Write($"0{num}  ");
//            }
//            else
//            {

//                Console.Write($"{num}  ");
//            }

//        }
//        Console.Write("\n");
//    }

//}

//else
//{
//    Console.WriteLine("Valor Invalido! Tente novamente");
//}
////Define o valor dos premios baseado na quantidade de acerto
//seisd = premio * 0.75;
//Console.WriteLine($"Acertou 6 dezenas o premio será de 75%, um total de R${seisd}");
//cincod = premio * 0.15;
//Console.WriteLine($"Acertou 5 dezenas o premio será de 15%, um total de R${cincod}");
//quatrod = premio * 0.10;
//Console.WriteLine($"Acertou 4 dezenas o premio será de 10%, um total de R${quatrod}");


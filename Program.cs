using NetworkSearch.Entities;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Insira o número de elementos do objeto Network (Exemplo: 7):");
        int numberOfElements = int.Parse(Console.ReadLine());

        var network = new Network(numberOfElements);

        while (true)
        {
            Console.WriteLine("Escolha uma das seguintes opções: 1) Conectar elementos 2) Verificar conexão 3) Sair");
            int option = int.Parse(Console.ReadLine());

            if (option == 1)
            {
                Console.WriteLine("Insira o elemento de origem da conexão:");
                int element1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Insira o elemento de destino da conexão:");
                int element2 = int.Parse(Console.ReadLine());
                network.connect(element1, element2);
            }
            else if (option == 2)
            {
                Console.WriteLine("Insira o elemento de origem:");
                int element1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Insira o elemento de destino:");
                int element2 = int.Parse(Console.ReadLine());
                bool isConnected = network.query(element1, element2);
            }
            else if (option == 3)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }
        }
    }
}

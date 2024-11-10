namespace NetworkSearch.Entities
{
    internal class Network
    {
        private List<int> Elements { get; set; }

        private Dictionary<int, List<int>> Connections { get; set; }

        public Network(int qntElementos)
        {
            Elements = new List<int>();
            Connections = new Dictionary<int, List<int>>();
            Random random = new Random();

            try
            {
                if (qntElementos < 1)
                    throw new Exception("Quantidade de elementos deve ser maior que 0");

                for (int i = 1; i <= qntElementos; i++)
                {
                    Elements.Add(i);
                    Connections.Add(i, new List<int>());
                    Console.WriteLine("Elemento " + i + " criado");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao criar Network: " + e.Message);
            }
        }

        public void connect(int source, int destination)
        {
            if (!Elements.Contains(source))
            {
                Console.WriteLine($"Elemento de origem não encontrado: {source}");
                return;
            }
            else if (!Elements.Contains(destination))
            {
                Console.WriteLine($"Elemento de destino não encontrado: {destination}");
                return;
            }
            else if (Connections[source].Contains(destination))
            {
                Console.WriteLine($"Conexão entre {source} e {destination} já existe");
                return;
            }

            Connections[source].Add(destination);
            Connections[destination].Add(source);

            Console.WriteLine($"Conexão entre {source} e {destination} criada");
        }

        public bool query(int source, int destination)
        {
            if (!Elements.Contains(source))
            {
                Console.WriteLine($"Elemento de origem não encontrado: {source}");
                return false;
            }
            else if (!Elements.Contains(destination))
            {
                Console.WriteLine($"Elemento de destino não encontrado: {destination}");
                return false;
            }

            HashSet<int> searchNodes = new HashSet<int> { source };
            Queue<int> queue = new Queue<int>(searchNodes);

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();

                if (node == destination)
                {
                    Console.WriteLine($"Existe conexão entre {source} e {destination}");
                    return true;
                }

                foreach (var connectedNode in Connections[node])
                {
                    if (searchNodes.Add(connectedNode))
                    {
                        queue.Enqueue(connectedNode);
                    }
                }
            }

            Console.WriteLine($"Não existe conexão entre {source} e {destination}");
            return false;
        }
    }
}

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.Clear();
            bool valida = false;
            string placaInserida = string.Empty;
            while (!valida)
            {
            Console.WriteLine("Digite a placa do veículo para estacionar:\n");
            placaInserida = Console.ReadLine().ToUpper();
                if (placaInserida.Length == 7)
                {
                    valida = true;
                }
                else
                {
                    Console.WriteLine("Insira uma placa válida, a placa deve ter 7 caracteres");
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                }
            }
            this.veiculos.Add(placaInserida);
            Console.WriteLine("Placa Inserida com sucesso");

        }

        public void RemoverVeiculo()
        {
            Console.Clear();
            if (veiculos.Any())
            {
                Console.WriteLine("Digite a placa do veículo para remover:");

                string placa = Console.ReadLine().ToUpper();

                if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                {
                    bool valida = false;
                    int horas = 0;

                    while (!valida)
                    {
                        Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                        string horasInseridas = Console.ReadLine();
                        if (int.TryParse(horasInseridas, out int result))
                        {
                            horas = result;
                            valida = true;
                        }
                        else
                        {
                            Console.WriteLine("Insira um valor de horas válido");
                            System.Threading.Thread.Sleep(2000);
                            Console.Clear();
                        }
                    }


                    decimal valorTotal = this.precoInicial + this.precoPorHora * horas;

                    this.veiculos.Remove(placa);

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                } 
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.\n");
            }
        }

        public void ListarVeiculos()
        {
            Console.Clear();
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:\n");
                int index = 1;
                foreach (string item in veiculos)
                {
                    Console.WriteLine($"Veículo {index}, Placa: {item}\n");
                    index++;
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.\n");
            }
        }
    }
}

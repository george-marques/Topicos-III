namespace Atividade2_George.src.Model
{
    class Program
    {
        static void Main(string[] args)
        {
            int ano = 0;
            bool simulacaoAtiva = true;

            while (simulacaoAtiva)
            {
                ano++;
                for (int mes = 1; mes <= 12; mes++)
                {
                    Console.WriteLine("Mes " + mes);
                    Entidade.SimularMes();

                    // Verifica se a Indústria ou Comércio podem continuar operando
                    if (Entidade.caixaIndustria <= 0 || !Entidade.ComercioPodeReporEstoque())
                    {
                        Console.WriteLine("A Indústria não tem mais dinheiro em caixa para operar");
                        simulacaoAtiva = false;
                        break;
                    }
                }

                // Exibe o status financeiro ao final do ano
                Console.WriteLine();
                Console.WriteLine("Situacao economica final");
                Entidade.ImprimeSituacaoEconomica();
                Console.WriteLine();
            }

            Console.WriteLine($"A simulação terminou no {ano} ano.");
        }

    }
}


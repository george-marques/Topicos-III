namespace Atividade2_George.src.Model
{
    public class Entidade
    {
        // Constantes do cenário
        const int TOTAL_PESSOAS = 1000;
        const int PESSOAS_PREFEITURA = 125;
        const int PESSOAS_COMERCIO = 200;
        const int PESSOAS_INDUSTRIA = TOTAL_PESSOAS - PESSOAS_PREFEITURA - PESSOAS_COMERCIO;
        const int PESSOAS_SERVICOS_SOCIAIS = 55;

        // Salários e benefícios
        const double SALARIO_PREFEITURA = 20000;
        const double SALARIO_COMERCIO = 7500;
        const double SALARIO_INDUSTRIA = 10000;
        const double BENEFICIO_SERVICOS_SOCIAIS = 1000;

        // Caixa inicial das entidades
        static double caixaPrefeitura = 0;
        static double caixaComercio = 10000000;
        public static double caixaIndustria = 50000000;

        // Custos e preços
        const double CUSTO_PRODUCAO_INDUSTRIA = 42.75;   
        const double PRECO_VENDA_INDUSTRIA = 75;        
        const double CUSTO_REPOSICAO_COMERCIO = PRECO_VENDA_INDUSTRIA; 
        const double PRECO_VENDA_COMERCIO = 203;        

        // Impostos
        const double IMPOSTO_SALARIAL_EMPRESA = 0.61;
        const double IMPOSTO_SALARIAL_TRABALHADOR = 0.25;
        const double IMPOSTO_VENDA_COMERCIO = 0.38;
        const double IMPOSTO_VENDA_INDUSTRIA = 0.18;
        
        // Simulação mensal
        public static void SimularMes()
        {
            PagarSalarios();
            RecolherImpostos();
            RealizarComprasComercio();
            ReporEstoqueComercio();

            ImprimeSituacaoEconomica();
        }

        public static void ImprimeSituacaoEconomica()
        {
            Console.WriteLine($"Caixa Prefeitura: R$ {caixaPrefeitura:C}");
            Console.WriteLine($"Caixa Comércio: R$ {caixaComercio:C}");
            Console.WriteLine($"Caixa Indústria: R$ {caixaIndustria:C}");
            Console.WriteLine();
        }

        // Pagamento de salários e benefícios sociais
        static void PagarSalarios()
        {
            double totalSalariosPrefeitura = PESSOAS_PREFEITURA * SALARIO_PREFEITURA;
            double totalSalariosComercio = PESSOAS_COMERCIO * SALARIO_COMERCIO;
            double totalSalariosIndustria = PESSOAS_INDUSTRIA * SALARIO_INDUSTRIA;
            double totalBeneficios = PESSOAS_SERVICOS_SOCIAIS * BENEFICIO_SERVICOS_SOCIAIS;

            // Prefeitura paga salários e benefícios
            caixaPrefeitura -= totalSalariosPrefeitura + totalBeneficios;

            // Comércio paga salários
            caixaComercio -= totalSalariosComercio;

            // Indústria paga salários
            caixaIndustria -= totalSalariosIndustria;
        }

        // Recolhimento de impostos sobre salários
        static void RecolherImpostos()
        {
            caixaPrefeitura += PESSOAS_PREFEITURA * (SALARIO_PREFEITURA * IMPOSTO_SALARIAL_EMPRESA);
            caixaPrefeitura += PESSOAS_COMERCIO * (SALARIO_COMERCIO * IMPOSTO_SALARIAL_EMPRESA);
            caixaPrefeitura += PESSOAS_INDUSTRIA * (SALARIO_INDUSTRIA * IMPOSTO_SALARIAL_EMPRESA);
        }

        // Realização de compras no comércio por todas as pessoas
        static void RealizarComprasComercio()
        {
            double totalSalarioPopulacao = (PESSOAS_PREFEITURA * SALARIO_PREFEITURA * (1 - IMPOSTO_SALARIAL_TRABALHADOR))
                                         + (PESSOAS_COMERCIO * SALARIO_COMERCIO * (1 - IMPOSTO_SALARIAL_TRABALHADOR))
                                         + (PESSOAS_INDUSTRIA * SALARIO_INDUSTRIA * (1 - IMPOSTO_SALARIAL_TRABALHADOR))
                                         + (PESSOAS_SERVICOS_SOCIAIS * BENEFICIO_SERVICOS_SOCIAIS);

            // A população compra itens no Comércio pelo PREÇO_VENDA_COMERCIO
            double totalItensComprados = totalSalarioPopulacao / PRECO_VENDA_COMERCIO;

            // Comércio recebe o dinheiro das compras
            caixaComercio += totalItensComprados * PRECO_VENDA_COMERCIO;

            // Comércio recolhe impostos sobre vendas
            double impostosComercio = totalItensComprados * PRECO_VENDA_COMERCIO * IMPOSTO_VENDA_COMERCIO;
            caixaPrefeitura += impostosComercio;

            // Caixa do comércio é descontado pelos impostos sobre vendas
            caixaComercio -= impostosComercio;
        }

        // Reposição de estoque do comércio
        static void ReporEstoqueComercio()
        {
            int totalItensNecessarios = TOTAL_PESSOAS;  

            // Comércio paga à Indústria pelos itens
            double custoReposicao = totalItensNecessarios * CUSTO_REPOSICAO_COMERCIO;
            caixaComercio -= custoReposicao;
            caixaIndustria += custoReposicao;

            // Indústria paga impostos sobre a venda
            double impostosIndustria = custoReposicao * IMPOSTO_VENDA_INDUSTRIA;
            caixaPrefeitura += impostosIndustria;

            // Caixa da indústria é descontado pelos impostos
            caixaIndustria -= impostosIndustria;

            // Indústria paga os custos de produção
            double custoProducaoTotal = totalItensNecessarios * CUSTO_PRODUCAO_INDUSTRIA;
            caixaIndustria -= custoProducaoTotal;
        }

        // Verifica se o comércio pode repor o estoque
        public static bool ComercioPodeReporEstoque()
        {
            int totalItensNecessarios = TOTAL_PESSOAS;
            double custoReposicao = totalItensNecessarios * CUSTO_REPOSICAO_COMERCIO;

            return caixaComercio >= custoReposicao;
        }
    }

}


using System;


namespace Calculadora
{
    class Program
    {
        enum Menu { Adição = 1, Subtração, Multiplicação, Divisão, Exponenciação, Radiciação, Sair };

        static double Entrada(string mensagem)
        {
            do
            {
                string entrada;
                double num;
                Console.Write(mensagem);
                entrada = Console.ReadLine();
                if (double.TryParse(entrada, out num))
                {
                    return num;
                }
                else
                {
                    Console.WriteLine("Valor informado não é válido! Informe outro valor.");
                }
            } while (true);
        }

        static void Somar()
        {
            double soma, numA, numB;
            numA = Entrada("Digite o primeiro número: ");
            numB = Entrada("Digite o segundo número: ");
            soma = numA + numB;
            Console.WriteLine("Resultado da Adição: " + soma);             
        } 

        static void Subtracao()
        {
            double subtracao, numA, numB;
            numA = Entrada("Digite o primeiro número: ");
            numB = Entrada("Digite o segundo número: ");
            subtracao = numA - numB;
            Console.WriteLine("Resultado da Subtração: " + subtracao);
        }

        static void Multiplicacao()
        {
            double multiplicacao, numA, numB;
            numA = Entrada("Digite o primeiro número: ");
            numB = Entrada("Digite o segundo número: ");
            multiplicacao = numA * numB;
            Console.WriteLine("Resultado da Multiplicação: " + multiplicacao);
        }

        static void Divisao()
        {
            double divisao, numA, numB = 0;
            numA = Entrada("Digite o primeiro número: ");
            while (numB == 0 )
            {
                numB = Entrada("Digite o segundo número: ");
                if (numB == 0)
                {
                    Console.WriteLine("Lembre-se que não existe divisão por 0 (zero).");
                }
            }

            divisao = numA / numB;
            Console.WriteLine("Resultado da Divisão: " + divisao);
        }

        static void Exponenciacao()
        {
            double exp, numA, numB;
            numA = Entrada("Digite o valor da base: ");
            numB = Entrada("Digite o valor do expoente: ");
            exp = Math.Pow(numA, numB);
            Console.WriteLine("Resultado da Exponenciação: " + exp);
        }

        static void Radiciacao()
        {
            double rad, numA, numB;
            numA = Entrada("Digite o valor do radicando: ");
            numB = Entrada("Digite o valor do índice: ");
            rad = Math.Pow(numA, 1/numB);
            Console.WriteLine("Resultado da Exponenciação: " + rad);
        }

        static void Main(string[] args)
        {
            int opcao;
            do
            {
                opcao = 0;
                string entrada;
                Console.WriteLine("\t\t\tSeja bem vindo ao CALC!!!");
                Console.WriteLine("===========================================================================");
                Console.WriteLine("\nDigite o número correspondente a cálculo que deseja realizar:");
                Console.WriteLine("1 - Adição de 2 números\n2 - Subtração de 2 números\n3 - Multiplicação de 2 números\n4 - Divisão de 2 números\n5 - Exponenciação\n6 - Radiciação\n7 - Sair");
                Console.Write("\nOpção desejada: ");
                entrada = Console.ReadLine();
                while (opcao == 0)
                {
                    if (int.TryParse(entrada, out opcao) && opcao <= 7 && opcao >= 1)
                    {
                        Menu operacao = (Menu)opcao;

                        Console.Clear();
                        Console.WriteLine("\t\t\tA operação escolhida foi " + operacao);
                        Console.WriteLine("===========================================================================");
                        switch (operacao)
                        {
                            case Menu.Adição:
                                Somar();
                                break;
                            case Menu.Subtração:
                                Subtracao();
                                break;
                            case Menu.Multiplicação:
                                Multiplicacao();
                                break;
                            case Menu.Divisão:
                                Divisao();
                                break;
                            case Menu.Exponenciação:
                                Exponenciacao();
                                break;
                            case Menu.Radiciação:
                                Radiciacao();
                                break;
                            case Menu.Sair:
                                break;
                        }
                    }
                    else
                    {
                        Console.Write("O valor informado não corresponde a nenhum item do menu. Confirme o valor correto e informe novamente:");
                        entrada = Console.ReadLine();
                    }
                };
                if (opcao != 7)
                {
                    Console.WriteLine("===========================================================================");
                    Console.WriteLine("Deseja realizar um novo cálculo? (Use s para Sim) ");
                    Console.Write("Opção desejada: ");
                    string opcao2 = Console.ReadLine();
                    if (!opcao2.ToUpper().Equals("S"))
                        opcao = 7;
                }                   
                Console.Clear();
            } while (opcao != 7);
        }
    }
}

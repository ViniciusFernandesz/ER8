using System;
using System.Threading;
using System.Collections.Generic;
using System.IO;

namespace EncontroRemoto
{
   class Program
   {
       static void Main(string[] args)
       {

           List<PessoaFisica> listaPf = new List<PessoaFisica>();
           List<PessoaJuridica> listaPj = new List<PessoaJuridica>();
           Console.Clear();
           Console.ForegroundColor = ConsoleColor.DarkGreen;
           Console.BackgroundColor = ConsoleColor.White;
           Console.WriteLine(@$"
========================================
|  Bem-vindo ao Sistema de Cadastro    |
|  de Pessoa Física e Pessoa Jurídica  |
========================================
");
            BarraCarregamento("Iniciando");

            string? opcao;
           
            do
            {
                Console.WriteLine(@$"
===================================
| Escolha uma das opções abaixo   |
|        PESSSOA FÍSICA           |
| 1 - Cadastrar Pessoa Física     |
| 2 - Listar Pessoa Física        |
| 3 = Remover Pessoa Física       |
|                                 | 
|         PESSOA JURÍDICA         |
| 4 - Cadastrar Pessoa Jurídica   |
| 5 - Listar Pessoa Jurídica      |
| 6 - Remover Pessoa Jurídica     |
|                                 |
|        0 - Sair                 |
===================================
");
                
                opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Endereco endPf = new Endereco();

                    Console.WriteLine($"Digite seu logradouro:");
                    endPf.logradouro = Console.ReadLine();

                    Console.WriteLine($"Digite o número:");
                    endPf.numero = int.Parse(Console.ReadLine());

                    Console.WriteLine($"Digite o complemento (aperte ENTER para vazio)");
                    endPf.complemento = Console.ReadLine();

                    Console.WriteLine($"Este endereço é comercial? S/N");
                    string endComercial = Console.ReadLine().ToUpper();

                    if (endComercial == "S")
                    {
                        endPf.enderecoComercial = true;
                    }
                    else
                    {
                        endPf.enderecoComercial = false;
                    }

                    PessoaFisica novapf = new PessoaFisica();

                    Console.WriteLine($"Digite seu CPF (somente números)");
                    novapf.cpf = Console.ReadLine();

                    Console.WriteLine($"Digite seu nome:");
                    novapf.nome = Console.ReadLine();

                    Console.WriteLine($"Digite sua data de nascimento:");
                    novapf.dataNascimento = DateTime.Parse(Console.ReadLine());

                    PessoaFisica pf = new PessoaFisica();
                    // pf.ValidarDataNascimento(novapf.dataNascimento);

                    bool idadeValida = pf.ValidarDataNascimento(novapf.dataNascimento);

                    if (idadeValida == true)
                    {
                        System.Console.WriteLine($"Cadastro Aprovado");
                        listaPf.Add(novapf);
                        Console.WriteLine($"Digite seu rendimento:");
                        novapf.rendimento = float.Parse(Console.ReadLine());
                        Console.WriteLine($"Imposto a pagar: R$" + pf.PagarImposto(novapf.rendimento).ToString("N2"));
                        StreamWriter sw = new StreamWriter("/home/clarice/Documentos/Estudos/Senai/SA2EncontroRemotoER8/" + novapf.nome + ".txt");
                        sw.WriteLine("Dados da Pessoa Física:");
                        sw.WriteLine("Nome: " + novapf.nome);
                        sw.WriteLine("CPF: " + novapf.cpf);
                        sw.WriteLine("Data de Nascimento: " + novapf.dataNascimento);
                        sw.WriteLine("Endereço: " + endPf.logradouro + ", n°" + endPf.numero);
                        sw.WriteLine("Rendimento: " + novapf.rendimento);
                        sw.WriteLine("Imposto a pagar: R$" +  pf.PagarImposto(novapf.rendimento).ToString("N2"));
                        sw.Close();
                    }
                    else
                    {
                        Console.WriteLine($"Cadastro Não Aprovado");
                    }

                    // Console.WriteLine(pf.ValidarDataNascimento(novapf.dataNascimento));
                    // Console.WriteLine("Rua: " + novapf.endereco.logradouro + ", " + novapf.endereco.numero);
                    break;

                case "2":
                    foreach (var cadaItem in listaPf)
                    {
                        Console.WriteLine($"{cadaItem.nome}, {cadaItem.cpf}, {cadaItem.dataNascimento}");
                    }
                    break;

                case "3":
                    Console.WriteLine($"Digite o CPF que deseja remover:");
                    string cpfProcurado = Console.ReadLine();

                    PessoaFisica pessoaEncontrada = listaPf.Find(cadaItem => cadaItem.cpf == cpfProcurado);
                    if (pessoaEncontrada != null)
                    {
                        listaPf.Remove(pessoaEncontrada);
                        Console.WriteLine($"Cadastro Removido");
                    }
                    else
                    {
                        Console.WriteLine($"CPF não encontrado");
                    }
                    break;
                    
                case "4":
                    Endereco endPj = new Endereco();

                    Console.WriteLine($"Digite seu logradouro:");
                    endPj.logradouro = Console.ReadLine();

                    Console.WriteLine($"Digite o número:");
                    endPj.numero = int.Parse(Console.ReadLine());

                    Console.WriteLine($"Digite o complemento (aperte ENTER para vazio)");
                    endPj.complemento = Console.ReadLine();

                    Console.WriteLine($"Este endereço é comercial? S/N");
                    string endComercialpj = Console.ReadLine().ToUpper();

                    if (endComercialpj == "S")
                    {
                        endPj.enderecoComercial = true;
                    }
                    else
                    {
                        endPj.enderecoComercial = false;
                    }
                    
                    PessoaJuridica novapj = new PessoaJuridica();

                    Console.WriteLine($"Digite seu CNPJ (somente números)");
                    novapj.cnpj = Console.ReadLine();

                    Console.WriteLine($"Digite a Razão Social:");
                    novapj.razaoSocial = Console.ReadLine();

                    PessoaJuridica pj = new PessoaJuridica();
                    // pj.ValidarCNPJ(novapj.cnpj);

                    bool cnpjValido = pj.ValidarCNPJ(novapj.cnpj);

                    if (cnpjValido == true)
                    {
                        System.Console.WriteLine($"Cadastro Aprovado");
                        listaPj.Add(novapj);
                        Console.WriteLine($"Digite seu rendimento:");
                        novapj.rendimento = float.Parse(Console.ReadLine());
                        Console.WriteLine($"Imposto a pagar: R$" + pj.PagarImposto(novapj.rendimento).ToString("N2"));
                        StreamWriter sw = new StreamWriter("/home/clarice/Documentos/Estudos/Senai/SA2EncontroRemotoER8/" + novapj.nome + ".txt");
                        sw.WriteLine("Dados da Pessoa Jurídica:");
                        sw.WriteLine("Razão Social: " + novapj.razaoSocial);
                        sw.WriteLine("CNPJ: " + novapj.cnpj);
                        sw.WriteLine("Endereço: " + endPj.logradouro + ", n°" + endPj.numero);
                        sw.WriteLine("Rendimento: " + novapj.rendimento);
                        sw.WriteLine("Imposto a pagar: R$" +  pj.PagarImposto(novapj.rendimento).ToString("N2"));
                        sw.Close();
                    }
                    else
                    {
                        Console.WriteLine($"Cadastro Não Aprovado");
                    }
                    
                    break;
                    
                case "5":
                    foreach (var cadaItem in listaPj)
                    {
                        Console.WriteLine($"{cadaItem.razaoSocial}, {cadaItem.cnpj}");
                    }
                    break;
                
                case "6":
                    Console.WriteLine($"Digite o CNPJ que deseja remover:");
                    string cnpjProcurado = Console.ReadLine();

                    PessoaJuridica pjEncontrada = listaPj.Find(cadaItem => cadaItem.cnpj == cnpjProcurado);
                    if (pjEncontrada != null)
                    {
                        listaPj.Remove(pjEncontrada);
                        Console.WriteLine($"Cadastro Removido");
                    }
                    else
                    {
                        Console.WriteLine($"CNPJ não encontrado");
                    }
                    break;
                
                case "0":
                    Console.WriteLine($"Obrigado por utilizar o nosso sistema");
                    BarraCarregamento("Finalizando");
                    break;
                
                default:
                    Console.WriteLine($"Opção inválida, digite uma opção válida");
                    break;
            }
                
            } while (opcao != "0");
       }

        static void BarraCarregamento(string textoCarregamento)
        {
            Console.ResetColor(); 
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(textoCarregamento);
            Thread.Sleep(500);


            for (var contador = 0; contador < 10; contador++)
            {
                
                Console.Write($".");
                Thread.Sleep(500);            
            }
            Console.ResetColor();  


        }
   }
}
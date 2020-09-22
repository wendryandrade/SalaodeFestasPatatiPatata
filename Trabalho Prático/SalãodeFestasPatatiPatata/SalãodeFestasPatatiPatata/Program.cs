using System;
using System.IO;
using System.Text;

namespace SalãodeFestasPatatiPatata
{
    class Program
    {
        static void Main(string[] args)
        {

            int opescolhida;

            do
            {
                Console.WriteLine("\n\nRESPONDA TUDO EM LETRA MINÚSCULA, MENOS AS OPÇÕES" +
                    "\nMenu Festa:" +
                    "\n1- Cadastrar um cliente" +
                    "\n2- Cadastrar um funcionário" +
                    "\n3- Cadastrar um fornecedor" +
                    "\n4- Cadastrar uma festa" +
                    "\n5- Contrato" +
                    "\n6- Pesquisar" +
                    "\n7- SAIR");
                opescolhida = int.Parse(Console.ReadLine());

                if (opescolhida == 1)
                {
                    //Cadastrar Cliente
                    int codcliente = 0, telcliente = 0, datanasc = 0;
                    string nomecliente = " ", end = " ";
                    CadastraCliente(codcliente, nomecliente, telcliente, end, datanasc);
                }

                if (opescolhida == 2)
                {
                    //Cadastrar Funcionário
                    int codfunc = 0, telfunc = 0;
                    string nomefunc = " ", funcao = " ", tipo = " ";
                    double salario = 0;
                    CadastraFuncionario(codfunc, nomefunc, telfunc, funcao, salario, tipo);
                }

                if (opescolhida == 3)
                {
                    //Cadastrar Fornecedor
                    int codforn = 0, telforn = 0;
                    string nomeforn = " ", produtoforn = " ";
                    CadastraFornecedor(codforn, nomeforn, telforn, produtoforn);
                }

                if (opescolhida == 4)
                {
                    //Cadastrar Festa
                    int codfesta = 0, qtdconv = 0, data = 0, hrinicio = 0, hrfim = 0, codcliente = 0;
                    string tema = " ", diasem = " ";
                    CadastraFesta(codfesta, qtdconv, data, diasem, hrinicio, hrfim, tema, codcliente);
                }

                if (opescolhida == 5)
                {

                    int opescolhidacontrato = 0;

                    Console.WriteLine("\nMenu Contrato" +
                        "\n1- Cadastrar um contrato" +
                        "\n2- Calcular valores de contratos já cadastrados" +
                        "\n3- Gerar ou atualizar status do contrato");
                    opescolhidacontrato = int.Parse(Console.ReadLine());

                    if (opescolhidacontrato == 1)
                    {

                        //Cadastrar Contrato
                        int numcontrato = 0, codfesta = 0;
                        string formpag = " ";
                        CadastraContrato(numcontrato, formpag, codfesta);

                    }

                    if (opescolhidacontrato == 2)
                    {

                        //Calcula Valores
                        double valortot = 0, valorfinal = 0;
                        string desconto = " ";
                        CalculaValorTotaleFinal(valortot, valorfinal, desconto);

                    }
                    
                    if (opescolhidacontrato == 3)
                    {
                        //Atualizar status de contrato


                        int novostatus = 0;
                        string respstatus = " ";

                        Console.WriteLine("\n\nStatus:" +
                            "\n1- Pago" +
                            "\n2- Cancelado" +
                            "\n3- Gerar");
                        novostatus = int.Parse(Console.ReadLine());

                        if (novostatus == 1)
                        {
                            respstatus = "pago";
                        }

                        if (novostatus == 2)
                        {
                            respstatus = "cancelado";
                        }

                        if (novostatus == 3)
                        {
                            respstatus = "a pagar";
                        }

                        if ((novostatus < 1) || (novostatus > 3))
                        {
                            Console.WriteLine("\nOpção inválida!");
                        }

                        GeraeAtualizaStatusContrato(respstatus);


                    }

                    if ((opescolhidacontrato < 1) || (opescolhidacontrato > 3))
                    {
                        Console.WriteLine("\nOpção inválida!");
                    }


                }


                if (opescolhida == 6)
                {
                    //Pesquisar
                    string opescolhidapesq = " ", nomecliente = " ", nomefunc = " ", nomeforn = " ";

                    Console.WriteLine("\n\nMenu Pesquisa:" +
                                       "\nA- Informações de Clientes" +
                                       "\nB- Informações de Funcionários" +
                                       "\nC- Informações de Fornecedores" +
                                       "\nD- Informações de Festas" +
                                       "\nE- Informações de Contrato");
                    opescolhidapesq = Console.ReadLine();

                    //Informações de clientes por nome
                    if (opescolhidapesq == "A")
                    {
                        Console.WriteLine("\nDigite o nome do cliente: ");
                        nomecliente = Console.ReadLine();
                        RealizaPesquisaCliente(nomecliente);
                    }

                    //Informações de funcionário por nome
                    if (opescolhidapesq == "B")
                    {
                        Console.WriteLine("\nDigite o nome do funcionário: ");
                        nomefunc = Console.ReadLine();
                        RealizaPesquisaFuncionario(nomefunc);
                    }

                    //Informações de fornecedor por nome
                    if (opescolhidapesq == "C")
                    {
                        Console.WriteLine("\nDigite o nome do fornecedor: ");
                        nomeforn = Console.ReadLine();
                        RealizaPesquisaFornecedor(nomeforn);
                    }

                    //Informações de festas
                    if (opescolhidapesq == "D")
                    {
                        string opescolhidafesta = " ";

                        Console.WriteLine("\n\nMenu Pesquisa Festas: " +
                            "\nA- Código do cliente" +
                            "\nB- Data da Festa (verá +info de contrato)");
                        opescolhidafesta = Console.ReadLine();

                        //Pesquisas festa por nome do cliente
                        if (opescolhidafesta == "A")
                        {
                            int codcliente = 0;

                            Console.WriteLine("\nDigite o código do cliente: ");
                            codcliente = int.Parse(Console.ReadLine());
                            RealizaPesquisaFestasCliente(codcliente);
                        }

                        //Pesquisar festa por data 
                        if (opescolhidafesta == "B")
                        {
                            int datafesta = 0;

                            Console.WriteLine("\nDigite a data da festa (sem separação): ");
                            datafesta = int.Parse(Console.ReadLine());
                            RealizaPesquisaFestasData(datafesta);
                        }
                    }

                    //Informações contrato
                    if (opescolhidapesq == "E")
                    {
                        int codfesta = 0;

                        Console.WriteLine("\nDigite o código da festa: ");
                        codfesta = int.Parse(Console.ReadLine());
                        RealizaPesquisaContrato(codfesta);
                    }

                }



                //SAIR
                if (opescolhida == 7)
                {
                    break;
                }

                //Opção inexistente
                if ((opescolhida > 7) || (opescolhida < 0))
                {
                    Console.WriteLine("\nOpção inválida, tente novamente!");
                }

            } while (opescolhida != 8);
        }



        //CLIENTE = código, nome, endereço, telefone, data de nascimento
        public static void CadastraCliente(int codcliente, string nomecliente, int telcliente, string end, int datanasc)
        {
            //Se o arquivo cliente existir
            if (File.Exists("cliente.txt"))
            {

                //Lê o arquivo cliente

                FileStream arqlecliente = new FileStream("cliente.txt", FileMode.Open);
                StreamReader lecliente = new StreamReader(arqlecliente);

                string linha = " ";
                string[] resultado;
                codcliente = 1;

                do
                {
                    linha = lecliente.ReadLine();
                    if (linha != null)
                    {
                        resultado = linha.Split(',');


                        if (resultado[0] == (" Código cliente: " + codcliente.ToString()))
                        {
                            //O novo código será o código anterior mais um
                            codcliente = codcliente + 1;
                        }

                    }
                } while (linha != null);

                lecliente.Close();


                //Append = abrirá arquivo existente e continuará escrevendo nele, e se não existir irá criar
                FileStream arqescrevecliente = new FileStream("cliente.txt", FileMode.Append);
                StreamWriter escrevecliente = new StreamWriter(arqescrevecliente);

                escrevecliente.Write(" Código cliente: " + codcliente + ",");

                Console.Write("\nDigite seu nome: ");
                nomecliente = Console.ReadLine();
                escrevecliente.Write(" Nome cliente: " + nomecliente + ",");

                Console.Write("\nDigite seu endereço: ");
                end = Console.ReadLine();
                escrevecliente.Write(" Endereço: " + end + ",");

                Console.Write("\nDigite seu telefone: ");
                telcliente = int.Parse(Console.ReadLine());
                escrevecliente.Write(" Telefone cliente: " + telcliente + ",");

                Console.Write("\nDigite sua data de nascimento (sem separação): ");
                datanasc = int.Parse(Console.ReadLine());
                escrevecliente.Write(" Data nasc: " + datanasc + ",");

                escrevecliente.WriteLine(" ");
                escrevecliente.Close();
            }

            //Se o arquivo cliente NÃO existir
            else
            {
                Console.WriteLine("Nenhum cliente foi cadastrado ainda, cadastre o primeiro agora!");

                //Abrir arquivo existente e continuar escrevendo nele, e se não existir irá criar
                FileStream arqescrevecliente = new FileStream("cliente.txt", FileMode.Append);
                StreamWriter escrevecliente = new StreamWriter(arqescrevecliente);

                codcliente = 1;
                escrevecliente.Write(" Código cliente: " + codcliente + ",");

                Console.Write("\nDigite seu nome: ");
                nomecliente = Console.ReadLine();
                escrevecliente.Write(" Nome cliente: " + nomecliente + ",");

                Console.Write("\nDigite seu endereço: ");
                end = Console.ReadLine();
                escrevecliente.Write(" Endereço: " + end + ",");

                Console.Write("\nDigite seu telefone: ");
                telcliente = int.Parse(Console.ReadLine());
                escrevecliente.Write(" Telefone cliente: " + telcliente + ",");

                Console.Write("\nDigite sua data de nascimento (sem separação): ");
                datanasc = int.Parse(Console.ReadLine());
                escrevecliente.Write(" Data nasc: " + datanasc + ",");

                escrevecliente.WriteLine(" ");
                escrevecliente.Close();
            }

        }


        //FUNCIONARIO = código, nome, telefone, função, salario, tipo (temporário ou fixo)
        public static void CadastraFuncionario(int codfunc, string nomefunc, int telfunc, string funcao, double salario, string tipo)
        {
            //Se o arquivo funcionário existir
            if (File.Exists("funcionario.txt"))
            {

                //Lê o arquivo funcionário

                FileStream arqlefunc = new FileStream("funcionario.txt", FileMode.Open);
                StreamReader lefunc = new StreamReader(arqlefunc);

                string linha = " ";
                string[] resultado;
                codfunc = 1;

                do
                {
                    linha = lefunc.ReadLine();
                    if (linha != null)
                    {
                        resultado = linha.Split(',');


                        if (resultado[0] == (" Código funcionário: " + codfunc.ToString()))
                        {
                            codfunc = codfunc + 1;
                        }

                    }
                } while (linha != null);

                lefunc.Close();


                //Abrirá o arquivo existente e continuará escrevendo nele, e se não existir irá criar
                FileStream arqescrevefunc = new FileStream("funcionario.txt", FileMode.Append);
                StreamWriter escrevefunc = new StreamWriter(arqescrevefunc);

                escrevefunc.Write(" Código funcionário: " + codfunc + ",");

                Console.Write("\nDigite seu nome: ");
                nomefunc = Console.ReadLine();
                escrevefunc.Write(" Nome funcionário: " + nomefunc + ",");

                Console.Write("\nDigite seu telefone: ");
                telfunc = int.Parse(Console.ReadLine());
                escrevefunc.Write(" Telefone funcionário: " + telfunc + ",");

                Console.Write("\nDigite sua função: ");
                funcao = Console.ReadLine();
                escrevefunc.Write(" Função: " + funcao + ",");

                Console.Write("\nDigite seu salário: ");
                salario = double.Parse(Console.ReadLine());
                escrevefunc.Write(" Salário: " + salario + ",");

                Console.Write("\nDigite seu tipo (temporário ou fixo): ");
                tipo = Console.ReadLine();
                escrevefunc.Write(" Tipo: " + tipo + ",");

                escrevefunc.WriteLine(" ");
                escrevefunc.Close();
            }

            //Se o arquivo funcionário NÃO existir
            else
            {
                Console.WriteLine("Nenhum funcionário foi cadastrado ainda, crie seu primeiro funcionário!");

                //Append = abrirá o arquivo existente e continuará escrevendo nele, e se não existir irá criar
                FileStream arqescrevefunc = new FileStream("funcionario.txt", FileMode.Append);
                StreamWriter escrevefunc = new StreamWriter(arqescrevefunc);

                codfunc = 1;
                escrevefunc.Write(" Código funcionário: " + codfunc + ",");

                Console.Write("\nDigite seu nome: ");
                nomefunc = Console.ReadLine();
                escrevefunc.Write(" Nome funcionário: " + nomefunc + ",");

                Console.Write("\nDigite seu telefone: ");
                telfunc = int.Parse(Console.ReadLine());
                escrevefunc.Write(" Telefone funcionário: " + telfunc + ",");

                Console.Write("\nDigite sua função: ");
                funcao = Console.ReadLine();
                escrevefunc.Write(" Função: " + funcao + ",");

                Console.Write("\nDigite seu salário: ");
                salario = double.Parse(Console.ReadLine());
                escrevefunc.Write(" Salário: " + salario + ",");

                Console.Write("\nDigite seu tipo (temporário ou fixo): ");
                tipo = Console.ReadLine();
                escrevefunc.Write(" Tipo: " + tipo + ",");

                escrevefunc.WriteLine(" ");
                escrevefunc.Close();
            }
        }





        //FORNECEDOR = código, nome, telefone, produto fornecido
        public static void CadastraFornecedor(int codforn, string nomeforn, int telforn, string produtoforn)
        {
            //Se o arquivo fornecedor existir
            if (File.Exists("fornecedor.txt"))
            {

                //Lê o arquivo fornecedor

                FileStream arqleforn = new FileStream("fornecedor.txt", FileMode.Open);
                StreamReader leforn = new StreamReader(arqleforn);

                string linha = " ";
                string[] resultado;
                codforn = 1;

                do
                {
                    linha = leforn.ReadLine();
                    if (linha != null)
                    {
                        resultado = linha.Split(',');


                        if (resultado[0] == (" Código fornecedor: " + codforn.ToString()))
                        {
                            codforn = codforn + 1;
                        }

                    }
                } while (linha != null);

                leforn.Close();


                //Abrirá o arquivo existente e continuará escrevendo nele, e se não existir irá criar
                FileStream arqescreveforn = new FileStream("fornecedor.txt", FileMode.Append);
                StreamWriter escreveforn = new StreamWriter(arqescreveforn);

                escreveforn.Write(" Código fornecedor: " + codforn + ",");

                Console.Write("\nDigite seu nome: ");
                nomeforn = Console.ReadLine();
                escreveforn.Write(" Nome fornecedor: " + nomeforn + ",");

                Console.Write("\nDigite seu telefone: ");
                telforn = int.Parse(Console.ReadLine());
                escreveforn.Write(" Telefone fornecedor: " + telforn + ",");

                Console.Write("\nDigite seu produto fornecido: ");
                produtoforn = Console.ReadLine();
                escreveforn.Write(" Produto fornecido: " + produtoforn + ",");

                escreveforn.WriteLine(" ");
                escreveforn.Close();
            }


            //Se o arquivo fornecedor NÃO existir
            else
            {
                Console.WriteLine("Nenhum fornecedor foi cadastrado ainda, crie seu primeiro fornecedor!");

                //Append = abrirá o arquivo existente e continuará escrevendo nele, e se não existir irá criar
                FileStream arqescreveforn = new FileStream("fornecedor.txt", FileMode.Append);
                StreamWriter escreveforn = new StreamWriter(arqescreveforn);

                codforn = 1;
                escreveforn.Write(" Código fornecedor: " + codforn + ",");

                Console.Write("\nDigite seu nome: ");
                nomeforn = Console.ReadLine();
                escreveforn.Write(" Nome fornecedor: " + nomeforn + ",");

                Console.Write("\nDigite seu telefone: ");
                telforn = int.Parse(Console.ReadLine());
                escreveforn.Write(" Telefone fornecedor: " + telforn + ",");

                Console.Write("\nDigite seu produto fornecido: ");
                produtoforn = Console.ReadLine();
                escreveforn.Write(" Produto fornecido: " + produtoforn + ",");

                escreveforn.WriteLine(" ");
                escreveforn.Close();
            }
        }




        //FESTA = código festa, quantidade de convidados, data, dia da semana, horário (inicio e fim), tema, código cliente
        public static void CadastraFesta(int codfesta, int qtdconv, int data, string diasem, int hrinicio, int hrfim, string tema, int codcliente)
        {

            //Se o arquivo festa existir
            if (File.Exists("festa.txt"))
            {

                //Lê o arquivo festa

                FileStream arqlefesta = new FileStream("festa.txt", FileMode.Open);
                StreamReader lefesta = new StreamReader(arqlefesta);

                string linhafesta = " ";
                string[] resultadofesta;
                codfesta = 1;

                do
                {
                    linhafesta = lefesta.ReadLine();
                    if (linhafesta != null)
                    {
                        resultadofesta = linhafesta.Split(',');


                        if (resultadofesta[0] == (" Código festa: " + codfesta.ToString()))
                        {
                            codfesta = codfesta + 1;
                        }

                    }
                } while (linhafesta != null);

                lefesta.Close();


                //Se o arquivo cliente existir
                if (File.Exists("cliente.txt"))
                {
                    Console.WriteLine("\nDigite o código do cliente: ");
                    codcliente = int.Parse(Console.ReadLine());


                    //Lê o arquivo cliente

                    FileStream arqlecodcliente = new FileStream("cliente.txt", FileMode.Open);
                    StreamReader lecodcliente = new StreamReader(arqlecodcliente);

                    string linhacodcliente = " ";
                    string[] resultadocodcliente;
                    bool respostacodcliente = false;

                    do
                    {
                        linhacodcliente = lecodcliente.ReadLine();

                        if (linhacodcliente != null)
                        {
                            resultadocodcliente = linhacodcliente.Split(",");

                            if (resultadocodcliente[0] == (" Código cliente: ") + codcliente.ToString())
                            {
                                Console.WriteLine("\nCliente encontrado, prossiga com o cadastro!");
                                respostacodcliente = true;
                                break;
                            }
                        }
                    } while (linhacodcliente != null);

                    lecodcliente.Close();


                    //Se for true (isso quer dizer que o código digitado é igual ao que está no arquivo)
                    if (respostacodcliente == true)
                    {
                        int ophrescolhida = 0;

                        Console.Write("\nDigite a data (sem separação): ");
                        data = int.Parse(Console.ReadLine());

                        Console.Write("\nDigite o dia da semana (olhe no calendário): ");
                        diasem = Console.ReadLine();

                        if (diasem == "sabado")
                        {
                            Console.WriteLine("\n\nEscolha um dos dois horários FIXOS: " +
                                "\n1- 12 às 16 horas" +
                                "\n2- 18 às 22 horas ");
                            ophrescolhida = int.Parse(Console.ReadLine());

                            if (ophrescolhida == 1)
                            {
                                hrinicio = 12;
                                hrfim = 16;
                            }

                            else if (ophrescolhida == 2)
                            {
                                hrinicio = 18;
                                hrfim = 22;
                            }

                            else
                            {
                                Console.WriteLine("\nOpção inválida!");
                            }
                        }


                        //Se o dia da semana NÃO for sabado
                        else
                        {
                            Console.Write("\nDigite em números o horário de início (duração de 4 horas): ");
                            hrinicio = int.Parse(Console.ReadLine());

                            Console.Write("\nDigite em números o horário do fim (duração de 4 horas): ");
                            hrfim = int.Parse(Console.ReadLine());
                        }

                        int resultadohoras = hrfim - hrinicio;


                        if (resultadohoras == 4)
                        {
                            //Lê o arquivo festa

                            FileStream arqlefestadhd = new FileStream("festa.txt", FileMode.Open);
                            StreamReader lefestadhd = new StreamReader(arqlefestadhd);

                            string linhadatahrdia = " ";
                            string[] resultadodatahrdia;
                            bool respostadata = false;
                            bool respostadiasem = false;
                            bool respostahr = false;

                            do
                            {
                                linhadatahrdia = lefestadhd.ReadLine();
                                if (linhadatahrdia != null)
                                {
                                    resultadodatahrdia = linhadatahrdia.Split(',');


                                    if (resultadodatahrdia[2] != (" Data: " + data.ToString()))
                                    {
                                        respostadata = true;
                                    }

                                    if (resultadodatahrdia[3] != (" Dia da semana: " + diasem))
                                    {
                                        respostadiasem = true;
                                    }

                                    if ((resultadodatahrdia[4] != (" Horário início: " + hrinicio.ToString()))
                                        && (resultadodatahrdia[5] != (" Horário fim: " + hrfim.ToString())))
                                    {
                                        respostahr = true;
                                    }
                                }
                            } while (linhadatahrdia != null);

                            lefestadhd.Close();



                            //DIAS DIFERENTES E HORÁRIOS DIFERENTES, DIAS DIFERENTES E HORÁRIOS EXISTENTES,
                            //MESMO DIA E HORÁRIOS DIFERENTES
                            if ((respostadata == true) && (respostahr == true) && (respostadiasem == true)
                                    || ((respostadata == true) && (respostahr == true) && (respostadiasem == false)
                                    || ((respostadata == false) && (respostahr == false) && (respostadiasem == true))))
                            {
                                Console.WriteLine("\nDisponíveis, prossiga com o cadastro!");

                                //Abrirá o arquivo existente e continuará escrevendo nele, e se não existir irá criar
                                FileStream arqescrevefesta = new FileStream("festa.txt", FileMode.Append);
                                StreamWriter escrevefesta = new StreamWriter(arqescrevefesta);

                                escrevefesta.Write(" Código festa: " + codfesta + ",");

                                escrevefesta.Write(" Data: " + data + ",");

                                Console.Write("\nDigite a quantidade de convidados: " +
                                "\n30" +
                                "\n50" +
                                "\n80" +
                                "\n100 \n");
                                qtdconv = int.Parse(Console.ReadLine());
                                escrevefesta.Write(" Qtd convidados: " + qtdconv + ",");

                                escrevefesta.Write(" Dia da semana: " + diasem + ",");

                                escrevefesta.Write(" Horário início: " + hrinicio + ",");

                                escrevefesta.Write(" Horário fim: " + hrfim + ",");

                                Console.Write("\nDigite o tema: ");
                                tema = Console.ReadLine();
                                escrevefesta.Write(" Tema: " + tema + ",");

                                escrevefesta.Write(" Código cliente: " + codcliente + ",");

                                escrevefesta.WriteLine(" ");
                                escrevefesta.Close();

                            }


                            //DIAS IGUAIS E HORÁRIOS IGUAIS
                            else
                            {
                                Console.WriteLine("\nIndisponível!");
                            }

                        }


                        //Se não (isso quer dizer que é diferente de 4)
                        else
                        {
                            Console.WriteLine("\nHorário incorreto, pois precisa ter duração de 4 horas!");
                        }

                    }


                    //Se for false (isso quer dizer que o código digitado NÃO é igual ao que está no arquivo)
                    else
                    {
                        Console.WriteLine("\nCliente não encontrado!");
                    }
                }


                //Se o arquivo cliente NÃO existir
                else
                {
                    Console.WriteLine("\nNenhum cliente cadastrado!" +
                        "\nPara cadastrar uma festa, primeiro vá ao MENU e cadastre um cliente!");
                }
            }










            //Se o arquivo festa NÃO existir
            else
            {
                codfesta = 1;
                Console.WriteLine("\nNenhuma festa foi cadastrada ainda, crie sua primeira festa a seguir!");


                //Se o arquivo cliente existir
                if (File.Exists("cliente.txt"))
                {
                    Console.WriteLine("\nDigite o código do cliente: ");
                    codcliente = int.Parse(Console.ReadLine());


                    //Lê o arquivo cliente

                    FileStream arqlecodcliente = new FileStream("cliente.txt", FileMode.Open);
                    StreamReader lecodcliente = new StreamReader(arqlecodcliente);

                    string linhacodcliente = " ";
                    string[] resultadocodcliente;
                    bool respostacodcliente = false;

                    do
                    {
                        linhacodcliente = lecodcliente.ReadLine();

                        if (linhacodcliente != null)
                        {
                            resultadocodcliente = linhacodcliente.Split(",");

                            if (resultadocodcliente[0] == (" Código cliente: ") + codcliente.ToString())
                            {
                                Console.WriteLine("\nCliente encontrado, prossiga com o cadastro!");
                                respostacodcliente = true;
                                break;
                            }
                        }
                    } while (linhacodcliente != null);

                    lecodcliente.Close();


                    //Se for true (isso quer dizer que o código digitado é igual ao que está no arquivo)
                    if (respostacodcliente == true)
                    {
                        int ophrescolhida = 0;

                        Console.Write("\nDigite a data: ");
                        data = int.Parse(Console.ReadLine());

                        Console.Write("\nDigite o dia da semana (olhe no calendário): ");
                        diasem = Console.ReadLine();

                        if (diasem == "sabado")
                        {
                            Console.WriteLine("\nEscolha um dos dois horários FIXOS: " +
                                "\n1- 12 às 16 horas" +
                                "\n2- 18 às 22 horas");
                            ophrescolhida = int.Parse(Console.ReadLine());

                            if (ophrescolhida == 1)
                            {
                                hrinicio = 12;
                                hrfim = 16;
                            }

                            else if (ophrescolhida == 2)
                            {
                                hrinicio = 18;
                                hrfim = 22;
                            }

                            else
                            {
                                Console.WriteLine("\nOpção inválida!");
                            }
                        }


                        //Se o dia da semana NÃO for sabado
                        else
                        {
                            Console.Write("\nDigite o horário de início (duração de 4 horas): ");
                            hrinicio = int.Parse(Console.ReadLine());

                            Console.Write("\nDigite o horário do fim (duração de 4 horas): ");
                            hrfim = int.Parse(Console.ReadLine());
                        }

                        int resultadohoras = hrfim - hrinicio;


                        if (resultadohoras == 4)
                        {
                            Console.WriteLine("\nDisponíveis, prossiga com o cadastro!");

                            //Abrirá o arquivo existente e continuará escrevendo nele, e se não existir irá criar
                            FileStream arqescrevefesta = new FileStream("festa.txt", FileMode.Append);
                            StreamWriter escrevefesta = new StreamWriter(arqescrevefesta);

                            escrevefesta.Write(" Código festa: " + codfesta + ",");

                            escrevefesta.Write(" Data: " + data + ",");

                            Console.Write("\nDigite a quantidade de convidados: " +
                                "\n30" +
                                "\n50" +
                                "\n80" +
                                "\n100 \n");
                            qtdconv = int.Parse(Console.ReadLine());
                            escrevefesta.Write(" Qtd convidados: " + qtdconv + ",");

                            escrevefesta.Write(" Dia da semana: " + diasem + ",");

                            escrevefesta.Write(" Horário início: " + hrinicio + ",");

                            escrevefesta.Write(" Horário fim: " + hrfim + ",");

                            Console.Write("\nDigite o tema: ");
                            tema = Console.ReadLine();
                            escrevefesta.Write(" Tema: " + tema + ",");

                            escrevefesta.Write(" Código cliente: " + codcliente + ",");

                            escrevefesta.WriteLine(" ");
                            escrevefesta.Close();

                        }




                        //Se não (isso quer dizer que é diferente de 4)
                        else
                        {
                            Console.WriteLine("\nHorário incorreto, pois deve ter duração de 4 horas!");
                        }


                    }

                    //Se for false (isso quer dizer que o código digitado NÃO é igual ao que está no arquivo)
                    else
                    {
                        Console.WriteLine("\nCliente não encontrado!");
                    }


                }

                //Se o arquivo cliente NÃO existir
                else
                {
                    Console.WriteLine("\nNenhum cliente cadastrado!" +
                        "\nPara cadastrar uma festa, primeiro vá ao MENU e cadastre um cliente!");
                }


            }

        }


        //CONTRATO = número contrato, valor total, desconto, valor final, forma de pagamento, status, código festa
        public static void CadastraContrato(int numcontrato, string formpag, int codfesta)
        {

            //Se o arquivo contrato existir
            if (File.Exists("contrato.txt"))
            {

                //Lê o arquivo contrato

                FileStream arqlecontrato = new FileStream("contrato.txt", FileMode.Open);
                StreamReader lecontrato = new StreamReader(arqlecontrato);

                string linha = " ";
                string[] resultado;
                numcontrato = 1;

                do
                {
                    linha = lecontrato.ReadLine();
                    if (linha != null)
                    {
                        resultado = linha.Split(',');


                        if (resultado[0] == (" Número do contrato: " + numcontrato.ToString()))
                        {
                            numcontrato = numcontrato + 1;
                        }

                    }
                } while (linha != null);

                lecontrato.Close();



                //Se o arquivo festa existir
                if (File.Exists("festa.txt"))
                {

                    Console.WriteLine("\nDigite o código da festa: ");
                    codfesta = int.Parse(Console.ReadLine());


                    //Lê o arquivo festa

                    FileStream arqlecodfesta = new FileStream("festa.txt", FileMode.Open);
                    StreamReader lecodfesta = new StreamReader(arqlecodfesta);

                    string linhacodfesta = " ";
                    string[] resultadocodfesta;
                    bool respostacodfesta = false;

                    do
                    {
                        linhacodfesta = lecodfesta.ReadLine();

                        if (linhacodfesta != null)
                        {
                            resultadocodfesta = linhacodfesta.Split(",");

                            if (resultadocodfesta[0] == (" Código festa: ") + codfesta.ToString())
                            {
                                Console.WriteLine("\nFesta encontrada, prossiga com o cadastro!");
                                respostacodfesta = true;
                                break;
                            }
                        }
                    } while (linhacodfesta != null);

                    lecodfesta.Close();



                    //Se for true (isso quer dizer que o código digitado é igual ao que está no arquivo)
                    if (respostacodfesta == true)
                    {

                        //Lê o arquivo contrato

                        FileStream arqlecontratocod = new FileStream("contrato.txt", FileMode.Open);
                        StreamReader lecontratocod = new StreamReader(arqlecontratocod);

                        string linhacontratocod = " ";
                        string[] resultadocontratocod;
                        bool respostacontratocod = false;

                        do
                        {
                            linhacontratocod = lecontratocod.ReadLine();

                            if (linhacontratocod != null)
                            {
                                resultadocontratocod = linhacontratocod.Split(",");

                                if (resultadocontratocod[2] == (" Código festa: ") + codfesta.ToString())
                                {
                                    Console.WriteLine("\nFesta já possui um contrato!");
                                    respostacontratocod = true;
                                    break;
                                }
                            }
                        } while (linhacontratocod != null);
                        lecontratocod.Close();


                        if (respostacontratocod == false)
                        {

                            //Abrirá o arquivo existente e continuará escrevendo nele, e se não existir irá criar
                            FileStream arqescrevecontrato = new FileStream("contrato.txt", FileMode.Append);
                            StreamWriter escrevecontrato = new StreamWriter(arqescrevecontrato);

                            escrevecontrato.Write(" Número do contrato: " + numcontrato + ",");

                            Console.Write("\nDigite a forma de pagamento:" +
                                "\na vista" +
                                "\nduas vezes" +
                                "\ntres vezes" +
                                "\nquatro ou mais vezes ");
                            formpag = Console.ReadLine();
                            escrevecontrato.Write(" Forma de pagamento: " + formpag + ",");

                            escrevecontrato.Write(" Código festa: " + codfesta + ",");

                            escrevecontrato.WriteLine(" ");
                            escrevecontrato.Close();

                        }

                    }


                    //Se for false (isso quer dizer que o código digitado NÃO é igual ao que está no arquivo)
                    else
                    {
                        Console.WriteLine("\nFesta não encontrada!");
                    }
                }

                else
                {
                    Console.WriteLine("\nNenhuma festa cadastrada!" +
                        "\nPara cadastrar um contrato, primeiro vá ao MENU e cadastre uma festa!");
                }

            }


            //Se o arquivo contrato NÃO existir
            else
            {
                Console.WriteLine("\nNenhum contrato foi cadastrado ainda, crie seu primeiro contrato!");
                numcontrato = 1;

                //Se o arquivo festa existir
                if (File.Exists("festa.txt"))
                {

                    Console.WriteLine("\nDigite o código da festa: ");
                    codfesta = int.Parse(Console.ReadLine());


                    //Lê o arquivo festa

                    FileStream arqlecodfesta = new FileStream("festa.txt", FileMode.Open);
                    StreamReader lecodfesta = new StreamReader(arqlecodfesta);

                    string linhacodfesta = " ";
                    string[] resultadocodfesta;
                    bool respostacodfesta = false;

                    do
                    {
                        linhacodfesta = lecodfesta.ReadLine();

                        if (linhacodfesta != null)
                        {
                            resultadocodfesta = linhacodfesta.Split(",");

                            if (resultadocodfesta[0] == (" Código festa: ") + codfesta.ToString())
                            {
                                Console.WriteLine("\nFesta encontrada, prossiga com o cadastro!");
                                respostacodfesta = true;
                                break;
                            }
                        }
                    } while (linhacodfesta != null);

                    lecodfesta.Close();


                    //Se for true (isso quer dizer que o código digitado é igual ao que está no arquivo)
                    if (respostacodfesta == true)
                    {

                        //Abrirá o arquivo existente e continuará escrevendo nele, e se não existir irá criar
                        FileStream arqescrevecontrato = new FileStream("contrato.txt", FileMode.Append);
                        StreamWriter escrevecontrato = new StreamWriter(arqescrevecontrato);


                        escrevecontrato.Write(" Número do contrato: " + numcontrato + ",");

                        Console.Write("\nDigite a forma de pagamento:" +
                            "\na vista" +
                            "\nduas vezes" +
                            "\ntres vezes" +
                            "\nquatro ou mais vezes ");
                        formpag = Console.ReadLine();
                        escrevecontrato.Write(" Forma de pagamento: " + formpag + ",");

                        escrevecontrato.Write(" Código festa: " + codfesta + ",");

                        escrevecontrato.WriteLine(" ");
                        escrevecontrato.Close();

                    }

                    //Se for false (isso quer dizer que o código digitado NÃO é igual ao que está no arquivo)
                    else
                    {
                        Console.WriteLine("\nFesta não encontrada!");
                    }
                }

                else
                {
                    Console.WriteLine("\nNenhuma festa cadastrada!" +
                        "\nPara cadastrar um contrato, primeiro vá ao MENU e cadastre uma festa!");
                }
            }
        }



        //Realiza pesquisas de cliente por nome
        public static void RealizaPesquisaCliente(string nomecliente)
        {
            if (File.Exists("cliente.txt"))
            {
                FileStream arqleclientepesq = new FileStream("cliente.txt", FileMode.Open);
                StreamReader leclientepesq = new StreamReader(arqleclientepesq);

                string linha = " ";
                string[] resultado;

                do
                {
                    linha = leclientepesq.ReadLine();
                    if (linha != null)
                    {
                        resultado = linha.Split(',');


                        if (resultado[1] == (" Nome cliente: " + nomecliente.ToString()))
                        {
                            Console.Write("\n" + linha);
                        }

                    }
                } while (linha != null);

                leclientepesq.Close();

            }

            else
            {
                Console.WriteLine("\nNenhum cliente está cadastrado!");
            }
        }

        //Realiza pesquisas de funcionário por nome
        public static void RealizaPesquisaFuncionario(string nomefunc)
        {
            if (File.Exists("funcionario.txt"))
            {
                FileStream arqlefuncpesq = new FileStream("funcionario.txt", FileMode.Open);
                StreamReader lefuncpesq = new StreamReader(arqlefuncpesq);

                string linha = " ";
                string[] resultado;

                do
                {
                    linha = lefuncpesq.ReadLine();
                    if (linha != null)
                    {
                        resultado = linha.Split(',');


                        if (resultado[1] == (" Nome funcionário: " + nomefunc.ToString()))
                        {
                            Console.Write("\n" + linha);
                        }

                    }
                } while (linha != null);

                lefuncpesq.Close();

            }

            else
            {
                Console.WriteLine("\nNenhum funcionário está cadastrado!");
            }
        }

        //Realiza pesquisas de fornecedor por nome
        public static void RealizaPesquisaFornecedor(string nomeforn)
        {
            if (File.Exists("fornecedor.txt"))
            {
                FileStream arqlefornpesq = new FileStream("fornecedor.txt", FileMode.Open);
                StreamReader lefornpesq = new StreamReader(arqlefornpesq);

                string linha = " ";
                string[] resultado;

                do
                {
                    linha = lefornpesq.ReadLine();
                    if (linha != null)
                    {
                        resultado = linha.Split(',');


                        if (resultado[1] == (" Nome fornecedor: " + nomeforn.ToString()))
                        {
                            Console.Write("\n" + linha);
                        }

                    }
                } while (linha != null);
                lefornpesq.Close();

            }

            else
            {
                Console.WriteLine("\nNenhum fornecedor está cadastrado!");
            }
        }

        //Realiza pesquisas de festas por código do cliente
        public static void RealizaPesquisaFestasCliente(int codcliente)
        {
            //Se o arquivo festa existir
            if (File.Exists("festa.txt"))
            {
                FileStream arqlefestacodcliente = new FileStream("festa.txt", FileMode.Open);
                StreamReader lefestacodcliente = new StreamReader(arqlefestacodcliente);

                string linha = " ";
                string[] resultado;
                string respostacodfesta = " ";

                do
                {
                    linha = lefestacodcliente.ReadLine();
                    if (linha != null)
                    {
                        resultado = linha.Split(',');


                        if (resultado[7] == (" Código cliente: " + codcliente.ToString()))
                        {
                            Console.Write("\n" + linha);
                            respostacodfesta = resultado[0];
                        }

                    }
                } while (linha != null);
                lefestacodcliente.Close();


            }
            else
            {
                Console.WriteLine("\nAinda não há nenhuma festa cadastrada!");
            }

        }

        //Realiza pesquisas de festas por data
        public static void RealizaPesquisaFestasData(int datafesta)
        {
            if (File.Exists("festa.txt"))
            {
                FileStream arqlefestadata = new FileStream("festa.txt", FileMode.Open);
                StreamReader lefestadata = new StreamReader(arqlefestadata);

                string linha = " ";
                string[] resultado;
                string respostadata = " ";
                bool resposta = false;

                do
                {
                    linha = lefestadata.ReadLine();
                    if (linha != null)
                    {
                        resultado = linha.Split(',');


                        if (resultado[1] == (" Data: " + datafesta.ToString()))
                        {
                            respostadata = resultado[0];
                            resposta = true;
                            Console.Write("\n\n" + linha);
                        }

                    }
                } while (linha != null);
                lefestadata.Close();

                //Se o arquivo contrato existir
                if (File.Exists("contrato.txt"))
                {
                    if (resposta == true)
                    {

                        FileStream arqlecontratocodcliente = new FileStream("contrato.txt", FileMode.Open);
                        StreamReader lecontratocodcliente = new StreamReader(arqlecontratocodcliente);

                        string linhacontrato = " ";
                        string[] resultadocontrato;
                        bool respostacontrato = false;

                        do
                        {
                            linhacontrato = lecontratocodcliente.ReadLine();

                            if (linhacontrato != null)
                            {
                                resultadocontrato = linhacontrato.Split(',');


                                if (resultadocontrato[2] == respostadata.ToString())
                                {
                                    Console.Write("\n" + linhacontrato);
                                    respostacontrato = true;
                                }

                            }
                        } while (linhacontrato != null);
                        lecontratocodcliente.Close();


                        //Se o arquivo calcula valores existir
                        if (File.Exists("calculavalores.txt"))
                        {
                            if (respostacontrato == true)
                            {

                                FileStream arqlecalculav = new FileStream("calculavalores.txt", FileMode.Open);
                                StreamReader lecalculav = new StreamReader(arqlecalculav);

                                string linhacalculav = " ";
                                string[] resultadocalculav;

                                do
                                {
                                    linhacalculav = lecalculav.ReadLine();

                                    if (linhacalculav != null)
                                    {
                                        resultadocalculav = linhacalculav.Split(',');

                                        if (resultadocalculav[7] == respostadata.ToString())
                                        {
                                            Console.Write("\n" + linhacalculav);
                                        }

                                    }
                                } while (linhacalculav != null);
                                lecalculav.Close();


                            }

                            else
                            {
                                Console.WriteLine("\nAinda não foi calculado valores para esse contrato");
                            }
                        }

                        else
                        {
                            Console.WriteLine("\nNenhum valor foi calculado para nenhum contrato ainda");
                        }
                    }

                    else
                    {
                        Console.WriteLine("\nEsse cliente não possui nenhum contrato ainda!");
                    }
                }



                else
                {
                    Console.WriteLine("\nNenhum contrato foi cadastrado ainda!");
                }



            }


            else
            {
                Console.WriteLine("\nNenhuma festa está cadastrada!");
            }
        }


        //Realiza Pesquisa Contrato
        public static void RealizaPesquisaContrato(int codfesta)
        {
            if (File.Exists("contrato.txt"))
            {

                if (File.Exists("festa.txt"))
                {
                    FileStream arqlefestacod = new FileStream("contrato.txt", FileMode.Open);
                    StreamReader lefestacod = new StreamReader(arqlefestacod);

                    string linha = " ";
                    string[] resultado;
                    string guardar = " ", guardar1 = " ";
                    bool resp = false;

                    do
                    {
                        linha = lefestacod.ReadLine();
                        if (linha != null)
                        {
                            resultado = linha.Split(',');


                            if (resultado[2] == (" Código festa: " + codfesta.ToString()))
                            {
                                Console.Write("\n" + linha);
                                resp = true;
                                guardar = resultado[2];
                                guardar1 = resultado[0];
                            }

                        }
                    } while (linha != null);
                    lefestacod.Close();


                    if (File.Exists("calculavalores.txt"))
                    {
                        if (resp == true)
                        {
                            FileStream arqlecvalores = new FileStream("calculavalores.txt", FileMode.Open);
                            StreamReader lecvalores = new StreamReader(arqlecvalores);

                            string linhacvalores = " ";
                            string[] resultadocvalores;

                            do
                            {
                                linhacvalores = lecvalores.ReadLine();
                                if (linhacvalores != null)
                                {
                                    resultadocvalores = linhacvalores.Split(',');


                                    if (resultadocvalores[7] == (guardar.ToString()))
                                    {
                                        Console.Write("\n" + linhacvalores);
                                    }

                                }
                            } while (linhacvalores != null);
                            lecvalores.Close();
                        }

                        else
                        {
                            Console.WriteLine("\nAinda não foi calculado os valores para esse contrato!");
                        }
                    }

                    else
                    {
                        Console.WriteLine("\nNenhum valor foi calculado ainda!");
                    }


                    if (File.Exists("status.txt"))
                    {
                        
                        if (resp == true)
                        {
                            FileStream arqlestatus = new FileStream("status.txt", FileMode.Open);
                            StreamReader lestatus = new StreamReader(arqlestatus);

                            string linhastatus = " ";
                            string[] resultadostatus;

                            do
                            {
                                linhastatus = lestatus.ReadLine();
                                if (linhastatus != null)
                                {
                                    resultadostatus = linhastatus.Split(',');


                                    if (resultadostatus[1] == (guardar1.ToString()))
                                    {
                                        Console.Write("\n" + linhastatus);
                                    }

                                }
                            } while (linhastatus != null);
                            lestatus.Close();
                        }
                    }

                    else
                    {
                        Console.WriteLine("\nNenhum status foi gerado ainda!");
                    }


                }

                else
                {
                    Console.WriteLine("\nNenhuma festa cadastrada ainda!");
                }
            }

            else
            {
                Console.WriteLine("\nNenhum contrato cadastrado ainda!");
            }


        }





        //Calcula valor total a ser pago, e valor final a ser pago
        public static void CalculaValorTotaleFinal(double valortot, double valorfinal, string desconto)
        {

            //Se existir o arquivo contrato
            if (File.Exists("contrato.txt"))
            {

                int codfesta = 0;

                Console.WriteLine("\nDigite novamente o código da festa para calcularmos os valores para seu contrato: ");
                codfesta = int.Parse(Console.ReadLine());

                FileStream arqlecontratocalculavalor = new FileStream("contrato.txt", FileMode.Open);
                StreamReader lecontratocalculavalor = new StreamReader(arqlecontratocalculavalor);

                string linhacontrato = " ";
                string[] resultadocontrato;
                bool resultadopesquisa = false;

                do
                {
                    linhacontrato = lecontratocalculavalor.ReadLine();
                    if (linhacontrato != null)
                    {
                        resultadocontrato = linhacontrato.Split(',');

                        if (resultadocontrato[2] == (" Código festa: " + codfesta.ToString()))
                        {
                            resultadopesquisa = true;
                        }

                    }
                } while (linhacontrato != null);
                lecontratocalculavalor.Close();


                //Se o arquivo festa existir
                if (File.Exists("festa.txt"))
                {
                    //Se o código digitado for mesmo correto
                    if (resultadopesquisa == true)
                    {
                        FileStream arqlefestacalculavalor = new FileStream("festa.txt", FileMode.Open);
                        StreamReader lefestacalculavalor = new StreamReader(arqlefestacalculavalor);


                        string linhafesta = " ";
                        string[] resultadofesta;
                        string qtdconvcontrato = " ";
                        string diasemcontrato = " ";
                        bool resultadocalculovalortotal = false;

                        do
                        {
                            linhafesta = lefestacalculavalor.ReadLine();
                            if (linhafesta != null)
                            {
                                resultadofesta = linhafesta.Split(',');

                                if (resultadofesta[0] == (" Código festa: " + codfesta.ToString()))
                                {

                                    qtdconvcontrato = resultadofesta[2];
                                    diasemcontrato = resultadofesta[3];


                                    //Calcula valor total
                                    if (qtdconvcontrato == (" Qtd convidados: " + "30"))
                                    {
                                        if ((diasemcontrato == (" Dia da semana: " + "segunda")) || (diasemcontrato == (" Dia da semana: " + "terça")) || (diasemcontrato == (" Dia da semana: " + "quarta")) || (diasemcontrato == (" Dia da semana: " + "quinta")))
                                        {
                                            valortot = 1899;
                                        }

                                        if ((diasemcontrato == (" Dia da semana: " + "sexta")) || (diasemcontrato == (" Dia da semana: " + "sabado")) || (diasemcontrato == (" Dia da semana: " + "domingo")))
                                        {
                                            valortot = 2099;
                                        }
                                    }


                                    if (qtdconvcontrato == (" Qtd convidados: " + "50"))
                                    {
                                        if ((diasemcontrato == (" Dia da semana: " + "segunda")) || (diasemcontrato == (" Dia da semana: " + "terça")) || (diasemcontrato == (" Dia da semana: " + "quarta")) || (diasemcontrato == (" Dia da semana: " + "quinta")))
                                        {
                                            valortot = 2199;
                                        }

                                        if ((diasemcontrato == (" Dia da semana: " + "sexta")) || (diasemcontrato == (" Dia da semana: " + "sabado")) || (diasemcontrato == (" Dia da semana: " + "domingo")))
                                        {
                                            valortot = 2299;
                                        }
                                    }


                                    if (qtdconvcontrato == (" Qtd convidados: " + "80"))
                                    {
                                        if ((diasemcontrato == (" Dia da semana: " + "segunda")) || (diasemcontrato == (" Dia da semana: " + "terça")) || (diasemcontrato == (" Dia da semana: " + "quarta")) || (diasemcontrato == (" Dia da semana: " + "quinta")))
                                        {
                                            valortot = 3199;
                                        }

                                        if ((diasemcontrato == (" Dia da semana: " + "sexta")) || (diasemcontrato == (" Dia da semana: " + "sabado")) || (diasemcontrato == (" Dia da semana: " + "domingo")))
                                        {
                                            valortot = 3499;
                                        }
                                    }


                                    if (qtdconvcontrato == (" Qtd convidados: " + "100"))
                                    {
                                        if ((diasemcontrato == (" Dia da semana: " + "segunda")) || (diasemcontrato == (" Dia da semana: " + "terça")) || (diasemcontrato == (" Dia da semana: " + "quarta")) || (diasemcontrato == (" Dia da semana: " + "quinta")))
                                        {
                                            valortot = 3799;
                                        }

                                        if ((diasemcontrato == (" Dia da semana: " + "sexta")) || (diasemcontrato == (" Dia da semana: " + "sabado")) || (diasemcontrato == (" Dia da semana: " + "domingo")))
                                        {
                                            valortot = 3999;
                                        }
                                    }


                                    resultadocalculovalortotal = true;

                                }

                            }
                        } while (linhafesta != null);
                        lefestacalculavalor.Close();


                        //Se o código for o mesmo do que está na festa também
                        if (resultadocalculovalortotal == true)
                        {

                            FileStream arqlecontratocalculavfinal = new FileStream("contrato.txt", FileMode.Open);
                            StreamReader lecontratocalculavfinal = new StreamReader(arqlecontratocalculavfinal);

                            string linhacontratovfinal = " ";
                            string[] resultadocontratovfinal;
                            string formpagcontrato = " ";

                            do
                            {
                                linhacontratovfinal = lecontratocalculavfinal.ReadLine();
                                if (linhacontratovfinal != null)
                                {
                                    resultadocontratovfinal = linhacontratovfinal.Split(',');

                                    formpagcontrato = resultadocontratovfinal[1];

                                    //Calcula valor final

                                    if (formpagcontrato == (" Forma de pagamento: " + "a vista"))
                                    {
                                        desconto = "10%";
                                        valorfinal = valortot * 0.90;
                                    }

                                    if (formpagcontrato == (" Forma de pagamento: " + "duas vezes"))
                                    {
                                        desconto = "5%";
                                        valorfinal = valortot * 0.95;
                                    }

                                    if (formpagcontrato == (" Forma de pagamento: " + "tres vezes"))
                                    {
                                        desconto = "2%";
                                        valorfinal = valortot * 0.97;
                                    }

                                    if (formpagcontrato == (" Forma de pagamento: " + "quatro ou mais vezes"))
                                    {
                                        desconto = "Sem desconto";
                                        valorfinal = valortot;
                                    }

                                }
                            } while (linhacontratovfinal != null);
                            lecontratocalculavfinal.Close();



                            FileStream arqescrevecalculav = new FileStream("calculavalores.txt", FileMode.Append);
                            StreamWriter escrevecalculav = new StreamWriter(arqescrevecalculav);

                            escrevecalculav.Write(qtdconvcontrato + ",");

                            escrevecalculav.Write(formpagcontrato + ",");

                            escrevecalculav.Write(diasemcontrato + ",");


                            escrevecalculav.Write(" Valor final: " + valorfinal + ",");

                            escrevecalculav.Write(" Valor total: " + valortot + ",");

                            escrevecalculav.Write(" Desconto: " + desconto + ",");

                            escrevecalculav.Write(" Código festa: " + codfesta + ",");

                            escrevecalculav.WriteLine(" ");
                            escrevecalculav.Close();


                        }

                        //Se resultadocalculovalortotal for false
                        else
                        {
                            Console.WriteLine("\nNão encontrado!");
                        }

                    }

                    //Não encontrado na pesquisa
                    else
                    {
                        Console.WriteLine("\nNão encontrado!");
                    }
                }

                else
                {
                    Console.WriteLine("\nNenhuma festa cadastrada ainda." +
                        "\nPrimeiro vá ao MENU e cadastre uma festa.");
                }
            }

            else
            {
                Console.WriteLine("\nNenhum contrato cadastrado ainda." +
                    "\nPrimeiro vá ao MENU  e cadastre um contrato.");
            }
        }







        //Atualiza status do contrato do cliente
        public static void GeraeAtualizaStatusContrato(string respstatus)
        {
            if (File.Exists("contrato.txt"))
            {
                int numcontrato = 0;

                Console.WriteLine("Digite o número do contrato que deseja atualizar: ");
                numcontrato = int.Parse(Console.ReadLine());

                FileStream arqlecontrato = new FileStream("contrato.txt", FileMode.Open);
                StreamReader lecontrato = new StreamReader(arqlecontrato);

                string linhacontrato = " ";
                string[] resultadocontrato;
                bool respostacontrato = false;
                string guardar = " ";

                do
                {
                    linhacontrato = lecontrato.ReadLine();
                    if (linhacontrato != null)
                    {
                        resultadocontrato = linhacontrato.Split(',');


                        if (resultadocontrato[0] == (" Número do contrato: " + numcontrato.ToString()))
                        {
                            respostacontrato = true;
                            guardar = (respstatus);
                        }

                    }
                } while (linhacontrato != null);

                lecontrato.Close();

                if (respostacontrato == true)
                {
                    FileStream arqescrevestatus = new FileStream("status.txt", FileMode.Append);
                    StreamWriter escrevestatus = new StreamWriter(arqescrevestatus);

                    escrevestatus.Write(" Status: " + guardar + ",");

                    escrevestatus.Write(" Número do contrato: " + numcontrato + ",");

                    escrevestatus.WriteLine(" ");
                    escrevestatus.Close();

                }

                else
                {
                    Console.WriteLine("\nNão há esse contrato cadastrado!");
                }

            }


            else
            {
                Console.WriteLine("\nNenhum contrato está cadastrado!");
            }
        }
    }
}
        

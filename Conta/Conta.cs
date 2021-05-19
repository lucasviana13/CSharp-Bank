using System;
namespace Banco
{
    public class Conta
    {
        private TipoConta TipoConta {get;set;}
        private double Credito {get;set;}
        private string Nome {get;set;}
        private double Saldo{get;set;}

            public Conta(TipoConta tipoConta, double credito, string nome, double saldo)
            {
                this.TipoConta = tipoConta;
                this.Credito = credito;
                this.Nome = nome;
                this.Saldo = saldo;
            }

            public bool Saque(double valorSaque)
            {
                if (this.Saldo-valorSaque <this.Credito*-1)
                {
                    Console.WriteLine("Saldo Insuficiente para realizar o saque");
                    return false;
                }
                
                this.Saldo = this.Saldo - valorSaque;
                Console.WriteLine("Saque realizado {0} \nSaldo atual de {1} reais",this.Nome,this.Saldo);
                return true;
            }    

            public void Deposito(double valorDepositado)
            {
                this.Saldo = this.Saldo + valorDepositado;
                Console.WriteLine("Saldo atual de {0} é de {1} reais",this.Nome,this.Saldo);
            }

            public void Transferencia(Conta contaDestino, double valorTransferido)
            {
                if (this.Saque(valorTransferido))
                {
                    contaDestino.Deposito(valorTransferido);
                    //Console.WriteLine("Transferencia efetuada com sucesso");
                }
                else
                {
                    //Console.WriteLine("Transferencia não efetuada.\nSaldo Insuficiente")
                }
            }

            public override string ToString()
            {
                string retorno = "";
                retorno +="Nome: "+this.Nome+"\n";
                retorno +="Tipo de Conta: "+this.TipoConta+"\n";
                retorno +="Saldo: "+this.Saldo+" reais\n";
                retorno +="Credito: "+this.Credito+" reais\n";
                
                return retorno;
            }
    }
}
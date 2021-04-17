using System;

namespace DIO.Bank
{
    public class Conta
    {
        private TipoConta TipoConta {get ; set;}

        private double Saldo {get; set;}

        private double ChequeEspecial {get ; set;}
        private string Nome {get; set;}

        public Conta(TipoConta tipoConta, double saldo, double chequeEspecial, string nome){
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.ChequeEspecial = chequeEspecial;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            if(this.Saldo - valorSaque < (this.ChequeEspecial *-1)){
                Console.WriteLine("Saldo insuficiente");
                return false;
            }
            
            this.Saldo -= valorSaque;
            Console.WriteLine("Saldo atual da conta {0} é de {1}", this.Nome, this.Saldo);
            return true;
        }

        public void Depositar(double valorDeposito){
            this.Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conta {0} é de {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino){
            if(this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo Conta " + this.TipoConta + "|";
            retorno += "Nome Titular " + this.Nome + "|";
            retorno += "Saldo " + this.Saldo + "|";
            retorno += "Cheque Especial " + this.ChequeEspecial + "|";
            return retorno;
        }
    }
}
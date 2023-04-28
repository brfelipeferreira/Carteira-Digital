using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contas.LibClasses
{
    public class Carteira
    {
        public double Saldo
        {
            get;
            private set;
        }
        public string Dono { get; set; }

        public string Cpf
        {
            get;
            set;
        }
        public double LimiteConta
        {
            get;
            set;
        }
        public DateTime Tarifa
        {
            get;
            set;
        }
        public bool cobrarTarifa(DateTime dataTarifa)
        {
            this.Saldo -= 19.90;
            this.Tarifa = dataTarifa;
            return true;
        }

        public bool Sacar(double Valor)
        {
            if (Valor > this.Saldo)
                return false;

            this.Saldo -= Valor;
            return true;
        }

        public bool Depositar(double Valor)
        {
            this.Saldo += Valor;
            return true;
        }

        public bool Transferir
            (Carteira destino, double valor)
        {  
            if (this.Saldo <= valor)
                return false;

            this.Sacar(valor);
            bool tOK = destino.Depositar(valor);
            if (tOK)
                return true;
            else
            {
                this.Depositar(valor);
                return false;
            }
        }
    }
}

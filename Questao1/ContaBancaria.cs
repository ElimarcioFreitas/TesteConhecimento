using System.Globalization;

namespace Questao1
{
    class ContaBancaria {

       public int numero {get; set;}
       public string titular {get; set;}
       public double depositoInicial {get; set;}
       public double saldo {get; set;}
       
       public static void deposito(double valor){

        this.saldo =+ valor;

       } 
       public static void saque(double valor) {

        this saldo =- valor - 3.5;

       }

       public string ContaBancaria(){
        string retorno = "Conta: " + this.numero.toString() + " Titular: " + this.titular + " Saldo: " + this.saldo.toString();
            return retorno;
       }

    }
}

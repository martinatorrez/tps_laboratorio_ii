using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        public Operando():this(0)
        {
            
        }
        public Operando(double numero) 
        {
            this.numero = numero;
        }
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }

        public string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }
        /// <summary>
        /// comprueba que el valor recibido sea numerico
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>si el valor recibido es numerico lo retorna en double, caso contrario retorna 0 </returns>
        private double ValidarOperando(string strNumero)
        {
            double numero;
            if (double.TryParse(strNumero, out numero))
            {
                return numero;
            }
            else
            {
                return 0;
            }

        }
        /// <summary>
        /// valida si la cadena de caracteres esta compuesta por 1 y 0
        /// </summary>
        /// <param name="binario"> cadena recibida</param>
        /// <returns>devuelve true si la cadena es binaria, caso contrario devuelve false</returns>
        private bool EsBinario(string binario)
        {
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] == '0' || binario[i] == '1')
                {
                    return true;
                }

            }
            return false;
        }
        /// <summary>
        /// convierte una cadena a decimal, despues de validar si es binaria
        /// </summary>
        /// <param name="binario">cadena binaria recibida</param>
        /// <returns>devuelve la conversion si se pudo realizar, caso contrario devuelve "valor invalido"</returns>
        public string BinarioDecimal(string binario)
        {
            char[] array = binario.ToCharArray();
            Array.Reverse(array);
            int numero = 0;
            string retorno = null;
            if (EsBinario(binario))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == '1')
                    {
                        numero += (int)Math.Pow(2, i);
                    }
                }
                retorno = numero.ToString();

            }
            else
            {
                retorno= "Valor invalido";
            }
            return retorno;
        }
        /// <summary>
        /// convierte una cadena a binario, si el numero es mayor a 0
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>devuelve la conversion si se pudo realizar, caso contrario devuelve "Valor invalido"</returns>
        public string DecimalBinario(string numero)
        {
            string retorno = null;
            double numeroDouble;
            bool conversion = double.TryParse(numero, out numeroDouble);
            int decimalNumero = (int)numeroDouble;
            int resto;
            if (conversion && decimalNumero > 0)
            {
                while (decimalNumero != 0)
                {
                    resto = decimalNumero % 2;
                    decimalNumero /= 2;
                    retorno = resto.ToString() + retorno;
                }
            }
            else
            {
                retorno = "Valor invalido";
            }

            return retorno;
        }
        /// <summary>
        /// recibe un numero en formato double y lo convierte a binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>retorna el numero en formato string</returns>
        public string DecimalBinario(double numero) 
        {
            return DecimalBinario(numero.ToString());
        }
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator -(Operando n1, Operando n2) 
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Operando n1, Operando n2) 
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Operando n1, Operando n2) 
        {
            if (n2.numero == 0) 
            {
                return double.MinValue;
            }
            else 
            {
                return n1.numero / n2.numero;
            }
        }
    }
}

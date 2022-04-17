using System;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// valida que el operador recibido sea +, -, / o *
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>devuelve el operador, en caso de que no sea +, -, / o * devuelve + </returns>
        private static char ValidarOperador(char operador) 
        {
            
            if(operador =='+' || operador == '-' || operador =='/' || operador == '*') 
            {
              return operador; 
            }
            else 
            {
             return '+'; 
            }
        }
        /// <summary>
        /// valida y realiza la operacion pedida entre los numeros
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>devuelve el resultado de la operacion</returns>
       public static double Operar(Operando num1, Operando num2, char operador) 
        {
            char validacion = ValidarOperador(operador);
            double resultado=0;
            switch (validacion) 
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
            
            }
            return resultado;
        }
    }
}

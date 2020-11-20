namespace Entidades.Clases
{
    public static class Calculadora
    {
        /// <summary>
        /// Validar que el operador recibido sea valido + - * /.
        /// </summary>
        /// <param name="operador">Operador aritmetico</param>
        /// <returns>Operador aritmetico valido, en el caso contrario retorna "+"</returns>
        private static string ValidarOperador(char operador)
        {
            if (operador != '+' && operador != '-' && operador != '*' && operador != '/')
            {
                return "+";
            }

            return operador.ToString();
        }

        /// <summary>
        /// Valida y realiza la operacion pedida entre ambos números
        /// </summary>
        /// <param name="num1">Operando1</param>
        /// <param name="num2">Operando2</param>
        /// <param name="operador">Operador aritmetico</param>
        /// <returns>Resultado de calculo entre dos clases del tipo Numero</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            switch (ValidarOperador(char.Parse(operador)))
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                case "/":
                    return num1 / num2;
                default:
                    return num1 + num2;
            }
        }
    }
}
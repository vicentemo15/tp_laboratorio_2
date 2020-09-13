namespace Entidades.Clases
{
    public static class Calculadora
    {
        private static string ValidarOperador(char operador)
        {
            if (operador != '+' && operador != '-' && operador != '*' && operador != '/') 
            {
                return "+";
            }

            return operador.ToString();
        }

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
            }

            return 0;
        }
    }
}

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;

namespace Patrones_de_Diseño.Clases.Comportamiento
{
    class Interpreter
    {
        public class ProgramInterpreter
        {
            public static void InterpeterTest()
            {
                string[] tree;
                var context = new Context();
                var expressions = new List<IExpression>();
                Console.WriteLine("ingrese la operacion en letras: ");
                string val = Console.ReadLine();
                tree = val.Split(' ');
                IExpression exp;
                foreach (var t in tree)
                {
                    if (Operators.ConditionalCompareObjectGreaterEqual(context.getInteger(t), 0, false))
                    {
                        exp = new NumericExpression(t);
                    }
                    else
                    {
                        exp = new OperatorExpression(t);
                    }

                    exp.interpret(context);
                }

                Console.WriteLine("El resultado para '{0}' es {1}", val, context.getResult());
                Console.ReadKey();
            }
            public interface IExpression
            {
                void interpret(Context context);
            }
            public class OperatorExpression : IExpression
            {
                private string operacion;
                public OperatorExpression(string token)
                {
                    operacion = token;
                }
                public void interpret(Context context)
                {
                    context.setOperation(operacion);
                }
            }
            public class Context
            {
                private string siguiente = "";
                private int operador = 0;
                private int resultado = 0;
                public int getInteger(string input)
                {
                    var switchExpr = input.ToLower();
                    switch (switchExpr)
                    {
                        case "cero":
                            {
                                return 0;
                            }

                        case "uno":
                            {
                                return 1;
                            }

                        case "dos":
                            {
                                return 2;
                            }

                        case "tres":
                            {
                                return 3;
                            }

                        case "cuatro":
                            {
                                return 4;
                            }

                        case "cinco":
                            {
                                return 5;
                            }

                        case "seis":
                            {
                                return 6;
                            }

                        case "siete":
                            {
                                return 7;
                            }

                        case "ocho":
                            {
                                return 8;
                            }

                        case "nueve":
                            {
                                return 9;
                            }

                        default:
                            {
                                return -1;
                            }
                    }
                }

                public void setOperator(int op)
                {
                    operador = op;
                }

                public void setOperation(string operation)
                {
                    if (operation.ToLower().Equals("mas"))
                    {
                        siguiente = "+";
                    }
                    else if (operation.ToLower().Equals("menos"))
                    {
                        siguiente = "-";
                    }
                }

                public void calculate()
                {
                    if (siguiente.Equals("+") || siguiente.Equals(""))
                    {
                        resultado += operador;
                    }
                    else if (siguiente.Equals("-"))
                    {
                        resultado -= operador;
                    }
                }

                public int getResult()
                {
                    return resultado;
                }


            }
            public class NumericExpression : IExpression
            {
                private string value;

                public NumericExpression(string token)
                {
                    value = token;
                }
                public void interpret(Context contex)
                {
                    contex.setOperator(contex.getInteger(value));
                    contex.calculate();
                }
            }
        }
    }
}

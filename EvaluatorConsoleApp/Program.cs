using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace EvaluatorConsoleApp { 
    public class Evaluator
    {
        double value = new double();
        Stack<double> nums = new Stack<double>();
        Stack<Char> ops = new Stack<Char>();
        public void evaluate()
        {
            Console.WriteLine("Enter the number corresponding to your notation");
            Console.WriteLine("Prefix: 1; Infix: 2; Postfix: 3");
            string type = Console.ReadLine();
            Console.WriteLine("Write your expression.");
            string expression = Console.ReadLine();
            char[] chars = expression.ToCharArray();
            if (type == "3")
            {
                //Goes through every character in the expression
                Debug.WriteLine("post code will run");
                for (int i = 0; i < chars.Count(); i++)
                {
                    if (chars[i] == ' ')
                    {
                        Console.WriteLine("space found");
                        continue;
                    }
                    else
                    //checks to see if character is a number or an operator
                    {
                        //Number
                        if (chars[i] >= 48 && chars[i] <= 57)
                        {
                            Debug.WriteLine("Number character detected");
                            //check to see if previous char was part of same number
                            if (nums.Count > 0)
                            {
                                if (chars[i - 1] >= 48 && chars[i - 1] <= 57)
                                {
                                    double temp = nums.Pop() * 10;
                                    nums.Push(chars[i]);
                                    nums.Push((nums.Pop() - 48) + temp);
                                    Debug.WriteLine("multicharacter number pushed to nums");
                                    continue;
                                } //this was for multicharacter numbers
                            }
                            //push the character and subtract 48 to get its corresponding integer value

                            nums.Push(chars[i]);
                            nums.Push(nums.Pop() - 48);
                            Debug.WriteLine("pushed number kar to nums value: " + nums.Peek());
                        }
                        else
                        //Operator
                        {   // + or -
                            if (chars[i] == '+')
                            {
                                nums.Push(nums.Pop() + nums.Pop());
                            }
                            if (chars[i] == '-')
                            {
                                double temp = nums.Pop();
                                nums.Push(nums.Pop() - temp);
                            }
                            if (chars[i] == '*')
                            {
                                nums.Push(nums.Pop() * nums.Pop());
                            }
                            if (chars[i] == '/')
                            {
                                double temp = nums.Pop();
                                nums.Push(nums.Pop() / temp);
                            }
                            if (chars[i] == '^')
                            {
                                nums.Push(Math.Pow(nums.Pop(), nums.Pop()));
                            }
                        }
                    }
                }
                value = nums.Pop();
                Debug.WriteLine("The answer is: " + value.ToString("N2"));
                Console.WriteLine("The answer is: " + value.ToString("N2"));

            }
            else if (type == "1")
            {
                Debug.WriteLine("prefix code will run");
                for (int i = (chars.Count() - 1); i >= 0; i--)
                {
                    if (chars[i] == ' ')
                    {
                        Debug.WriteLine("space found");
                        continue;
                    }
                    else
                    //checks to see if character is a number or an operator
                    {
                        //Number
                        if (chars[i] >= 48 && chars[i] <= 57)
                        {
                            Debug.WriteLine("Number character detected");
                            //check to see if previous char was part of same number
                            if (nums.Count > 0)
                            {
                                if (chars[i - 1] >= 48 && chars[i - 1] <= 57)
                                {
                                    double temp = nums.Pop() * 10;
                                    nums.Push(chars[i]);
                                    nums.Push((nums.Pop() - 48) + temp);
                                    Console.WriteLine("multicharacter number pushed to nums");
                                    continue;
                                } //this was for multicharacter numbers
                            }
                            //push the character and subtract 48 to get its corresponding integer value

                            nums.Push(chars[i]);
                            nums.Push(nums.Pop() - 48);
                            Debug.WriteLine("pushed number kar to nums value: " + nums.Peek());
                        }
                        else
                        //Operator
                        {   // + or -
                            if (chars[i] == '+')
                            {
                                nums.Push(nums.Pop() + nums.Pop());
                            }
                            if (chars[i] == '-')
                            {
                                nums.Push(nums.Pop() - nums.Pop());
                            }
                            if (chars[i] == '*')
                            {
                                nums.Push(nums.Pop() * nums.Pop());
                            }
                            if (chars[i] == '/')
                            {
                                nums.Push(nums.Pop() / nums.Pop());
                            }
                            if (chars[i] == '^')
                            {
                                nums.Push(Math.Pow(nums.Pop(), nums.Pop()));
                            }
                        }
                    }
                }
                value = nums.Pop();
                Debug.WriteLine("The answer is: " + value.ToString("N2"));
                Console.WriteLine("The answer is: " + value.ToString("N2"));

                }//end pre
                else if (type == "2")//Infix
            {
                Debug.WriteLine("Infix code will run");
                Debug.WriteLine("Char count: " + chars.Count());
                //Goes through every character in the expression
                for (int i = 0; i < chars.Count(); i++)
                {
                        Debug.WriteLine("chars iteration: " + i);
                    //checks for a space
                    if (chars[i] == ' ')
                    {
                            Debug.WriteLine("space found");
                        continue;
                    }
                    else
                    //checks to see if character is a number or an operator
                    {
                        //Number
                        if (chars[i] >= 48 && chars[i] <= 57)
                        {
                                Debug.WriteLine("Number character detected");
                            //check to see if previous char was part of same number
                            if (nums.Count > 0)
                            {
                                if (chars[i - 1] >= 48 && chars[i - 1] <= 57)
                                {
                                    double temp = nums.Pop() * 10;
                                    nums.Push(chars[i]);
                                    nums.Push((nums.Pop() - 48) + temp);
                                    Debug.WriteLine("multicharacter number pushed to nums");
                                    continue;
                                } //this was for multicharacter numbers
                            }
                            //push the character and subtract 48 to get its corresponding integer value

                            nums.Push(chars[i]);
                            nums.Push(nums.Pop() - 48);
                            Debug.WriteLine("pushed number kar to nums value: " + nums.Peek());
                        }
                        else
                        //Operator
                        {   // + or -
                            if (chars[i] == '+' || chars[i] == '-')
                            {
                                //cant put lower precidence on higher precidence so do those calulations before pushing next operator
                                if (ops.Count > 0 && ops.Peek() == '*')
                                {
                                    ops.Pop();
                                    nums.Push(nums.Pop() * nums.Pop());
                                }
                                else if (ops.Count > 0 && ops.Peek() == '/')
                                {
                                    ops.Pop();
                                    Double temp = nums.Pop();
                                    nums.Push(nums.Pop() / temp);
                                }
                                else if (ops.Count > 0 && ops.Peek() == '^')
                                {
                                    ops.Pop();
                                    Double temp = nums.Pop();
                                    nums.Push(Math.Pow(nums.Pop(), temp));
                                }

                                ops.Push(chars[i]);

                                Debug.WriteLine("pushed + or - ");
                            }
                            // ^
                            else if (chars[i] == '^')
                            {
                                ops.Push(chars[i]);
                            }
                            // * or /
                            else
                            {
                                if (ops.Count > 0 && ops.Peek() == '^') //cant put lower precidence on higher precidence so do those calulations before pushing next operator
                                {
                                    Double temp = nums.Pop();
                                    nums.Push(Math.Pow(nums.Pop(), temp));
                                }
                                else { ops.Push(chars[i]); }
                            }
                        }
                    }
                }//All Characters pushed  
                while (ops.Count != 0)
                {
                    double temp = 0;
                    Debug.WriteLine("ops.Peek(): " + ops.Peek());
                    switch (ops.Pop())
                    {
                        case '-':
                            temp = nums.Pop();
                            nums.Push(nums.Pop() - temp);
                            break;
                        case '+':
                            nums.Push(nums.Pop() + nums.Pop());
                            break;
                        case '/':
                            temp = nums.Pop();
                            nums.Push(nums.Pop() / temp);
                            break;
                        case '*':
                            temp = nums.Pop();
                            nums.Push(nums.Pop() * temp);
                            break;
                        case '^':
                            temp = nums.Pop();
                            nums.Push(Math.Pow(nums.Pop(), temp));
                            break;
                        default:
                            break;
                    }
                }

                Debug.WriteLine("nums count: " + nums.Count + "   peek nums: " + nums.Peek());
                //remaining number is value  2 decimals max!
                value = nums.Pop();
                Debug.WriteLine("The answer is: " + value.ToString("N2"));
                Console.WriteLine("The answer is: " + value.ToString("N2"));

                } //end infix
                else
                {
                Debug.WriteLine("error in your entry");
                Console.WriteLine("error in your entry");
                }
            Console.WriteLine("");    
            evaluate();
        } //end evaluate method


        public static void Main(string[] args)
        {
            Evaluator evaluator = new Evaluator();
            evaluator.evaluate();
        }
    }//end Class
}//end namespace
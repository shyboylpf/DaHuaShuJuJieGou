using System;
using System.Collections.Generic;

namespace 波兰表达式
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> charStack = new Stack<string>();
            string s = "931-3*+82/+";
            int left;
            int right;
            foreach( var s1 in s)
            {
                if (!"+-*/".Contains(s1))
                {
                    charStack.Push(s1.ToString());
                }
                else
                {
                    right = int.Parse(charStack.Pop().ToString());
                    left = int.Parse(charStack.Pop().ToString());
                    switch (s1)
                    {
                        case '+':
                            charStack.Push((left+right).ToString());
                            break;
                        case '-':
                            charStack.Push((left - right).ToString());
                            break;
                        case '*':
                            charStack.Push((left * right).ToString());
                            break;
                        case '/':
                            charStack.Push((left / right).ToString());
                            break;
                    }
                }
            }

            Console.WriteLine(charStack.Pop());
        }
    }
}

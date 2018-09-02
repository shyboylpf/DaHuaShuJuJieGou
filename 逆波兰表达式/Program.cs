using System;
using System.Collections.Generic;

namespace 逆波兰表达式
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> charStack = new Stack<char>();
            Dictionary<char, int> charDic = new Dictionary<char, int>();
            charDic['('] = 0;
            charDic['+'] = 1;
            charDic['-'] = 1;
            charDic['*'] = 2;
            charDic['/'] = 2;
            charDic[')'] = 3;
            string chars = "+-*/()";
            string s = "9+(3-1)*3+10/2";
            foreach(char s1 in s)
            {
                if (chars.IndexOf(s1) == -1)
                {
                    Console.Write(s1);
                }
                else
                {
                    if (s1 == '(')
                    {
                        charStack.Push(s1);
                    }
                    else if (s1 == ')')
                    {
                        while (charStack.Peek() != '(')
                        {
                            Console.Write(charStack.Pop());
                        }
                        charStack.Pop();
                    }
                    else if (!charStack.TryPeek(out char temp) || charStack.Peek()=='(')
                    {
                        charStack.Push(s1);
                    }
                    else if (charDic[charStack.Peek()] > charDic[s1])
                    {
                        Console.Write(s1);
                    }
                    else
                    {
                        Console.Write(charStack.Pop());
                        charStack.Push(s1);
                    }
                }
            }
            Console.WriteLine("Hello World!");
        }
    }
    class bolanStack
    {
        const int MAXSIZE = 50;
        char[] array = new char[MAXSIZE];
        int head = -1;
        public void Push(char i)
        {
            if (head != MAXSIZE - 1)
            {
                array[++head] = i;
            }
            throw new IndexOutOfRangeException("满");
        }
        public char? Pop()
        {
            if (head != -1)
            {
                return array[head--];
            }
            return null;
        }
    }
}

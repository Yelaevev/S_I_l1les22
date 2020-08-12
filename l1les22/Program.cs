using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {
        public static string BalancedParentheses(int N)
        {
            int temp = N;
           /// добавляем замкнутые скобки + ()+
            if (N == 1) return "()";
            if (N == 2) return "()() (())";
            List<string> TotalList = new List<string>();
            string [] RecurseList=BalancedParentheses(N - 1).Split(' ');
            
            for (int i = 0; i < RecurseList.Length; i++)
            {  // ставим скобочку открытия вначале, а закрытия прогоняем  по каждой позиции
                RecurseList[i] = RecurseList[i].Insert(0, "(");
                for (int j = 1; j < RecurseList[i].Length; j++)
                {
                    RecurseList[i] = RecurseList[i].Insert(j, ")");
                    TotalList.Add(RecurseList[i]);
                    RecurseList[i] = RecurseList[i].Remove(j, 1);
                }
                RecurseList[i] = RecurseList[i].Insert(RecurseList[i].Length, ")");
                TotalList.Add(RecurseList[i]);
                RecurseList[i] = RecurseList[i].Remove(RecurseList[i].Length-1, 1);
                RecurseList[i] = RecurseList[i].Remove(0, 1);

                // ставим скобочку закрытия вконце, а открытия прогоняем  по каждой позиции
                RecurseList[i] = RecurseList[i].Insert(RecurseList[i].Length, ")");
                for (int j = RecurseList[i].Length-1; j >=0; j--)
                {
                    RecurseList[i] = RecurseList[i].Insert(j, "(");
                    TotalList.Add(RecurseList[i]);
                    RecurseList[i] = RecurseList[i].Remove(j, 1);
                }

            }




            /////удаляем повторяющиеся комбинации из строки
            //string[] TotalArray = AnsTotal.Split(' ');
           // List<string> TotalList = new List<string>();
           // foreach (string t in TotalArray) TotalList.Add(t);

            int Board = TotalList.Count;

            int sample = 0;
            while (sample < Board)
            {
                int check = 0;
                while (check < Board)
                {
                    // if ((sample != check) && (string.Compare(TotalList[sample], TotalList[check]) == 1))
                    if (TotalList[sample] == TotalList[check])
                    {
                        if (sample != check)
                        {
                            TotalList.RemoveAt(check);
                            Board = Board - 1;
                            check--;
                        }

                    }
                    check++;
                }
                sample++;
            }

            //AnsTotal = AnsTotal.Remove(0);
           string AnsTotal = TotalList[0];
            for (int k = 1; k < TotalList.Count; k++)
            {
                AnsTotal = AnsTotal.Insert(AnsTotal.Length, " ");
                AnsTotal = AnsTotal.Insert(AnsTotal.Length, TotalList[k]);
            }
            // Console.WriteLine(AnsTotal+" после");
            return AnsTotal;
        }



        //static void Main(string[] args)
        //{
        //    //string test = "abc";
        //    //test = test.Insert(0, "(");
        //    //for (int i = 1; i < test.Length; i++)
        //    //{
        //    //    test = test.Insert(i, ")");
        //    //    Console.WriteLine(test);
        //    //    test = test.Remove(i, 1);
        //    //}

        //    //string t1 = BalancedParentheses(1);
        //    //Console.WriteLine(t1);
        //    //string t2 = BalancedParentheses(2);
        //    //Console.WriteLine(t2);
        //    //string t3 = BalancedParentheses(3);
        //    //Console.WriteLine(t3);

        //    //string t4 = BalancedParentheses(4);
        //    //Console.WriteLine(t4);
        //    string t5 = BalancedParentheses(7);
        //    string[] Mount = t5.Split(' ');
        //    Console.WriteLine(Mount.Length);
        //    Console.WriteLine(t5);
        //}
    }
}

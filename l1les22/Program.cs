using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {
        public static string BalancedParentheses(int N)
        {
            int temp = N;
            string ans1;/// добавляем замкнутые скобки + ()+
            if (N == 1) return "()";
            if (N == 2) return "()() (())";
            ans1 = BalancedParentheses(N - 1);
            int i = 1;
            ans1 = ans1.Insert(0, "()");
            while ( i < ans1.Length)
            {
                if (ans1[i]==' ')
                {
                    ans1 = ans1.Insert(i+1, "()");
                    i = i + 2;// добавили два элемента , чтобы в счете вернуться на прежнее место
                }

                i++;
            }
            /// добавляем замкнутые скобки +() +
            string ans3 = BalancedParentheses(N - 1);
            ans3 = ans3.Substring((N-1)*2+1);
            ans3 = ans3.Insert(ans3.Length, "()");
            int l = 0;
            while (l < ans3.Length)
            {
                if (ans3[l] == ' ')
                {
                    ans3 = ans3.Insert(l, "()");
                    l = l + 2;// добавили два элемента , чтобы в счете вернуться на прежнее место
                }

                l++;
            }

            string ans2;/// добавляем обвалакивающие скобки (+ ......+) 
            ans2 = BalancedParentheses(N - 1);
            int j = 1;
            ans2 = ans2.Insert(0, "(");
            ans2 = ans2.Insert(ans2.Length,")");
            while (j < ans2.Length)
            {
                if (ans2[j] == ' ')
                {
                    ans2 = ans2.Insert(j, ")");
                    j = j +1;
                    ans2 = ans2.Insert(j+1, "(");// +1 ибо новую скобку открываем после пробела
                    j = j + 1;
                }

               j++;
            }
            //// объединяем оба случая
            string AnsTotal = ans1;
            AnsTotal = AnsTotal.Insert(AnsTotal.Length," ");
            AnsTotal = AnsTotal = AnsTotal.Insert(AnsTotal.Length, ans3);
            AnsTotal = AnsTotal.Insert(AnsTotal.Length, " ");
            AnsTotal = AnsTotal = AnsTotal.Insert(AnsTotal.Length, ans2);
            // ans = ans.Insert(0, ans);
           

            /////удаляем повторяющиеся комбинации из строки
            string[] TotalArray = AnsTotal.Split(' ');
            List<string> TotalList = new List<string>();
            foreach (string t in TotalArray) TotalList.Add(t);

            int Board = TotalList.Count;

            int sample = 0;
            while (sample < Board)
            {
                int check = 0;
                while (check < Board)
                {
                   // if ((sample != check) && (string.Compare(TotalList[sample], TotalList[check]) == 1))
                   if(TotalList[sample]== TotalList[check])
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

            AnsTotal = AnsTotal.Remove(0);
            AnsTotal = TotalList[0];
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

        //    string t1 = BalancedParentheses(1);
        //    Console.WriteLine(t1);
        //    string t2 = BalancedParentheses(2);
        //    Console.WriteLine(t2);
        //    string t3 = BalancedParentheses(3);
        //    Console.WriteLine(t3);

        //    string t4 = BalancedParentheses(4);
        //    Console.WriteLine(t4);
        //    string t5 = BalancedParentheses(5);
        //    Console.WriteLine(t5);
        //}
    }
}

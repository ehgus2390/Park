using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20250418
{
    internal class Bubble
    {
        public static void BubbleSort(IList<int>list)
        {
            for (int i = 1; i < list.Count; i++)       //i는 1부터 시작해서 리스트의 개수보다 1 작은값까지 증가한다
            {
                for (int j = 0; j < list.Count-i; j++)
                {
                    if (list[j] > list[j+1])
                    {
                        Swap(list, j, j + 1);
                    }
                }
            }
        }

        private static void Swap(IList<int>list, int left, int right)
        {
            int temp = list[left];
            list[left] = list[right];
            list[right] = temp;
        }
        static void Main()
        {

        }
    }
}

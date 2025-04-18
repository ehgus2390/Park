
namespace _20250418
{
    //internal class Ex
    //{
    //    public void stack()
    //    {
    //        int height = 10;
    //        int width = 20;
    //        for (int i = 0; i < height; i++)
    //        {
    //            for (int j = 0; j < 20; j++)
    //            {
    //                if (i == 0)
    //                {
    //                    Console.WriteLine("★");
    //                }
    //                else if (j == 20)
    //                {
    //                    Console.WriteLine("★");
    //                }
    //                else if (j == 20 && i <= 20)
    //                {
    //                    Console.WriteLine("★");
    //                }
    //                else
    //                {
    //                    Console.WriteLine("　");
    //                }
    //            }
    //            Console.WriteLine();
    //        }
    //    }
    //    static void Main()
    //    {
    //        //Ex ex = new Ex();
    //        //ex.stack(20,20);
    //    }
    //}

    internal class Bubble
    {
        public static void BubbleSort(IList<int>list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count-1; j++)
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
    


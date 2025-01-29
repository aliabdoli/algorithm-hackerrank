using Array = System.Array;
using Console = System.Console;
using Convert = System.Convert;
using String = System.String;

namespace HackerRankAlgorithm.ConstructiveAlgorithm
{
    class Solution
    {
        static int[] GetCounts(int n)
        {
            var arr = new int[n];
            int step = 1;
            while (step <= n)
            {
                for (int i = 0; i < n; i += step)
                {
                    arr[i]++;
                }

                step *= 2;
            }

            return arr;
        }

        //sorts val and ind after values
        static void Sort(ref int[] val, ref int[] ind)
        {
            var zipped = val.Zip(ind, (x, y) => new { x, y }).OrderByDescending(pair => pair.x).ToList();
            val = zipped.Select(pair => pair.x).ToArray();
            ind = zipped.Select(pair => pair.y).ToArray();
        }


        static void Recursion(int[] res, int[] nums, int index, int a, int b, int n)
        {

            if (b >= n)
            {
                Console.WriteLine("YES");
                Console.WriteLine(String.Join(" ", res));
            }
            else
            {
                for (int i = 0; i < b - a; i++)
                {
                    if (res[a + i] > nums[index + i])
                    {
                        int j = index + i + 1;
                        while (j < index + b - a && res[a + i] > nums[j])
                        {
                            j++;
                        }

                        if (j == index + b - a)
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        else
                        {
                            int temp = nums[j];
                            for (int z = j; z > index + i; z--)
                            {
                                nums[z] = nums[z - 1];
                            }

                            nums[index + i] = temp;
                        }
                    }
                }

                for (int i = 0; i < b - a; i++)
                {
                    if (b + 2 * i == 4018)
                    {
                        var cur = new int[b - a];
                        for (int q = 0; q < b - a; q++)
                        {
                            cur[q] = res[a + q];
                        }
                    }

                    if (b + 2 * i + 1 == 4018)
                    {
                        var cur = new int[b - a];
                        for (int q = 0; q < b - a; q++)
                        {
                            cur[q] = nums[index + q];
                        }
                    }

                    res[b + 2 * i] = res[a + i];
                    res[b + 2 * i + 1] = nums[index + i];
                }

                Recursion(res, nums, index + b - a, b, b + 2 * (b - a), n);
            }
        }

        static void Solve(int n, int[] arr)
        {
            var idealcounts = GetCounts(n).OrderByDescending(t => t).ToArray();
            int N = arr.Length;
            Array.Sort(arr);
            var nums = new int[n];
            var counts = new int[n];
            int ind1 = 0, ind2 = 0;
            while (ind1 < n)
            {
                nums[ind1] = arr[ind2];
                while (ind2 < N && nums[ind1] == arr[ind2])
                {
                    counts[ind1]++;
                    ind2++;
                }

                ind1++;
                if (ind2 == N && ind1 != n)
                {
                    Console.WriteLine("NO");
                    return;
                }
            }

            Sort(ref counts, ref nums);
            for (int i = 0; i < n; i++)
            {
                if (counts[i] != idealcounts[i])
                {
                    Console.WriteLine("NO");
                    return;
                }
            }

            int[] res = new int[N];
            int step = 1;
            for (int i = 0; i < n;)
            {
                res[i] = nums[0];
                i += step;
                step *= 2;
            }

            Recursion(res, nums, 1, 0, 1, n);
        }

        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] nums = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(nums, t => Convert.ToInt32(t));
            Solve(n, arr);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_proj_01
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a static array to test data with..
            int[] testaData = {13,-3,-25,20,-3,-16,-23,18,20,-7,12,-5,-22,15,-4,7};

            var data = FindMaximumSubArray(testaData, 0, testaData.Length - 1);

        }

        public static int[] FindMaxCrossingSubArray(int[] A, int low, int mid, int high)
        {
            int left_sum = -100000;
            int sum = 0;
            int max_left = mid;
            int[] values = new int[3]; // this will contain the respective low, high, sum values for each side.
            for (int i = mid; i > low; i--)
            {
                sum += A[i];
                if (sum > left_sum)
                {
                    left_sum = sum;
                    max_left = i;
                }
            }

            int right_sum = -1000000;
            int max_right = (mid + 1);
            sum = 0;
            for (int j = mid + 1; j < high; j++)
            {
                sum += A[j];
                if (sum > right_sum)
                {
                    right_sum = sum;
                    max_right = j;
                }
            }

            // return values...
            values[0] = max_left;
            values[1] = max_right;
            values[2] = left_sum + right_sum;
            return values;
        }

        public static int[] FindMaximumSubArray(int[] A, int low, int high)
        {
            int mid;
            int[] values = new int[3];
            int[] maxSubLow, maxSubHigh, maxCross;
            if (low == high)
            {
                values[0] = low;
                values[1] = high;
                values[2] = A[low];
                return values;
            }
            mid = (low + high)/2;
            maxSubLow = FindMaximumSubArray(A,low,mid);
            maxSubHigh = FindMaximumSubArray(A, mid + 1, high);
            maxCross = FindMaxCrossingSubArray(A, low, mid, high);

            if(maxSubLow[2] >= maxSubHigh[2] && maxSubLow[2] >= maxCross[2])
                return maxSubLow;
            if (maxSubHigh[2] >= maxSubLow[2] && maxSubHigh[2] >= maxCross[2])
                return maxSubHigh;

            return maxCross;
        }
    }
}

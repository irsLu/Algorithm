using System;

public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int allNums = nums1.Length + nums2.Length;
        int sMedian = allNums % 2 == 0
            ? (int)Math.Floor((double)(allNums) / 2)
            : (int)Math.Floor((double)(allNums) / 2) + 1;
        int bMedian = allNums % 2 == 0 ? (int)Math.Ceiling((double)(allNums) / 2) + 1 : (int)Math.Ceiling((double)(allNums) / 2);

        allNums = 0;

        int i = 0, j = 0;

        int rets = 0, retb = 0;

        while (i < nums1.Length && j < nums2.Length)
        {
            if (nums1[i] > nums2[j])
            {
                allNums++;


                if (allNums == sMedian)
                {
                    rets = nums2[j];

                }

                if (allNums == bMedian)
                {
                    retb = nums2[j];

                }

                j++;


            }
            else
            {
                allNums++;

                if (allNums == sMedian)
                {
                    rets = nums1[i];

                }

                if (allNums == bMedian)
                {
                    retb = nums1[i];

                }

                i++;

            }
        }

        while (i < nums1.Length)
        {
            allNums++;


            if (allNums == sMedian)
            {
                rets = nums1[i];

            }
            if (allNums == bMedian)
            {
                retb = nums1[i];

            }

            i++;
        }

        while (j < nums2.Length)
        {
            allNums++;

            if (allNums == sMedian)
            {
                rets = nums2[j];

            }

            if (allNums == bMedian)
            {
                retb = nums2[j];

            }

            j++;
        }



        return (rets + retb) / 2f;
    }
}
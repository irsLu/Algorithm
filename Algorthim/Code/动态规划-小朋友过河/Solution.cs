// 小朋友过桥问题：在一个夜黑风高的晚上，有n（n <= 50）个小朋友在桥的这边，现在他们需要过桥，
// 但是由于桥很窄，每次只允许不大于两人通过，他们只有一个手电筒，所以每次过桥的两个人需要把手电筒带回来，
// i号小朋友过桥的时间为T[i]，两个人过桥的总时间为二者中时间长者。问所有小朋友过桥的总时间最短是多少。

using System;

class Solution
{
   public int baby_cross_river(int[] time, int n)
    {
        int ret = 0;

        if (n <= 2) return time[n];

        if (n == 3) return time[1] + time[2] + time[3];

        int ret_n_2 = time[2];
        int ret_n_1 = time[1] + time[2] + time[3];

        for(int i = 4; i < n+1;i++)
        {
            ret = 2 * time[2] + time[1] + time[i] + ret_n_2;
            ret_n_2 = ret_n_1;
            ret_n_1 = ret;
        }

        return ret;
    }
}
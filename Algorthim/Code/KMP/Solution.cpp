#include <iostream>
#include <string>
using namespace std;


class Solution {
public:
    /*
     * @param source: A source string
     * @param target: A target string
     * @return: An integer as index
     */

    int *next;

    // how get it???
    // void getNext(char * p, int * next)
    // {
    //     next[0] = -1;
    //     int i = 0, j = -1;

    //     while (i < strlen(p))
    //     {
    //         if (j == -1 || p[i] == p[j])
    //         {
    //             ++i;
    //             ++j;
    //             next[i] = j;
    //         }
    //         else
    //             j = next[j];
    //     }
    // }

    void getNext(const char* s)
    {
        string str = s;
        int len = str.length();
        next = new int[len];
        next[0] = -1;
        int i,k;
        for(i = 1; i < len; i++)
        {
            k = i - 1;
            while(k > 0)
            {
                if(str.substr(0, k) == str.substr(i - k, k))
                    break;

                k--;
            }

            next[i] = k;
        }

    }


    int strStr2(const char* source, const char* target) {
        // write your code here
        getNext(target);

        int sp = 0, tp = 0, slen = strlen(source), tlen = strlen(target);

        while((sp < slen) && (tp < tlen))
        {
            if(tp == -1 || source[sp] == target[tp])
            {
                sp++;
                tp++;
            }
            else
            {
                tp = next[tp];

            }

        }

        if(tp == strlen(target))
            return sp - tp;
        else
            return -1;
    }

};

 int main()
{
    const char* x = "source";
    const char* t = "target";
    Solution su;
    cout<< su.strStr2(x, t);
    return 0;
}

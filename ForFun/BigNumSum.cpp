#include <iostream>
#include <string>
#include <memory>
using namespace std;


string bigNumSum(const string numA, const string numB)
{
    int maxLen = numA.length() > numB.length() ? numA.length(): numB.length();

    int *arrA = new int[maxLen + 1],i=0;
    memset(arrA, 0, sizeof(int)*(maxLen + 1));

    for(i = 0; i < numA.length(); i++)
        arrA[i] = numA[numA.length() - i - 1] - '0';

    int *arrB = new int[maxLen + 1];
    memset(arrB, 0, sizeof(int) * (maxLen + 1));

    for(i = 0; i < numB.length(); i++)
        arrB[i] = numB[numB.length() - i - 1] - '0';

    int *res = new int(maxLen + 1);
    memset(res, 0, sizeof(int) * (maxLen + 1));

    for(i = 0;i < maxLen + 1; i++)
    {
        int temp = res[i];
        temp += arrA[i];
        temp += arrB[i];

        if(temp >= 10)
        {
            temp = temp - 10;
            res[i+1] = 1;
        }

        res[i] = temp;
    }


    string resStr;
    bool findFirst = false;
    for(i = maxLen; i > -1; i--)
    {
        if(!findFirst)
        {
            if(res[i] == 0)
                continue;

            findFirst = true;
        }

        resStr.append(to_string(res[i]));
    }

    return resStr;
}


int main()
{
    string a = "11111";
    string b = "222222";

    string c = bigNumSum(a, b);

    cout<<c<<endl;
}

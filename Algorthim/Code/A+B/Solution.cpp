#include <iostream>
#include <string>
#include <math.h>
using namespace std;

int bitvalue(int v, int i)
{
    int _bit = 0;
    if (v & (1 << i))
    {
        _bit = 1;
    }
    else
    {
        _bit = 0;
    }
    
    return _bit;
}

char tochar(int i)
{
	return i == 1? '1' : '0';
}

int toint(const string s)
{
	int n = 0;

	for(int i = 0; i < s.size();i++)
	{
		n = n + pow(2, i) * (s[i] - '0');
	}

	return n;
}

int aplusb(int a, int b) 
{
    string res = "";
   	int sum = bitvalue(a, 0) ^ bitvalue(b, 0);
   	int carry = bitvalue(a, 0) & bitvalue(b, 0);
    res += tochar(sum);
    for (int i = 1; i < 31; i++)
    {
        int a_bit = bitvalue(a, i);
        int b_bit = bitvalue(b, i);
        
	    sum = ((!a_bit) & (!b_bit) & carry) | ((!a_bit) & b_bit & (!carry)) | (a_bit & (!b_bit) & (!carry)) | (a_bit & b_bit & carry);
	    carry = (a_bit & b_bit & (!carry)) | (a_bit & (!b_bit) & carry) | ((!a_bit) & b_bit & carry) | (a_bit & b_bit & carry);
        res += tochar(sum);
    }
   	cout<<res<<endl;

   	return toint(res);
}
   
int main()
{

	int res = aplusb(100,5);

	cout<<res<<endl;
	return 0;
}
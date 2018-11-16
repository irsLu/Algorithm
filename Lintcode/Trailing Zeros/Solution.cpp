#include <iostream>
#include <string>

using namespace std;

long long trailingZeros(long long n) {
    // write your code here, try to do it without arithmetic operators.
    long long res = 0;
    while(n > 0)
    {
        res += n / 5;
        n = n / 5;
    }
    
    return res;
}
   
int main()
{	
	long long res = trailingZeros(105);
	cout<<res<<endl;
	return 0;
}
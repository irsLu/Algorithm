#include <iostream>
#include <string>
#include <cmath>
using namespace std;

 int digitCounts(int k, int n) 
{ 
	int count = 0; 
	int num = n == 0 ? 0:  log10(n);
	for (int i = 0; i <= num; i++) 
	{ 
		int currentWei = ((int)(n / pow(10,i))%10);//当前位 
		
		int leftWei = (int) (n/pow(10,i+1));
		//高位 
		int rightWei = (int) (n%(int)pow(10,i));
		//低位 
		if(currentWei > k )
		{ 
			count += (leftWei+1)*pow(10,i); 
		}
		else if(currentWei < k)
		{ 
			count += leftWei *pow(10,i); 
		}else 
		{ 
			count += leftWei *pow(10,i)+rightWei+1; 
		} 
	} 
	return count; 
}
int main()
{	
	int res = digitCounts(0, 0);
	cout<<res<<endl;
	return 0;
}


#include <iostream>
using namespace std;

void quick_sort(int arr[], int left, int right)
{
	if(left < right)
	{
		int l = left, r = right;
		int x = arr[l];
		cout<<l<<"_"<<r<<endl;
		while(l < r)
		{
			while(l < r && arr[r] >= x)
				r--;
		
			if(l < r) arr[l++] = arr[r];

			while(l < r && arr[l] <= x)
				l++;

			if(l < r) arr[r--] = arr[l];
		}
		arr[l] = x;
		quick_sort(arr, left, l-1);
		quick_sort(arr, l+1, right);
	}
}



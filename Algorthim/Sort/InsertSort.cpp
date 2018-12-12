#include <iostream>
using namespace std;

void insert_sort(int arr[]，int low, int high)
{
	for(int i = low + 1; i< high; i++)
	{
		int temp = arr[i];
		int j = i - 1;
		while(j >= low && arr[j] > temp)
		{
			arr[j+1] = arr[j];
			j--;
		}

		arr[j+1] = temp;
	}
}


#include <iostream>
using namespace std;
void swap(int *i, int *j)
{
	int temp = *i;
	*i = *j;
	*j = temp;
}


void bulle_sort (int arr[], int len)
{
	for(int i = 0; i < len - 1; i++)
	{
		for(int j = 0; j < len - i - 1; j++)
		{
			if(arr[j] < arr[j + 1])
			{
				swap(&arr[j], &arr[j + 1]);
			}
		}
	}
}

//设置变量 防止有序后还进行遍历
void bulle_sort_sign (int arr[], int len)
{
	int sign = 0;
	for(int i = 0; i < len - 1 && sign != 1; i++)
	{
		sign = 1;
		for(int j = 0; j < len - i - 1; j++)
		{
			if(arr[j] < arr[j + 1])
			{
				sign = 0;
				swap(&arr[j], &arr[j + 1]);
			}
		}
	}
}

//鸡尾酒排序
void cocktail_sort(int arr[], int len)
{
	int j , left = 0, right = len - 1;
	while(left < right)
	{
		for(j = left; j < right; j++)
		{
			if(arr[j] > arr[j+1])
			{
				swap(arr[j], arr[j+1]);
			}
				
		}

		right--;

		for(j = right; j > left; j--)
		{
			if(arr[j-1] > arr[j])
			{
				swap(arr[j-1], arr[j]);
			}

		}
		left++;
	}
}

void print_arr(int arr[], int len)
{
	for(int p = 0; p < len; p++)
	{
		cout<<arr[p]<<endl;
	}
}


int main()
{
	int test[] = {1,2,5,3,8,6};
	cocktail_sort(test, 6);
	print_arr(test, 6);
	return 0;
}
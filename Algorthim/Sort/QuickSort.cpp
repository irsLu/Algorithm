#include <iostream>
using namespace std;

void quick_sort(int arr[], int low, int high)
{
	if(low >= high)
	{
		return;
	}

	int l = low, r = high;
	int pivot = arr[l];
	while(l < r)
	{
		while(l < r && arr[r] >= pivot)
			r--;
	
		if(l < r) arr[l++] = arr[r];

		while(l < r && arr[l] <= pivot)
			l++;

		if(l < r) arr[r--] = arr[l];
	}
	arr[l] = pivot;
	quick_sort(arr, low, l-1);
	quick_sort(arr, l+1, high);

}

void swap(int *i, int *j)
{
	int temp = *i;
	*i = *j;
	*j = temp;
}

void insert_sort(int arr[], int low, int high)
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

int select_pivot_median_of_three(int arr[], int low, int high)
{
	int firstNum = arr[low];
	int lastNum = arr[high];
	int medianNum = arr[(low + high)/2];

	if((firstNum <= lastNum && firstNum >= medianNum ) || (firstNum <= medianNum && firstNum >= lastNum))
		return low;

	if((medianNum <= lastNum && medianNum >= firstNum) || (medianNum <= firstNum && medianNum >= lastNum))
		return (low + high)/2;

	if((lastNum <= medianNum && lastNum >= firstNum) || (lastNum <= firstNum && lastNum >= medianNum))
		return high;

	return low;
}

void quick_sort_optim(int arr[], int low, int high)
{
	int first = low;
	int last = high;
 
	int left = low;
	int right = high;
 
	int leftLen = 0;
	int rightLen = 0;

	// when array small enough, insert sort is better than quick sort
	if(high - low + 1 < 10)
	{
		//insert_sort(arr, low, high);
	}
	
	if(low >= high)
	{
		return;
	}

	int pivotIndex = select_pivot_median_of_three(arr, low, high);
	swap(&arr[low], &arr[pivotIndex]);
	int pivot = arr[low];

	while(first < last)
	{
		while(first < last && arr[last] >= pivot)
		{
			if(arr[last] == pivot)
			{
				swap(&arr[last], &arr[right]);
				right--;
				rightLen++;
			}

			last--;
		}

		if(first < last) arr[first++] = arr[last];

		while(first < last && arr[first] <=pivot)
		{
			if(arr[first] == pivot)
			{
				swap(&arr[first], &arr[left]);
				left++;
				leftLen++;
			}
			first++;
		}

		if(first < last) arr[last++] = arr[first];
	}


	arr[first] = pivot;

	int i = first - 1;
	int j = low;

	while(j < left && arr[i] != pivot)
	{
		swap(&arr[j], &arr[i]);
		j++;
		i--;
	}

	i = first + 1;
	j = high;

	while(j > right && arr[i] != pivot)
	{
		swap(&arr[j], &arr[i]);
		i++;
		j--;
	}
	quick_sort_optim(arr, low, first - leftLen - 1);
	quick_sort_optim(arr, first + rightLen + 1, high);

}

int main()
{
	int test[] = {1, 4, 6, 7, 6, 6, 7, 6, 8, 6};
	quick_sort_optim(test, 0, 9);
	return 0;
}



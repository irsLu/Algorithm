#include <iostream>
using namespace std;

void swap(int *i, int *j)
{
    int temp = *i;
    *i = *j;
    *j = temp;
}

void select_sort(int arr[], int len)
{

    int left = 0, right = len - 1;

    while(left < right)
    {
        int max = left;
        int min = right;

        for(int i = left; i <= right; i++)
        {
            if(arr[i] < arr[min])
                min = i;

            if(arr[i] > arr[max])
                max = i;
        }
        swap(&arr[right], &arr[max]);

         if(min == right)
            min = max;

        swap(&arr[left], &arr[min]);

        left++;
        right--;
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
    int test[] = {10,2,5,3,8,1,6};
    select_sort(test, 7);
    print_arr(test, 7);
    return 0;
}
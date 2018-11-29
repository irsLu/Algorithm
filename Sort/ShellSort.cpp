#include <iostream>

void swap(int *i, int *j)
{
    int temp = *i;
    *i = *j;
    *j = temp;
}

void shell_sort(int arr[], int len)
{
    while(int grap = len/2; grap > 0; grap /= 2)
    {
        for(int i = grap; i < len; i++)
        {
            int j = i;
            while(j - grap >= 0 && arr[j] < arr[j - grap])
            {
                swap(&arr[j], &arr[j - grap]);
                j -= grap;
            }
        }
    }
}



int main()
{

        return 0;
}
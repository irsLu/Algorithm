#include <iostream>
#include <vector>

using namespace std;


int select_pivot_median_of_three(vector<int> arr, int low, int high)
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

void swap(int *i, int *j)
{
    int temp = *i;
    *i = *j;
    *j = temp;
}

bool isFindRes;
int nthNum;

void quick_sort(vector<int> arr, int left, int right, int res)
{
    if(left >= right || isFindRes)
    {
        if(left == right && left == res)
        {
            isFindRes = true;
            nthNum = arr[left];
        }
        return;
    }
    int l = left, r = right;
    int index = select_pivot_median_of_three(arr, left, right);
    swap(&arr[l], &arr[index]);
    int x = arr[l];
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
    if(res == l)
    {
        isFindRes = true;
        nthNum = x;
        return;
    }
    else if(res < l)
    {
         quick_sort(arr, left, l-1, res);
    }
    else
    {
         quick_sort(arr, l+1, right, res);
    }
    
}

int kthLargestElement(int n, vector<int> &nums) {
    isFindRes = false;
    nthNum = 0;
    int nReverser = (nums).size() - n;
    quick_sort(nums, 0, (nums).size()-1, nReverser);
    return nthNum;
}


int main(int argc, char const *argv[])
{
    
    vector<int> test;
    test.push_back(1);
    test.push_back(2);
    test.push_back(3);
    test.push_back(4);
    test.push_back(5);
    int res = kthLargestElement(2, test);
    cout<<"the res "<<res<<endl;
    return 0;
}

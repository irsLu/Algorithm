#include <iostream>
#include <vector>
using namespace std;

class Solution {
public:
    /*
     * @param nums: A list of integers.
     * @return: A list of permutations.
     */
    vector<vector<int>> permute(vector<int> &nums) {
        // write your code here

        vector<vector<int>> res;
        vector<int> temp;
        int* arr = new int[nums.size()]();
        _permute(res, arr, temp, nums);
        return res;
    }
private:
    void _permute(vector<vector<int>> &res, int arr[], vector<int> &temp, vector<int> &nums)
    {
        if(temp.size() == nums.size())
        {
            vector<int> v(temp);
            res.push_back(v);
            return;
        }

        for(int i = 0; i < nums.size(); i++)
        {
            if(arr[i] == 1)
            {
                continue;
            }
            arr[i] = 1;
            temp.push_back(nums[i]);
            _permute(res, arr, temp, nums);
            arr[i] = 0;
            temp.pop_back();
        }
    }
};

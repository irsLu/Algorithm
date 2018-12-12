#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

class Solution {
public:
    /**
     * @param nums: A set of numbers
     * @return: A list of lists
     */
    vector<vector<int>> subsets(vector<int> &nums) {
        // write your code here
        vector<int> v;
        vector<vector<int>> res;
        std::sort(nums.begin(), nums.end());
        dfs(nums, 0, v, res);
        //bfs(nums, res);
        return res;
    }

private:
    void bfs(vector<int> &nums, vector<vector<int>> &res)
    {
        std::vector<int>temp;
        res.push_back(temp);
        int len = nums.size();
        if(!len) {
            return;
        }

        std::sort(nums.begin(), nums.end());
        for(int i = 0; i < len; i++) {
            int t = res.size();
            for(int j = 0; j < t; j++) {
                std::vector<int> temp = res[j];
                temp.push_back(nums[i]);
                res.push_back(temp);
            }
        }
    }

    void dfs(vector<int> &nums, int index, vector<int> &temp, vector<vector<int>> &res)
    {
        if(index == nums.size())
        {
            std::vector<int> v(temp);
            res.push_back(v);
            return;
        }

        temp.push_back(nums[index]);
        dfs(nums, index+1, temp, res);

        temp.pop_back();
        dfs(nums, index+1, temp, res);
    }

};
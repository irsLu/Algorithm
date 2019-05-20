/**
 * Definition of TreeNode:
 * class TreeNode {
 * public:
 *     int val;
 *     TreeNode *left, *right;
 *     TreeNode(int val) {
 *         this->val = val;
 *         this->left = this->right = NULL;
 *     }
 * }
 */
 #include <iostream>

 using namespace std;

class Solution {
public:
    /**
     * @param root: param root: The root of the binary search tree
     * @param k1: An integer
     * @param k2: An integer
     * @return: return: Return all keys that k1<=key<=k2 in ascending order
     */
    vector<int> ret;

    vector<int> searchRange(TreeNode * root, int k1, int k2) {
        // write your code here
        _searchRange(root, k1, k2);

        return ret;

    }

    void _searchRange(TreeNode * root, int k1, int k2)
    {

        if(Null == root)
            return;

        if(root->val < k1)
        {
            _searchRange(root->right, k1, k2);
        }
        else if(root->val > k2)
        {
            _searchRange(root->left, k1, k2);
        }
        else if(root->val == k1)
        {
            ret.push_back(root->val);
            _searchRange(root->right, k1, k2);
        }
        else if(root->val == k2)
        {
            ret.push_back(root->val);
            _searchRange(root->left, k1, k2);
        }
        else if(root->val < k2 && root->val > k1)
        {
            ret.push_back(root->val);
            _searchRange(root->left, k1, k2);
            _searchRange(root->right, k1, k2);
        }

    }

    int main()
    {

        return 0;
    }
};
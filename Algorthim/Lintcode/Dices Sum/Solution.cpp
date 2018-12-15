#include <iostream>
#include <vector>
#include <math.h>
#include <map>
using namespace std;

class Solution {
public:
    /**
     * @param n an integer
     * @return a list of pair<sum, probability>
     */

    vector<pair<int, double>> dicesSum(int n) {
        // Write your code here
        vector<pair<int, double> > res;

        map<int, double> _map;
        _map[1] = 1;
        _map[2] = 1;
        _map[3] = 1;
        _map[4] = 1;
        _map[5] = 1;
        _map[6] = 1;

        map<int, double> _temp;

        map<int, double>::iterator iter;
        for (int i = 1; i < n;i++)
        {

            for (int i = 1; i <= 6; i++)
            {
                for (iter = _map.begin(); iter != _map.end(); iter++)
                {
                    if (_temp.find(i+(iter->first)) != _temp.end())
                    {
                        _temp[i + (iter->first)] += iter->second;
                    }
                    else
                    {
                        _temp[i + (iter->first)] = iter->second;
                    }
                }
            }

            _map.clear();
            for (iter = _temp.begin(); iter != _temp.end(); iter++)
            {
                _map[iter->first] = iter->second;
            }
            _temp.clear();
        }

        double rate = 1.0 / pow(6, n);
        for (iter = _map.begin(); iter != _map.end(); iter++)
        {
            res.push_back(make_pair(iter->first, rate*(iter->second)));
        }

        return res;
    }
};

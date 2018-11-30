#include <iostream>
#include <stack>

using namespace std;

class MinStack {

private:
    stack<int> dataStack;
    stack<int> minStack;
public:
    MinStack() {
        // do intialization if necessary
    }

    /*
     * @param number: An integer
     * @return: nothing
     */
    void push(int number) {
        // write your code here
        dataStack.push(number);

        if(minStack.empty())
            minStack.push(number);
        else
        {
            if(minStack.top() <= number)
                minStack.push(minStack.top());
            else
                minStack.push(number);
        }
    }

    /*
     * @return: An integer
     */
    int pop() {
        // write your code here
        int ret = dataStack.top();
        minStack.pop();
        dataStack.pop();

        return ret;
    }

    /*
     * @return: An integer
     */
    int min() {
        // write your code here
        int ret = minStack.top();
        return ret;
    }
};
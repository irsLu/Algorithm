#include <iostream>
#include <string>
#include <vector>
using namespace std;

template<class T>
class CHeap
{
public:
	~CHeap()
	{
		m_heap.clear();
	}

	CHeap(){}

	void push(T element)
	{

		if(isexist(element)) return;

		m_heap.push_back(element);
		int index = m_heap.size() -1;
		while(index != 0 && element < m_heap[(index-1)/2])
		{
			m_heap[index] = m_heap[(index-1)/2];
			index = (index-1)/2;
		}

		m_heap[index] = element;
	}

	bool isexist(T e)
	{
		for(int i = 0; i < m_heap.size(); i++)
		{
			if(m_heap[i] == e)
				return true;
		}
		return false;
	}

	T pop()
	{
		if(m_heap.size() == 0)
			exit(1);
		
		T res = m_heap[0];
		T lastNode = m_heap[m_heap.size() - 1];
		m_heap.pop_back();
		int parent = 0, child = 1, size = m_heap.size();
		while(child < size)
		{
			if(child < size && m_heap[child] > m_heap[child + 1])
				child++;
			

			if(lastNode > m_heap[child])
			{
				m_heap[parent] = m_heap[child];
				parent = child;
				child = child*2 + 1;
			}
			else
			{
				break;
			}

		}
		m_heap[parent] = lastNode;
		return res;
	}


private:
	vector<T> m_heap;
};

long long nthUglyNumber(int n) {
    // write your code here
    CHeap<long long > minHeap;
    minHeap.push(1);
    long long  res;

    while(n > 0)
    {
    	res = minHeap.pop();
    	minHeap.push(res * 2);
    	minHeap.push(res * 3);
    	minHeap.push(res * 5);
    	n--;
    }

    return res;
}

int main()
{	
	int res = nthUglyNumber(10);
	cout<<"the res "<<res<<endl;
	return 0;
}

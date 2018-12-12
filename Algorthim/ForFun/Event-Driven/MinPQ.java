/**
 * Created by Administrator on 2017-01-20.
 */
import java.util.Comparator;
import java.util.Iterator;
import java.util.NoSuchElementException;

public class MinPQ<Key> implements Iterable<Key>
{
    private Key[] pq;
    private int N;
    private Comparator<Key> comparator;

    public MinPQ(int capacity)
    {
        pq = (Key[]) new Comparable[capacity+1];
        N = 0;
    }

    public MinPQ() {
        this(1);
    }

    public MinPQ(int initCapacity, Comparator<Key> comparator) {
        this.comparator = comparator;
        pq = (Key[]) new Object[initCapacity + 1];
        N = 0;
    }

    public MinPQ(Comparator<Key> comparator) {
        this(1, comparator);
    }

    public MinPQ(Key[] keys) {
        N = keys.length;
        pq = (Key[]) new Object[keys.length + 1];
        for (int i = 0; i < N; i++)
            pq[i+1] = keys[i];
        for (int k = N/2; k >= 1; k--)
            sink(k);
        assert isMinHeap();
    }


    public boolean isEmpty()
    { return N == 0; }

    public int size()
    { return N; }

    public Key min() {
        if (isEmpty()) throw new NoSuchElementException("Priority queue underflow");
        return pq[1];
    }

    private void resize(int capacity) {
        assert capacity > N;
        Key[] temp = (Key[]) new Object[capacity];
        for (int i = 1; i <= N; i++) {
            temp[i] = pq[i];
        }
        pq = temp;
    }

    public void insert(Key key)
    {
        // 必需时翻倍数组长度
        if (N == pq.length - 1) resize(2 * pq.length);

        pq[++N] = key;
        swim(N);
        assert isMinHeap();
    }

    public void exch(int i, int j)
    {
        Key t = pq[i];
        pq[i] = pq[j];
        pq[j] = t;
    }

    public boolean greater(int i,int j)
    {
        if (comparator == null)
        {
            return ((Comparable<Key>) pq[i]).compareTo(pq[j]) > 0;
        }
        else
        {
            return comparator.compare(pq[i], pq[j]) > 0;
        }
    }

    public Key delMin()
    {
        if (isEmpty()) throw new NoSuchElementException("Priority queue underflow");
        Key min = pq[1];
        exch(1, N--);
        sink(1);
        pq[N+1] = null;
        if ((N > 0) && (N == (pq.length - 1) / 4)) resize(pq.length  / 2);
        assert isMinHeap();
        return min;
    }

    private void swim(int k)
    {
        while (k > 1 && greater(k/2,k))
        {
            exch(k,k/2);
            k = k/2;
        }
    }

    public void sink(int k)
    {
        while  (2*k <= N)
        {
            int j = 2*k;
            if (j < N && greater(j, j+1)) j++;
            if (!greater(k,j)) break;
            exch(k,j);
            k = j;
        }
    }

    private boolean isMinHeap() {
        return isMinHeap(1);
    }

    private boolean isMinHeap(int k)
    {
        if (k > N) return true;
        int left = 2*k;
        int right = 2*k + 1;
        if (left <= N && greater(k,left)) return false;
        if (right <= N && greater(k,right)) return false;
        return isMinHeap(left) && isMinHeap(right);
    }

    public Iterator<Key> iterator() { return new HeapIterator();}

    private class HeapIterator implements Iterator<Key> {
        // 构造一个新的队列pq
        private MinPQ<Key> copy;

        //把所有项添加到复制堆中
        //只需花费线性时间（在被复制的堆有序的情况下）
        public HeapIterator()
        {
            if(comparator == null) copy = new MinPQ<Key>(size());
            else                   copy = new MinPQ<Key>(size(),comparator);
            for (int i = 1; i <= N; i++)
                copy.insert(pq[i]);
        }

        public boolean hasNext()  { return !copy.isEmpty();                     }
        public void remove()      { throw new UnsupportedOperationException();  }

        public Key next() {
            if (!hasNext()) throw new NoSuchElementException();
            return copy.delMin();
        }
    }
}
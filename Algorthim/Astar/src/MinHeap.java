
public class MinHeap {
	private Node[] heap;
	private int size;
	private int pointer;
	
	
	public MinHeap(int size)
	{
		this.size = size;
		heap = new Node[size*size + 1];
		pointer = 1;
		
	}
	
	public void add(Node site)
	{
		if(pointer > heap.length) return;
		
		heap[pointer] = site;
		int i = pointer,p;
		pointer++;

		while(true)
		{
			if(i == 1)break;
			p = i / 2;
			if(heap[p].getFValue() <= heap[i].getFValue())break;
			swap(p,i);
			i = p;
		}
	}
	
	public Node getMin()
	{
		return heap[1];
	}
	
	public boolean isEmpty()
	{
		return pointer == 1?true:false;
	}
	
	private void  swap(int i,int j)
	{
		Node temp = heap[i];
		heap[i] = heap[j];
		heap[j] = temp;
	}
	
	public Node remove()
	{
		Node res = heap[1];
		
		heap[1] = heap[pointer-1];
		int i = 1,child;
		
		pointer--;
		while(true)
		{
			child = 2* i;
			if(child >= pointer)break;
			
			if(child + 1 < pointer)
			{
				if(heap[child].getFValue() > heap[child+1].getFValue()) child++;
			}
			
			if(heap[i].getFValue() <= heap[child].getFValue())break;
			swap(i,child);
			i = child;
			
		}
		
		return res;
	}
	
	public boolean contains(Coordinate obj)
	{
		if(obj.col<1 || obj.col >size || obj.row < 1 || obj.row > size) return false;
		for (int i = 1; i < pointer;i++)
		{
			if(heap[i].getPos().row == obj.row && heap[i].getPos().col == obj.col)
			{
				return true;
			}
		}
		return false;
	}
	
	public void updateValue(Coordinate obj,int g,int h)
	{
		if(obj.col<1 || obj.col >size || obj.row < 1 || obj.row > size) return;
		for (int i = 1; i < pointer;i++)
		{
			if(heap[i].getPos().row == obj.row && heap[i].getPos().col == obj.col)
			{
				heap[i].updateValue(g, h);
			}
		}
	}
}

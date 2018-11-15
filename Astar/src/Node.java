
public class Node {
	
	//F = G + H
	private int Given;
	private int Heuristic;
	private int F;
	private boolean isOpen;
	private int type;
	private Coordinate pos;
	private Coordinate parent;
	public Node(int row,int col)
	{
		this.Given = 0;
		this.Heuristic = 0;
		this.F = 0;
		this.isOpen = true;
		this.type = 0;
		this.pos  = new Coordinate(row,col);
		this.parent = new Coordinate(row,col);
	}
	
	public void updateValue(int g,int h,Coordinate parent)
	{
		Given = g;
		Heuristic = h;
		this.parent = parent;
		F = Given + Heuristic;
	}
	
	public Coordinate getParent()
	{
		return this.parent;
	}
	
	
	public void updateValue(int g,int h)
	{
		Given = g;
		Heuristic = h;
		F = Given + Heuristic;
	}
	
	public Coordinate getPos()
	{
		return this.pos;
	}
	public int getType()
	{
		return this.type;
	}
	
	public void setType(int type)
	{
		this.type = type;
	}
	
	public int getFValue()
	{
		return F;
	}
	
	public void setSiteBolck()
	{
		isOpen= false;
	}
	public boolean isOpen()
	{
		return this.isOpen;
	}
	
	public int getGiven()
	{
		return this.Given;
	}
	
	public void setParent(Coordinate parent)
	{
		this.parent = parent;
	}
	@Override
	public boolean equals(Object obj) {
		if(obj instanceof Node)
		{
			Node co = (Node) obj;
			return pos.row == co.pos.row && pos.col == co.pos.col;
		}
		return false;
	}
}

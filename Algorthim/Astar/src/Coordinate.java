
public class Coordinate {
	public int row;
	public int col;
	
	public Coordinate()
	{
		row = 0;
		col = 0;
	}
	
	public Coordinate(int row, int col)
	{
		this.row = row;
		this.col = col;
	}
	
	public void changeRowAndCol(int row, int col)
	{
		this.row = row;
		this.col = col;
	}
	
	@Override
	public boolean equals(Object obj) {
		if(obj instanceof Coordinate)
		{
			Coordinate co = (Coordinate) obj;
			return row == co.row && col == co.col;
		}
		return false;
	}
}

import java.util.Queue;

import edu.princeton.cs.algs4.StdDraw;
import java.util.LinkedList;
import edu.princeton.cs.algs4.StdRandom;

public class AStar {

	private Node[] map;
	private int size;
	private MinHeap openList;
	private Queue<Coordinate> closeList;
	private Coordinate src;
	private Coordinate des;
	private static int AStarType = 1;
	
	public AStar(int mapSize) {
		size = mapSize;
		map = new Node[size*size];
		for (int i = 0; i < map.length; i++) {
			map[i] = new Node(i / size + 1,i % size + 1);
			//map[i].setPos(i / size + 1,i % size + 1);
		}
		/*
		for(int i = 0;i < 60; i++)
		{
			int col = StdRandom.uniform(size) + 1;
			int row = StdRandom.uniform(size) + 1;
			
			map[(row - 1)*size + col - 1].setSiteBolck();
		}
		*/
		map[coord2Index(new Coordinate(15,2))].setSiteBolck();
		map[coord2Index(new Coordinate(2,11))].setSiteBolck();
		map[coord2Index(new Coordinate(16,14))].setSiteBolck();
		map[coord2Index(new Coordinate(9,4))].setSiteBolck();
		map[coord2Index(new Coordinate(11,6))].setSiteBolck();
		map[coord2Index(new Coordinate(12,11))].setSiteBolck();
		map[coord2Index(new Coordinate(4,4))].setSiteBolck();
		map[coord2Index(new Coordinate(6,9))].setSiteBolck();
		map[coord2Index(new Coordinate(2,11))].setSiteBolck();
		map[coord2Index(new Coordinate(3,15))].setSiteBolck();
		map[coord2Index(new Coordinate(13,9))].setSiteBolck();
		map[coord2Index(new Coordinate(3,19))].setSiteBolck();
		map[coord2Index(new Coordinate(13,12))].setSiteBolck();
		map[coord2Index(new Coordinate(10,9))].setSiteBolck();
		map[coord2Index(new Coordinate(11,8))].setSiteBolck();
		map[coord2Index(new Coordinate(11,5))].setSiteBolck();
		openList = new MinHeap(size); 
		closeList = new LinkedList<Coordinate>();

	}

	public void beginAStar(Coordinate src, Coordinate des) {
		this.src = src;
		this.des = des;
		
		map[coord2Index(src)].updateValue(0, 0,src);
		openList.add(map[coord2Index(src)]);
		if(AStarType == 1)
		{
			initSrcEightChild();
		}
		while (true) {
			if (!findNextSite()) {
				break;
			}
		}
		
		drawPath();
		AStarVisualizer.draw(this, size);
	    StdDraw.show();
	}
	private void initSrcEightChild()
	{
		Coordinate t1 =new  Coordinate(src.row - 1,src.col - 1);
		if(isInBound(t1))map[coord2Index(t1)].setParent(src);
		
		Coordinate t2 =new  Coordinate(src.row + 1,src.col - 1);
		if(isInBound(t2))map[coord2Index(t2)].setParent(src);
		
		Coordinate t3 =new  Coordinate(src.row + 1,src.col + 1);
		if(isInBound(t3))map[coord2Index(t3)].setParent(src);
		
		Coordinate t4 =new  Coordinate(src.row - 1,src.col + 1);
		if(isInBound(t4))map[coord2Index(t4)].setParent(src);
		
		Coordinate t5 =new  Coordinate(src.row,src.col - 1);
		if(isInBound(t5))map[coord2Index(t5)].setParent(src);
		
		Coordinate t6 =new  Coordinate(src.row,src.col + 1);
		if(isInBound(t6))map[coord2Index(t6)].setParent(src);
		
		Coordinate t7 =new  Coordinate(src.row + 1,src.col);
		if(isInBound(t7))map[coord2Index(t7)].setParent(src);
		
		Coordinate t8 =new  Coordinate(src.row - 1,src.col);
		if(isInBound(t8))map[coord2Index(t8)].setParent(src);
		
	}
	private void drawPath()
	{
		Coordinate path = des;
		while(true)
		{
			
			path = map[coord2Index(path)].getParent();
			if(path.equals(src)) break;
			map[coord2Index(path)].setType(3);
		}
	}

	private boolean findNextSite() {
		if (openList.isEmpty()) {
			System.out.println("AStar is over~");
			return false;
		} else {
			//Coordinate cur = openList.peek();
			 AStarVisualizer.draw(this, size);
		     StdDraw.show();
			Coordinate cur = findQueueMinF().getPos();
			
			if (cur.equals(des)) {
				System.out.println("to des, is over~");
				return false;
			} else {
				openList.remove();
				closeList.offer(cur);
				if(AStarType == 0)
				{
					checkNeighbor(cur);
				}
				else
				{
					checkNeighborByJPS(cur);
				}
			}
		}
		return true;
	}
	
	private Node findQueueMinF()
	{
		Node result = openList.getMin();
		
		System.out.println("_findQueueMinF_result_"+result.getPos().row+"_"+result.getPos().col+"_"+result.getFValue());
		return result;
	}
	
	public int getNodeType(Coordinate cur)
	{
		return map[coord2Index(cur)].getType();
	}
	
	public void setNodeType(Coordinate cur,int type)
	{
		this.map[coord2Index(cur)].setType(type);
	}
	private void checkNeighbor(Coordinate cur) {
		Coordinate temp = new Coordinate(cur.row - 1,cur.col - 1);
	
		if(temp.row >= 1 && temp.col >= 1 && nextCanArriveSite(temp))
		{
			addOrUpdateNeighbor(cur,new Coordinate(temp.row,temp.col));
		}
		
		temp.changeRowAndCol(cur.row - 1, cur.col);
		if(temp.row >= 1 && nextCanArriveSite(temp))
		{
			addOrUpdateNeighbor(cur,new Coordinate(temp.row,temp.col));
		}
		
		temp.changeRowAndCol(cur.row - 1, cur.col + 1);
		if(temp.row <= size && temp.col <= size && nextCanArriveSite(temp))
		{
			addOrUpdateNeighbor(cur,new Coordinate(temp.row,temp.col));
		}
		
		temp.changeRowAndCol(cur.row, cur.col - 1);
		if(temp.col >= 1 && nextCanArriveSite(temp))
		{
			addOrUpdateNeighbor(cur,new Coordinate(temp.row,temp.col));
		}
		
		temp.changeRowAndCol(cur.row, cur.col + 1);
		if(temp.col <= size && nextCanArriveSite(temp))
		{
			addOrUpdateNeighbor(cur,new Coordinate(temp.row,temp.col));
		}
		
		temp.changeRowAndCol(cur.row + 1, cur.col - 1);
		if(temp.row <= size && temp.col >= 1 && nextCanArriveSite(temp))
		{
			addOrUpdateNeighbor(cur,new Coordinate(temp.row,temp.col));
		}
		
		temp.changeRowAndCol(cur.row + 1, cur.col);
		if(temp.row <= size && nextCanArriveSite(temp))
		{
			addOrUpdateNeighbor(cur,new Coordinate(temp.row,temp.col));
		}
		
		temp.changeRowAndCol(cur.row + 1, cur.col + 1);
		if(temp.row <= size && temp.col <= size && nextCanArriveSite(temp))
		{
			addOrUpdateNeighbor(cur,new Coordinate(temp.row,temp.col));
		}
	}
	
	private void srcJump()
	{
		Coordinate temp = tiltJump(new Coordinate(src.row - 1,src.col - 1), src);
		if(temp != null)
		{
			addOrUpdateNeighbor(src,temp);
		}
		
		Coordinate temp1 = tiltJump(new Coordinate(src.row + 1,src.col + 1), src);
		if(temp1 != null)
		{
			addOrUpdateNeighbor(src,temp1);
		}
		
		Coordinate temp2 = tiltJump(new Coordinate(src.row - 1,src.col + 1), src);
		if(temp2 != null)
		{
			addOrUpdateNeighbor(src,temp2);
		}
		
		Coordinate temp3 = tiltJump(new Coordinate(src.row + 1,src.col - 1), src);
		if(temp3 != null)
		{
			addOrUpdateNeighbor(src,temp3);
		}
		
		Coordinate temp4 = lineJump(new Coordinate(src.row,src.col - 1), src);
		if(temp4 != null)
		{
			addOrUpdateNeighbor(src,temp4);
		}
		
		Coordinate temp5 = lineJump(new Coordinate(src.row,src.col + 1), src);
		if(temp5 != null)
		{
			addOrUpdateNeighbor(src,temp5);
		}
		
		Coordinate temp6 = lineJump(new Coordinate(src.row + 1,src.col), src);
		if(temp6 != null)
		{
			addOrUpdateNeighbor(src,temp6);
		}
		
		Coordinate temp7 = lineJump(new Coordinate(src.row - 1,src.col), src);
		if(temp7 != null)
		{
			addOrUpdateNeighbor(src,temp7);
		}
		
	}
	
	private void checkNeighborByJPS(Coordinate cur)
	{
		//TODO JPS
		
		if(cur.equals(src))
		{
			srcJump();
		}
		else
		{
			otherJump(cur);
			//Coordinate jumpSite;
			
			/*
			if(JudgeIsLineJump(cur))
			{
				jumpSite = lineJump(cur,map[coord2Index(cur)].getParent());
			}
			else
			{
				jumpSite = tiltJump(cur,map[coord2Index(cur)].getParent());
			}
			if(jumpSite != null)
			{
				addOrUpdateNeighbor(cur,jumpSite);
				
			}*/
		}
		
		
		
	}
	
	public void otherJump(Coordinate cur)
	{
		if(judgeIsLineJump(cur))
		{
			Coordinate lineNaturePoint = lineJump(nextNeighbor(cur), cur);
			if(lineNaturePoint != null) addOrUpdateNeighbor(cur,lineNaturePoint);
			
			if(cur.row - map[coord2Index(cur)].getParent().row == 0)
			{
				
				Coordinate lineForceTop = tiltJump(isHDesHasTopForceNeighbor(cur), cur);
				if(lineForceTop != null) addOrUpdateNeighbor(cur,lineForceTop);
			
				Coordinate lineForceDown = tiltJump(isHDesHasDownForceNeighbor(cur), cur);
				if(lineForceDown != null) addOrUpdateNeighbor(cur,lineForceDown);
			}
			else
			{
				Coordinate lineForceLeft = tiltJump(isVDesHasLeftForceNeighbor(cur), cur);
				if(lineForceLeft != null) addOrUpdateNeighbor(cur,lineForceLeft);
			
				Coordinate lineForceRight = tiltJump(isVDesHasRightForceNeighbor(cur), cur);
				if(lineForceRight != null) addOrUpdateNeighbor(cur,lineForceRight);
			}
		}
		else
		{
			Coordinate tiltNaturePoint = tiltJump(nextNeighbor(cur), cur);
			if(tiltNaturePoint != null) addOrUpdateNeighbor(cur,tiltNaturePoint);
			
			Coordinate tiltNaturePointV = lineJump(tiltNextVNeighbor(cur), cur);
			if(tiltNaturePointV != null) addOrUpdateNeighbor(cur,tiltNaturePointV);
			
			Coordinate tiltNaturePointH = lineJump(tiltNextHNeighbor(cur), cur);
			if(tiltNaturePointH != null) addOrUpdateNeighbor(cur,tiltNaturePointH);
			
			Coordinate tiltForcePointH = tiltJump(isHTiltForceNeighbor(cur),cur);
			if(tiltForcePointH != null) addOrUpdateNeighbor(cur,tiltForcePointH);
			
			Coordinate tiltForcePointV = tiltJump(isVTiltForceNeighbor(cur),cur);
			if(tiltForcePointV != null) addOrUpdateNeighbor(cur,tiltForcePointV);
		}
	}
	
	public boolean judgeIsLineJump(Coordinate cur)
	{
		if(Math.abs(cur.row - map[coord2Index(cur)].getParent().row) == 0 ||  Math.abs(cur.col - map[coord2Index(cur)].getParent().col) == 0)
		{
			return true;
		}
		return false;
	}
	
	public Coordinate lineJump(Coordinate cur,Coordinate parent)
	{
		if(cur == null) return null;
		
		if(!isInBound(cur) || !map[coord2Index(cur)].isOpen()) return null;
		
		if(cur.equals(des)) return cur;
		
		if(isInBound(cur)) map[coord2Index(cur)].setParent(parent);
		if(isLineExistForceNeighbor(cur)) return cur;
		
		return lineJump(nextNeighbor(cur),cur);
	}
	
	
	private Coordinate nextNeighbor(Coordinate cur)
	{
		Coordinate res = new Coordinate();
		res.row = siteNextRow(cur);
		res.col = siteNextCol(cur);
		
		return res;
	}
	
	private int siteNextRow(Coordinate cur)
	{
		if(cur.row - map[coord2Index(cur)].getParent().row  ==  0)
		{
			return cur.row;
		}
		return cur.row - map[coord2Index(cur)].getParent().row > 0 ? cur.row + 1 : cur.row - 1;
	}
	
	private int siteNextCol(Coordinate cur)
	{
		if(cur.col - map[coord2Index(cur)].getParent().col  ==  0)
		{
			return cur.col;
		}
		return cur.col - map[coord2Index(cur)].getParent().col > 0 ? cur.col + 1 : cur.col - 1;
	}
	
	private boolean isLineExistForceNeighbor(Coordinate cur)
	{
		
		if(map[coord2Index(cur)].getParent().row - cur.row == 0)
		{
		
			if(isHDesHasTopForceNeighbor(cur) != null) return true;
			
			if(isHDesHasDownForceNeighbor(cur) != null) return true;
			
		}
		else
		{
			
			if(isVDesHasLeftForceNeighbor(cur) != null) return true;
		
			if(isVDesHasRightForceNeighbor(cur) != null) return true;
		}
		
		
		return false;
	}
	
	private Coordinate isVDesHasLeftForceNeighbor(Coordinate cur)
	{
		Coordinate left = new Coordinate(cur.row,cur.col - 1);
		Coordinate leftDes = new Coordinate(siteNextRow(cur),left.col);
		if(isInBound(left) && isInBound(leftDes) &&!map[coord2Index(left)].isOpen() && map[coord2Index(leftDes)].isOpen())
		{
			return leftDes;
		}
		
		return null;
	}
	
	private Coordinate isVDesHasRightForceNeighbor(Coordinate cur)
	{
		Coordinate right = new Coordinate(cur.row,cur.col + 1);
		Coordinate rightDes = new Coordinate(siteNextRow(cur),right.col);
		if(isInBound(right) && isInBound(rightDes) && !map[coord2Index(right)].isOpen() && map[coord2Index(rightDes)].isOpen())
		{
			return rightDes;
		}
		return null;
	}
	
	private Coordinate isHDesHasTopForceNeighbor(Coordinate cur)
	{
		Coordinate top = new Coordinate(cur.row - 1,cur.col);
		Coordinate topDes = new Coordinate(top.row,siteNextCol(cur));
		if(isInBound(top) && isInBound(topDes) && !map[coord2Index(top)].isOpen() && map[coord2Index(topDes)].isOpen())
		{
			return topDes;
		}
		return null;
	}
	
	private Coordinate isHDesHasDownForceNeighbor(Coordinate cur)
	{
		Coordinate down = new Coordinate(cur.row + 1,cur.col);
		Coordinate downDes = new Coordinate(down.row,siteNextCol(cur));
		if(isInBound(down) && isInBound(downDes) && !map[coord2Index(down)].isOpen() && map[coord2Index(downDes)].isOpen())
		{
			return downDes;
		}
		return null;
	}
	
	private boolean isInBound(Coordinate cur)
	{
		if(cur.col<1 || cur.col >size || cur.row < 1 || cur.row > size) return false;
		
		return true;
	}
	
	private boolean isTiltExistForceNeighbor(Coordinate cur)
	{
		
		if(isVTiltForceNeighbor(cur) != null) return true;
		
		
		if(isHTiltForceNeighbor(cur) != null) return true;
		
		return false;
	}
	
	private Coordinate isVTiltForceNeighbor(Coordinate cur)
	{
		Coordinate v = new Coordinate( map[coord2Index(cur)].getParent().row,cur.col);
		Coordinate vDes = new Coordinate(v.row,siteNextCol(cur));
		if(isInBound(v) && isInBound(vDes)&&!map[coord2Index(v)].isOpen() && map[coord2Index(vDes)].isOpen())
		{
			return vDes;
		}
		return null;
	}
	
	private Coordinate isHTiltForceNeighbor(Coordinate cur)
	{

		Coordinate h = new Coordinate(cur.row,map[coord2Index(cur)].getParent().col);
		Coordinate hDes = new Coordinate(siteNextRow(cur),h.col);
		
		if(isInBound(h) && isInBound(hDes) && !map[coord2Index(h)].isOpen() && map[coord2Index(hDes)].isOpen())
		{
			return hDes;
		}
		
		return null;
	}
	
	private Coordinate tiltJump(Coordinate cur,Coordinate parent)
	{
		if(cur == null) return null;
		if(!isInBound(cur) || !map[coord2Index(cur)].isOpen()) return null;
		
		if(cur.equals(des)) return cur;
		
		if(isInBound(cur)) map[coord2Index(cur)].setParent(parent);
		if(isTiltExistForceNeighbor(cur)) return cur;
		
		Coordinate HNeighbor = lineJump(tiltNextHNeighbor(cur), cur);
		if (HNeighbor != null) return cur;
		
		Coordinate VNeighbor = lineJump(tiltNextVNeighbor(cur), cur);
		if (VNeighbor != null) return cur;
		
		return tiltJump(nextNeighbor(cur),cur);
	}
	
	private Coordinate tiltNextHNeighbor(Coordinate cur)
	{
		Coordinate res = new Coordinate();
		res.row =cur.row;
		res.col = siteNextCol(cur);
		
		return res;
	}
	
	private Coordinate tiltNextVNeighbor(Coordinate cur)
	{
		Coordinate res = new Coordinate();
		res.row = siteNextRow(cur);
		res.col = cur.col;
		
		return res;
	}
	
	private void addOrUpdateNeighbor(Coordinate parent,Coordinate temp)
	{
		if(openList.contains(temp))
		{
			updateFValue(parent,temp);
		}
		else
		{
			updateFValue(parent,temp);
			
			openList.add(map[coord2Index(temp)]);
			
			
		}
	}
	
	private void updateFValue(Coordinate parent,Coordinate cur)
	{
		//TODO Find G and H ,update F
		int parentG = map[coord2Index(parent)].getGiven();
		
		//int selfG = ((Math.abs(parent.row - cur.row) + Math.abs(parent.col - cur.col)) == 2?14:10);
		int x = (Math.abs(parent.row - cur.row) + Math.abs(parent.col - cur.col)) == 2?14:10;
		int d = Math.abs(parent.row - cur.row) > Math.abs(parent.col - cur.col) ? Math.abs(parent.row - cur.row) :  Math.abs(parent.col - cur.col);
		int selfG = x * d;
		int selfH = Math.abs(des.row - cur.row)*10 + Math.abs(des.col - cur.col)*10;
		
		map[coord2Index(cur)].updateValue(parentG + selfG, selfH,parent);
		//openList.updateValue(cur,parentG + selfG, selfH);
		
	}
	
	private boolean nextCanArriveSite(Coordinate cur)
	{
		if(cur.col<1 || cur.col >size || cur.row < 1 || cur.row > size) return false;
		return !closeList.contains(cur) && map[coord2Index(cur)].isOpen();
	}
	
	public boolean isInCloseList(Coordinate cur)
	{
		return closeList.contains(cur);
	}
	
	public boolean isInOpenList(Coordinate cur)
	{
		return openList.contains(cur);
	}
	
	public boolean isOpen(Coordinate cur)
	{
		//System.out.println("indx_" + coord2Index(cur)+"_" + cur.row + "_"+cur.col);
		return map[coord2Index(cur)].isOpen();
	}

	private int coord2Index(Coordinate site) {
		return (site.row - 1) * size + site.col - 1;
	}
	
	private int coord2Index(int row,int col) {
		return (row - 1) * size + col - 1;
	}
	

	public void setBlock(Coordinate pos) {
		map[(pos.row - 1) * pos.col].setSiteBolck();
	}
}



import edu.princeton.cs.algs4.StdDraw;
import edu.princeton.cs.algs4.StdOut;

public class InteractiveAStarVisualizer {
	private static AStar as;

    public static void main(String[] args) {
        // n-by-n percolation system (read from command-line, default = 10)
        int n = 20;          
        if (args.length == 1) n = Integer.parseInt(args[0]);

        StdDraw.enableDoubleBuffering();
        //Percolation perc = new Percolation(n);
        as = new AStar(n);
        AStarVisualizer.draw(as, n);
        StdDraw.show();
        Coordinate src = new Coordinate();
        Coordinate des = new Coordinate();
        int count = 0;
        
        while(true){

            // detected mouse click
            if (StdDraw.isMousePressed()) {
            	
                // screen coordinates
                double x = StdDraw.mouseX();
                double y = StdDraw.mouseY();

                // convert to row i, column j
                int i = (int) (n - Math.floor(y));
                int j = (int) (1 + Math.floor(x));

                // open site (i, j) provided it's in bounds
                if (i >= 1 && i <= n && j >= 1 && j <= n && count == 0) {
                	System.out.println("src_"+i+"_"+ j);
                    src.changeRowAndCol(i, j);
                    as.setNodeType(src, 1);
                }
                else if(i >= 1 && i <= n && j >= 1 && j <= n && count == 1){
                	des.changeRowAndCol(i, j);
                	System.out.println("des_"+i+"_"+ j);
                	as.setNodeType(des, 2);
                }

                // draw n-by-n percolation system
                AStarVisualizer.draw(as, n);
                
                StdDraw.show();
                count++;
                StdDraw.pause(100);
            }

            if(count == 2)
            {
            	as.beginAStar(src, des);
            	break;
            }

        }

        
    }
}

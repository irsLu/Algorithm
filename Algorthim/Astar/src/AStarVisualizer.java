
import java.awt.Font;

import edu.princeton.cs.algs4.In;
import edu.princeton.cs.algs4.StdDraw;

public class AStarVisualizer {

    // delay in miliseconds (controls animation speed)
    private static final int DELAY = 100;

    // draw n-by-n percolation system
    public static void draw(AStar perc, int n) {
        StdDraw.clear();
        StdDraw.setPenColor(StdDraw.BLACK);
        StdDraw.setXscale(-0.05*n, 1.05*n);
        StdDraw.setYscale(-0.05*n, 1.05*n);   // leave a border to write text
        StdDraw.filledSquare(n/2.0, n/2.0, n/2.0);

        // draw n-by-n grid
       
        for (int row = 1; row <= n; row++) {
            for (int col = 1; col <= n; col++) {
                if (perc.isOpen(new Coordinate(row,col))) {
                    StdDraw.setPenColor(StdDraw.WHITE);
                   
                }
                else
                {
                    StdDraw.setPenColor(StdDraw.BLACK);
                }
                
           
                
                
                if (perc.isInOpenList(new Coordinate(row,col))) {
                    StdDraw.setPenColor(StdDraw.GREEN);
                  
                }
                
                if (perc.isInCloseList(new Coordinate(row,col))) {
                    StdDraw.setPenColor(StdDraw.YELLOW);
                  
                }
                
                if(perc.getNodeType(new Coordinate(row,col))== 1)
                {
                	StdDraw.setPenColor(StdDraw.RED);
                }
                
                if(perc.getNodeType(new Coordinate(row,col))== 2)
                {
                	StdDraw.setPenColor(StdDraw.BLUE);
                }
                
                if(perc.getNodeType(new Coordinate(row,col))== 3)
                {
                	StdDraw.setPenColor(StdDraw.PINK);
                }
                

                StdDraw.filledSquare(col - 0.5, n - row + 0.5, 0.45);
            }
        }

        
       
       

    }

   
}

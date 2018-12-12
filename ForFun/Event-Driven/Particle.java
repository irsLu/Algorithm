/**
 * Created by Administrator on 2017-01-20.
 */
import java.awt.Color;

import edu.princeton.cs.algs4.StdDraw;
import edu.princeton.cs.algs4.StdRandom;

public class Particle {
    private static final double INFINITY = Double.POSITIVE_INFINITY;

    private double rx,ry;           //位置
    private double vx,vy;           //速度
    private int count;              //已碰撞次数
    private final double radius;    //粒子半径
    private final double mass;      //质量
    private final Color color;      //颜色

    public Particle(double rx, double ry, double vx, double vy, double radius, double mass, Color color)
    {
        this.vx = vx;
        this.vy = vy;
        this.rx = rx;
        this.ry = ry;
        this.radius = radius;
        this.mass = mass;
        this.color = color;
    }

    public Particle() {
        rx     = StdRandom.uniform(0.0, 1.0);
        ry     = StdRandom.uniform(0.0, 1.0);
        vx     = StdRandom.uniform(-0.005, 0.005);
        vy     = StdRandom.uniform(-0.005, 0.005);
        radius = 0.01;
        mass   = 0.5;
        color  = Color.BLACK;
    }

    public void drew()
    {
        StdDraw.setPenColor(color);
        StdDraw.filledCircle(rx,ry,radius);
    }

    public void move(double dt)
    {
        rx += vx * dt;
        ry += vy * dt;
    }

    public int count()
    { return count; }

    public double timeToHit(Particle that)
    {
        if (this == that) return  INFINITY;
        double dx = that.rx - this.rx;
        double dy = that.ry - this.ry;
        double dvx = that.vx - this.vx;
        double dvy = that.vy - this.vy;
        double dvdr = dx*dvx + dy*dvy;
        if (dvdr > 0) return INFINITY;
        double dvdv = dvx*dvx + dvy*dvy;
        double drdr = dx*dx + dy*dy;
        double sigma = this.radius + that.radius;
        double d = (dvdr*dvdr) - dvdv * (drdr - sigma*sigma);
        if (d < 0) return INFINITY;
        return -(dvdr + Math.sqrt(d)) / dvdv;
    }

    public double timeToHitVerticalWall()
    {
        if (vx > 0) return (1.0 - rx - radius) / vx;
        else if (vx < 0) return (radius - rx) / vx;
        else return INFINITY;
    }

    public double timeToHitHorizontalWall()
    {
        if (vy > 0) return (1.0 - ry - radius) / vy;
        else if (vy < 0) return (radius - ry) / vy;
        else return INFINITY;
    }



    public void bounceOff(Particle that)
    {
        double dx  = that.rx - this.rx;
        double dy  = that.ry - this.ry;
        double dvx = that.vx - this.vx;
        double dvy = that.vy - this.vy;
        double dvdr = dx*dvx + dy*dvy;
        double dist = this.radius + that.radius;   // 碰撞的两个粒子中心之间的距离

        // 撞击力的度量
        double magnitude = 2 * this.mass * that.mass * dvdr / ((this.mass + that.mass) * dist);

        // 求得x，y方向上的作用力
        double fx = magnitude * dx / dist;
        double fy = magnitude * dy / dist;

        // 由动量守恒定律与牛顿定律推导得到的完全弹性碰撞后速度公式
        this.vx += fx / this.mass;
        this.vy += fy / this.mass;
        that.vx -= fx / that.mass;
        that.vy -= fy / that.mass;

        // update collision counts
        this.count++;
        that.count++;


    }

    public void bounceOffHorizontalWall()
    {
        vy = -vy;
        count++;
    }

    public void bounceOffVerticallWall()
    {
        vx = -vx;
        count++;
    }

    public double kineticEnergy() {
        // 返回粒子的动能
        return 0.5 * mass * (vx*vx + vy*vy);
    }

}
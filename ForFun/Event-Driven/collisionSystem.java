import java.awt.*;

import edu.princeton.cs.algs4.StdDraw;
import edu.princeton.cs.algs4.StdIn;

/**
 * Created by Administrator on 2017-01-20.
 */
public class collisionSystem {

    private class Event implements Comparable<Event> {
        private final double time;
        private final Particle a, b;
        private final int countA, countB;

        public Event(double t, Particle a, Particle b)
        {
            this.time = t;
            this.a = a;
            this.b = b;
            if (a != null) this.countA = a.count(); else countA = -1;
            if (b != null) this.countB = b.count(); else countB = -1;
        }

        public int compareTo(Event that)
        {
            /*
            if      (this.time < that.time) return -1;
            else if (this.time > that.time) return +1;
            else return 0;
            */
            System.out.print("!");
            return Double.compare(this.time, that.time);
        }

        public boolean isValid()
        {
            if (a != null && a.count() != countA) return false;
            if (b != null && b.count() != countB) return false;
            return true;
        }
    }

    private MinPQ<Event> pq;        // 优先队列
    private double t = 0.0;         // 模拟时钟
    private Particle[] particles;   // 粒子数组

    public collisionSystem(Particle[] particles)
    {
        this.particles = particles.clone();
    }

    private void predictCollisions(Particle a, double limit)
    {
        // 预测接下来会发生的时间且将之保存进优先队列中
        if (a == null) return;
        // 预测粒子间碰撞
        for (int i = 0; i < particles.length; i++)
        {
            double dt = a.timeToHit(particles[i]);
            if (t + dt <= limit)
                pq.insert(new Event(t + dt, a, particles[i]));
        }
        // 预测粒子与墙之间的碰撞
        double dtX = a.timeToHitVerticalWall();
        double dtY = a.timeToHitHorizontalWall();
        if (t + dtX <= limit)
            pq.insert(new Event(t + dtX, a, null));
        if (t + dtY <= limit)
            pq.insert(new Event(t + dtY, null, a));
    }

    public void redrew(double limit, double Hz)
    {   //重绘事件，将所有粒子重新画出来
        StdDraw.clear();
        for(int i = 0; i < particles.length; i++) particles[i].drew();
        StdDraw.show();
        StdDraw.pause(20);
        if (t < limit)
            pq.insert(new Event(t + 1.0 / Hz, null, null));

    }

    public void simulate(double limit, double Hz)
    {
        pq = new MinPQ<Event>();
        for (int i = 0; i < particles.length; i++)
            predictCollisions(particles[i], limit);
        pq.insert(new Event(0, null, null));    // 添加重绘事件
        while (!pq.isEmpty())
        {   //取出接下来将要发生的事件
            Event event = pq.delMin();
            if (!event.isValid()) continue;
            for (int i = 0; i < particles.length; i++)
                particles[i].move(event.time - t);  // 更新粒子的位置
            t = event.time;                         // 和时间

            //处理事件
            Particle a = event.a, b = event.b;
            if      (a != null && b != null) a.bounceOff(b);
            else if (a != null && b == null) a.bounceOffVerticallWall();
            else if (a == null && b != null) b.bounceOffHorizontalWall();
            else if (a == null && b == null) redrew(limit, Hz);

            //更新事件处理完后的预测事件队列
            predictCollisions(a, limit);
            predictCollisions(b, limit);
        }
    }

    public static void main(String[] args)
    {
        StdDraw.setCanvasSize(800,800);
        StdDraw.enableDoubleBuffering();
        Particle[] particles;

        if (args.length == 1) {
            int n = Integer.parseInt(args[0]);
            particles = new Particle[n];
            for (int i = 0; i < n; i++)
                particles[i] = new Particle();
        }

        else {
            int n = StdIn.readInt();
            particles = new Particle[n];
            for (int i = 0; i < n; i++)
            {
                double rx     = StdIn.readDouble();
                double ry     = StdIn.readDouble();
                double vx     = StdIn.readDouble();
                double vy     = StdIn.readDouble();
                double radius = StdIn.readDouble();
                double mass   = StdIn.readDouble();
                int r         = StdIn.readInt();
                int g         = StdIn.readInt();
                int b         = StdIn.readInt();
                Color color   = new Color(r, g, b);
                particles[i] = new Particle(rx, ry, vx, vy, radius, mass, color);

            }
        }
        collisionSystem system = new collisionSystem(particles);
        system.simulate(1000000, 0.5);
    }

}
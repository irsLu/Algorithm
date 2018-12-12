public class SleepSort implements Runnable{

    private int number;

    public SleepSort(int number)
    {
        this.number = number;
    }

    public static void main(String[] args)
    {
        int[] numbers = new int[]{334,100000000,580,666,100000002};
        for(int number : numbers)
        {
            new Thread(new SleepSort(number)).start();
        }
    }

    @Override
    public void run()
    {
        try{
            Thread.sleep(this.number);
            System.out.println(this.number);
        }
        catch(InterruptedException e){
            e.printStackTrace();
        }
    }
}

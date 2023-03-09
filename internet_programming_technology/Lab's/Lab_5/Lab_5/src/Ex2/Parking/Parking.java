package Ex2.Parking;

import java.util.Timer;
import java.util.TimerTask;
import java.util.concurrent.Semaphore;

public class Parking extends Thread{
    public static int countOfFreePlaces_1 = 3;
    public static int countOfFreePlaces_2 = 4;
    Semaphore sem;
    public int idCar;

    public Parking(Semaphore sem, int id)
    {
        this.sem = sem;
        this.idCar = id;
    }

    public void run(){
        try {
            sem.acquire();

            Timer t = new Timer();
            Timer t2 = new Timer();
            t.scheduleAtFixedRate(
                    new TimerTask()
                    {
                        public void run()
                        {
                            System.out.println("С парковки номер один уехал автомобиль");
                            countOfFreePlaces_1++;
                            t.cancel();
                        }
                    },
                    2000,      // run first occurrence immediatetly
                    3000); // run every two seconds

            t2.scheduleAtFixedRate(
                    new TimerTask()
                    {
                        public void run()
                        {
                            System.out.println("С парковки номер два уехал автомобиль");
                            countOfFreePlaces_2++;
                            t2.cancel();
                        }
                    },
                    1700,      // run first occurrence immediatetly
                    3300); // run every two seconds

            if (countOfFreePlaces_1 > 0)
            {
                System.out.println("Машина " + idCar + " заехала на парковку один");
                countOfFreePlaces_1--;
                sleep(500);
            }
            else if (countOfFreePlaces_2 > 0) {
                System.out.println("Машина " + idCar + " заехала на парковку два");
                countOfFreePlaces_2--;
                sleep(500);
            }
            if (countOfFreePlaces_1 <= 0 && countOfFreePlaces_2 <=0)
            {
                System.out.println("К сожалению, все парковочные места заняты");
            }
            sem.release();
        }
        catch(InterruptedException e)
        {
            System.out.println ("Что-то пошло не так");
        }
    }
}

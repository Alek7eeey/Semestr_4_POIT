import Ex2.Parking.Parking;

import java.util.concurrent.Semaphore;

import static java.lang.Thread.sleep;

public class main {
    public static void main(String[] args) {

        //----------ex_1-----------
        /*Operator operator1 = new Operator(1);
        Operator operator2 = new Operator(2);
        Operator operator3 = new Operator(3);

        Operator[] arrOfOperator = {operator1, operator2, operator3};
        Semaphore sem = new Semaphore(3);
        for (int i = 1; i<=10; i++)
        {
            new CallCenter(sem, i, arrOfOperator).start();
        }*/

        //------------------------
        //----------ex_2-----------
        //Car[] arrayOfCar = {new Car(1), new Car(2), new Car(3),new Car(4), new Car(5), new Car(6)};
        Semaphore sem = new Semaphore(1);
        for (int i = 0; i<8; i++)
        {
            new Parking(sem, i).start();
        }
    }
}

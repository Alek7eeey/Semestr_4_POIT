package Ex1.CallCentre;
import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;
import java.util.Queue;
import java.util.concurrent.Semaphore;

public class CallCenter extends Thread{
    Semaphore sem;
    int clientID;
    static ArrayList<Operator> op = new ArrayList<>();

    public CallCenter(Semaphore sem, int idOfclient, Operator[] operators)
     {
         this.sem = sem;
         this.clientID = idOfclient;
         for(int i = 0; i<operators.length; i++)
         {
             op.add(operators[i]);
         }
     }

     public void run()
    {
        Operator operator = null;
         try {
                /* for (int i = 0; i < op.size(); i++)
                 {
                     sem.acquire();
                     if (op.get(i).isReady) {
                         op.get(i).isFree(false);
                         System.out.println("Оператор " + op.get(i).id + " обслуживает клиента " + clientID);
                         sleep(500);
                         System.out.println("Оператор " + op.get(i).id + " завершил обслуживать клиента " + clientID);
                         op.get(i).isFree(true);
                         sleep(600);
                     }
                     sem.release();
                 }*/
             sem.acquire();
             if (!op.isEmpty()) {
                 operator = op.get(0);
                 op.remove(0);
                 operator.isFree(false);
                 System.out.println("Оператор " + operator.id + " обслуживает клиента " + clientID);
                 sleep(500);
                 System.out.println("Оператор " + operator.id + " завершил обслуживать клиента " + clientID);
                 operator.isFree(true);
                 sleep(600);
                 op.add(operator);
             }
             sem.release();
         }
         catch(InterruptedException e)
         {
             System.out.println ("Что-то пошло не так");
         }


     }
}
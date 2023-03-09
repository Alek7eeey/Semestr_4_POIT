package Ex1.CallCentre;

public class Operator {
    public int id;
    public boolean isReady = true;
    public void isFree(boolean a)
    {
        this.isReady = a;
    }
    public int GetID()
    {
        return this.id;
    }
    public Operator(int id) {
        this.id = id;
    }
}
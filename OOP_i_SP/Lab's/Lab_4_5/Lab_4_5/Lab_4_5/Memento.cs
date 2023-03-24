using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_5
{
    public class Memento
    {
        public static Stack<Souvenirs> BeforeStepStack = new Stack<Souvenirs>();
        public static Stack<Souvenirs> AfterStepStack = new Stack<Souvenirs>();
        private PullOfMethods pull = new PullOfMethods();
        public Memento() { }

        public void redo() //переделать, вернуть
        {
            if (AfterStepStack.Count>0)
            {
                Souvenirs newSouv = AfterStepStack.Pop();
                if (DataBase.souvenirsList.Contains(newSouv))
                {
                    DataBase.RemoveSouvenir(newSouv);
                }
                else
                {
                    DataBase.AddToDataBase(newSouv);
                }
                pull.AddDefaultProducts();
                BeforeStepStack.Push(newSouv);
            }
        }

        public void undo() //отменить
        {
            if (BeforeStepStack.Count > 0)
            {
                Souvenirs newSouv = BeforeStepStack.Pop();

                if (DataBase.souvenirsList.Contains(newSouv))
                {
                    DataBase.RemoveSouvenir(newSouv);
                }
                else
                {
                    DataBase.AddToDataBase(newSouv);
                }

                pull.AddDefaultProducts();
                AfterStepStack.Push(newSouv);
            }
        }
    }
}

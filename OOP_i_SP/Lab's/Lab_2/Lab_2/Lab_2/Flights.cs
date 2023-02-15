using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    public class Flights
    {
        public long ?ID = 0;
        public model model_ = model.none;
        public enum model{
            Boeing,
            Airbus,
            Embraer,
            CRJ,
            none
        }
        public int countOfSeat = 0;
        public string yearOfIssue = "";
        public int carrying = 0;
        public string DateOfService = "";
        public typeOfPlane typePlane = typeOfPlane.none;
        public enum typeOfPlane
        {
            Пассажирский,
            Грузовой,
            Военный,
            none
        }
        CrewMember cm;

        public static List<Flights> flights = new List<Flights>();

        public Flights(int id, model modEL, int countSeat, string yearOfIss, int carry, string dateServ, typeOfPlane top, string name, int age, int yearEx, string po) { 
        
            ID = id;
            model_= modEL;
            countOfSeat = countSeat;
            yearOfIssue = yearOfIss;
            carrying = carry;
            DateOfService = dateServ;
            typePlane = top;
            cm = new (name, age, yearEx, po);
        }
        public Flights()
        { }
        public override string ToString()
        {
            string text = "Информация про рейс: "+ Environment.NewLine +
                $"ID: {ID}"+ Environment.NewLine + $"Модель: {model_}" + Environment.NewLine +
                $"Количество посадочных мест: {countOfSeat}" + Environment.NewLine +
                $"Год выпуска: {yearOfIssue}" + Environment.NewLine +
                $"Грузоподъёмность: {carrying}" + Environment.NewLine +
                $"Дата тех.обслуживания: {DateOfService}" + Environment.NewLine +
                $"Тип самолёта: {typePlane}";

            return text;
        }
    }
}

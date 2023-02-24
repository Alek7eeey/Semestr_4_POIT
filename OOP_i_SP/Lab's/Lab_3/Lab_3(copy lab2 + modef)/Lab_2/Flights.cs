using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IDAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null && value is long ID)
            {
                if(Convert.ToString(ID).Length <= 5)
                return true;
            }

            return false;
        }
    }

    public class Flights
    {
        [ID(ErrorMessage = "ID должен быть не более 5 символов")]
        public long? ID { set; get; } = 0;

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
        public List<CrewMember> crewMe = new List<CrewMember>();
        public enum typeOfPlane
        {
            Пассажирский,
            Грузовой,
            Военный,
            none
        }

        public Flights(int id, model modEL, int countSeat, string yearOfIss, int carry, string dateServ, typeOfPlane top) { 
        
            ID = id;
            model_= modEL;
            countOfSeat = countSeat;
            yearOfIssue = yearOfIss;
            carrying = carry;
            DateOfService = dateServ;
            typePlane = top;
        }
        public Flights()
        { }

        public void returnToTheDefaultValue()
        {
            ID = 0;
            model_ = model.none;
            countOfSeat = 0;
            yearOfIssue = "";
            carrying = 0;
            DateOfService = "";
            typePlane = typeOfPlane.none;

        }
        public override string ToString()
        {
            string text = "Информация про рейс: "+ Environment.NewLine +
                $"ID: {ID}"+ Environment.NewLine + $"Модель: {model_}" + Environment.NewLine +
                $"Количество посадочных мест: {countOfSeat}" + Environment.NewLine +
                $"Год выпуска: {yearOfIssue}" + Environment.NewLine +
                $"Грузоподъёмность: {carrying}" + Environment.NewLine +
                $"Дата тех.обслуживания: {DateOfService}" + Environment.NewLine +
                $"Тип самолёта: {typePlane}" + Environment.NewLine + Environment.NewLine + "Информация про членов экипажа: ";
            bool isTrue = false;
            foreach(var a in crewMe)
            {
                text+= a.ToString();
                isTrue=true;
            }

            if(!isTrue)
            {
                text += "Отсутствуют" + Environment.NewLine + Environment.NewLine;
            }
            else
            {
                text+= Environment.NewLine + Environment.NewLine;
            }
            


            return text;
        }
    }
}

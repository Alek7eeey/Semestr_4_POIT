using Lab_8.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Lab_8
{
    public class Plane
    {
        public int id { get; set; }
        public string? type { get; set; }
        public string? model { get; set; }

        public int countSeat { get; set; }

        public int yearOfIssue { get; set; }

        public int capacityLoad { get; set; }

        public DateOnly dateOfTo { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public BitmapImage image { get; set; }

        public List<CrewMembers> crewers { get; set; } = new List<CrewMembers>();

        public Plane(int id, string? type, string? model, int countSeat, int yearOfIssue, int capacityLoad, DateOnly dateOfTo, BitmapImage img)
        {
            this.id = id;
            this.type = type;
            this.model = model;
            this.countSeat = countSeat;
            this.yearOfIssue = yearOfIssue;
            this.capacityLoad = capacityLoad;
            this.dateOfTo = dateOfTo;
            this.image = img;
        }

        public Plane() { }

        public void addPersonal(CrewMembers cm)
        {
            crewers.Add(cm);
        }

        public void addPersonal(List<CrewMembers> cm)
        {
            foreach (var a in cm)
            {
                crewers.Add(a);
            }
        }

        public void removePersonal(CrewMembers cm) 
        { 
            crewers.Remove(cm);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ID: {id}");
            sb.AppendLine($"Type: {type}");
            sb.AppendLine($"Model: {model}");
            sb.AppendLine($"Count of seats: {countSeat}");
            sb.AppendLine($"Year of issue: {yearOfIssue}");
            sb.AppendLine($"Capacity load: {capacityLoad}");
            sb.AppendLine($"Date of TO: {dateOfTo.ToString("dd-MM-yyyy")}");
            sb.AppendLine("Crew Members:");

            foreach (var cm in crewers)
            {
                sb.AppendLine($"\t{cm.ToString()}");
            }

            return sb.ToString();
        }
    }
}

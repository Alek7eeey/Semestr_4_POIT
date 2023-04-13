using Lab_11.Command;
using Lab_11.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace Lab_11.ViewModel
{
    class ConsultationViewModel : ViewModelBase
    {
        public Consultation consultation;
        public ConsultationViewModel(Consultation consultation)
        {
            this.consultation = consultation;
        }

        #region Fileds
        public string Name
        {
            get { return consultation.Name; }
            set
            {
                consultation.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Subject
        {
            get { return consultation.Subject; }
            set
            {
                consultation.Subject = value;
                OnPropertyChanged("Subject");
            }
        }

        public string Time
        {
            get { return consultation.time; }
            set
            {
                consultation.time = value;
                OnPropertyChanged("Time");
            }
        }

        public DateOnly Date
        {
            get { return consultation.date; }
            set
            {
                consultation.date = value;
                OnPropertyChanged("Date");
            }
        }

        public bool IsFree
        {
            get { return consultation.isFree; }
            set
            {
                consultation.isFree = value;
                OnPropertyChanged("IsFree");
            }
        }

        private Brush _textColor = Brushes.Black;

        public Brush TextColor
        {
            get { return _textColor; }
            set
            {
                _textColor = value;
                OnPropertyChanged(nameof(TextColor));
            }
        }

        #endregion
        #region command

        public ICommand Booking
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    this.consultation.isFree = false;
                    TextColor = Brushes.Red;
                    IsFree = false;
                }, (obj)=> this.consultation.isFree);
            }
        }

        public ICommand UnBooking
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    this.consultation.isFree = true;
                    TextColor = Brushes.Black;
                    IsFree = true;
                }, (obj)=>!this.consultation.isFree);
            }
        }

        #endregion
    }
}

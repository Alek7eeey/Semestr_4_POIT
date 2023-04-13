using Lab_11.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_11.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        public ObservableCollection<ConsultationViewModel> ConsultationsList { get; set; }

        public MainViewModel(List<Consultation> consultation)
        {
            ConsultationsList = new ObservableCollection<ConsultationViewModel>(consultation.Select(b => new ConsultationViewModel(b)));
        }
    }
}

using AutoMapper;
using Less1_hw.BLL.DTO;
using Less1_hw.BLL.Services;
using Less1_hw.DAL.Repositories;
using Less1_hw.Extensions;
using Less1_hw.Mapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less1_hw.ViewModels
{
    public class MainWindowViewModel:INotifyPropertyChanged
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        IMapper mapper = ModelMapper.Instanse.Mapper;
        ServiceManager serviceManager;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public ObservableCollection<WorkerDTO> Workers { get; set; } = new ObservableCollection<WorkerDTO>();
        public MainWindowViewModel()
        {
            serviceManager = new ServiceManager(unitOfWork, mapper);
            Workers.AddRange(serviceManager.WorkerService.GetAll());
        }
    }
}

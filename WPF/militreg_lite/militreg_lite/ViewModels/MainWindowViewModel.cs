using AutoMapper;
using militreg_lite.BLL.DTO;
using militreg_lite.BLL.Services.Services;
using militreg_lite.DAL.Entities;
using militreg_lite.DAL.UoW;
using militreg_lite.Extensions;
using militreg_lite.Mapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.ViewModels
{
    public class MainWindowViewModel
    {
        ServiceManager serviceManager;
        IMapper mapper = ModelMapper.Instanse.Mapper;
        UnitOfWork unitOfWork = new UnitOfWork();

        public ObservableCollection<GenderDTO> Genders { get; set; } = new ObservableCollection<GenderDTO>();
        public ObservableCollection<MilitaristDTO> Militarists { get; set; } = new ObservableCollection<MilitaristDTO>();
        public ObservableCollection<PidrozdilDTO> Pidrozdils { get; set; } = new ObservableCollection<PidrozdilDTO>();
        public ObservableCollection<PosadaDTO> Posadas { get; set; } = new ObservableCollection<PosadaDTO>();
        public ObservableCollection<PrizivTypeDTO> PrizivTypes { get; set; } = new ObservableCollection<PrizivTypeDTO>();
        public ObservableCollection<RtckDTO> Rtcks { get; set; } = new ObservableCollection<RtckDTO>();
        public ObservableCollection<UbdDTO> Ubds { get; set; } = new ObservableCollection<UbdDTO>();
        public ObservableCollection<UserDTO> Users { get; set; } = new ObservableCollection<UserDTO>();
        public ObservableCollection<VosDTO> Voss { get; set; } = new ObservableCollection<VosDTO>();
        public ObservableCollection<ZvanDTO> Zvans { get; set; } = new ObservableCollection<ZvanDTO>();

        public MainWindowViewModel()
        {
            serviceManager = new ServiceManager(unitOfWork, mapper);
            Genders.AddRange(serviceManager.GenderService.GetAll());
            Militarists.AddRange(serviceManager.MilitaristService.GetAll());
            Militarists.CollectionChanged += Militarists_CollectionChanged;
            Pidrozdils.AddRange(serviceManager.PidrozdilService.GetAll());
            Posadas.AddRange(serviceManager.PosadaService.GetAll());
            PrizivTypes.AddRange(serviceManager.PrizivTypeService.GetAll());
            Rtcks.AddRange(serviceManager.RtckService.GetAll());
            Ubds.AddRange(serviceManager.UbdService.GetAll());
            Users.AddRange(serviceManager.UserService.GetAll());
            Users.CollectionChanged += Users_CollectionChanged;
            Voss.AddRange(serviceManager.VosService.GetAll());
            Zvans.AddRange(serviceManager.ZvanService.GetAll());
        }

        private void Users_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (INotifyPropertyChanged added in e.NewItems)
                {
                    added.PropertyChanged += SpringDataOnPropertyChanged;
                    serviceManager.UserService.Add(added as UserDTO);
                }
            }

            if (e.OldItems != null)
            {
                foreach (INotifyPropertyChanged removed in e.OldItems)
                {
                    removed.PropertyChanged -= SpringDataOnPropertyChanged;
                    serviceManager.UserService.Remove((removed as UserDTO).Id);
                }
            }
        }

        private void Militarists_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (INotifyPropertyChanged added in e.NewItems)
                {
                    added.PropertyChanged += SpringDataOnPropertyChanged;
                    serviceManager.MilitaristService.Add(added as MilitaristDTO);
                }
            }

            if (e.OldItems != null)
            {
                foreach (INotifyPropertyChanged removed in e.OldItems)
                {
                    removed.PropertyChanged -= SpringDataOnPropertyChanged;
                    serviceManager.MilitaristService.Remove((removed as MilitaristDTO).Id);
                }
            }
;
        }

        private void SpringDataOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            unitOfWork.Save();
        }
    }
}

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
            Pidrozdils.CollectionChanged += Pidrozdils_CollectionChanged;
            Posadas.AddRange(serviceManager.PosadaService.GetAll());
            Posadas.CollectionChanged += Posadas_CollectionChanged;
            PrizivTypes.AddRange(serviceManager.PrizivTypeService.GetAll());
            PrizivTypes.CollectionChanged += PrizivTypes_CollectionChanged;
            Rtcks.AddRange(serviceManager.RtckService.GetAll());
            Rtcks.CollectionChanged += Rtcks_CollectionChanged;
            Ubds.AddRange(serviceManager.UbdService.GetAll());
            Ubds.CollectionChanged += Ubds_CollectionChanged;
            Users.AddRange(serviceManager.UserService.GetAll());
            Users.CollectionChanged += Users_CollectionChanged;
            Voss.AddRange(serviceManager.VosService.GetAll());
            Voss.CollectionChanged += Voss_CollectionChanged;
            Zvans.AddRange(serviceManager.ZvanService.GetAll());
            Zvans.CollectionChanged += Zvans_CollectionChanged;
        }

        private void Zvans_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                foreach (INotifyPropertyChanged added in e.NewItems)
                {
                    serviceManager.ZvanService.Update(added as ZvanDTO);
                }
                return;
            }
            if (e.NewItems != null)
            {
                foreach (INotifyPropertyChanged added in e.NewItems)
                {
                    added.PropertyChanged += SpringDataOnPropertyChanged;
                    serviceManager.ZvanService.Add(added as ZvanDTO);
                }
            }

            if (e.OldItems != null)
            {
                foreach (INotifyPropertyChanged removed in e.OldItems)
                {
                    removed.PropertyChanged -= SpringDataOnPropertyChanged;
                    serviceManager.ZvanService.Remove((removed as ZvanDTO).Id);
                }
            }
        }

        private void Voss_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                foreach (INotifyPropertyChanged added in e.NewItems)
                {
                    serviceManager.VosService.Update(added as VosDTO);
                }
                return;
            }
            if (e.NewItems != null)
            {
                foreach (INotifyPropertyChanged added in e.NewItems)
                {
                    added.PropertyChanged += SpringDataOnPropertyChanged;
                    serviceManager.VosService.Add(added as VosDTO);
                }
            }

            if (e.OldItems != null)
            {
                foreach (INotifyPropertyChanged removed in e.OldItems)
                {
                    removed.PropertyChanged -= SpringDataOnPropertyChanged;
                    serviceManager.VosService.Remove((removed as VosDTO).Id);
                }
            }
        }

        private void Ubds_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                foreach (INotifyPropertyChanged added in e.NewItems)
                {
                    serviceManager.UbdService.Update(added as UbdDTO);
                }
                return;
            }
            if (e.NewItems != null)
            {
                foreach (INotifyPropertyChanged added in e.NewItems)
                {
                    added.PropertyChanged += SpringDataOnPropertyChanged;
                    serviceManager.UbdService.Add(added as UbdDTO);
                }
            }

            if (e.OldItems != null)
            {
                foreach (INotifyPropertyChanged removed in e.OldItems)
                {
                    removed.PropertyChanged -= SpringDataOnPropertyChanged;
                    serviceManager.UbdService.Remove((removed as UbdDTO).Id);
                }
            }
        }

        private void Rtcks_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                foreach (INotifyPropertyChanged added in e.NewItems)
                {
                    serviceManager.PrizivTypeService.Update(added as PrizivTypeDTO);
                }
                return;
            }
            if (e.NewItems != null)
            {
                foreach (INotifyPropertyChanged added in e.NewItems)
                {
                    added.PropertyChanged += SpringDataOnPropertyChanged;
                    serviceManager.PrizivTypeService.Add(added as PrizivTypeDTO);
                }
            }

            if (e.OldItems != null)
            {
                foreach (INotifyPropertyChanged removed in e.OldItems)
                {
                    removed.PropertyChanged -= SpringDataOnPropertyChanged;
                    serviceManager.PrizivTypeService.Remove((removed as PrizivTypeDTO).Id);
                }
            }
        }

        private void PrizivTypes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                foreach (INotifyPropertyChanged added in e.NewItems)
                {
                    serviceManager.PrizivTypeService.Update(added as PrizivTypeDTO);
                }
                return;
            }
            if (e.NewItems != null)
            {
                foreach (INotifyPropertyChanged added in e.NewItems)
                {
                    added.PropertyChanged += SpringDataOnPropertyChanged;
                    serviceManager.PrizivTypeService.Add(added as PrizivTypeDTO);
                }
            }

            if (e.OldItems != null)
            {
                foreach (INotifyPropertyChanged removed in e.OldItems)
                {
                    removed.PropertyChanged -= SpringDataOnPropertyChanged;
                    serviceManager.PrizivTypeService.Remove((removed as PrizivTypeDTO).Id);
                }
            }
        }

        private void Posadas_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                foreach (INotifyPropertyChanged added in e.NewItems)
                {
                    serviceManager.PosadaService.Update(added as PosadaDTO);
                }
                return;
            }
            if (e.NewItems != null)
            {
                foreach (INotifyPropertyChanged added in e.NewItems)
                {
                    added.PropertyChanged += SpringDataOnPropertyChanged;
                    serviceManager.PosadaService.Add(added as PosadaDTO);
                }
            }

            if (e.OldItems != null)
            {
                foreach (INotifyPropertyChanged removed in e.OldItems)
                {
                    removed.PropertyChanged -= SpringDataOnPropertyChanged;
                    serviceManager.PosadaService.Remove((removed as PosadaDTO).Id);
                }
            }
        }

        private void Pidrozdils_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                foreach (INotifyPropertyChanged added in e.NewItems)
                {
                    serviceManager.PidrozdilService.Update(added as PidrozdilDTO);
                }
                return;
            }
            if (e.NewItems != null)
            {
                foreach (INotifyPropertyChanged added in e.NewItems)
                {
                    added.PropertyChanged += SpringDataOnPropertyChanged;
                    serviceManager.PidrozdilService.Add(added as PidrozdilDTO);
                }
            }

            if (e.OldItems != null)
            {
                foreach (INotifyPropertyChanged removed in e.OldItems)
                {
                    removed.PropertyChanged -= SpringDataOnPropertyChanged;
                    serviceManager.PidrozdilService.Remove((removed as PidrozdilDTO).Id);
                }
            }
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

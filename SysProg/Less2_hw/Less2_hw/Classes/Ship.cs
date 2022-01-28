using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Less2_hw.Classes
{
    public class Ship : INotifyPropertyChanged
    {

        string[] types = { "bread", "banan", "dress" };
        int[] capasityes = { 10, 50, 100 };
        Task task;
        int current;

        public string Type { get; set; }
        public int Capasity { get; set; }
        public int Current
        {
            get
            {
                return current;
            }
            set
            {
                current = value;
                OnPropertyChanged(nameof(Current));
            }
        }
        public int? Id => task.Id;

        public event Action<Ship> CreateShip;
        public event Action<Ship> MoveToTunel;
        public event Action<Ship> MoveToBreadPier;
        public event Action<Ship> MoveToBananPier;
        public event Action<Ship> MoveToDressPier;
        public event Action<Ship> FinishedShipOnBreadPier;
        public event Action<Ship> FinishedShipOnBananPier;
        public event Action<Ship> FinishedShipOnDressPier;

        static Random random = new Random();
        static Mutex mutex_bread = new Mutex();
        static Mutex mutex_banan = new Mutex();
        static Mutex mutex_dress = new Mutex();
        static Semaphore semafor = new Semaphore(5,5);
       
        public Ship()
        {
            Type = types[random.Next(types.Length)];
            Capasity = capasityes[random.Next(capasityes.Length)];
            task = new Task(() =>
            {
                CreateShip?.Invoke(this);
                semafor.WaitOne();
                MoveToTunel(this);
                switch (Type)
                {
                    case "bread":
                        mutex_bread.WaitOne();
                        semafor.Release();
                        MoveToBreadPier(this);
                        FillShip();
                        FinishedShipOnBreadPier(this);
                        mutex_bread.ReleaseMutex();
                        break;
                    case "banan":
                        mutex_banan.WaitOne();
                        semafor.Release();
                        MoveToBananPier(this);
                        FillShip();
                        FinishedShipOnBananPier(this);
                        mutex_banan.ReleaseMutex();
                        break;
                    case "dress":
                        mutex_dress.WaitOne();
                        semafor.Release();
                        MoveToDressPier(this);
                        FillShip();
                        FinishedShipOnDressPier(this);
                        mutex_dress.ReleaseMutex();
                        break;
                }
            });
            
        }

        private void FillShip()
        {
            for(var i=1; i<=Capasity; i++)
            {
                Current = i;
                Thread.Sleep(100);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public void Start()
        {
            task.Start();
        }
    }
}

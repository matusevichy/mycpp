using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Less2_hw.Classes
{
    public class Sea
    {
        public ObservableCollection<Ship> Ships { get; set; } = new ObservableCollection<Ship>();
        public ObservableCollection<Ship> ShipsInTunnel { get; set; } = new ObservableCollection<Ship>();
        public ObservableCollection<Ship> ShipsInBananPier { get; set; } = new ObservableCollection<Ship>();
        public ObservableCollection<Ship> ShipsInBreadPier { get; set; } = new ObservableCollection<Ship>();
        public ObservableCollection<Ship> ShipsInDressPier { get; set; } = new ObservableCollection<Ship>();
        public void AddShip(Ship ship)
        {
            ship.CreateShip += Ship_CreateShip;
            ship.MoveToTunel += Ship_MoveToTunel;
            ship.MoveToBananPier += Ship_MoveToBananPier;
            ship.MoveToBreadPier += Ship_MoveToBreadPier;
            ship.MoveToDressPier += Ship_MoveToDressPier;
            ship.FinishedShipOnBananPier += Ship_FinishedShipOnBananPier;
            ship.FinishedShipOnBreadPier += Ship_FinishedShipOnBreadPier;
            ship.FinishedShipOnDressPier += Ship_FinishedShipOnDressPier;
        }

        private void Ship_FinishedShipOnDressPier(Ship obj)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() => ShipsInDressPier.Remove(obj)), null);
        }

        private void Ship_FinishedShipOnBreadPier(Ship obj)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() => ShipsInBreadPier.Remove(obj)), null);
        }

        private void Ship_FinishedShipOnBananPier(Ship obj)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() => ShipsInBananPier.Remove(obj)), null);
        }

        private void Ship_MoveToDressPier(Ship obj)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() => ShipsInDressPier.Add(obj)), null);
            Application.Current.Dispatcher.BeginInvoke(new Action(() => ShipsInTunnel.Remove(obj)), null);
        }

        private void Ship_MoveToBreadPier(Ship obj)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() => ShipsInBreadPier.Add(obj)), null);
            Application.Current.Dispatcher.BeginInvoke(new Action(() => ShipsInTunnel.Remove(obj)), null);
        }

        private void Ship_MoveToBananPier(Ship obj)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() => ShipsInBananPier.Add(obj)), null);
            Application.Current.Dispatcher.BeginInvoke(new Action(() => ShipsInTunnel.Remove(obj)), null);
        }

        private void Ship_MoveToTunel(Ship obj)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() => ShipsInTunnel.Add(obj)), null);
            Application.Current.Dispatcher.BeginInvoke(new Action(() => Ships.Remove(obj)), null);
        }

        private void Ship_CreateShip(Ship obj)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() => Ships.Add(obj)), null);
            Console.WriteLine(obj.Id);
        }
    }
}

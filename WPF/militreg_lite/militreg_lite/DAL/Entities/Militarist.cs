using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.DAL.Entities
{
    public class Militarist: BaseEntity<int>

    {
        int posadaId;
        public int PosadaId
        {
            get
            {
                return posadaId;
            }
            set
            {
                posadaId = value;
                OnPropertyChanged(nameof(PosadaId));
            }
        }
        public virtual Posada Posada { get; set; }
        
        double oklad;
        public double Oklad
        {
            get
            {
                return oklad;
            }
            set
            {
                oklad = value;
                OnPropertyChanged(nameof(Oklad));
            }
        }
        
        int vosId;
        public int VosId
        {
            get
            {
                return vosId;
            }
            set
            {
                vosId = value;
                OnPropertyChanged(nameof(VosId));
            }
        }
        public virtual Vos Vos { get; set; }
        
        private int zvanShtatId;
        public int ZvanShtatId
        {
            get { return zvanShtatId; }
            set 
            { 
                zvanShtatId = value;
                OnPropertyChanged(nameof(ZvanShtatId));
            }
        }
        public virtual Zvan ZvanShtat { get; set; }
        
        private int zvanFactId;
        public int ZvanFactId
        {
            get { return zvanFactId; }
            set
            {
                zvanFactId = value;
                OnPropertyChanged(nameof(ZvanFactId));
            }
        }
        public virtual Zvan ZvanFact { get; set; }
        
        string pib;
        public string Pib
        {
            get
            {
                return pib;
            }
            set
            {
                pib = value;
                OnPropertyChanged(nameof(Pib));
            }
        }
        
        private DateTime dateBegin;
        public DateTime DateBegin
        {
            get { return dateBegin; }
            set 
            {
                dateBegin = value;
                OnPropertyChanged(nameof(DateBegin));
            }
        }
        
        private DateTime dateEnd;
        public DateTime DateEnd
        {
            get { return dateEnd; }
            set
            {
                dateEnd = value;
                OnPropertyChanged(nameof(DateEnd));
            }
        }
        
        DateTime birthDay;
        public DateTime BirthDay
        {
            get
            {
                return birthDay;
            }
            set
            {
                birthDay = value;
                OnPropertyChanged(nameof(BirthDay));
            }
        }
        
        int rtckId;
        public int RtckId
        {
            get
            {
                return rtckId;
            }
            set
            {
                rtckId = value;
                OnPropertyChanged(nameof(RtckId));
            }
        }
        public virtual Rtck Rtck { get; set; }
        
        private int genderId;
        public int GenderId
        {
            get { return genderId; }
            set 
            {
                genderId = value;
                OnPropertyChanged(nameof(GenderId));
            }
        }
        public virtual Gender Gender { get; set; }

        private int pidrozdilId;
        public int PidrozdilId
        {
            get { return pidrozdilId; }
            set 
            { 
                pidrozdilId = value;
                OnPropertyChanged(nameof(Pidrozdil));
            }
        }
        public virtual Pidrozdil Pidrozdil { get; set; }

        private int ubdId;
        public int UbdId
        {
            get { return ubdId; }
            set 
            { 
                ubdId = value;
                OnPropertyChanged(nameof(UbdId));
            }
        }
        public virtual Ubd Ubd { get; set; }

        private int prizivTypeId;
        public int PrizivTypeId
        {
            get { return prizivTypeId; }
            set 
            {
                prizivTypeId = value;
                OnPropertyChanged(nameof(prizivTypeId));
            }
        }
        public virtual PrizivType PrizivType { get; set; }

        private string osvita;


        public string Osvita
        {
            get { return osvita; }
            set
            {
                osvita = value;
                OnPropertyChanged(nameof(Osvita));
            }
        }

        public Militarist(Militarist militarist)
        {
            Id = militarist.Id;
            PosadaId=militarist.PosadaId;
            Posada=militarist.Posada;
            Oklad=militarist.Oklad;
            VosId=militarist.VosId;
            Vos=militarist.Vos;
            ZvanShtatId=militarist.ZvanShtatId;
            ZvanShtat=militarist.ZvanShtat;
            ZvanFactId=militarist.ZvanFactId;
            ZvanFact=militarist.ZvanFact;
            Pib=militarist.Pib;
            DateBegin=militarist.DateBegin;
            DateEnd=militarist.DateEnd;
            BirthDay=militarist.BirthDay;
            RtckId=militarist.RtckId;
            GenderId=militarist.GenderId;
            Gender=militarist.Gender;
            PidrozdilId=militarist.PidrozdilId;
            Pidrozdil=militarist.Pidrozdil;
            UbdId=militarist.UbdId;
            Ubd=militarist.Ubd;
            PrizivTypeId=militarist.PrizivTypeId;
            PrizivType=militarist.PrizivType;
            Osvita=militarist.Osvita;
        }

        public Militarist()
        {
        }
    }
}

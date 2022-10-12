using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.BLL.DTO
{
    public class MilitaristDTO:BaseDTO
    {
        int? posadaId;
        public int? PosadaId
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
        private PosadaDTO posada;
        public virtual PosadaDTO Posada 
        {
            get
            {
                return posada;
            }
            set
            {
                posada = value;
                OnPropertyChanged(nameof(Posada));
            }
        }

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

        int? vosId;
        public int? VosId
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
        private VosDTO vos;
        public virtual VosDTO Vos
        {
            get
            {
                return vos;
            }
            set
            {
                vos = value;
                OnPropertyChanged(nameof(Vos));
            }
        }

        private int? zvanShtatId;
        public int? ZvanShtatId
        {
            get { return zvanShtatId; }
            set
            {
                var obj = this;
                zvanShtatId = value;
                OnPropertyChanged(nameof(ZvanShtatId));
            }
        }
        private ZvanDTO zvanShtat;
        public virtual ZvanDTO ZvanShtat 
        {
            get
            {
                return zvanShtat;
            }
            set
            {
                zvanShtat = value;
                OnPropertyChanged(nameof(ZvanShtat));
            }
        }

        private int? zvanFactId;
        public int? ZvanFactId
        {
            get { return zvanFactId; }
            set
            {
                zvanFactId = value;
                OnPropertyChanged(nameof(ZvanFactId));
            }
        }
        private ZvanDTO zvanFact;
        public virtual ZvanDTO ZvanFact
        {
            get
            {
                return zvanFact;
            }
            set
            {
                zvanFact = value;
                OnPropertyChanged(nameof(ZvanFact));
            }
        }

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

        private DateTime dateBegin = DateTime.Now;
        public DateTime DateBegin
        {
            get { return dateBegin; }
            set
            {
                dateBegin = value;
                OnPropertyChanged(nameof(DateBegin));
            }
        }

        private DateTime dateEnd = DateTime.Now;
        public DateTime DateEnd
        {
            get { return dateEnd; }
            set
            {
                dateEnd = value;
                OnPropertyChanged(nameof(DateEnd));
            }
        }

        DateTime birthDay = DateTime.Now;
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
        private RtckDTO rtck;
        public virtual RtckDTO Rtck
        {
            get
            {
                return rtck;
            }
            set
            {
                rtck = value;
                OnPropertyChanged(nameof(Rtck));
            }
        }

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
        private GenderDTO gender;
        public virtual GenderDTO Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }

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
        private PidrozdilDTO pidrozdil;
        public virtual PidrozdilDTO Pidrozdil
        {
            get
            {
                return pidrozdil;
            }
            set
            {
                pidrozdil = value;
                OnPropertyChanged(nameof(Pidrozdil));
            }
        }

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
        private UbdDTO ubd;
        public virtual UbdDTO Ubd
        {
            get
            {
                return ubd;
            }
            set
            {
                ubd = value;
                OnPropertyChanged(nameof(Ubd));
            }
        }
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
        private PrizivTypeDTO prizivType;
        public virtual PrizivTypeDTO PrizivType
        {
            get
            {
                return prizivType;
            }
            set
            {
                prizivType = value;
                OnPropertyChanged(nameof(PrizivType));
            }
        }
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

        public MilitaristDTO(MilitaristDTO militarist)
        {
            Id = militarist.Id;
            PosadaId = militarist.PosadaId;
            Posada = militarist.Posada;
            Oklad = militarist.Oklad;
            VosId = militarist.VosId;
            Vos = militarist.Vos;
            ZvanShtatId = militarist.ZvanShtatId;
            ZvanShtat = militarist.ZvanShtat;
            ZvanFactId = militarist.ZvanFactId;
            ZvanFact = militarist.ZvanFact;
            Pib = militarist.Pib;
            DateBegin = militarist.DateBegin;
            DateEnd = militarist.DateEnd;
            BirthDay = militarist.BirthDay;
            RtckId = militarist.RtckId;
            Rtck = militarist.Rtck;
            GenderId = militarist.GenderId;
            Gender = militarist.Gender;
            PidrozdilId = militarist.PidrozdilId;
            Pidrozdil = militarist.Pidrozdil;
            UbdId = militarist.UbdId;
            Ubd = militarist.Ubd;
            PrizivTypeId = militarist.PrizivTypeId;
            PrizivType = militarist.PrizivType;
            Osvita = militarist.Osvita;
        }

        public MilitaristDTO()
        {
        }
    }
}

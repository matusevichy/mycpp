using AutoMapper;
using militreg_lite.DAL.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.BLL.Services.Services
{
    public class ServiceManager
    {
        Lazy<GenderService> genderService;
        public GenderService GenderService => genderService.Value;
        Lazy<MilitaristService> militaristService;
        public MilitaristService MilitaristService => militaristService.Value;
        Lazy<PidrozdilService> pidrozdilService;
        public PidrozdilService PidrozdilService => pidrozdilService.Value;
        Lazy<PosadaService> posadaService;
        public PosadaService PosadaService => posadaService.Value;
        Lazy<PrizivTypeService> prizivTypeService;
        public PrizivTypeService PrizivTypeService => prizivTypeService.Value;
        Lazy<RtckService> rtckService;
        public RtckService RtckService => rtckService.Value;
        Lazy<UbdService> ubdService;
        public UbdService UbdService => ubdService.Value;
        Lazy<UserService> userService;
        public UserService UserService => userService.Value;
        Lazy<VosService> vosService;
        public VosService VosService => vosService.Value;
        Lazy<ZvanService> zvanService;
        public ZvanService ZvanService => zvanService.Value;

        public ServiceManager(UnitOfWork unitOfWork, IMapper mapper)
        {
            genderService = new Lazy<GenderService>(() => new GenderService(unitOfWork, mapper));
            militaristService = new Lazy<MilitaristService>(() => new MilitaristService(unitOfWork, mapper));
            pidrozdilService = new Lazy<PidrozdilService>(() => new PidrozdilService(unitOfWork, mapper));
            posadaService = new Lazy<PosadaService>(() => new PosadaService(unitOfWork, mapper));
            prizivTypeService = new Lazy<PrizivTypeService>(() => new PrizivTypeService(unitOfWork, mapper));
            rtckService = new Lazy<RtckService>(() => new RtckService(unitOfWork, mapper));
            ubdService = new Lazy<UbdService>(() => new UbdService(unitOfWork, mapper));
            userService = new Lazy<UserService>(() => new UserService(unitOfWork, mapper));
            vosService = new Lazy<VosService>(() => new VosService(unitOfWork, mapper));
            zvanService = new Lazy<ZvanService>(() => new ZvanService(unitOfWork, mapper));
        }
    }
}

using AutoMapper;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using HS.Data.Repositories;
using HS.Wpf.ARO.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Wpf.ARO.ViewModels
{
    [POCOViewModel]
    public class MainViewModel
    {
        private readonly AroUnitOfWork _uow;
        private readonly IMapper _mapper;

        public virtual object ViewModel { get; set; }

        public MainViewModel(IMapper mapper, AroUnitOfWork uow)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void SetViewModelByString(string s)
        {
            if (string.IsNullOrEmpty(s)) throw new ArgumentNullException(nameof(s));

            switch (s)
            {
                case "OperationRoom":
                    ViewModel = ViewModelSource.Create(() => new OperationRoomViewModel(_mapper, _uow)); break;
                default: throw new NotSupportedException($"'{s}' není podporován.");
            };
        }
    }
}

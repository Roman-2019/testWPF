using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVMPhone.ViewModels
{
    public interface IPhone
    {
        void OnPropertyChanged([CallerMemberName]string prop = "");
    }
}

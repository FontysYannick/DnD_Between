using Interface_DnD.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_DnD.Interface
{
    public interface IBackground
    {
        List<BackgroundDTO> Getall();
        List<BackgroundDTO> Getbyfilter(string filter);
    }
}

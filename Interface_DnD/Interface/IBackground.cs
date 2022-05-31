using Interface_DnD.DTO;
using System.Collections.Generic;

namespace Interface_DnD.Interface
{
    public interface IBackground
    {
        List<BackgroundDTO> Getall();
        List<BackgroundDTO> Getbyfilter(string filter);
    }
}

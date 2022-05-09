using Interface_DnD.DTO;
using Interface_DnD.Interface;
using System;
using System.Collections.Generic;

namespace Stub_DnD.Stub
{
    public class RaceStub : IRace
    {
        public List<RaceDTO> RaceList { get; set; }

        public RaceStub()
        {
            this.RaceList = new List<RaceDTO>()
            {
                new RaceDTO{ID = 1, name = "Barb" },
                new RaceDTO{ID = 2, name = "Bard" },
            };
        }

        public List<RaceDTO> Getall()
        {
            return this.RaceList;
        }
    }
}

using Interface_DnD.DTO;
using Interface_DnD.Interface;
using System.Collections.Generic;

namespace Stub_DnD.Stub
{
    public class BackgroundStub : IBackground
    {
        public List<BackgroundDTO> BackgroundList { get; set; }

        public BackgroundStub()
        {
            this.BackgroundList = new List<BackgroundDTO>()
            {
                new BackgroundDTO{ID = 1, Class = "Barb", Name = "Rage", Description = "Barb go brr" },
                new BackgroundDTO{ID = 2, Class = "Bard", Name = "PLay", Description = "Bard go pling you are charmed" },
            };
        }

        public List<BackgroundDTO> Getall()
        {
            return this.BackgroundList;
        }

        public List<BackgroundDTO> Getbyfilter(string filter)
        {
            List<BackgroundDTO> list = new List<BackgroundDTO>();
            for (var i = 0; i < BackgroundList.Count; i++)
            {
                if (BackgroundList[i].Class == filter)
                {
                    list.Add(BackgroundList[i]);
                }
            }

            return list;
        }
    }
}

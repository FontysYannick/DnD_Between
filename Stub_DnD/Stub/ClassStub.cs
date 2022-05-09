using Interface_DnD.DTO;
using Interface_DnD.Interface;
using System;
using System.Collections.Generic;

namespace Stub_DnD.Stub
{
    public class ClassStub : IClass
    {
        public List<ClassDTO> ClassList { get; set; }

        public ClassStub()
        {
            this.ClassList = new List<ClassDTO>()
            {
                new ClassDTO{ID = 1, name = "Barb" },
                new ClassDTO{ID = 2, name = "Bard" },
            };
        }

        public List<ClassDTO> Getall()
        {
            return this.ClassList;
        }
    }
}

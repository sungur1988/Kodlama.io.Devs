﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Dtos
{
    public class ProgrammingLanguageListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<string> TechNames { get; set; }
    }
}

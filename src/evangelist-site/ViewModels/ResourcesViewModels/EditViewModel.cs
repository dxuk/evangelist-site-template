using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using evangelist_site.Models;

namespace evangelist_site.ViewModels.ResourcesViewModels
{
    public class EditViewModel
    {
        public Resource Resource { get; set; }

        public IEnumerable<SelectListItem> ResourceGroups { get; set; }

        public IEnumerable<SelectListItem> Talks { get; set; }
    }
}

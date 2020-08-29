using PersonelMVCUI.Models.EntityFramework;
using System.Collections.Generic;

namespace PersonelMVCUI.ViewModels
{
    public class PersonelFormViewModel
    {

        public IEnumerable<Departman> Departmanlar { get; set; }
        public Personel Personel { get; set; }


    }

}

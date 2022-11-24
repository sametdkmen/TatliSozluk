using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }

        [StringLength(50)] // Attirbutelerle kısıtlama uyguladık.
        public string WriterName { get; set; }

        [StringLength(50)] // Attirbutelerle kısıtlama uyguladık.
        public string WriterSurName { get; set; }

        [StringLength(100)] // Attirbutelerle kısıtlama uyguladık.
        public string WriterImage { get; set; }

        [StringLength(50)] // Attirbutelerle kısıtlama uyguladık.
        public string WriterMail { get; set; }

        [StringLength(20)] // Attirbutelerle kısıtlama uyguladık.
        public string WriterPassword { get; set; }

        public ICollection<Heading> Headings { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace _25DH110475_MyStore.Models
{
    public partial class Product
    {
        [NotMapped]
        public HttpPostedFileBase UploadImg { get; set; }
    }
}
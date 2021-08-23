
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class PRODUTO
    {        
        public string COD_PRODUTO { get; set; }
        public string DESC_PRODUTO { get; set; }
        public string STA_STATUS { get; set; }

        public virtual PRODUTO_COSIF PRODUTO_COSIF { get; set; }
    }
}

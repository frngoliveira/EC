using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class PRODUTO_COSIF
    {
        public string COD_COSIF { get; set; }
        public string COD_CLASSIFICACAO { get; set; }
        public string STA_STATUS { get; set; }
        public string COD_PRODUTO { get; set; }
        public PRODUTO PRODUTO { get; set; }
        

    }
}

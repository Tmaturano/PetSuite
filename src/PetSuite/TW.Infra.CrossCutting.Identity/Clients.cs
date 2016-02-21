using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TW.Infra.CrossCutting.Identity
{
    [Table("AspNetClients")]
    public class Client
    {
        [Key]
        public int Id { get; set; }

        public string ClientKey { get; set; }
    }
}

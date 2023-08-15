using System.ComponentModel.DataAnnotations.Schema;

namespace PCBuilder.Web.ViewModels.Sockets
{
    [Table("Socket")]
    public class SocketCategoryFormModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

    }
}

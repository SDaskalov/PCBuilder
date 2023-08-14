using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PCBuilder.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilder.Data.DataSeed
{
    public class SocketEntityConfiguration : IEntityTypeConfiguration<Socket>
    {
        public void Configure(EntityTypeBuilder<Socket> builder)
        {
            builder.HasData(SeedSockets());
        }

        private Socket[] SeedSockets()
        {
            ICollection<Socket> sockets = new HashSet<Socket>();

            Socket s = new Socket()
            {
                Id = 1,
                Name= "AM4"
                
            };
            sockets.Add(s);

            s = new Socket()
            {
                Id= 2,
                Name="AM5"
            };
            sockets.Add(s);
            s = new Socket()
            {
                Id = 3,
                Name = "LGA1200"
            };
            sockets.Add(s);
            s = new Socket()
            {
                Id = 4,
                Name = "LGA1700"
            };
            sockets.Add(s);
            return sockets.ToArray();   

        }
    }
}

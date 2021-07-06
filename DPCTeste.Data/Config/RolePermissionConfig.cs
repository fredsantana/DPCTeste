using DPCTeste.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPCTeste.Data.Config
{
    public class RolePermissionConfig : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasKey(c => new { c.RoleId, c.PermissionId });

            /*builder.HasOne(c => c.Role)
                .WithMany(c => c.Permissions)
                .HasForeignKey(c => c.RoleId);*/

            builder.HasOne(c => c.Permission);
            //    .WithMany(c => c.Roles)
            //    .HasForeignKey(c => c.PermissionId);
        }
    }
}

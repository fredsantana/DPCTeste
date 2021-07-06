using DPCTeste.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPCTeste.Data.Config
{
    public class UsuarioRoleConfig : IEntityTypeConfiguration<UsuarioRole>
    {
        public void Configure(EntityTypeBuilder<UsuarioRole> builder)
        {
            builder.HasKey(c => new { c.UsuarioId, c.RoleId });

            /*builder.HasOne(c => c.Usuario)
                .WithMany(c => c.Roles)
                .HasForeignKey(c => c.UsuarioId);*/

            builder.HasOne(c => c.Role);
                //.WithMany(c => c.Users)
                //.HasForeignKey(c => c.RoleId);
        }
    }
}

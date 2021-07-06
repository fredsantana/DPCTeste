using DPCTeste.Data.Config;
using DPCTeste.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Reflection;
using System.Text;

namespace DPCTeste.Data
{
    public class Context : DbContext
    {
        private const string dbName = "DPCDatabase.db";
        public Context() : base()
        {
            if (!File.Exists(dbName))
            {
                Database.EnsureCreated();

                var role = this.Roles.Add(new Role() { Name = "ADMIN", Description = "Role para administrador" });
                var permission = this.Permissions.Add(new Permission() { Description = "admin-permission" });
                SaveChanges();
                this.RolePermissions.Add(new RolePermission { RoleId = role.Entity.Id, Permission = permission.Entity });
                SaveChanges();
            }
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UsuarioRole> UsuarioRoles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={dbName}", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new ContatoConfig());
            modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new PermissionConfig());
            modelBuilder.ApplyConfiguration(new UsuarioRoleConfig());
            modelBuilder.ApplyConfiguration(new RolePermissionConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}

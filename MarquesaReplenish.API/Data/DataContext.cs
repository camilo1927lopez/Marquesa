using MarquesaReplenish.Manager.DTO;
using MarquesaReplenish.Manager.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesaReplenish.API.Data
{
    public class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ClienteDTO>().HasIndex(t => t.Nit).IsUnique();
            modelBuilder.Entity<tblProducto>().HasIndex(t => t.Nombre).IsUnique();
            modelBuilder.Entity<tblRol>().HasIndex(t => t.Nombre).IsUnique();
        }

        //public DbSet<tblPermisos> TblPermisos { get; set; }
        //public DbSet<tblDetalleRolPermisos> TblDetalleRolPermisos  { get; set; }
        public DbSet<tblRol> TblRol { get; set; }
        public DbSet<tblCliente> tblCliente { get; set; }
        //public DbSet<tblDetalleRolCliente> TblDetalleRolCliente { get; set; }
        public DbSet<tblUsuario> TblUsuario { get; set; }

        public DbSet<tblPermisos> tblPermisos { get; set; }

        public DbSet<tblProducto> tblProducto { get; set; }

        public DbSet<tblTipoGrupo> tblTipoGrupo { get; set; }

        public DbSet<tblTipo> tblTipo { get; set; }
         
        public DbSet<tblPoblacion> tblPoblacion { get; set; }

        public DbSet<tblAdicionales> tblAdicionales { get; set; }

        public DbSet<tblDetalleRolCliente> tblDetalleRolCliente { get; set; }

        public DbSet<tblDetalleRolPermisos> tblDetalleRolPermisos { get; set; }

    }
}

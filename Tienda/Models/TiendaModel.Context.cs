//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tienda.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TIENDADBEntities : DbContext
    {
        public TIENDADBEntities()
            : base("name=TIENDADBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<TicketDetalle> TicketDetalle { get; set; }
        public virtual DbSet<TipoProducto> TipoProducto { get; set; }
    }
}

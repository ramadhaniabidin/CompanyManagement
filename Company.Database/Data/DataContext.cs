using Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }
        public DbSet<Akun> Akun { get; set; }
        public DbSet<Peran> Peran { get; set; }
        public DbSet<Pengguna> Pengguna { get; set;}
        public DbSet<Kantor> Kantor { get; set; }
        public DbSet<Pengguna_Akun> Pengguna_Akun { get; set; }
        public DbSet<Pengguna_Kantor> Pengguna_Kantor { get; set; }
        public DbSet<Peran_Akun> Peran_Akun { get; set; }
        public DbSet<Layar> Layar { get; set; }
        public DbSet<LayarAkun> LayarAkun { get; set; }
        
    }
}

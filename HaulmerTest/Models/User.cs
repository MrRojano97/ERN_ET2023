namespace HaulmerTest.Models {
    public class User {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Correo { get; set; }
        public required string Telefono { get; set; }
        public required string Contrasena { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
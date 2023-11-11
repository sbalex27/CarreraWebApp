using System.ComponentModel.DataAnnotations;

namespace CarreraWebApp.Models
{
    public enum Facultad
    {
        [Display(Name = "Derecho")]
        Derecho,
        [Display(Name = "Ingenieria en Sistemas")]
        Sistemas,
        [Display(Name = "Ingenieria Industrial")]
        Civil,
        [Display(Name = "Administracion")]
        Administracion,
        [Display(Name = "Psicologia")]
        Psicologia,
        [Display(Name = "Forense")]
        Forense
    }

    public enum Talla
    {
        S, M, L, XL, XXL
    }

    public enum Genero
    {
        Masculino, Femenino
    }

    public class Participante
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Carnet { get; set; } = null!;
        public Facultad Facultad { get; set; }
        public int Edad { get; set; }
        public string Personalizacion { get; set; } = null!;
        public Talla Talla { get; set; }
        public Genero Genero { get; set; }
    }
}

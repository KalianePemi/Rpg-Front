
using RpgMvc.Models.Enums;

namespace RpgMvc.Models

{
    public class PersonagemViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "Frodo";
        public int PontosVida { get; set; } = 100;
        public int Forca { get; set; } = 10;
        public int Defesa { get; set; } = 10;
        public int Inteligencia { get; set; } = 10;
        public ClasseEnum Classe { get; set; }
        public byte[] FotoPersonagem { get; set; }

        
        //public Usuario Usuario { get; set; }
        public int UsuarioId {get; set;} = 1;

        //public Arma Arma{get; set;}
        //public List<PersonagemHabilidade> PersonagemHabilidades { get; set; }

        public int Disputas { get; set; }
        public int Vitorias { get; set; }
        public int Derrotas { get; set; }        
    }
}

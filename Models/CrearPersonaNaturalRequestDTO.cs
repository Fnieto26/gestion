namespace GestionTerceros.Models
{
    public class CrearPersonaNaturalRequestDTO
    {
        public string un_TIPOID { get; set; }
        public string un_cc { get; set; }
        public string un_NOM1 { get; set; }
        public string? un_NOM2 { get; set; } //No obligatorio
        public string un_APE1 { get; set; }
        public string? un_APE2 { get; set; } //No obligatorio
        public string un_TEL { get; set; }
        public string? un_CEL { get; set; } //No obligatorio
        public string un_DIR { get; set; }
        public string un_EMAIL { get; set; }
    }
}

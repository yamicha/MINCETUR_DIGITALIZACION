using System.Runtime.Serialization;


namespace ApiServiciosDigitalizacion.Models.ArchivoCentral.Administracion
{

    [DataContract(Name = "Area")]
    public class AreaModel
    {
        [DataMember(Name = "strIdArea", Order = 1)]
        public int IdArea { get; set; }

        [DataMember(Name = "strDescArea", Order = 2)]
        public string DescArea { get; set; }

        [DataMember(Name = "strSigla", Order = 3)]
        public string Sigla { get; set; }

        [DataMember(Name = "strFlgEstado", Order = 4)]
        public string FlgEstado { get; set; }

        [DataMember(Name = "strUsuarioCreacion", Order = 5)]
        public string UsuCreacion { get; set; }

        [DataMember(Name = "strUsuarioModificacion", Order = 6)]
        public string UsuModificacion { get; set; }
    }

}

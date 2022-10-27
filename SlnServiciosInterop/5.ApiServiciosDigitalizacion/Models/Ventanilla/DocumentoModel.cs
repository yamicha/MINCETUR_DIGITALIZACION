using System.Runtime.Serialization;


namespace ApiServiciosDigitalizacion.Models.Ventanilla
{
    public class DocumentoModel
    {
        [DataMember(Name = "ID_EXPE", Order = 1)]
        public long ID_EXPE { get; set; }
        [DataMember(Name = "NUM_SIZE_DOC", Order = 1)]
        public long NUM_SIZE_DOC { get; set; }
        [DataMember(Name = "ID_DOC", Order = 1)]
        public long ID_DOC { get; set; }
    }
}

using Branef.Domain.Enums;

namespace Branef.Domain.Entity
{
    public class Cliente 
    {
        public Cliente(string nomeEmpresa, EPorte porte,Guid id)
        {
            Id = id;
            NomeEmpresa = nomeEmpresa;
            Porte = porte;
        }

        public Cliente (Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
        public string NomeEmpresa { get; set; }
        public EPorte Porte { get; set; } 
    }
}

using DesafioWebMotors.Data.Context;
using DesafioWebMotors.Domain.Entities;
using DesafioWebMotors.Domain.Interfaces;

namespace DesafioWebMotors.Data.Repository
{
    public class AnuncioWebmotorsRespository : BaseRepository<AnuncioWebmotorsEntity>, IAnuncioWebmotorsRespository
    {
        private readonly DesafioWebmotorsContext _context;

        public AnuncioWebmotorsRespository(DesafioWebmotorsContext context) : base(context)
        {
            _context = context;
        }
    }
}

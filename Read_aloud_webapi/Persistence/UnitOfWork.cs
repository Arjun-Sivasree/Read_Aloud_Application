namespace Read_aloud_webapi.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReadAloudContext _context;
        public UnitOfWork(ReadAloudContext context)
        {
            _context = context;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
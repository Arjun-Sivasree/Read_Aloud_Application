namespace Read_aloud_webapi.Persistence
{
    public interface IUnitOfWork
    {
        public Task<int> Complete();
    }
}
namespace MVCToDoWebApp
{
    public interface IRepository<T>
    {
        public static List<T> database { get; set; }

        public void Add(T item);
        public void Remove(T item);

    }
}

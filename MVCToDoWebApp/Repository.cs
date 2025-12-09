using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace MVCToDoWebApp
{
    public class Repository<T> : IRepository<T>
    {
        public static List<T> database { get; set; }

        public Repository() : this(new List<T> {  }) { }
        public Repository(List<T> data)
        { 
            database = data;
        }

        public void Add(T item)
        { 
            database.Add(item);
        }

        public void Remove(T item)
        { 
            database.Remove(item);
        }
    }
}

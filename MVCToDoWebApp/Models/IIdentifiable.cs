namespace MVCToDoWebApp.Models
{
    public interface IIdentifiable
    {
        private static int _id;
        public int Id { get; set; }
    }
}

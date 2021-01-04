namespace CICD_API.Entity
{
    public class Collection
    {
        public int Id { get; set; }
        
        public int IdUser { get; set; }
        
        public string Name { get; set; }
        
        public object GameList { get; set; }
    }
}
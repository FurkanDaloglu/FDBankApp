namespace FDBankApp.Data.Entities
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        //navigation property
        public List<Account> Accounts { get; set; }
    }
}

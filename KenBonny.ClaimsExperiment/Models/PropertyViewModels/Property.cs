namespace KenBonny.ClaimsExperiment.Models.PropertyViewModels
{
    public class Property
    {
        public Property(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; }
        public string Description { get; }
    }
}
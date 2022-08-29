namespace CountMyWords.Domain.Text
{
    // Make an Identity class that'll act as a wrapper around Id type
    public class Text // : Identity
    {
        public Text(Guid id, string value)
        {
            Id = id;
            Value = value;
        }

        public Guid Id { get; }

        public string Value { get; set; }

        // Some business logic encapsulated inside the domain model ...
    }
}

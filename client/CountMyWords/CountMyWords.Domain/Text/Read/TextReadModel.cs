namespace CountMyWords.Domain.Text.Read
{
    // Immutable model used for query requests only
    public class TextReadModel
    {
        public TextReadModel(Guid id, string value)
        {
            Id = id;
            Value = value;
        }

        public Guid Id { get; }
        
        public string Value { get; }
    }
}

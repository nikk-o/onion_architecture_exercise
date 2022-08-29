namespace CountMyWords.Domain.Text
{
    public class TextFactory : ITextFactory
    {
        private readonly ITextIdGenerator textIdGenerator;

        public TextFactory(ITextIdGenerator textIdGenerator)
        {
            this.textIdGenerator = textIdGenerator;
        }

        public Text Create(string text)
        {
            var id = textIdGenerator.GenerateNext();

            return new Text(id, text);
        }
    }
}

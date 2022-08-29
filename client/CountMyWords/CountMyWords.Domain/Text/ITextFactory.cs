using CountMyWords.Domain.Common;

namespace CountMyWords.Domain.Text
{
    public interface ITextFactory : IFactory
    {
        public Text Create(string text);
    }
}

namespace CountMyWords.Application.Validation
{
    public class ValidationException : Exception
    {
        public ValidationException(string message)
            : base(message) { }

        public ValidationException(IDictionary<string, IEnumerable<string>> errorMessages) 
            : base(GetMessage(errorMessages))
        {   
        }

        private static string GetMessage(IDictionary<string, IEnumerable<string>> errorMessages)
        {
            var propertyMessages = errorMessages.Select(e => e.Key + ": " + string.Join("\n", e.Value));

            var message = string.Join("\n", propertyMessages);

            return message;
        }
    }
}

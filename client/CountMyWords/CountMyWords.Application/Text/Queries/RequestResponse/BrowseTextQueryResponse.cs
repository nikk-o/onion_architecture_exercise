namespace CountMyWords.Application.Text.Queries.RequestResponse
{
    public class BrowseTextQueryResponse
    {
        public List<SingleTextResponse> Texts { get; set; }
    }

    public class SingleTextResponse
    {
        public Guid Id { get; set; }
        
        public string Text { get; set; }    
    }
}

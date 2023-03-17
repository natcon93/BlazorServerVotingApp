namespace BlazorServerVotingApp.Models
{
    public class Poll
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime EndTime { get; set; }
        public IList<PollOption> PollOptions { get; set; } = new List<PollOption>();

    }
}

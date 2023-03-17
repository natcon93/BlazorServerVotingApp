using System.Text.Json.Serialization;

namespace BlazorServerVotingApp.Models
{
    public class PollOption
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<PollVote>? PollVotes { get; set; } = new List<PollVote>();
        public int PollID { get; set; }
        [JsonIgnore]
        public Poll Poll { get; set; }
    }
}

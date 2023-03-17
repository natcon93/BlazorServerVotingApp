using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorServerVotingApp.Models
{
    public class PollVote
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int PollOptionId { get; set; }
        [Required(ErrorMessage ="Please Select an option before voting.")]
        [JsonIgnore]
        public PollOption PollOption { get; set; }
    }
}

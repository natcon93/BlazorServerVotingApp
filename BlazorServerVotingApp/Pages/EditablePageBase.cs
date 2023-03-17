using BlazorServerVotingApp.Enums;
using Microsoft.AspNetCore.Components;
using BlazorServerVotingApp.Enums;

namespace BlazorServerVotingApp.Pages
{
    public class EditablePageBase : PageBase
    {
        [Parameter]
        public int Id { get; set; }
        public Mode Mode => Id == 0 ? Mode.Create : Mode.Edit;
    }
}
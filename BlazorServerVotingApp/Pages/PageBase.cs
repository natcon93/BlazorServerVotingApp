using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using BlazorServerVotingApp.Data;
using Microsoft.EntityFrameworkCore;
using BlazorServerVotingApp.Data;

namespace BlazorServerVotingApp.Pages
{
    public class PageBase : ComponentBase, IDisposable
    {
        [Inject]
        public IDbContextFactory<ApplicationDbContext>? DbContextFactory { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IJSRuntime JS { get; set; }
        protected ApplicationDbContext? Context { get; set; }
        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Context = await DbContextFactory.CreateDbContextAsync();
        }
        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}

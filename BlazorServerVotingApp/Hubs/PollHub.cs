using BlazorServerVotingApp.Models;
using Microsoft.AspNetCore.SignalR;

namespace BlazorServerVotingApp.Server.Hubs;

public class PollHub : Hub
{
    public async Task UpdateData()
    {
        await Clients.All.SendAsync("DataUpdated");
    }
}
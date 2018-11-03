namespace MishMash.Services.Contracts
{
    using System.Collections.Generic;
    using Models.ViewModels;

    public interface IChannelService
    {
        void CreateChannel(string name, string description, string channelType, string tags);

        ChannelDetailsViewModel ChannelDetails(int channelId);

        ICollection<FollowedChannelsViewModel> FollowedChannels(string username);
    }
}
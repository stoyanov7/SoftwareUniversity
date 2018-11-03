namespace MishMash.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data;
    using Models;
    using Models.Enums;
    using Models.ViewModels;

    public class ChannelService : IChannelService
    {
        private readonly MishMashContext context;

        public ChannelService(MishMashContext context)
        {
            this.context = context;
        }

        public void CreateChannel(string name, string description, string channelType, string tags)
        {
            var channel = new Channel
            {
                Name = name,
                Description = description,
                ChannelType = (ChannelType)Enum.Parse(typeof(ChannelType), channelType, true)
            };

            var tagsArgs = tags
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(t => new ChannelTag
                {
                    Tag = new Tag { Name = t },
                    Channel = channel
                })
                .ToList();

            channel.Tags = tagsArgs;

            this.context.Channels.Add(channel);
            this.context.SaveChanges();
        }

        public ChannelDetailsViewModel ChannelDetails(int channelId)
        {
            return this.context
                .Channels
                .Where(ch => ch.Id == channelId)
                .Select(ch => new ChannelDetailsViewModel
                {
                    Channel = ch.Name,
                    Type = ch.ChannelType.ToString(),
                    Followers = ch.Followers.Count(),
                    Description = ch.Description,
                    Tags = string.Join(", ", ch.Tags.Select(t => t.Tag.Name))
                }).FirstOrDefault();
        }

        public ICollection<FollowedChannelsViewModel> FollowedChannels(string username)
        {
            var followedChannelsViewModels = new List<FollowedChannelsViewModel>();

            var followedChannels = this.context
                .Users
                .FirstOrDefault(u => u.Username == username)
                ?.FollowedChannels
                .Select(ch => ch.Channel)
                .ToList();

            for (var i = 0; i < followedChannels?.Count; i++)
            {
                var model = new FollowedChannelsViewModel
                {
                    Index = i + 1,
                    ChannelId = followedChannels[i].Id,
                    Name = followedChannels[i].Name,
                    ChannelType = followedChannels[i].ChannelType.ToString(),
                    FollowersCount = followedChannels[i].Followers.Count()
                };

                followedChannelsViewModels.Add(model);
            }

            return followedChannelsViewModels;
        }
    }
}
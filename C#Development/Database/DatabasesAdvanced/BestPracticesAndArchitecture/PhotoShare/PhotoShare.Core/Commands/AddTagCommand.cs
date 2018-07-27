namespace PhotoShare.Core.Commands
{
    using System;
    using Client.Utilities;
    using Contracts;
    using Services.Contracts;
    using Utilities.Constants;

    public class AddTagCommand : ICommand
    {
        private readonly ITagService tagService;

        public AddTagCommand(ITagService tagService) => this.tagService = tagService;

        public string Execute(string[] args)
        {
            var tagName = args[0];
            var tagExist = this.tagService.Exists(tagName);

            if (tagExist)
            {
                throw new ArgumentException(string.Format(Message.AlreadyExist, "Tag", tagName));
            }

            tagName = tagName.ValidateOrTransform();
            var tag = this.tagService.AddTag(tagName);

            return string.Format(Message.SuccessfullyAdded, "tag", tagName);
        }
    }
}

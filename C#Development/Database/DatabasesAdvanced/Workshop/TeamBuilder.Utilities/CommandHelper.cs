namespace TeamBuilder.Utilities
{
    using System;
    using System.Linq;
    using Data;
    using Models;

    public static class CommandHelper 
    {
        public static bool IsTeamExisting(string teamName)
        {
            using (var context = new TeamBuilderContext())
            {
                return context
                    .Teams
                    .Any(t => t.Name == teamName);
            }
        }

        public static bool IsUserExisting(string username)
        {
            using (var context = new TeamBuilderContext())
            {
                return context
                    .Users
                    .Any(u => u.Username == username);
            }
        }

        public static bool IsInviteExisting(string teamName, User user)
        {
            using (var context = new TeamBuilderContext())
            {
                return context
                    .Invitations
                    .Any(i => i.Team.Name == teamName &&
                              i.InvitedUserId == user.Id && i.IsActive);
            }
        }

        public static bool IsUserCreatorOfTeam(string teamName, User user)
        {
            throw new NotImplementedException();
        }

        public static bool IsUserCreatorOfEvent(string eventName, User user)
        {
            using (var context = new TeamBuilderContext())
            {
                return context
                    .Events
                    .Single(e => e.Name == eventName)
                    .Creator
                    .Equals(user.Id);
            }
           
        }

        public static bool IsMemberOfTeam(string teamName, string username)
        {
            using (var context = new TeamBuilderContext())
            {
                return context
                    .Teams
                    .Single(t => t.Name == teamName)
                    .UserTeams
                    .Any(ut => ut.User.Username == username);
            }
        }

        public static bool IsEventExisting(string eventName)
        {
            using (var context = new TeamBuilderContext())
            {
                return context
                    .Events
                    .Any(e => e.Name == eventName);
            }
        }
    }
}
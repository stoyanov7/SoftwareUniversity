namespace PhotoShare
{
    using AutoMapper;
    using Models;
    using ModelsDto;

    public class PhotoShareProfile : Profile
    {
        public PhotoShareProfile()
        {
            this.CreateMap<User, User>();

            this.CreateMap<Town, TownDto>()
                .ReverseMap();

            this.CreateMap<Album, AlbumDto>()
                .ReverseMap();

            this.CreateMap<Tag, TagDto>()
                .ReverseMap();

            this.CreateMap<AlbumRole, AlbumRoleDto>()
                .ForMember(dest => dest.AlbumName, 
                           from => from.MapFrom(p => p.Album.Name))
                .ForMember(dest => dest.Username, 
                           from => from.MapFrom(p => p.User.Username))
                .ReverseMap();

            this.CreateMap<User, UserFriendsDto>()
                .ForMember(dto => dto.Friends,
                           opt => opt.MapFrom(u => u.FriendsAdded));

            this.CreateMap<Friendship, FriendDto>()
                .ForMember(dto => dto.Username,
                           opt => opt.MapFrom(f => f.Friend.Username));
        }
    }
}
using AutoMapper;
using Common.ViewModel.Models.Quiers.Comment;
using Common.ViewModel.Models.Quiers.users;
using Common.ViewModel.Models.RequestModel.users;
using Common.ViewModel.RequestModel.users;
using Core.Domain;

namespace Core.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region ::USER::
            CreateMap<User, LoginUserViewModul>()
            .ReverseMap();
            CreateMap<User, CreateUserCommand>()
                .ReverseMap();
            CreateMap<User, UpdateUserCommand>()
               .ReverseMap();
            CreateMap<LoginUserViewModul, User>()
                .ReverseMap();
            #endregion
            #region ::COMMENT::
            //DeleteCommentCommand UpdateCommentCommand
            CreateMap<GetCommentQueryViewModel, Comment>()
               .ReverseMap();
            CreateMap<CreateCommentCommand, Comment>()
               .ReverseMap();
            #endregion


        }
    }
}

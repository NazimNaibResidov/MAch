using Common.ViewModel.Models.RequestModel.users;
using FluentValidation;

namespace Core.Validators.Comment
{
    public class CommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CommentCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .Length(4)
                .MaximumLength(40)
                .MinimumLength(5)
                .WithMessage("{PropertyName} not valid");
            RuleFor(x => x.Content)
                .NotNull()
                .Length(4)
                .MaximumLength(490)
                .MinimumLength(10)
                .WithMessage("{PropertyName} not valid");

        }
    }
}

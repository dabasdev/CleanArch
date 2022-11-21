using FluentValidation;

namespace CleanArch.Application.Features.Posts.Commands.CreatePost;

public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostCommandValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty()
            .NotNull()
            .MaximumLength(10);

        RuleFor(p => p.Content)
            .NotEmpty()
            .NotNull();
    }
}
using ASP_MVC.ViewModels.Items;
using FluentValidation;

namespace ASP_MVC.Validators.Items
{
    public sealed class ItemViewModelValidator : AbstractValidator<ItemViewModel>
    {
        public ItemViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100);
        }
    }
}




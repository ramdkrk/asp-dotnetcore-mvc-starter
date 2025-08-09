using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.ViewModels.Items
{
    public sealed class ItemViewModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}




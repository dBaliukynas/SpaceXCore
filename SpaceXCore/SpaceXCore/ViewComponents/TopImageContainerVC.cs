using Microsoft.AspNetCore.Mvc;
using SpaceXCore.Models.ViewModels;

[ViewComponent(Name = "TopImageContainer")]
public class TopImageContainerVC : ViewComponent
{
    public IViewComponentResult Invoke(Uri Image, string Name, bool imageObjectFitContain=false)
    {
        var model = new TopImageContainerViewModel();

        model.Image = Image;
        model.Name = Name;
        model.ImageObjectFitContain = imageObjectFitContain;

        return View(model);
    }
}
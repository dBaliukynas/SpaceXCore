using Microsoft.AspNetCore.Mvc;

[ViewComponent(Name = "TopImageContainer")]
public class TopImageContainerVC : ViewComponent
{
    public IViewComponentResult Invoke(Uri Image, string Name, bool containImage=false)
    {
        ViewBag.Image = Image;
        ViewBag.Name = Name;
        ViewBag.ContainImage = containImage;

        return View();
    }
}
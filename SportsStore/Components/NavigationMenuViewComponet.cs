using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SportsStore.Models;

namespace SportsStore.Components
{
    public class NavigationMenuviewComponent : ViewComponent
    {
        private IProductRepository _repository;

        public NavigationMenuviewComponent(IProductRepository repo)
        {
            _repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(_repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x)
            );
        }
    }
}
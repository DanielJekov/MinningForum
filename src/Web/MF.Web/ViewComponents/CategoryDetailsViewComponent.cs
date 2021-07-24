﻿namespace MF.Web
{
    using System.Linq;
    using System.Threading.Tasks;

    using MF.Data;
    using MF.Models.ViewModels.Category;

    using Microsoft.AspNetCore.Mvc;

    public class CategoriesDropdownViewComponent : ViewComponent
    {
        private readonly MFDbContext data;

        public CategoriesDropdownViewComponent(MFDbContext data)
        {
            this.data = data;
        }

        public async Task<IViewComponentResult> InvokeAsync(int categoryId)
        {
            return null;
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVC.ViewComponents
{
    public class CommentViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            List<string> data = new List<string> { "Hello", "Hi" };
            return View(data);
        }
    }
}

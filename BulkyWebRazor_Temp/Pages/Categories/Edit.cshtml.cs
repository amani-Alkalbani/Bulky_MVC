using Bulky.Models;
using BulkyWebRazor_Temp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Category Category { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
          if(id !=null && id != 0)
            {
                Category = _db.categories.Find(id);
            }

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.categories.Update(Category);
                _db.SaveChanges();
              TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index");
            }
            return Page();  
            
        }
    }
}

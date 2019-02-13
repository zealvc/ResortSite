using Resort.Domain.Entities;
using System.Diagnostics;
using Resort.Application.Accommodation.Models;

namespace Resort.Application.Category.Category.Commands
{
    public class CreateCategory
    {
        public string Create(CategoryModel categoryModel)
        {
            ResortSiteDbContext context = new ResortSiteDbContext();
            Resort.Domain.Entities.Category adr = new Resort.Domain.Entities.Category() { Name = categoryModel.Name
                , Description = categoryModel.Description
                , LanguageId =categoryModel.LanguageId};
            context.Category.Add(adr);
            int ret=context.SaveChanges();
            Debug.WriteLine("Test: "+ret);
            return "ok";
        }
        public string Delete(int id)
        {
            ResortSiteDbContext context = new ResortSiteDbContext();
            Resort.Domain.Entities.Category category = new Resort.Domain.Entities.Category() { Id = id };
            context.Category.Attach(category);
            context.Category.Remove(category);
            context.SaveChanges();
            return "ok";
        }
    }
}

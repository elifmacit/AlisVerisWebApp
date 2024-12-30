
namespace AlisVerisWebApp.Models
{
    public interface ISubCategory
    {
        Category Category { get; set; }
        int Category_Id { get; set; }
        ICollection<Product> Products { get; set; }
        int SubCategory_Id { get; set; }
        string SubCategory_Name { get; set; }
    }
}
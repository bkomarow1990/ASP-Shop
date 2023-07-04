namespace Shop.Application.DTO.Category;

public class EditCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid? ParentCategoryId { get; set; }
}
public interface ITemplateService
{
    Task GenerateCrudController(string entityName);
    Task GenerateService(string entityName);
    Task GenerateTests(string entityName);
    Task GenerateAllCrudComponents(string entityName);
}
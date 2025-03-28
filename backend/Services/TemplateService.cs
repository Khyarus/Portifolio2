using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using System.Text;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;

namespace Portfolio2.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly IWebHostEnvironment _env;
        private readonly string _templatesPath;

        public TemplateService(IWebHostEnvironment env)
        {
            _env = env;
            _templatesPath = Path.Combine(_env.ContentRootPath, "Services", "Templates");
        }

        public async Task GenerateAllCrudComponents(string entityName)
        {
            await GenerateCrudController(entityName);
            await GenerateService(entityName);
            await GenerateTests(entityName);
        }

        public async Task GenerateCrudController(string entityName)
        {
            var templatePath = Path.Combine(_templatesPath, "ControllerTemplate.cshtml");
            var outputPath = Path.Combine(_env.ContentRootPath, "Controllers", $"{entityName}Controller.cs");

            var template = await File.ReadAllTextAsync(templatePath);
            var generatedCode = template.Replace("{{EntityName}}", entityName)
                                      .Replace("{{entityName}}", entityName.ToLower());

            await File.WriteAllTextAsync(outputPath, generatedCode);
        }

        public async Task GenerateService(string entityName)
        {
            // Gerar interface
            var interfaceTemplate = Path.Combine(_templatesPath, "ServiceInterfaceTemplate.cshtml");
            var interfaceOutput = Path.Combine(_env.ContentRootPath, "Services", $"I{entityName}Service.cs");

            var interfaceContent = await File.ReadAllTextAsync(interfaceTemplate);
            var generatedInterface = interfaceContent.Replace("{{EntityName}}", entityName);

            await File.WriteAllTextAsync(interfaceOutput, generatedInterface);

            // Gerar implementação
            var implTemplate = Path.Combine(_templatesPath, "ServiceImplementationTemplate.cshtml");
            var implOutput = Path.Combine(_env.ContentRootPath, "Services", $"{entityName}Service.cs");

            var implContent = await File.ReadAllTextAsync(implTemplate);
            var generatedImpl = implContent.Replace("{{EntityName}}", entityName);

            await File.WriteAllTextAsync(implOutput, generatedImpl);
        }

        public async Task GenerateTests(string entityName)
        {
            var templatePath = Path.Combine(_templatesPath, "TestTemplate.cshtml");
            var outputPath = Path.Combine(_env.ContentRootPath, "Tests", $"{entityName}ControllerTests.cs");

            var template = await File.ReadAllTextAsync(templatePath);
            var generatedCode = template.Replace("{{EntityName}}", entityName);

            await File.WriteAllTextAsync(outputPath, generatedCode);
        }
    }
}
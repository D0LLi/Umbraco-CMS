using NUnit.Framework;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.ContentEditing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Services.Navigation;
using Umbraco.Cms.Tests.Common.Testing;
using Umbraco.Cms.Tests.Integration.Testing;

namespace Umbraco.Cms.Tests.Integration.Umbraco.Core.Services;

[TestFixture]
[UmbracoTest(Database = UmbracoTestOptions.Database.NewSchemaPerTest)]
public abstract class DocumentNavigationServiceTestsBase : UmbracoIntegrationTest
{
    protected IContentTypeService ContentTypeService => GetRequiredService<IContentTypeService>();

    // Testing with IContentEditingService as it calls IContentService underneath
    protected IContentEditingService ContentEditingService => GetRequiredService<IContentEditingService>();

    protected IDocumentNavigationQueryService DocumentNavigationQueryService => GetRequiredService<IDocumentNavigationQueryService>();

    protected IContentType ContentType { get; set; }

    protected IContent Root { get; set; }

    protected IContent Child1 { get; set; }

    protected IContent Grandchild1 { get; set; }

    protected IContent Grandchild2 { get; set; }

    protected IContent Child2 { get; set; }

    protected IContent Grandchild3 { get; set; }

    protected IContent GreatGrandchild1 { get; set; }

    protected IContent Child3 { get; set; }

    protected IContent Grandchild4 { get; set; }

    protected ContentCreateModel CreateContentCreateModel(string name, Guid key, Guid? parentKey = null)
        => new()
        {
            ContentTypeKey = ContentType.Key,
            ParentKey = parentKey ?? Constants.System.RootKey,
            InvariantName = name,
            Key = key,
        };
}

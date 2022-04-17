using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

namespace MyCms.Projects
{
    public class Migrations : DataMigration
    {
        IContentDefinitionManager _contentDefinitionManager;

        public Migrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public int Create()
        {
            _contentDefinitionManager.AlterTypeDefinition("Project", type => type
                .Draftable()
                .Versionable()
                .Creatable()
                .Securable()
                .Listable()
                .WithPart("Project")
            );

            _contentDefinitionManager.AlterPartDefinition("Project", part => part
                .WithField("Name", field => field
                    .OfType("TextField")
                    .WithDisplayName("Name")
                )
                .WithField("StartDate", field => field
                    .OfType("DateField")
                    .WithDisplayName("Start date")
                )
                .WithField("Image", field => field
                    .OfType("MediaField")
                    .WithDisplayName("Main image")
                )
                .WithField("Cost", field => field
                    .OfType("NumericField")
                    .WithDisplayName("Cost")
                )
            );

            return 1;
        }
    }
}
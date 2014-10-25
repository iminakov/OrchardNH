using Orchard.UI.Resources;

namespace NHStoreUI
{
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder)
        {
            var manifest = builder.Add();
            manifest.DefineStyle("NHStoreUI_Style").SetUrl("style.css");
        }
    }
}
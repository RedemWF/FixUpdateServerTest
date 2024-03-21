using UnityEditor;
using System.IO;
namespace Editor
{
    public class CreatAssetBundles
    {
        [MenuItem("Assets/Build AssetBundles")]
        static void BuildAssetBundles()
        {
            string dir = "AssetBundles";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            BuildPipeline.BuildAssetBundles(dir,BuildAssetBundleOptions.None,BuildTarget.StandaloneWindows64);
        }
    }
}

using UnityEditor;
using System.IO;

public class BuildAssetBundles
{
    [MenuItem("Assets/Build AssetBundle")]
    private static void BuildBundles()
    {
        string path = "AssetBundles";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }
}

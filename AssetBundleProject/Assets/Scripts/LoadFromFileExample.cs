using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadFromFileExample : MonoBehaviour
{

    private IEnumerator Start()
    {
        //AssetBundle ab = AssetBundle.LoadFromFile("AssetBundles/wall.unity3d");
        //while (!Caching.ready)
        //{
        //    yield return null;
        //}

        //WWW www = WWW.LoadFromCacheOrDownload("http://localhost/AssetBundles/wall.unity3d", 1);
        //yield return www;
        //if (!string.IsNullOrEmpty(www.error))
        //{
        //    Debug.Log(www.error);
        //    yield return null;
        //}
        //AssetBundle ab= www.assetBundle;

        string url = "http://localhost/AssetBundles/Cube.unity3d";
        string url2 = "http://localhost/AssetBundles/texture.unity3d";
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(url);
        UnityWebRequest request2 = UnityWebRequestAssetBundle.GetAssetBundle(url2);
        yield return request.SendWebRequest();
        yield return request2.SendWebRequest();

        AssetBundle ab = (request.downloadHandler as DownloadHandlerAssetBundle).assetBundle;
        AssetBundle abMaterial = (request2.downloadHandler as DownloadHandlerAssetBundle).assetBundle;
        GameObject wallGo = ab.LoadAsset<GameObject>("Cube");
        //GameObject maGo = ab.LoadAsset<GameObject>("Hand_Painted_Grass");
        GameObject.Instantiate(wallGo);


        #region 获取AssetBundle下的Manifest文件并获取里面的依赖关系
        string url3 = "http://localhost/AssetBundles/AssetBundles";
        UnityWebRequest request3= UnityWebRequestAssetBundle.GetAssetBundle(url3);
        yield return request3.SendWebRequest();
        AssetBundle manifest = (request3.downloadHandler as DownloadHandlerAssetBundle).assetBundle;
        AssetBundleManifest manifest2= manifest.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        string[] bundles= manifest2.GetAllAssetBundles();
        string[] dependon = manifest2.GetAllDependencies("cube.unity3d");
        foreach (var item in bundles)
        {
            Debug.Log(item);
        }

        foreach (var item in dependon)
        {
            Debug.Log(item);
        }
        #endregion

    }
}

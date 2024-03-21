using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using XLua;
using UnityEngine.Networking;

public class HotFixScript : MonoBehaviour
{
    private LuaEnv _luaEnv;
    private Dictionary<string, GameObject> prefabs = new();
    private void Awake()
    {
        Debug.Log("ApplicationPath::"+Application.dataPath);
        _luaEnv = new LuaEnv();
        _luaEnv.AddLoader(MyLoader);
        _luaEnv.DoString("require 'Test'");
    }

    private byte[] MyLoader(ref string filePath)
    {
        Debug.Log("FilePath::"+filePath);
        string absPath = $"G:/UnityHub/UnityProject/HotFixProject/Lua/{filePath}.lua";
        return Encoding.UTF8.GetBytes(File.ReadAllText(absPath)) ;
    }
    
    private void OnDisable()
    {
        _luaEnv.DoString("require 'LuaDispose'");
    }

    private void OnDestroy()
    {
        _luaEnv.Dispose();
    }
    [LuaCallCSharp]
    public void LoadResource(string resName,string resPath)
    {
        StartCoroutine(Load(resName,resPath));
    }

    IEnumerator Load(string resName, string resPath)
    {
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle($"http://localhost/update{resPath}");
        Debug.Log(request.url);
        yield return request.SendWebRequest();
        AssetBundle ab = (request.downloadHandler as DownloadHandlerAssetBundle).assetBundle;
        var go = ab.LoadAsset<GameObject>(resName);
        prefabs.Add(resName,go);
    }
    [LuaCallCSharp]
    public GameObject GetPrefab(string resName)
    {
        GameObject go = null;
        prefabs.TryGetValue(resName,out go );
        return go;
    }
}

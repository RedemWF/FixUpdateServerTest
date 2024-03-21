using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
public class LoadLua : MonoBehaviour
{
    void Start()
    {
        
        StartCoroutine(LoadLuaFile());
    }
    IEnumerator LoadLuaFile()
    {
        UnityWebRequest request = UnityWebRequest.Get($"http://localhost/update?filename=Test.lua");
        yield return request.SendWebRequest();
        string str = request.downloadHandler.text;
        Debug.Log(str);
        File.WriteAllText($"G:/UnityHub/UnityProject/HotFixProject/Lua/Test.lua",str);
        UnityWebRequest request1 = UnityWebRequest.Get($"http://localhost/update?filename=LuaDispose.lua");
        yield return request1.SendWebRequest();
        string str1 = request1.downloadHandler.text;
        File.WriteAllText($"G:/UnityHub/UnityProject/HotFixProject/Lua/LuaDispose.lua",str1);
        Debug.Log(str1);
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

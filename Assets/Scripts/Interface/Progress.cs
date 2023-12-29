using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Progress : MonoBehaviour
{
    public static int playerId;
    public static string saveId;
    public int lastScene;
    public bool[] levelsComplete;
    public string accessToken;
    public string refreshToken;
    public int saveVer = 0;
    public int levelSaveVer = 0;

    public static Progress Instance;

    public void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        levelsComplete = new bool[15];
        for (int i = 0; i < 15; i++)
        {
            levelsComplete[i] = false;
        }
    }

    [System.Serializable]
    class GetAnswer
    {
        public string id;
        public string username;
        public string gender;
        public string isAdmin;
    }

    public IEnumerator GetPlayerId()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost:8081/api/account/me"))
        {
            www.SetRequestHeader("Authorization", "Bearer " + accessToken);
            yield return www.SendWebRequest();
            GetAnswer answer = JsonUtility.FromJson<GetAnswer>(www.downloadHandler.text);
            playerId = Convert.ToInt32(answer.id);
            www.Dispose();

        }
    }

    public int techStatCalc()
    {
        int levelCount = 0;
        for (int i = 0; i < 5; i++)
        {
            if (levelsComplete[i]) levelCount++;
        }
        return levelCount;
    }

    public int progStatCalc()
    {
        int levelCount = 0;
        for (int i = 5; i < 10; i++)
        {
            if (levelsComplete[i]) levelCount++;
        }
        return levelCount;
    }

    public int sysStatCalc()
    {
        int levelCount = 0;
        for (int i = 10; i < 15; i++)
        {
            if (levelsComplete[i]) levelCount++;
        }
        return levelCount;
    }

    public string SaveToString(bool[] array)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            new BinaryFormatter().Serialize(ms, array);
            return System.Convert.ToBase64String(ms.ToArray());
        }
    }

    public bool[] StringToSave(string base54String)
    {
        byte[] bytes = System.Convert.FromBase64String(base54String);
        using (MemoryStream ms = new MemoryStream(bytes, 0, bytes.Length))
        {
            ms.Write(bytes, 0, bytes.Length);
            ms.Position = 0;
            return (bool[])new BinaryFormatter().Deserialize(ms);
        }
    }

    [Serializable]
    class Save
    {
        public string name;
        public string description;
    }



    IEnumerator CreateSaveRequest()
    {
        saveVer++;
        Save save = new Save();
        save.name = playerId + "save" + saveVer;
        save.description = SaveToString(levelsComplete);
        string jsonData = JsonUtility.ToJson(save);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8081/api/profession/new", jsonData, "application/json"))
        {
            www.SetRequestHeader("Authorization", "Bearer " + accessToken);
            yield return www.SendWebRequest();
            www.Dispose();
        }
    }

    [System.Serializable]
    public class GetSaveAnswer
    {
        public string id;
        public string name;
        public string description;
    }

    IEnumerator GetSaveRequest()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost:8081/api/profession"))
        {
            www.SetRequestHeader("Authorization", "Bearer " + accessToken);
            yield return www.SendWebRequest();
            RootObject answer = new RootObject();
            answer = JsonUtility.FromJson<RootObject>("{\"saves\":" + www.downloadHandler.text + "}");
            Debug.Log(www.downloadHandler.text);
            if (www.downloadHandler.text.IndexOf(playerId + "save") > -1)
            {
                foreach(GetSaveAnswer saveAnswer in answer.saves)
                {
                    if (saveAnswer.name.IndexOf(playerId + "save") > -1)
                    {
                        int maxVersion = int.MinValue;
                        int index = saveAnswer.name.LastIndexOf("save");
                        int saveVersion = Convert.ToInt32(saveAnswer.name.Substring(index + 4));
                        if (saveVersion > maxVersion)
                        {
                            maxVersion = saveVersion;
                            levelsComplete = StringToSave(saveAnswer.description);
                            saveVer = maxVersion;
                        }
                    }
                }
            }
            else
            {
                StartCoroutine(CreateSaveRequest());
            }
            www.Dispose();
        }
    }

    public IEnumerator GetLastScene()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost:8081/api/profession"))
        {
            www.SetRequestHeader("Authorization", "Bearer " + accessToken);
            yield return www.SendWebRequest();
            RootObject answer = new RootObject();
            answer = JsonUtility.FromJson<RootObject>("{\"saves\":" + www.downloadHandler.text + "}");
            if (www.downloadHandler.text.IndexOf(playerId + "levelSave") > -1)
            {
                Debug.Log("Метод запущен");
                foreach (GetSaveAnswer saveAnswer in answer.saves)
                {
                    if (saveAnswer.name.IndexOf(playerId + "levelSave") > -1)
                    {
                        int maxVersion = int.MinValue;
                        int index = saveAnswer.name.LastIndexOf("levelSave");
                        int saveVersion = Convert.ToInt32(saveAnswer.name.Substring(index + 9));
                        Debug.Log(saveVersion);
                        if (saveVersion > maxVersion)
                        {
                            maxVersion = saveVersion;
                            lastScene = Convert.ToInt32(saveAnswer.description);
                            levelSaveVer = maxVersion;

                        }
                    }
                }
            }
            www.Dispose();
        }
    }


    public IEnumerator SaveLevel()
    {
        levelSaveVer++;
        Save save = new Save();
        save.name = playerId + "levelSave" + levelSaveVer;
        save.description = Convert.ToString(lastScene);
        string jsonData = JsonUtility.ToJson(save);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8081/api/profession/new", jsonData, "application/json"))
        {
            www.SetRequestHeader("Authorization", "Bearer " + accessToken);
            yield return www.SendWebRequest();
            www.Dispose();
        }
    }

    public void Continue()
    {
        if(lastScene != 0)
        SceneManager.LoadScene(lastScene);
    }

    public void LoadStat()
    {
        StartCoroutine(GetSaveRequest());
        StartCoroutine(GetLastScene());
        GetLastScene();
    }

    public void SaveStat()
    {
        StartCoroutine(CreateSaveRequest());
    }

    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [System.Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }

    [Serializable]
    public class UserObject
    {
        public int userId;
        public int id;
        public string title;
        public string body;
    }

    [Serializable]
    public class RootObject
    {
        public GetSaveAnswer[] saves;
    }
}

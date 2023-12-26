using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Networking;

public class Progress : MonoBehaviour
{
    public string playerId;
    public int techStat;
    public int progStat;
    public int sysStat;
    public int lastScene;
    public bool[] techLevelsComplete;
    public bool[] progLevelsComplete;
    public bool[] sysLevelsComplete;

    public static Progress Instance;

    public void Awake()
    {
        techLevelsComplete = new bool[5];
        progLevelsComplete = new bool[5];
        sysLevelsComplete = new bool[5];
        for (int i = 0; i < 5; i++)
        {
            techLevelsComplete[i] = false;
            progLevelsComplete[i] = false;
            sysLevelsComplete[i] = false;
        }
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
    }

    public IEnumerator GetPlayerId()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost:8081/api/account/me"))
        {
            www.SetRequestHeader("Authorization", "Bearer " + GameLoginControler.LoginController.accessToken);
            yield return www.SendWebRequest();
            int idIndex1 = www.downloadHandler.text.LastIndexOf("id");
            int idIndex2 = www.downloadHandler.text.LastIndexOf("username");
            playerId = www.downloadHandler.text.Substring(idIndex1 + 4, idIndex2 - 8);
            www.Dispose();

        }
    }

    public void Test()
    {
        StartCoroutine(GetPlayerId());
        GetPlayerId();
        SaveStat();
    }

    public int techStatCalc()
    {
        int levelCount = 0;
        foreach (bool levelComplete in techLevelsComplete)
        {
            if (levelComplete) levelCount++;
        }
        return levelCount;
    }

    public int progStatCalc()
    {
        int levelCount = 0;
        foreach (bool levelComplete in progLevelsComplete)
        {
            if (levelComplete) levelCount++;
        }
        return levelCount;
    }

    public int sysStatCalc()
    {
        int levelCount = 0;
        foreach (bool levelComplete in sysLevelsComplete)
        {
            if (levelComplete) levelCount++;
        }
        return levelCount;
    }

    public void SaveStat()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.streamingAssetsPath + "/" + playerId + "save.dat");

        StatSave stat = new StatSave();
        stat.techLevelsCompleteSaved = techLevelsComplete;
        stat.progLevelsCompleteSaved = progLevelsComplete;
        stat.sysLevelsCompleteSaved = sysLevelsComplete;
        bf.Serialize(file, stat);
        file.Close();
        Debug.Log(techStat);
        Debug.Log(progStat);
        Debug.Log(sysStat);
    }

    public void LoadStat()
    {
        if (!File.Exists(Application.streamingAssetsPath + "/" + playerId + "save.dat"))
            return;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.streamingAssetsPath + "/" + playerId + "save.dat", FileMode.Open);

        StatSave stat = (StatSave)bf.Deserialize(file);
        techLevelsComplete = stat.techLevelsCompleteSaved;
        progLevelsComplete = stat.progLevelsCompleteSaved;
        sysLevelsComplete = stat.sysLevelsCompleteSaved;
        techStat = techStatCalc();
        progStat = progStatCalc();
        sysStat = sysStatCalc();
        file.Close();
    }

    [System.Serializable]
    public class StatSave
    {
        public bool[] techLevelsCompleteSaved;
        public bool[] progLevelsCompleteSaved;
        public bool[] sysLevelsCompleteSaved;
    }
}

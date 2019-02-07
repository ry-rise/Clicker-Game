using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private Player player;
    private UIManager iManager;
    private readonly string FileName = "//SaveData.json";
    private float time;
    public bool isRandomDrop = false;
    [SerializeField] private GameObject randomObject;

    private void Awake ()
    {
        player = gameObject.GetComponent<Player>();
        iManager = gameObject.GetComponent<UIManager>();
        if (File.Exists($"{Application.persistentDataPath}{FileName}") == true)
        {
            Debug.Log("LOAD");
            DataLoad();
        }
        else
        {
            Debug.LogWarning("Data Not Found");
        }
    }

    private void Update ()
    {
        //秒で増える
        time += Time.deltaTime;
        if (time >= 1.0f)
        {
            player.TotalIncrementSecond = player.Item1IncrementSecond * player.Item1Multiple;
            player.Money += player.TotalIncrementSecond;
            player.CumulativeMoney += player.TotalIncrementSecond;
            iManager.PersecondText.text = $"PerSecond { player.TotalIncrementSecond.ToString()}";
            iManager.MoneyText.text = $"¥ {player.Money.ToString()}";
            RandomDrop();
            time = 0;
        }
    }
    
    /// <summary>
    /// バックグラウンド判定
    /// </summary>
    /// <param name="pause"></param>
    private void OnApplicationPause(bool pause)
    {
        if (pause == true)
        {
            Debug.Log("SAVE_Background");
            DataSave();
        }
    }
    /// <summary>
    /// アプリ終了時に呼び出し
    /// </summary>
    private void OnApplicationQuit()
    {
        Debug.Log("SAVE");
        DataSave();
    }
    /// <summary>
    /// ランダムドロップ
    /// </summary>
    private void RandomDrop()
    {
        if (!isRandomDrop)
        {
            if (Random.Range(0, 100) == 0)
            {
                GameObject obj = Instantiate(randomObject, transform);
                obj.transform.SetParent(transform.Find("Image_Home"));
                isRandomDrop = true;
            }
        }
    }
    ///<summary>
    ///ファイルをセーブ
    ///</summary>
    public void DataSave()
    {
        GameData data = new GameData()
        {
            User = player.User,
            Money = player.Money,
            CumulativeMoney = player.CumulativeMoney,
            TotalIncrementSecond = player.TotalIncrementSecond,
        };
        string json = JsonUtility.ToJson(data); //Jsonデータ
        string path = $"{Application.persistentDataPath}{FileName}";
        File.WriteAllText(path, json); //保存
    }
    ///<summary>
    ///ファイルをロード
    ///</summary>
    public void DataLoad()
    {
        string path = $"{Application.persistentDataPath}{FileName}";
        string json = File.ReadAllText(path);//読み込み
        GameData restoreData = JsonUtility.FromJson<GameData>(json);//復元データ
        player.User = restoreData.User;
        player.Money = restoreData.Money;
        player.CumulativeMoney = restoreData.CumulativeMoney;
        player.TotalIncrementSecond = restoreData.TotalIncrementSecond;
    }
}

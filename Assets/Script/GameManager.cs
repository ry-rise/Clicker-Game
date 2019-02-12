using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private Player player;
    private Store store;
    private Upgrade upgrade;
    private UIManager iManager;
    public static readonly string FileName = "//SaveData.json";
    private float time;
    public bool isRandomDrop = false;
    [SerializeField] private GameObject randomObject;

    private void Awake ()
    {
        player = gameObject.GetComponent<Player>();
        store = transform.Find("Image_Store").gameObject.GetComponent<Store>();
        upgrade = transform.Find("Image_Upgrade").gameObject.GetComponent<Upgrade>();
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
            player.TotalIncrementSecond = ((player.Item1IncrementSecond * player.Item1Multiple) +
                                          (player.Item2IncrementSecond * player.Item2Multiple) +
                                          (player.Item3IncrementSecond * player.Item3Multiple) +
                                          (player.Item4IncrementSecond * player.Item4Multiple) +
                                          (player.Item5IncrementSecond * player.Item5Multiple));
            player.Money += player.TotalIncrementSecond;
            player.CumulativeMoney += player.TotalIncrementSecond;
            if (player.Money >= 100)
            {
                player.Money -= 100;
                player.User += 1;
            }
            iManager.PersecondText.text = $"PerSecond { player.TotalIncrementSecond.ToString()}";
            iManager.MoneyText.text = $"¥ {player.Money.ToString()}";
            iManager.UserText.text = $"{player.User.ToString()} User";
            RandomDrop();
            Debug.Log(player.TotalIncrementSecond);
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
            Item1IncrementSecond = player.Item1IncrementSecond,
            Item2IncrementSecond = player.Item2IncrementSecond,
            Item3IncrementSecond = player.Item3IncrementSecond,
            Item4IncrementSecond = player.Item4IncrementSecond,
            Item5IncrementSecond = player.Item5IncrementSecond,
            Item1Multiple = player.Item1Multiple,
            Item2Multiple = player.Item2Multiple,
            Item3Multiple = player.Item3Multiple,
            Item4Multiple = player.Item4Multiple,
            Item5Multiple = player.Item5Multiple,
            StorePrice = store.Price,
            StoreQuantity=store.Quantity,
            UpgradePrice=upgrade.Price,
            UpgradeMultiple=upgrade.Multiple
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
        player.Item1IncrementSecond = restoreData.Item1IncrementSecond;
        player.Item2IncrementSecond = restoreData.Item2IncrementSecond;
        player.Item3IncrementSecond = restoreData.Item3IncrementSecond;
        player.Item4IncrementSecond = restoreData.Item4IncrementSecond;
        player.Item5IncrementSecond = restoreData.Item5IncrementSecond;
        player.Item1Multiple = restoreData.Item1Multiple;
        player.Item2Multiple = restoreData.Item2Multiple;
        player.Item3Multiple = restoreData.Item3Multiple;
        player.Item4Multiple = restoreData.Item4Multiple;
        player.Item5Multiple = restoreData.Item5Multiple;
        store.Price = restoreData.StorePrice;
        store.Quantity = restoreData.StoreQuantity;
        upgrade.Price=restoreData.UpgradePrice;
        upgrade.Multiple = restoreData.UpgradeMultiple;


    }
}

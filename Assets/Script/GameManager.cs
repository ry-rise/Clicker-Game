using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Player player;
    private UIManager iManager;
    private float time;
    public bool isRandomDrop = false;
    [SerializeField] private GameObject randomObject;

    private void Awake()
    {
        DataLoad();
    }
    private void Start ()
    {
        player = gameObject.GetComponent<Player>();
        iManager = gameObject.GetComponent<UIManager>();
        //player.TotalIncrementSecond = 0;
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
        if(pause==true)
        {
            Debug.Log("SAVE");
            DataSave();
        }
        else
        {

        }
    }

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
            if (Random.Range(0, 10) == 0)
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
    private void DataSave()
    {
        var data = new GameData() { User = player.User, Money = player.Money,
                                    CumulativeMoney=player.CumulativeMoney,TotalIncrementSecond=player.TotalIncrementSecond};
        var json = JsonUtility.ToJson(data);//Jsonデータ

        var path = $"{Application.persistentDataPath}\\data.json";
        File.WriteAllText(path, json);//保存

        //json = File.ReadAllText(path);//読み込み
        //var data2 = JsonUtility.FromJson<GameData>(json);//復元データ
    }
    ///<summary>
    ///ファイルをロード
    ///</summary>
    private void DataLoad()
    {
        var path = $"{Application.persistentDataPath}\\data.json";
        var json = File.ReadAllText(path);//読み込み
        var data2 = JsonUtility.FromJson<GameData>(json);//復元データ
    }
}

using UnityEngine;
using UnityEngine.UI;

// TODO: Clickってクラス名よくない。
// 何をする役割なのか分かりやすい名詞表現で。
public class UIManager : MonoBehaviour {

    // TODO: スコアどこに配置するのが適切か考える
    // 別途スコア管理するやつ（べたな名前だとスコアマネージャー的な）が必要
    [SerializeField] private GameObject home;
    [SerializeField] private GameObject store;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject upgrade;
    private GameObject itemUpgrade;
    private GameObject item;
    public Text UserText { get; private set; }
    private Text MoneyText;
    public Text ItemPriceText { get; private set; }
    public Text ItemQuantityText { get; private set; }
    public Text UpgradePriceText { get; private set; }
    public Text UpgradeMultipleText { get; private set; }
    public Text PersecondText { get; private set; }
    private Player player;
    private Store storeScript;
    private Upgrade upgradeScript;

    private void Start()
    {
        //Player
        player = GameObject.Find("Player").GetComponent<Player>();
        //タブ
        itemUpgrade=GameObject.Find("Canvas").transform.Find("Image_Upgrade/Button_ItemUpgrade_1").gameObject;
        item = GameObject.Find("Canvas").transform.Find("Image_Store/Button_Item_1").gameObject;
        storeScript = GameObject.Find("Canvas").transform.Find("Image_Store").GetComponent<Store>();
        upgradeScript = GameObject.Find("Canvas").transform.Find("Image_Upgrade").GetComponent<Upgrade>();
        //テキスト
        UserText =GameObject.Find("Canvas").transform.Find("Header/Text_User").GetComponent<Text>();
        UserText.text = $"{player.Score.ToString()} User";
        MoneyText = GameObject.Find("Canvas").transform.Find("Header/Text_Money").GetComponent<Text>();
        MoneyText.text = $"¥ {player.Money.ToString()}";
        ItemPriceText = item.transform.Find("Price").GetComponent<Text>();
        ItemQuantityText = item.transform.Find("Quantity").GetComponent<Text>();
        UpgradePriceText = itemUpgrade.transform.Find("Price").GetComponent<Text>();
        PersecondText = GameObject.Find("Canvas").transform.Find("Image_Home/Text_PerSecond").GetComponent<Text>();
        PersecondText.text = "PerSecond " + 0;
        UpgradeMultipleText= itemUpgrade.transform.Find("Multiple").GetComponent<Text>();
        UpgradeMultipleText.text = "1";

    }

    void Update ()
    {
        // TODO: 毎フレーム計算するの無駄
        // score が変更されたときに↓の計算する
        //scoretext.text = score.ToString() + " Byte";
	}

    public void OnClick(GameObject buttonObject)
    {
        //増えるボタンを押すと
        if (buttonObject.name == "Button_Increase")
        {
            player.Score += 1;
            UserText.text = player.Score.ToString() + " User";
        }
        //アイテムボタンを押すと
        if (buttonObject.name == "Button_Item_1")
        {
            if (player.Score >= storeScript.Price)
            {
                //スコアから値段を引く
                player.Score -= storeScript.Price;
                //数を増やす
                storeScript.Quantity += 1;
                //値段を上げる
                storeScript.Price += 10;
                player.Item1IncrementSecond += 1;
                UserText.text = player.Score.ToString() + " User";
                ItemQuantityText.text = storeScript.Quantity.ToString();
                ItemPriceText.text = storeScript.Price.ToString();
                PersecondText.text = "PerSecond " + player.TotalIncrementSecond.ToString();
            }
        }
        if (buttonObject.name == "Button_ItemUpgrade_1")
        {
            if (player.Score >= upgradeScript.Price)
            {
                player.Score -= upgradeScript.Price;
                upgradeScript.Price += 10;
                //倍率を上げる
                player.Item1Multiple += 1;
                upgradeScript.Multiple += 1;
                UpgradePriceText.text = upgradeScript.Price.ToString();
                UpgradeMultipleText.text = "×" + upgradeScript.Multiple.ToString();
            }
        }
    }
}


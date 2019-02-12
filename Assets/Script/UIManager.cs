using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject home;
    [SerializeField] private GameObject store;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject upgrade;
    private GameObject[] itemUpgrade;
    private GameObject[] item;
    public Text UserText { get; private set; }
    public Text MoneyText { get; private set; }
    public Text[] ItemPriceText { get; private set; }
    public Text[] ItemQuantityText { get; private set; }
    public Text[] UpgradePriceText { get; private set; }
    public Text[] UpgradeMultipleText { get; private set; }
    public Text PersecondText { get; private set; }
    private GameManager gameManager;
    private Player player;
    private Store storeScript;
    private Upgrade upgradeScript;

    private void Start()
    {
        GetGameObject();
        Initialize();
    }
    private void GetGameObject()
    {
        item = new GameObject[5];
        itemUpgrade = new GameObject[5];
        ItemPriceText = new Text[5];
        ItemQuantityText = new Text[5];
        UpgradePriceText = new Text[5];
        UpgradeMultipleText = new Text[5];
        gameManager = gameObject.GetComponent<GameManager>();
        player = gameObject.GetComponent<Player>();
        //タブ

        storeScript = gameObject.transform.Find("Image_Store").GetComponent<Store>();
        upgradeScript = gameObject.transform.Find("Image_Upgrade").GetComponent<Upgrade>();
        //テキスト
        UserText = gameObject.transform.Find("Header/Text_User").GetComponent<Text>();
        MoneyText = gameObject.transform.Find("Header/Text_Money").GetComponent<Text>();
        PersecondText = gameObject.transform.Find("Image_Home/Text_PerSecond").GetComponent<Text>();
        itemUpgrade[0] = gameObject.transform.Find("Image_Upgrade/Button_ItemUpgrade_1").gameObject;
        item[0] = gameObject.transform.Find("Image_Store/Button_Item_1").gameObject;
        itemUpgrade[1] = gameObject.transform.Find("Image_Upgrade/Button_ItemUpgrade_2").gameObject;
        item[1] = gameObject.transform.Find("Image_Store/Button_Item_2").gameObject;
        itemUpgrade[2] = gameObject.transform.Find("Image_Upgrade/Button_ItemUpgrade_3").gameObject;
        item[2] = gameObject.transform.Find("Image_Store/Button_Item_3").gameObject;
        itemUpgrade[3] = gameObject.transform.Find("Image_Upgrade/Button_ItemUpgrade_4").gameObject;
        item[3] = gameObject.transform.Find("Image_Store/Button_Item_4").gameObject;
        itemUpgrade[4] = gameObject.transform.Find("Image_Upgrade/Button_ItemUpgrade_5").gameObject;
        item[4] = gameObject.transform.Find("Image_Store/Button_Item_5").gameObject;

        {
            ItemPriceText[0] = item[0].transform.Find("Price").gameObject.GetComponent<Text>();
            ItemQuantityText[0] = item[0].transform.Find("Quantity").GetComponentInChildren<Text>();
            UpgradePriceText[0] = itemUpgrade[0].transform.Find("Price").GetComponent<Text>();
            UpgradeMultipleText[0] = itemUpgrade[0].transform.Find("Multiple").GetComponent<Text>();
            ItemPriceText[1] = item[1].transform.Find("Price").GetComponent<Text>();
            ItemQuantityText[1] = item[1].transform.Find("Quantity").GetComponentInChildren<Text>();
            UpgradePriceText[1] = itemUpgrade[1].transform.Find("Price").GetComponent<Text>();
            UpgradeMultipleText[1] = itemUpgrade[1].transform.Find("Multiple").GetComponent<Text>();
            ItemPriceText[2] = item[2].transform.Find("Price").GetComponent<Text>();
            ItemQuantityText[2] = item[2].transform.Find("Quantity").GetComponentInChildren<Text>();
            UpgradePriceText[2] = itemUpgrade[2].transform.Find("Price").GetComponent<Text>();
            UpgradeMultipleText[2] = itemUpgrade[2].transform.Find("Multiple").GetComponent<Text>();
            ItemPriceText[3] = item[3].transform.Find("Price").GetComponent<Text>();
            ItemQuantityText[3] = item[3].transform.Find("Quantity").GetComponentInChildren<Text>();
            UpgradePriceText[3] = itemUpgrade[3].transform.Find("Price").GetComponent<Text>();
            UpgradeMultipleText[3] = itemUpgrade[3].transform.Find("Multiple").GetComponent<Text>();
            ItemPriceText[4] = item[4].transform.Find("Price").GetComponent<Text>();
            ItemQuantityText[4] = item[4].transform.Find("Quantity").GetComponentInChildren<Text>();
            UpgradePriceText[4] = itemUpgrade[4].transform.Find("Price").GetComponent<Text>();
            UpgradeMultipleText[4] = itemUpgrade[4].transform.Find("Multiple").GetComponent<Text>();

        }

    }
    private void Initialize()
    {

        UserText.text = $"{player.User.ToString()} User";
        MoneyText.text = $"¥ {player.Money.ToString()}";
        PersecondText.text = $"PerSecond {player.TotalIncrementSecond.ToString()}";
        //Debug.Log(upgradeScript.Price[0]);
        //UpgradePriceText[0].text = $"¥ {upgradeScript.Price[0].ToString()}";
        //UpgradePriceText[1].text = $"¥ {upgradeScript.Price[1].ToString()}";
        //UpgradePriceText[2].text = $"¥ {upgradeScript.Price[2].ToString()}";
        //UpgradePriceText[3].text = $"¥ {upgradeScript.Price[3].ToString()}";
        //UpgradePriceText[4].text = $"¥ {upgradeScript.Price[4].ToString()}";
        //UpgradeMultipleText[0].text = $"×{upgradeScript.Multiple[0].ToString()}";
        //UpgradeMultipleText[1].text = $"×{upgradeScript.Multiple[1].ToString()}";
        //UpgradeMultipleText[2].text = $"×{upgradeScript.Multiple[3].ToString()}";
        //UpgradeMultipleText[3].text = $"×{upgradeScript.Multiple[3].ToString()}";
        //UpgradeMultipleText[4].text = $"×{upgradeScript.Multiple[4].ToString()}";
    }
    public void OnClick(GameObject buttonObject)
    {
        //増えるボタンを押すと
        if (buttonObject.name == "Button_Increase")
        {
            player.Money += 1;
            MoneyText.text = $"¥ {player.Money.ToString()}";
        }
        //アイテムボタンを押すと
        if (buttonObject.name == "Button_Item_1")
        {
            if (player.Money >= storeScript.Price[0])
            {
                //スコアから値段を引く
                player.Money -= storeScript.Price[0];
                //数を増やす
                storeScript.Quantity[0] += 1;
                //値段を上げる
                storeScript.Price[0] += 10;
                player.Item1IncrementSecond += 1;
                MoneyText.text =$"¥ {player.Money.ToString()}";
                ItemQuantityText[0].text = storeScript.Quantity[0].ToString();
                ItemPriceText[0].text = $"¥ {storeScript.Price[0].ToString()}";
                PersecondText.text = "PerSecond " + player.TotalIncrementSecond.ToString();
            }
        }
        if (buttonObject.name == "Button_Item_2")
        {
            if (player.Money >= storeScript.Price[1])
            {
                //スコアから値段を引く
                player.Money -= storeScript.Price[1];
                //数を増やす
                storeScript.Quantity[1] += 1;
                //値段を上げる
                storeScript.Price[1] += 10;
                player.Item2IncrementSecond += 1;
                MoneyText.text = $"¥ {player.Money.ToString()}";
                ItemQuantityText[1].text =storeScript.Quantity[1].ToString();
                ItemPriceText[1].text = $"¥ {storeScript.Price[1].ToString()}";
                PersecondText.text = "PerSecond " + player.TotalIncrementSecond.ToString();
            }
        }
        if (buttonObject.name == "Button_Item_3")
        {
            if (player.Money >= storeScript.Price[2])
            {
                //スコアから値段を引く
                player.Money -= storeScript.Price[2];
                //数を増やす
                storeScript.Quantity[2] += 1;
                //値段を上げる
                storeScript.Price[2] += 10;
                player.Item3IncrementSecond += 1;
                MoneyText.text = $"¥ {player.Money.ToString()}";
                ItemQuantityText[2].text =storeScript.Quantity[2].ToString();
                ItemPriceText[2].text =$"¥ {storeScript.Price[2].ToString()}";
                PersecondText.text = "PerSecond " + player.TotalIncrementSecond.ToString();
            }
        }
        if (buttonObject.name == "Button_Item_4")
        {
            if (player.Money >= storeScript.Price[3])
            {
                //スコアから値段を引く
                player.Money -= storeScript.Price[3];
                //数を増やす
                storeScript.Quantity[3] += 1;
                //値段を上げる
                storeScript.Price[3] += 10;
                player.Item4IncrementSecond += 1;
                MoneyText.text = $"¥ {player.Money.ToString()}";
                ItemQuantityText[3].text =storeScript.Quantity[3].ToString();
                ItemPriceText[3].text =$"¥ {storeScript.Price[3].ToString()}";
                PersecondText.text = "PerSecond " + player.TotalIncrementSecond.ToString();
            }
        }
        if (buttonObject.name == "Button_Item_5")
        {
            if (player.Money >= storeScript.Price[4])
            {
                //スコアから値段を引く
                player.Money -= storeScript.Price[4];
                //数を増やす
                storeScript.Quantity[4] += 1;
                //値段を上げる
                storeScript.Price[4] += 10;
                player.Item5IncrementSecond += 1;
                MoneyText.text = $"¥ {player.Money.ToString()}";
                ItemQuantityText[4].text = storeScript.Quantity[4].ToString();
                ItemPriceText[4].text =$"¥ {storeScript.Price[4].ToString()}";
                PersecondText.text = "PerSecond " + player.TotalIncrementSecond.ToString();
            }
        }
        if (buttonObject.name == "Button_ItemUpgrade_1")
        {
            if (player.Money >= upgradeScript.Price[0])
            {
                player.Money -= upgradeScript.Price[0];
                upgradeScript.Price[0] += 10;
                //倍率を上げる
                player.Item1Multiple += 1;
                upgradeScript.Multiple[0] += 1;
                UpgradePriceText[0].text = $"¥ {upgradeScript.Price[0].ToString()}";
                UpgradeMultipleText[0].text = $"×{upgradeScript.Multiple[0].ToString()}";
            }
        }
        if (buttonObject.name == "Button_ItemUpgrade_2")
        {
            if (player.Money >= upgradeScript.Price[1])
            {
                player.Money -= upgradeScript.Price[1];
                upgradeScript.Price[1] += 10;
                //倍率を上げる
                player.Item2Multiple += 1;
                upgradeScript.Multiple[1] += 1;
                UpgradePriceText[1].text =$"¥ {upgradeScript.Price[1].ToString()}";
                UpgradeMultipleText[1].text = $"×{upgradeScript.Multiple[1].ToString()}";
            }
        }
        if (buttonObject.name == "Button_ItemUpgrade_3")
        {
            if (player.Money >= upgradeScript.Price[2])
            {
                player.Money -= upgradeScript.Price[2];
                upgradeScript.Price[2] += 10;
                //倍率を上げる
                player.Item3Multiple += 1;
                upgradeScript.Multiple[2] += 1;
                UpgradePriceText[2].text =$"¥ {upgradeScript.Price[2].ToString()}";
                UpgradeMultipleText[2].text = $"×{upgradeScript.Multiple[2].ToString()}";
            }
        }
        if (buttonObject.name == "Button_ItemUpgrade_4")
        {
            if (player.Money >= upgradeScript.Price[3])
            {
                player.Money -= upgradeScript.Price[3];
                upgradeScript.Price[3] += 10;
                //倍率を上げる
                player.Item4Multiple += 1;
                upgradeScript.Multiple[3] += 1;
                UpgradePriceText[3].text =$"¥ {upgradeScript.Price[3].ToString()}";
                UpgradeMultipleText[3].text = $"×{upgradeScript.Multiple[3].ToString()}";
            }
        }
        if (buttonObject.name == "Button_ItemUpgrade_5")
        {
            if (player.Money >= upgradeScript.Price[4])
            {
                player.Money -= upgradeScript.Price[4];
                upgradeScript.Price[4] += 10;
                //倍率を上げる
                player.Item5Multiple += 1;
                upgradeScript.Multiple[4] += 1;
                UpgradePriceText[4].text =$"¥ {upgradeScript.Price[4].ToString()}";
                UpgradeMultipleText[4].text = $"×{upgradeScript.Multiple[4].ToString()}";
            }
        }
        //ランダムドロップを押すと
        if (buttonObject.tag == "RandomDrop")
        {
            player.Money += 1000;
            Destroy(buttonObject);
            gameManager.isRandomDrop = false;
        }
    }
}


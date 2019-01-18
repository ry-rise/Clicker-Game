﻿using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject home;
    [SerializeField] private GameObject store;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject upgrade;
    private GameObject itemUpgrade;
    private GameObject item;
    private GameObject canvas;
    public Text UserText { get; private set; }
    public Text MoneyText { get; private set; }
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
        GetGameObject();
        Initialize();
    }
    private void GetGameObject()
    {
        canvas = gameObject;
        //Player
        player = gameObject.GetComponent<Player>();
        //タブ
        itemUpgrade = /*GameObject.Find("Canvas")*/canvas.transform.Find("Image_Upgrade/Button_ItemUpgrade_1").gameObject;
        item = GameObject.Find("Canvas").transform.Find("Image_Store/Button_Item_1").gameObject;
        storeScript = GameObject.Find("Canvas").transform.Find("Image_Store").GetComponent<Store>();
        upgradeScript = GameObject.Find("Canvas").transform.Find("Image_Upgrade").GetComponent<Upgrade>();
        //テキスト
        UserText = GameObject.Find("Canvas").transform.Find("Header/Text_User").GetComponent<Text>();
        MoneyText = GameObject.Find("Canvas").transform.Find("Header/Text_Money").GetComponent<Text>();
        ItemPriceText = item.transform.Find("Price").GetComponent<Text>();
        ItemQuantityText = item.transform.Find("Quantity").GetComponent<Text>();
        UpgradePriceText = itemUpgrade.transform.Find("Price").GetComponent<Text>();
        PersecondText = GameObject.Find("Canvas").transform.Find("Image_Home/Text_PerSecond").GetComponent<Text>();
        UpgradeMultipleText = itemUpgrade.transform.Find("Multiple").GetComponent<Text>();
    }
    private void Initialize()
    {
        UserText.text = $"{player.User.ToString()} User";
        MoneyText.text = $"¥ {player.Money.ToString()}";
        PersecondText.text = "PerSecond " + 0;
        UpgradeMultipleText.text = "1";
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
            if (player.Money >= storeScript.Price)
            {
                //スコアから値段を引く
                player.Money -= storeScript.Price;
                //数を増やす
                storeScript.Quantity += 1;
                //値段を上げる
                storeScript.Price += 10;
                player.Item1IncrementSecond += 1;
                MoneyText.text =$"¥ {player.Money.ToString()}";
                ItemQuantityText.text = storeScript.Quantity.ToString();
                ItemPriceText.text = storeScript.Price.ToString();
                PersecondText.text = "PerSecond " + player.TotalIncrementSecond.ToString();
            }
        }
        if (buttonObject.name == "Button_ItemUpgrade_1")
        {
            if (player.Money >= upgradeScript.Price)
            {
                player.Money -= upgradeScript.Price;
                upgradeScript.Price += 10;
                //倍率を上げる
                player.Item1Multiple += 1;
                upgradeScript.Multiple += 1;
                UpgradePriceText.text = upgradeScript.Price.ToString();
                UpgradeMultipleText.text = $"×{upgradeScript.Multiple.ToString()}";
            }
        }
    }
}


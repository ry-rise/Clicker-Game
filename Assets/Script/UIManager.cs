using UnityEngine;
using UnityEngine.UI;

// TODO: Clickってクラス名よくない。
// 何をする役割なのか分かりやすい名詞表現で。
public class UIManager : MonoBehaviour {

    // TODO: スコアどこに配置するのが適切か考える
    // 別途スコア管理するやつ（べたな名前だとスコアマネージャー的な）が必要
    private GameObject home;
    private GameObject store;
    private GameObject settings;
    private GameObject products;
    public Text scoreText { get; set; }
    public Text priceText { get; set; }
    public Text quantityText { get; set; }
    private Player player;
    private Store storeSctipt;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        home = GameObject.Find("Canvas").transform.Find("Image_Home").gameObject;
        store = GameObject.Find("Canvas").transform.Find("Image_Store").gameObject;
        storeSctipt = store.GetComponent<Store>();
        settings = GameObject.Find("Canvas").transform.Find("Image_Settings").gameObject;
        scoreText =GameObject.Find("Canvas").transform.Find("Image_Home/Text_Score").GetComponent<Text>();
        scoreText.text = player.Score.ToString() + " User";
        products = GameObject.Find("Canvas").transform.Find("Image_Store/Button_Item_1").gameObject;
        priceText = products.transform.Find("Price").GetComponent<Text>();
        quantityText = products.transform.Find("Quantity").GetComponent<Text>();
        home.SetActive(true);
        store.SetActive(false);
        settings.SetActive(false);
    }

    void Update ()
    {
        // TODO: 毎フレーム計算するの無駄
        // score が変更されたときに↓の計算する
        //scoretext.text = score.ToString() + " Byte";
	}

    public void OnClick()
    {
        if (transform.name == "Button_Increase")
        {
            player.Score += 1;
            scoreText.text = player.Score.ToString() + " User";
        }
        if (transform.name == "Button_Home")
        {
            home.SetActive(true);
            store.SetActive(false);
            settings.SetActive(false);
        }
        if (transform.name == "Button_Store")
        {
            home.SetActive(false);
            store.SetActive(true);
            settings.SetActive(false);
        }
        if (transform.name == "Button_Settings")
        {
            home.SetActive(false);
            store.SetActive(false);
            settings.SetActive(true);
        }
        if (transform.name == "Button_Item_1")
        {
            if (player.Score >=storeSctipt.price)
            {
                player.Score -= storeSctipt.price;
                storeSctipt.quantity += 1;
                storeSctipt.price += 10;
                scoreText.text = player.Score.ToString() + " User";
                quantityText.text = storeSctipt.quantity.ToString();
                priceText.text = storeSctipt.price.ToString();
            }
        }
    }
}

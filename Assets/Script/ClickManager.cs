using UnityEngine;
using UnityEngine.UI;

// TODO: Clickってクラス名よくない。
// 何をする役割なのか分かりやすい名詞表現で。
public class ClickManager : MonoBehaviour {

    // TODO: スコアどこに配置するのが適切か考える
    // 別途スコア管理するやつ（べたな名前だとスコアマネージャー的な）が必要
    private GameObject home;
    private GameObject store;
    private GameObject settings;
    private Text scoretext;
    private Player player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        home = GameObject.Find("Canvas").transform.Find("Image_Home").gameObject;
        store = GameObject.Find("Canvas").transform.Find("Image_Store").gameObject;
        settings = GameObject.Find("Canvas").transform.Find("Image_Settings").gameObject;
        scoretext = GameObject.Find("Text_Score").GetComponent<Text>();
        scoretext.text = player.score.ToString() + " User";
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
            player.score += 1;
            scoretext.text = player.score.ToString() + " User";
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
    }
}

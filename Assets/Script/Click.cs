using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour {
    private int score;
    private Text scoretext;

    void Start()
    {
        scoretext = GameObject.Find("Text_Score").GetComponent<Text>();
        scoretext.text = "0 G";
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
            score += 1;
            scoretext.text = score.ToString() + " G";
        }
        if (transform.name == "Button_Store")
        {
            SceneManager.LoadScene("");
        }
        if (transform.name == "Button_Desktop")
        {
            SceneManager.LoadScene("");
        }
    }
}

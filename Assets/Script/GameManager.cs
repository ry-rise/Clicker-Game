using UnityEngine;

public class GameManager : MonoBehaviour {
    private Player player;
    private UIManager iManager;
    //private float time;

	void Start ()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        iManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        //player.IncrementSecond = 1;
    }
    void Update ()
    {
        //time += Time.deltaTime;
        //player.Score += player.IncrementSecond * time;
        //iManager.scoreText.text = player.Score.ToString() + " User";
    }
}

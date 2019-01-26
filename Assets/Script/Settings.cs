using UnityEngine;

public class Settings : MonoBehaviour
{
    private GameManager gameManager;
    public float volume { get; set; }

    private void Awake()
    {
        gameManager = transform.root.gameObject.GetComponent<GameManager>();
    }

    public void OnClick(GameObject buttonObject)
    {
        if (buttonObject.name == "ButtonSave")
        {
            Debug.Log("SAVE_Settings");
            gameManager.DataSave();
        }
        if (buttonObject.name == "ButtonLoad")
        {
            Debug.Log("LOAD_Settings");
            gameManager.DataLoad();
        }
    }
}

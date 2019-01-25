using UnityEngine;

public class SettingButton : MonoBehaviour {
    private GameManager gameManager;

	private void Start ()
    {
        gameManager = transform.root.gameObject.GetComponent<GameManager>();
	}

    public void OnClick()
    {
        gameManager.OnClick(gameObject);
    }
	
	
}

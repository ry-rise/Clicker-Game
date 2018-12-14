using UnityEngine;

public class IncrementButton : MonoBehaviour {
    private UIManager iManager;
    private int ID;

	private void Start ()
    {
        iManager = transform.root.gameObject.GetComponent<UIManager>();
	}
    public void OnClick()
    {
        iManager.OnClick(gameObject);
    }
}

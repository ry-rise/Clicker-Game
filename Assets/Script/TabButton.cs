using UnityEngine;

public class TabButton : MonoBehaviour {
    [SerializeField] private GameObject holdObject;
    private TabManager tabManager;

    private void Start()
    {
        tabManager = GameObject.Find("Canvas").GetComponent<TabManager>();
    }
    public void OnClick()
    {
        tabManager.SetTab(holdObject);
    }
}

using UnityEngine;

public class TabButton : MonoBehaviour
{
    [SerializeField] private GameObject holdObject;
    private TabManager tabManager;

    private void Awake()
    {
        tabManager = transform.root.gameObject.GetComponent<TabManager>();
    }
    public void OnClick()
    {
        tabManager.SetTab(holdObject);
        tabManager.SetColor(gameObject);
    }
}

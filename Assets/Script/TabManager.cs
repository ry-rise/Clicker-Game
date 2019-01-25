using UnityEngine;

public class TabManager : MonoBehaviour
{
    [SerializeField] private GameObject home;
    [SerializeField] private GameObject store;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject upgrade;
    private GameObject oldTab = null;
    private GameObject newTab;

    private void Start ()
    {
        newTab = home;
        SetTab(newTab);
    }
    public void SetTab(GameObject newTab)
    {
        if (oldTab == null)
        {
            newTab.SetActive(true);
            oldTab = newTab;
            newTab = null;
        }
        else
        {
            oldTab.SetActive(false);
            newTab.SetActive(true);
            oldTab = newTab;
            newTab = null;
        }
    }
    public GameObject GetTab()
    {
        return oldTab;
    }
}

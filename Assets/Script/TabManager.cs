using UnityEngine;

public class TabManager : MonoBehaviour {
    private GameObject home;
    private GameObject store;
    private GameObject settings;

    void Start ()
    {
        //storeSctipt = store.GetComponent<Store>();
        home.SetActive(true);
        store.SetActive(false);
        settings.SetActive(false);
    }
	
	void Update ()
    {
		
	}

    public void SetTab(GameObject newTab)
    {

    }
}

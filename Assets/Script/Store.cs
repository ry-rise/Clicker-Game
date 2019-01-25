using UnityEngine;

public class Store : MonoBehaviour
{
    private UIManager iManager;
    public int Price { get; set; }
    public int Quantity { get; set; }
    GameObject[] Item;

    private void Start ()
    {
        Item = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount - 1; i += 1)
        {
            Item[i] = transform.GetChild(i).GetComponent<GameObject>();
        }
        
        iManager = transform.root.gameObject.GetComponent<UIManager>();
        //for (int i = 0; i < transform.childCount - 1; i += 1)
        {
            Price = int.Parse(iManager.ItemPriceText.text);
            Quantity = int.Parse(iManager.ItemQuantityText.text);
        }
	}
    
}

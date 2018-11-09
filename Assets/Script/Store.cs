using UnityEngine;

public class Store : MonoBehaviour {
    private UIManager iManager;
    public int Price { get; set; }
    public int Quantity { get; set; }

    void Start ()
    {
        iManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        Price = int.Parse(iManager.ItemPriceText.text);
        Quantity = int.Parse(iManager.ItemQuantityText.text);
	}
    
}

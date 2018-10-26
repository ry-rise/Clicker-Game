using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour {
    private UIManager iManager;
    public int price { get; set; }
    public int quantity { get; set; }

    void Start ()
    {
        iManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        price = int.Parse(iManager.priceText.text);
        quantity = int.Parse(iManager.quantityText.text);
	}
    
}

using UnityEngine;

public class Store : MonoBehaviour
{
    private UIManager iManager;
    public int[] Price { get; set; }
    public int[] Quantity { get; set; }
    GameObject[] Item;

    private void Awake ()
    {
        Item = new GameObject[5];
        Price = new int[5];
        Quantity = new int[5];
        for (int i = 0; i < 5; i += 1)
        {
            Item[i] = transform.GetChild(i).GetComponent<GameObject>();
        }
        
        iManager = transform.root.gameObject.GetComponent<UIManager>();
        //for (int i = 0; i < transform.childCount - 1; i += 1)
        //{
        //    Price[i] = int.Parse(iManager.ItemPriceText[i].text);
        //    Quantity[i] = int.Parse(iManager.ItemQuantityText[i].text);
        //}
	}
    
}

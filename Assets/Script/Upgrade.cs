using UnityEngine;

public class Upgrade : MonoBehaviour {
    private UIManager iManager;
    public int Price { get; set; }
    public int Multiple { get; set; }

    private void Start()
    {
        iManager = transform.root.gameObject.GetComponent<UIManager>();
        Price = int.Parse(iManager.UpgradePriceText.text);
        Multiple = int.Parse(iManager.UpgradeMultipleText.text);
    }

}

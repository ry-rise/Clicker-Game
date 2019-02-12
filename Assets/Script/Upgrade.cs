using System.IO;
using UnityEngine;

public class Upgrade : MonoBehaviour {
    private UIManager iManager;
    public int[] Price { get; set; }
    public int[] Multiple { get; set; }

    private void Awake()
    {
        Price = new int[5];
        Multiple = new int[5];
        if(File.Exists($"{Application.persistentDataPath}{GameManager.FileName}") == false)
        {
            Price[0] = 30;
            Price[1] = 40;
            Price[2] = 50;
            Price[3] = 60;
            Price[4] = 70;
            Multiple[0] = 1;
            Multiple[1] = 1;
            Multiple[2] = 1;
            Multiple[3] = 1;
            Multiple[4] = 1;

        }
        
        iManager = transform.root.gameObject.GetComponent<UIManager>();
        //for (int i = 0; i < transform.childCount; i += 1)
        //{
        //    Price[i] = int.Parse(iManager.UpgradePriceText[i].text);
        //    Multiple[i] = int.Parse(iManager.UpgradeMultipleText[i].text);
        //}
    }
}

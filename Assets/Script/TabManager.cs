using UnityEngine;
using UnityEngine.UI;

public class TabManager : MonoBehaviour
{
    [SerializeField] private GameObject home;
    [SerializeField] private GameObject store;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject upgrade;
    [SerializeField] private GameObject newFooter;
    private GameObject oldFooter = null;
    private GameObject oldTab = null;
    private GameObject newTab;

    private void Awake ()
    {
        newTab = home;
        SetTab(newTab);
        SetColor(newFooter);
    }
    public void SetTab(GameObject buttonTab)
    {
        if (oldTab == null)
        {
            buttonTab.SetActive(true);
            oldTab = buttonTab;
            buttonTab = null;
        }
        else
        {
            oldTab.SetActive(false);
            buttonTab.SetActive(true);
            oldTab = buttonTab;
            buttonTab = null;
        }
    }
    public void SetColor(GameObject footerObject)
    {        
        if (oldFooter == null)
        {
            Button newColor = newFooter.GetComponent<Button>();
            ColorBlock newColors = newColor.colors;
            newColors.normalColor = new Color(188f/255f, 188f/255f, 188f/255f);
            newColors.highlightedColor = new Color(188f / 255f, 188f / 255f, 188f / 255f);
            newColors.pressedColor = new Color(188f / 255f, 188f / 255f, 188f / 255f);
            newColors.disabledColor = new Color(188f / 255f, 188f / 255f, 188f / 255f);
            newColor.colors = newColors;
            oldFooter = newFooter;
            newFooter = null;
        }
        else
        {
            Button oldColor = oldFooter.GetComponent<Button>();
            ColorBlock oldColors = oldColor.colors;
            oldColors.normalColor = new Color(255f/255f, 255f/255f, 255f/255f);
            oldColors.highlightedColor = new Color(255f / 255f, 255f / 255f, 255f / 255f);
            oldColors.pressedColor = new Color(255f / 255f, 255f / 255f, 255f / 255f);
            oldColors.disabledColor = new Color(255f / 255f, 255f / 255f, 255f / 255f);
            oldColor.colors = oldColors;

            Button NewColor = footerObject.GetComponent<Button>();
            ColorBlock NewColors = NewColor.colors;
            NewColors.normalColor = new Color(188f/255f, 188f/255f, 188f/255f);
            NewColors.highlightedColor = new Color(188f / 255f, 188f / 255f, 188f / 255f);
            NewColors.pressedColor = new Color(188f / 255f, 188f / 255f, 188f / 255f);
            NewColors.disabledColor = new Color(188f / 255f, 188f / 255f, 188f / 255f);
            NewColor.colors = NewColors;

            oldFooter = footerObject;
            newFooter = null;
        }
    }
}

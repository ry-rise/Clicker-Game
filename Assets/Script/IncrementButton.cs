using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrementButton : MonoBehaviour {
    private UIManager iManager;

	void Start () {
        iManager = transform.root.gameObject.GetComponent<UIManager>();
	}

    public void OnClick()
    {
        iManager.OnClick(gameObject);
    }
}

﻿using UnityEngine;

public class SettingButton : MonoBehaviour {
    private Settings settings;

	private void Start ()
    {
        settings = transform.parent.gameObject.GetComponent<Settings>();
	}

    public void OnClick()
    {
        settings.OnClick(gameObject);
    }
	
	
}

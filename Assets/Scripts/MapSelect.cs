using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelect : MonoBehaviour {
    private Image image;
    public InformationScript info;
	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
        Debug.Log(image.name); 
        
	}
	
	public void SelectMap()
    {
        info.map = image.sprite.name;
        PlayerPrefs.SetString("Map", image.sprite.name);
        Debug.Log("You have selected the " + info.map + " map");
    }
}

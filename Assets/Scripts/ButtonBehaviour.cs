using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonBehaviour : MonoBehaviour {

    private Vector2 biggerV2;
    private Vector2 normalV2;
    
    void Start () {
        
        normalV2 = new Vector2(transform.localScale.x, transform.localScale.y);
        biggerV2 = new Vector2(transform.localScale.x + (transform.localScale.x * 0.2f), transform.localScale.y + (transform.localScale.y * 0.2f));
	}
	
	// Update is called once per frame
	void Update () {
		if(EventSystem.current.currentSelectedGameObject == this.gameObject)
        {
            transform.localScale = new Vector2(biggerV2.x ,biggerV2.y);
           
        }
        else
        {
            transform.localScale = new Vector2(normalV2.x, normalV2.y);
            
        }
	}

    


}

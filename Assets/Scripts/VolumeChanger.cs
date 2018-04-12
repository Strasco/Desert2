using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour {
    [SerializeField]
    private Slider slider;
    private Text text;
    
    public InformationScript info;
	// Use this for initialization
	void Start()
    {
        text = GetComponent<Text>();
    }
	// Update is called once per frame
	void Update () {
        text.text = slider.value+"%";
        AudioListener.volume = slider.value/100;
	}

    public void setAudioSetting()
    {
        info.masterAudioSettings = slider.value / 100;
        PlayerPrefs.SetFloat("AudioLevel", info.masterAudioSettings);
        Debug.Log(info.masterAudioSettings);
    }
}

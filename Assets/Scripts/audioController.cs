using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour {

    public Sprite[] sprites;
    AudioSource audio;
    public SpriteRenderer button;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	public void handleClick() {
        if (audio.isPlaying) {
            button.sprite = sprites[0];
            audio.Stop();
        }
        else
        {
            audio.Play();
            button.sprite = sprites[1];
        }
    }

    
    // void OnTriggerEnter(Collider other){
    //     Debug.Log(other);
    // }
}

using UnityEngine;
using System.Collections;

//附加音效播放器組件
[RequireComponent (typeof (AudioSource))]
public class OpenDown : MonoBehaviour {

	public AudioClip openAudio;//開啟音效
	public AudioClip downAudio;//關閉音效

	bool open;

	Animation anim;
	AudioSource audio;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation> ();
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Switch (){
		if (!anim.isPlaying){//沒有播放任何動畫
			open = !open;
			if (open){//開啟
				anim.Play("open");
				audio.PlayOneShot(openAudio);
			}
			else{//關閉
				anim.Play("down");
				audio.PlayOneShot(downAudio);
			}
		}		
		
	}
}

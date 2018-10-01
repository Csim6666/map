using UnityEngine;
using System.Collections;

//附加音效播放器組件
[RequireComponent (typeof (AudioSource))]
public class PlayMovie : MonoBehaviour {

	bool open;

	// Use this for initialization
	void Start () {

		GetComponent<Renderer>().material.color = new Color(0,0,0,255);//材質球顏色=黑、不透明
		(GetComponent<Renderer>().material.mainTexture as MovieTexture).Stop();//停止播放
		(GetComponent<Renderer>().material.mainTexture as MovieTexture).loop = true;//播放模式，循環
		GetComponent<AudioSource>().loop = true;//播放音效模式，循環
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Switch (){

		open=!open;
		if (open){
			GetComponent<Renderer>().material.color= new Color(1,1,1,0);//材質球顏色=白、透明
			(GetComponent<Renderer>().material.mainTexture as MovieTexture).Play();//播放
		}
		else{
			GetComponent<Renderer>().material.color= new Color(0,0,0,255);//材質球顏色=黑、不透明
			(GetComponent<Renderer>().material.mainTexture as MovieTexture).Stop();//停止播放
		}
	}
}

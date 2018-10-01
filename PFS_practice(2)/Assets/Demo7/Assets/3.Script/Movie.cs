using UnityEngine;
using System.Collections;

//附加音效播放器組件
[RequireComponent (typeof (AudioSource))]
public class Movie : MonoBehaviour {

	bool open;

	Material mat;
	MovieTexture movie;

	// Use this for initialization
	void Start () {

		mat = GetComponent<Renderer> ().material;
		movie = mat.mainTexture as MovieTexture;	

		mat.color = new Color(0,0,0,255);//材質球顏色=黑、不透明
		movie.loop = true;//播放模式，循環
		GetComponent<AudioSource>().loop = true;//播放音效模式，循環
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Switch (){

		open=!open;

		if (open){
			mat.color = new Color(1,1,1,0);//材質球顏色=白、透明
			movie.Play();//播放
		}
		else{
			mat.color = new Color(0,0,0,255);//材質球顏色=黑、不透明
			movie.Stop();//停止播放
		}
	}
}

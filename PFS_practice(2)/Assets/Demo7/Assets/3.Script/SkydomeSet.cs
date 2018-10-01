using UnityEngine;
using System.Collections;

public class SkydomeSet : MonoBehaviour {

	public GUIText skydomeGui;//提示文字的GUI
	
	bool a;
	
	skydomeScript2 setSky;

	// Use this for initialization
	void Start () {
		//搜尋名稱為skydome的物件，獲取名稱為skydomeScript2的腳本
		setSky = GameObject.Find("skydome").GetComponent<skydomeScript2>();
		skydomeGui.material.color = Color.red;
		skydomeGui.enabled =false;
	}
	
	// Update is called once per frame
	void Update () {
		if (a){//判斷是否有進入觸發框
			if (Input.GetKeyDown("tab")){
				setSky.debug = !setSky.debug;
				CharacterMove.isGui = !CharacterMove.isGui;	
			}
			if (!setSky.debug)
				skydomeGui.text = "按下Tab設定";
			else	
				skydomeGui.text = "按下Tab結束設定";
		}    		
	}

	//進入觸發框，可以啟動設定
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player"){
			skydomeGui.enabled =true;
			a = true;
		}					
	}
	//離開觸發框，不能啟動設定
	void OnTriggerExit (Collider other) {
		skydomeGui.enabled =false;
		a = false;
	}
}

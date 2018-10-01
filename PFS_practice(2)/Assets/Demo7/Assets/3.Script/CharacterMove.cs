using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]
public class CharacterMove : MonoBehaviour {

	public LayerMask hitLayer;//射線使用層
	public Transform myCursor;//光標物件
	public Texture[] mouse_pic;//游標圖片

	int i = 0;//游標參數
	float walkSp = 1.04f;//走路速度
	Vector3 pos;//移動座標
	Transform Switch;//物件開關

	public static bool isGui;//GUI隔絕射線

	// Use this for initialization
	void Start () {
	
		Cursor.visible = false;//隱藏預設鼠標

		myCursor.gameObject.SetActiveRecursively(false);
		myCursor.GetComponent<Animation>().wrapMode = WrapMode.Loop;//游標動畫模式
		GetComponent<Animation>().wrapMode = WrapMode.Loop;//自身動畫模式
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		
		if (Physics.Raycast (ray, out hit, 100, hitLayer) && !isGui) {//射線偵測
			
			if (hit.transform.tag == "Switch"){//當碰到開關
				Switch = hit.transform;
				var SwitchPos = new Vector3(Switch.position.x,0,Switch.position.z);
				var myPos = new Vector3(transform.position.x,0,transform.position.z);
				var dist = Vector3.Distance(myPos,SwitchPos);
				if (dist > 0.2  && dist < 3){//能開啟的範圍
					i = 1;
					if (Input.GetMouseButtonDown(0)){
						Switch.SendMessageUpwards("Switch", SendMessageOptions.DontRequireReceiver);
						pos = transform.position;
					}
				}						
			}		
			else {//平常移動
				i = 0;	
				if (Input.GetMouseButtonDown(0))
				{			
					pos = hit.point;
					pos.y = 0.05f;
					myCursor.gameObject.SetActiveRecursively(true);//顯示光標
					myCursor.transform.position = pos;	
				}
			}			
			Debug.DrawLine (ray.origin, hit.point);
		}	
		MoveTowards(pos);
	}

	void MoveTowards (Vector3 position) {
		
		var forward = transform.TransformDirection(Vector3.forward);
		var direction = position - transform.position;
		direction.y = 0;
		
		if (direction.magnitude > 0.1f) {//人物轉身
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation(direction), 5 * Time.deltaTime);
			transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
		}
		else	
			myCursor.gameObject.SetActiveRecursively(false);//隱藏光標
		
		var speedModifier = Vector3.Dot(forward, direction.normalized);
		speedModifier = Mathf.Clamp01(speedModifier);
		direction = forward * walkSp * speedModifier;
		GetComponent<CharacterController>().SimpleMove(direction);//人物移動
		
		playAnimation(1 * speedModifier);
	}
	
	void playAnimation (float speed) {//腳色動畫
		if (speed > 0.5 )
			GetComponent<Animation>().CrossFade("walk");
		else
			GetComponent<Animation>().CrossFade("idle2");
	}
	
	void OnGUI() {//顯示鼠標與鼠標位置
		GUI.depth = 0;
		var mouse_pos=Input.mousePosition;
		GUI.DrawTexture(new Rect(mouse_pos.x,Screen.height-mouse_pos.y,64,64),mouse_pic[i]);
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AutoWayPoint : MonoBehaviour {

    //存路徑點
	public List<AutoWayPoint> connected = new List<AutoWayPoint> ();

    //一格陣列
	static AutoWayPoint[] waypoints = new AutoWayPoint[0];

	void Awake () {

		RebuildWaypointList();
	}

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    //機器人找最近的點跑
	static public AutoWayPoint FindClosest (Vector3 pos) {
		// The closer two vectors, the larger the dot product will be.
		AutoWayPoint closest = null;
		float closestDistance = 100000.0f;

		foreach (var cur in waypoints) {
			var distance = Vector3.Distance(cur.transform.position, pos);

			if (distance < closestDistance)
			{
				closestDistance = distance;
				closest = cur;
			}
		}
		
		return closest;
	}

	[ContextMenu ("Update Waypoints")]
	void UpdateWaypoints () {

		RebuildWaypointList();
	}

	// Draw the waypoint pickable gizmo
	void OnDrawGizmos() {

		Gizmos.DrawIcon (transform.position, "Waypoint.tif");
	}
	
	// Draw the waypoint lines only when you select one of the waypoints
	void OnDrawGizmosSelected () {

		if (waypoints.Length == 0)
			RebuildWaypointList();

		foreach (var p in connected) {

			if(p == null) 
			{
				connected.Remove(p);
				break;
			}

			if (Physics.Linecast(transform.position, p.transform.position)) {
				Gizmos.color = Color.red;
				Gizmos.DrawLine (transform.position, p.transform.position);
			} else {
				Gizmos.color = Color.green;
				Gizmos.DrawLine (transform.position, p.transform.position);
			}
		}
	}
	
    //awake時呼叫
	void RebuildWaypointList () {

		waypoints = FindObjectsOfType<AutoWayPoint> (); 
		
		foreach (var point in waypoints) {
			point.RecalculateConnectedWaypoints();
		}
	}
	
	void RecalculateConnectedWaypoints ()
	{
        //先清除arraylist中的值
		connected.Clear ();
		
		foreach (var other  in waypoints) {
			// Don't connect to ourselves
			if (other == this)
				continue;
			
			// Do we have a clear line of sight?
			if (!Physics.Linecast(transform.position, other.transform.position)) {
				connected.Add(other);
			}
		}	
	}
}

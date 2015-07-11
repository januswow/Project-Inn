using UnityEngine;
using System.Collections;

public class BuildingPlacment : MonoBehaviour {

	bool isMoving = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isMoving) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 8)) {
				Debug.Log(hit.collider);
				Transform hitPos = hit.collider.GetComponentInParent<Transform>();
				transform.position = new Vector3(hitPos.position.x, hitPos.position.y, 0);				
				//transform.position = new Vector3(hit.point.x, hit.point.y, 0);
			}
		}
	}

	void OnMouseDown () {
		Debug.Log("Building Clicked");
		isMoving = !isMoving;
	}
}

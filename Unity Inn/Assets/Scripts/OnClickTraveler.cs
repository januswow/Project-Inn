using UnityEngine;
using System.Collections;

public class OnClickTraveler : MonoBehaviour {
	GameObject gameGO;

	public Transform rootGO;

	// Use this for initialization
	void Start () {
		//gameGO = transform.find
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown () {
		Debug.Log(this.name);
		SetColor(Color.green);
		rootGO.Translate(Vector3.up);
	}

	private void SetColor(Color color) {
		MeshRenderer mr = GetComponent<MeshRenderer>();
		mr.material.SetColor("_Color", color);
	}
}

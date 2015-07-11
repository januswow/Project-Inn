using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProduceTraveler : MonoBehaviour {

	public GameObject travelerPrefab;
	public static List<GameObject> waitingTravelers = new List<GameObject>();

	int waitingMax = 6;

	// Use this for initialization
	void Start () {
		// 產生旅客
		GenerateTraveler();
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void GenerateTraveler () {
		if (waitingTravelers.Count < waitingMax) {
			GameObject newTraveler = Instantiate(travelerPrefab, new Vector3(waitingTravelers.Count*-1, 0, 0), Quaternion.identity) as GameObject;
			waitingTravelers.Add(newTraveler);


		}
		StartCoroutine("WaitingCounter");
	}

	IEnumerator WaitingCounter () {
		int waitingTime = Random.Range(1,3);
		yield return new WaitForSeconds(waitingTime);
		GenerateTraveler();
	}
}

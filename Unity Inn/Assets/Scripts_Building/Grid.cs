using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour {

	public GameObject tilePrefab;
	public int numberOfTiles = 25;
	public int numberOfRow = 5;
	public float tileSpacing = 1.0f;

	List<GameObject> tilesList = new List<GameObject>();

	// Use this for initialization
	void Start () {
		CreateTiles();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CreateTiles() {
		float offsetX = 0;
		float offsetY = 0;
		for ( int createdCount = 0; createdCount<numberOfTiles; createdCount++ ) {
			//產生位置
			if ( createdCount != 0 && createdCount % numberOfRow == 0) {
				Debug.Log (createdCount);
				offsetX = 0;
				offsetY += tileSpacing;
			}
			
			GameObject newTile = (GameObject)Instantiate(tilePrefab, new Vector3(transform.position.x + offsetX, transform.position.y + offsetY, transform.position.z), transform.rotation);
			tilesList.Add(newTile);

			offsetX += tileSpacing;
		}
	}
}

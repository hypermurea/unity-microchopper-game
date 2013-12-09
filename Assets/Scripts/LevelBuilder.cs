using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class LevelBuilder : MonoBehaviour {

	public GameObject ObstacleWall;
	public float WallInterval = 10f;
	public float MinY = .5f;
	public float MaxY = 6.5f;

	void Start () {
		GameObject parentWall = new GameObject("ParentWall");
		parentWall.transform.position = Vector3.zero;
		for( int w = 1; w < 1000; w++ )
		{
			GameObject go = (GameObject) Instantiate(
				ObstacleWall,
				new Vector3(
				w * WallInterval,
				Random.Range( MinY, MaxY ),
				0 ),
				Quaternion.identity ) as GameObject;
			go.transform.parent = parentWall.gameObject.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

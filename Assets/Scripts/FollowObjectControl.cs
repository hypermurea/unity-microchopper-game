using UnityEngine;
using System.Collections;

public class FollowObjectControl : MonoBehaviour {

	public GameObject GameObjectToFollow;
	public float OffsetX;
	public float LockedY;
	float OriginalZ;


	void Start () {
		OriginalZ = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(
			GameObjectToFollow.transform.position.x + OffsetX,
			LockedY,
			OriginalZ );
	}

}

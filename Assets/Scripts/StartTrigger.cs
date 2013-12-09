using UnityEngine;
using System.Collections;

public class StartTrigger : MonoBehaviour {

	public bool GoodToGo = false;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerExit( Collider c ) {
		if( c.gameObject.name == "Player" ) GoodToGo = true;
	}

	// Update is called once per frame
	void Update () {
	
	}
}

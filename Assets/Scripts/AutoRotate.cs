using UnityEngine;
using System.Collections;
public class AutoRotate : MonoBehaviour {
	
	public enum eRotationAxis { X, Y, Z };
	public eRotationAxis RotationAxis = eRotationAxis.X;
	public float RotationSpeed = 20;
	
	void Update ()
	{
		switch( RotationAxis ) {
		case eRotationAxis.X:
			transform.localEulerAngles = new Vector3(
				transform.localEulerAngles.x + RotationSpeed,
				transform.localEulerAngles.y,
				transform.localEulerAngles.z );
			break;
		case eRotationAxis.Y:
			transform.localEulerAngles = new Vector3(
				transform.localEulerAngles.x,
				transform.localEulerAngles.y + RotationSpeed,
				transform.localEulerAngles.z );
			break;
		case eRotationAxis.Z:
			transform.localEulerAngles = new Vector3(
				transform.localEulerAngles.x,
				transform.localEulerAngles.y,
				transform.localEulerAngles.z + RotationSpeed );
			break;
		}
	}
}

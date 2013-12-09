using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{

		public float ForcePower = 10000f;
		bool AddForce = false;
		GameLogic gameLogic;
		StartTrigger startTrigger;
		public float DistanceTravelled = 0;
		Vector3 originalStartingPoint;
		float   originalTimeScale;

		void Start ()
		{
				originalStartingPoint = transform.position;
				originalTimeScale = Time.timeScale;
				gameLogic = GameObject.FindWithTag ("GameLogic").GetComponent<GameLogic> ();
				startTrigger = GameObject.FindWithTag ("StartTrigger").GetComponent<StartTrigger> ();
		}
	
		void Update ()
		{
				switch (gameLogic.GameState) {
				case GameLogic.GameState_Starting:
						if (Input.GetMouseButtonUp (0) || Input.touchCount > 0) {
								gameLogic.GameState = GameLogic.GameState_InGame;
						}
						break;
				case GameLogic.GameState_InGame:
						if (Input.GetMouseButton (0) || Input.touchCount > 0) {
								AddForce = true;
						} else if (Input.GetMouseButtonUp (0) || Input.touchCount == 0) {
								AddForce = false;
						}
						if (AddForce) {
								rigidbody.AddForce (Vector3.up * ForcePower, ForceMode.Force);
						}
						if (startTrigger.GoodToGo) {
								rigidbody.AddForce (
					Vector3.right * (ForcePower * 0.2f), ForceMode.Force);
						}
						if (rigidbody.velocity.x > 10) {
								rigidbody.velocity = new Vector3 (
					10,
					rigidbody.velocity.y,
					0);
								DistanceTravelled = transform.position.x;
							
						}
			break;
				case GameLogic.GameState_GameOver:
						if (Input.GetMouseButtonUp (0) || Input.touchCount > 0) {
								Reset ();
								gameLogic.GameState = GameLogic.GameState_InGame;
								gameLogic.Reset ();
						}
						break;
				
				case GameLogic.GameState_Paused:
						break;
				}
		}

		void OnGUI ()
		{
				switch (gameLogic.GameState) {
				case GameLogic.GameState_Starting:
						GUI.Label (
				new Rect (
				(Screen.width / 2),
				(Screen.height / 2) - 45,
				200,
				90),
				"MICROCHOPPER\n\nTap to play.");
						break;
				case GameLogic.GameState_InGame:
						GUI.Label (
				new Rect (
				10,
				(Screen.height / 2) - 15,
				200,
				30),
				"Distance Travelled : " + DistanceTravelled.ToString ("f2"));
						break;
				case GameLogic.GameState_GameOver:
						GUI.Label (
				new Rect (
				(Screen.width / 2),
				(Screen.height / 2) - 60,
				200,
				120),
				"GAME OVER!\nDistance Travelled : " +
								DistanceTravelled.ToString ("f2") +
								"\n\nTap to play again.");
						break;
			
				case GameLogic.GameState_Paused:
						break;
				}
		}

		void OnCollisionEnter (Collision c)
		{
				if (gameLogic.GameState == GameLogic.GameState_InGame &&
						c.gameObject.name != "StartPlatform") {
						gameLogic.GameState = GameLogic.GameState_GameOver;
						Time.timeScale = 0;
						UnityMessaging.MessagingClient.Client.SendMessage ("gameover", DistanceTravelled.ToString("f2"));
				}
		}

		public void Reset ()
		{
				rigidbody.velocity = Vector3.zero;
				transform.position = originalStartingPoint;
				Time.timeScale = originalTimeScale;
		}


}

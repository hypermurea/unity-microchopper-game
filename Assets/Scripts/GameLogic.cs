using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

	PlayerControls playerControls;
	StartTrigger startTrigger;
	public float DifficultyFactor = 0.01f;
	float OriginalDifficultyScale;
	public GameObject WallCeiling;
	public GameObject WallFloor;

	public int GameState;
	public const int GameState_Starting = 0;
	public const int GameState_InGame   = 1;
	public const int GameState_GameOver = 2;
	public const int GameState_Paused   = 99;

	public class Highscores {
		public string Id { get; set; }
		public int Score { get; set; }
	}

	void Start () {
		GameState = GameState_Starting;
		OriginalDifficultyScale = WallCeiling.transform.localScale.y;
	}
	// Update is called once per frame
	void Update () {
		switch( GameState ) {
		case GameState_Starting:
			break;
		case GameState_InGame:
			float DifficultyScale = WallCeiling.transform.localScale.y +
				(DifficultyFactor * Time.deltaTime);
			WallCeiling.transform.localScale = new Vector3(
				WallCeiling.transform.localScale.x,
				DifficultyScale,
				WallCeiling.transform.localScale.z );
			WallFloor.transform.localScale = new Vector3(
				WallFloor.transform.localScale.x,
				DifficultyScale,
				WallFloor.transform.localScale.z );
			break;
			
		case GameState_GameOver:
			break;
			
		case GameState_Paused:
			break;
		}
	}

	public void Reset() {
		WallCeiling.transform.localScale = new Vector3(  
		                                               WallCeiling.transform.localScale.x,
		                                               OriginalDifficultyScale,
		                                               WallCeiling.transform.localScale.z );
		WallFloor.transform.localScale = new Vector3(
			WallFloor.transform.localScale.x,
			OriginalDifficultyScale,
			WallFloor.transform.localScale.z );
	}

}

using UnityEngine;
using System.Collections;

public class MazeLoader : MonoBehaviour {
	[SerializeField]
	int mazeRows, mazeColumns;
	[SerializeField] 
	GameObject wall;
	[SerializeField] 
	GameObject floorP;
	[SerializeField] 
	float size = 2f;
	[SerializeField]
	float offset = 1000f;
	private MazeCell[,] mazeCells;
	private MazeCell[,] mazeCells2;
	// Use this for initialization
	void Start () {
		mazeCells = new MazeCell[mazeRows, mazeColumns];
		mazeCells2 = new MazeCell[mazeRows, mazeColumns];
		InitializeMaze(mazeCells);
		InitializeMaze(mazeCells2,offset);
		MazeAlgorithm ma = new HuntAndKillMazeAlgorithm (mazeCells);
		MazeAlgorithm ma2 = new HuntAndKillMazeAlgorithm(mazeCells2);
		ma.CreateMaze ();
		ma2.CreateMaze();
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void InitializeMaze(MazeCell[,] mazeCells,float offset=0f) {

		//mazeCells = new MazeCell[mazeRows,mazeColumns];

		for (int r = 0; r < mazeRows; r++) {
			for (int c = 0; c < mazeColumns; c++) {
				mazeCells [r, c] = new MazeCell ();

				// For now, use the same wall object for the floor!
				mazeCells [r, c] .floor = Instantiate (floorP, new Vector3 (r*size + offset, -(size/2f), c*size), Quaternion.identity) as GameObject;
				mazeCells [r, c] .floor.name = "Floor " + r + "," + c;
				mazeCells [r, c] .floor.transform.Rotate (Vector3.right, 90f);
				if (r == mazeRows - 1 && c == mazeColumns - 1 || r==0 && c==0)
					continue;
				if (c == 0) {
					mazeCells[r,c].westWall = Instantiate (wall, new Vector3 (r*size + offset, 0, (c*size) - (size/2f)), Quaternion.identity) as GameObject;
					mazeCells [r, c].westWall.name = "West Wall " + r + "," + c;
				}

				mazeCells [r, c].eastWall = Instantiate (wall, new Vector3 (r*size + offset, 0, (c*size) + (size/2f)), Quaternion.identity) as GameObject;
				mazeCells [r, c].eastWall.name = "East Wall " + r + "," + c;

				if (r == 0) {
					mazeCells [r, c].northWall = Instantiate (wall, new Vector3 ((r*size) - (size/2f) + offset, 0, c*size), Quaternion.identity) as GameObject;
					mazeCells [r, c].northWall.name = "North Wall " + r + "," + c;
					mazeCells [r, c].northWall.transform.Rotate (Vector3.up * 90f);
				}

				mazeCells[r,c].southWall = Instantiate (wall, new Vector3 ((r*size) + (size/2f) + offset, 0, c*size), Quaternion.identity) as GameObject;
				mazeCells [r, c].southWall.name = "South Wall " + r + "," + c;
				mazeCells [r, c].southWall.transform.Rotate (Vector3.up * 90f);
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour {

    static public int height = 10;

    static public int width = 10;

    public Camera cam;

    public int xSpacing = 2;

    public int ySpacing = 2;

    public int xOrigin = 0;

    public int yOrigin = 0;

    public GameObject tilePrefab;

    public GameObject[,] tiles = new GameObject[height, width];

    private void generateBoard()
    {

        Vector2 spawnPos = new Vector2(xOrigin, yOrigin);

        for (int row = 0; row < height; ++row)
        {
            for (int col = 0; col < width; ++col)
            {
                Debug.Log("Placing tile at x = " + spawnPos.x + " y = " + spawnPos.y);
                tiles[row, col] = (GameObject)Instantiate(tilePrefab, spawnPos, Quaternion.identity);
                spawnPos.x = spawnPos.x + xSpacing;             
            }

            spawnPos.x = xOrigin;
            spawnPos.y = spawnPos.y - ySpacing;
        }

        //Hide prefab tile
        tilePrefab.GetComponent<Renderer>().enabled = false;
    }

	// Use this for initialization
	void Start () {
        generateBoard();

        
        if (height > width)
        {
            cam.orthographicSize = height*3;
        }

        else
        {
            cam.orthographicSize = width*3;
        }
        

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

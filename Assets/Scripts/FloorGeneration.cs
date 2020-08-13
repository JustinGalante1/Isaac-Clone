using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGeneration : MonoBehaviour
{
    [SerializeField]
    private int numberOfRooms;
    private int gridSize;

    private int numRoomsAdded;
    private bool[,] grid;
    private Room[] roomQueue;

    private void Start()
    {
        gridSize = numberOfRooms * 3;
        grid = new bool[gridSize, gridSize];
        (int x, int y) initialRoomCoordinate = (((int)(gridSize / 2) - 1), ((int)(gridSize / 2) - 1));
        grid[initialRoomCoordinate.x, initialRoomCoordinate.y] = true;
        (int x, int y) currentCoordinate = initialRoomCoordinate;

    }
}

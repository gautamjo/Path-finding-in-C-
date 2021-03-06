﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    // Use this for initialization
    void Start ()
    {
        LoadBlocks();
        ColorStartAndEnd();
        ExploreNeighbours();
    }

    private void ExploreNeighbours()
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = direction + startWaypoint.GetGridPos();

            try
            {
                grid[explorationCoordinates].SetTopColor(Color.blue);
            }

            catch
            {
                Debug.Log("Value does not exist");
            }

        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();

        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();

            if (!grid.ContainsKey(gridPos))
            {
                grid.Add(gridPos, waypoint);
            }
        }
    }   

    // Update is called once per frame
    void Update () {
		
	}
}

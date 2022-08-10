using System.Collections;
using System.Collections.Generic;
using Tritan.Obstacles;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(ObstacleManager))]
public class ObstacleManagerInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var obstacleManager = (ObstacleManager) target;
        
        // Add button for calling method from the inspector
        if (GUILayout.Button("Create Obstacle Cube"))
            obstacleManager.CreateObstacleCube();
    }
}

// Note: Odin Inspector is better way, but I haven't bought it yet.
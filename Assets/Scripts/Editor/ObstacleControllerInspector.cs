using System.Collections;
using System.Collections.Generic;
using Tritan.Obstacles;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(ObstacleAbstract), true)]
public class ObstacleControllerInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var obstacle = (ObstacleAbstract) target;
        
        // Add button for calling method from the inspector
        if (GUILayout.Button("Delete Obstacle"))
            obstacle.DeleteObstacle();
    }
}

// Note: Odin Inspector is better way, but I haven't bought it yet.

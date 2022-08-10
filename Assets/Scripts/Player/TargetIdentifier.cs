using System;
using System.Collections;
using System.Collections.Generic;
using Tritan.Inputs;
using Tritan.Obstacles;
using Tritan.Player;
using UnityEngine;


namespace Tritan.Player
{
    public class TargetIdentifier : MonoBehaviour
    {
        [SerializeField] private InputManager _InputManager;
        [SerializeField] private Camera _Camera;
        [SerializeField] private PlayerController _PlayerController;

        private int _layerMask;


        private void Start()
        {
            _InputManager.DidDeterminedTargetPosition += IdentifyTarget;
            
            // Just the ground and obstacles are allowed to touch
            _layerMask = LayerMask.GetMask("Ground", "Obstacle");
        }


        // Determine which object touched 
        private void IdentifyTarget(Vector3 mousePosition)
        {
            var ray = _Camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, _layerMask))
            {
                if (hit.transform.TryGetComponent(out ObstacleAbstract obstacleAbstract))
                    _PlayerController.MoveToObstacle(obstacleAbstract);
                else
                    _PlayerController.MoveToPosition(hit.point);
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Tritan.Player;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Tritan.Inputs
{
    public class InputManager : MonoBehaviour
    {
        public event Action<Vector3> DidDeterminedTargetPosition;

        [SerializeField] private PlayerController _PlayerController;

        private bool _isActive;


        private void Start()
        {
            _PlayerController.DidStartedMovement += OnStartedMovement;
            _PlayerController.DidEndedMovement += OnEndedMovement;
            _isActive = true;
        }


        private void Update()
        {
            if (!_isActive) return;
            
            // Check mouse is on UI object or not
            if(EventSystem.current && EventSystem.current.currentSelectedGameObject) return;
            
            if (Input.GetMouseButtonUp(0))
                DidDeterminedTargetPosition?.Invoke(Input.mousePosition);
        }


        // Deactivate input while the player is moving
        private void OnStartedMovement() => _isActive = false;


        // Activate input when the player finish movement
        private void OnEndedMovement() => _isActive = true;
    }
}
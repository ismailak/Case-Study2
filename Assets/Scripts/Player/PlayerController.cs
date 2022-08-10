using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Tritan.Data;
using Tritan.Inputs;
using Tritan.Obstacles;
using Tritan.UI;


namespace Tritan.Player
{
    public class PlayerController : MonoBehaviour
    {
        public event Action DidStartedMovement;
        public event Action DidEndedMovement;
        public event Action DidChangedData;
        public event Action DidDestroyedObstacle;

        [SerializeField] private InputManager _InputManager;
        [SerializeField] private GameSettingsScriptableObject _GameSettings;
        [SerializeField] private UIManager _UIManager;
        [SerializeField] private DataManager _DataManager;
        [SerializeField] private SliderController _SpeedSliderController;

        private Vector3 _lastPosition;

        
        private void Start()
        {
            _UIManager.DidIncreasedSpeed += OnIncreasedSpeed;
            _UIManager.DidDecreasedSpeed += OnDecreasedSpeed;
            
            _lastPosition = transform.position;

            SetSpeedSlider();
        }

        
        // Move from the current position to target position
        public void MoveToPosition(Vector3 targetPosition)
        {
            DidStartedMovement?.Invoke();

            targetPosition.y = 1;
            var duration = Vector3.Distance(_lastPosition, targetPosition) / _DataManager.GameData.Speed;
            
            transform.DOMove(targetPosition, duration)
                .OnComplete(() =>
                {
                    _lastPosition = targetPosition;
                    DidEndedMovement?.Invoke();
                });
        }

        
        // Move from the current position to obstacle position
        public void MoveToObstacle(ObstacleAbstract obstacleAbstract)
        {
            DidStartedMovement?.Invoke();

            var targetPosition = obstacleAbstract.transform.position;
            targetPosition.y = 1;
            var duration = Vector3.Distance(_lastPosition, targetPosition) / _DataManager.GameData.Speed;
            
            transform.DOMove(targetPosition, duration)
                .OnComplete(() =>
                {
                    _lastPosition = targetPosition;
                    
                    // Destroy the obstacle
                    obstacleAbstract.DestroyObstacle();
                    DidDestroyedObstacle?.Invoke();
                    
                    DidEndedMovement?.Invoke();
                });
        }


        // Change speed
        private void OnIncreasedSpeed()
        {
            _DataManager.GameData.Speed = Mathf.Clamp(_DataManager.GameData.Speed + _GameSettings._SpeedChangeAmount, _GameSettings._MinSpeed,
                _GameSettings._MaxSpeed);
            DidChangedData?.Invoke();
            
            SetSpeedSlider();
        }
        
        
        // Change speed
        private void OnDecreasedSpeed()
        {
            _DataManager.GameData.Speed = Mathf.Clamp(_DataManager.GameData.Speed - _GameSettings._SpeedChangeAmount, _GameSettings._MinSpeed,
                _GameSettings._MaxSpeed);
            DidChangedData?.Invoke();
            
            SetSpeedSlider();
        }
        

        // Change the speed slider's value
        private void SetSpeedSlider()
        {
            var targetSpeedSliderValue = Mathf.InverseLerp(_GameSettings._MinSpeed, _GameSettings._MaxSpeed,
                _DataManager.GameData.Speed);
            _SpeedSliderController.SetTarget(targetSpeedSliderValue, _GameSettings._SpeedSliderFillDuration);
        }
    }
}

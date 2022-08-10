using System;
using System.Collections;
using System.Collections.Generic;
using Tritan.Player;
using Tritan.UI;
using UnityEngine;


namespace Tritan.Obstacles
{
    public class ObstacleManager : MonoBehaviour
    { 
        public static ObstacleManager Instance { get; private set; }
        
        [SerializeField] private List<ObstacleAbstract> _ObstacleCubes;
        [SerializeField] private GameObject _ObstacleCubePrefab;
        [SerializeField] private PlayerController _PlayerController;
        [SerializeField] private SliderController _GoalSliderController;
        [SerializeField] private GameSettingsScriptableObject _GameSettings;

        private int _destroyedCubeCount;
        
        
        private void Awake() 
        { 
            // Singleton
            if (Instance != null && Instance != this) 
                Destroy(this); 
            else 
                Instance = this; 
        }


        private void Start()
        {
            _PlayerController.DidDestroyedObstacle += OnDestroyedObstacle;
        }


        private void OnDestroyedObstacle()
        {
            _destroyedCubeCount++;
            
            // Set new value for the goal slider
            var targetGoalSliderValue = (float)_destroyedCubeCount / _ObstacleCubes.Count;
            _GoalSliderController.SetTarget(targetGoalSliderValue, _GameSettings._GoalSliderFillDuration);
        }


        // Add obstacle from the inspector(For designers)
        public void CreateObstacleCube()
        {
            var obstacle = Instantiate(_ObstacleCubePrefab, transform).GetComponent<ObstacleAbstract>();
            obstacle.Init(this);
            _ObstacleCubes.Add(obstacle);
        }

        
        // Run when an obstacle deleted from the inspector
        public void DeleteObstacle(ObstacleAbstract obstacle) => _ObstacleCubes.Remove(obstacle);
    }
}
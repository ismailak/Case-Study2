using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tritan.Obstacles
{
    public abstract class ObstacleAbstract : MonoBehaviour
    {
        [SerializeField] private ObstacleManager _ObstacleManager;


        public void Init(ObstacleManager obstacleManager) => _ObstacleManager = obstacleManager;
        
        
        // Called when the obstacle is clicked
        public void DestroyObstacle()
        {
            // Add process something before destroy...
            
            
            Destroy(gameObject);
        }


        // Delete the obstacle from the inspector(For Designers)
        public void DeleteObstacle()
        {
            _ObstacleManager.DeleteObstacle(this);
            DestroyImmediate(gameObject);
        }
    }
}
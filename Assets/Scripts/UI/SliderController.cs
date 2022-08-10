using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Tritan.UI
{
    public class SliderController : MonoBehaviour
    {
        [SerializeField] private Slider _Slider;
        
        private float _currentSliderValue;
        
        
        public void SetTarget(float targetSliderValue, float duration)
        {
            StopAllCoroutines(); // Stop Filling Routines which is running still 
            var startSliderValue = _currentSliderValue;
            StartCoroutine(FillingRoutine());
            
            // Fill the slider
            IEnumerator FillingRoutine()
            {
                for (var t = 0f; t < duration; t += Time.deltaTime)
                {
                    _currentSliderValue = Mathf.Lerp(startSliderValue, targetSliderValue, t / duration);
                    _Slider.value = _currentSliderValue;
                    yield return null;
                }
            }
        }
    }
}
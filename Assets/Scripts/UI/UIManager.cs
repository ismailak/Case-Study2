using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tritan.UI
{
    public class UIManager : MonoBehaviour
    {
        public event Action DidIncreasedSpeed;
        public event Action DidDecreasedSpeed;

        //Speed up button
        public void ButtonIncreaseSpeed() => DidIncreasedSpeed?.Invoke();


        //Speed down button
        public void ButtonDecreasedSpeed() => DidDecreasedSpeed?.Invoke();
    }
}
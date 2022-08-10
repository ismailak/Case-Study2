using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettingsScriptableObject")]
public class GameSettingsScriptableObject : ScriptableObject
{
    [Header("Player Movement")]
    public float _MinSpeed = 1f;
    public float _MaxSpeed = 7f;
    public float _SpeedChangeAmount = 1f;
    public float _DefaultSpeed = 3f;
    
    [Header("Slider")]
    public float _GoalSliderFillDuration = 1f;
    public float _SpeedSliderFillDuration = 1f;
}

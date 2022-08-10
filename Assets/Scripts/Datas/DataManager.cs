using System;
using System.Collections;
using System.Collections.Generic;
using Tritan.Player;
using UnityEngine;


namespace Tritan.Data
{
    public class DataManager : MonoBehaviour
    {
        [SerializeField] private GameSettingsScriptableObject _GameSettings;
        [SerializeField] private PlayerController _PlayerController;

        private const string GAME_DATA_STRING = "game_data";
        private GameData _gameData;

        public GameData GameData
        {
            get => _gameData;
            private set
            {
                _gameData = value;
                OnChangedData();
            }
        }


        private void Awake()
        {
            // If it is exist, get data from playerpref, otherwise create default
            GameData = PlayerPrefs.HasKey(GAME_DATA_STRING)
                ? JsonUtility.FromJson<GameData>(PlayerPrefs.GetString(GAME_DATA_STRING))
                : new GameData(_GameSettings._DefaultSpeed);
        }


        private void Start()
        {
            _PlayerController.DidChangedData += OnChangedData;
        }


        // Save data
        private void OnChangedData() => PlayerPrefs.SetString(GAME_DATA_STRING, JsonUtility.ToJson(GameData));
    }

    public class GameData
    {
        public float Speed;

        public GameData(float speed)
        {
            Speed = speed;
        }
    }
}
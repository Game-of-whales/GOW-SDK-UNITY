using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfWhalesSettings : ScriptableObject {



    private static GameOfWhalesSettings _instance;

    public static GameOfWhalesSettings instance {
        get {
            if (!_instance) {
                _instance = (GameOfWhalesSettings) Resources.Load<GameOfWhalesSettings>("GameOfWhalesSettings");
            }
            return _instance;
        }
    }



    
        [SerializeField] private bool _notificationsEnabled;
        [SerializeField] private bool _debugLogging;
        [SerializeField] private string _gameID;
        [SerializeField] private string _androidProjectID;

        public bool notificationsEnabled {
            get { return _notificationsEnabled; }
            set { _notificationsEnabled = value; }
        }

        public bool debugLogging {
            get { return _debugLogging; }
            set { _debugLogging = value; }
        }

        public string gameID {
            get { return _gameID; }
            set { _gameID = value; }
        }

        public string androidProjectID {
            get { return _androidProjectID; }
            set { _androidProjectID = value; }
        }
}

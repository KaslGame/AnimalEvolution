using UnityEngine;

namespace PlayerScripts
{
    public class Player : MonoBehaviour
    {
        private const int _scoreAdded = 50; // Переименовать
        

        private int _level;
        private float _currentScore;

        private float _needScore => _level * _scoreAdded;


    }
}
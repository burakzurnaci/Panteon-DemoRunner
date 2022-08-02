using System;
using _game.Scripts.Manager;
using UnityEngine;

namespace _game.Scripts.Player
{
    public class InputManager : MonoBehaviour
    {
        private float _lastFrameFingerPositionX;
        public float MoveFactorX { get; private set; }

        void Update()
        {
            if (GameManager.Instance.states == GameManager.GameStates.NotStarted)
            {
                if (Input.GetMouseButton(0))
                {
                    GameManager.Instance.StartLevel();
                }
            }

            switch (GameManager.Instance.states)
            {
                case GameManager.GameStates.Started when Input.GetMouseButtonDown(0):
                    _lastFrameFingerPositionX = Input.mousePosition.x;
                    break;
                case GameManager.GameStates.Started when Input.GetMouseButton(0):
                    MoveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
                    _lastFrameFingerPositionX = Input.mousePosition.x;
                    break;
                case GameManager.GameStates.Started:
                {
                    if (Input.GetMouseButtonUp(0))
                    {
                        MoveFactorX = 0f;
                    }

                    break;
                }
                case GameManager.GameStates.Draw:
                    LevelManager.Instance.DrawSection();
                    break;
            }
        }
    }
}
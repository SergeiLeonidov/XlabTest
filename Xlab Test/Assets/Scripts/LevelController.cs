using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public SpawnRocks spawner;
        private float m_delay = 0.5f;

        public float delayMax = 2f;
        public float delayMin = 0.4f;
        public float delayStep = 0.1f;

        private float m_lastSpawnedTime = 0;

        public int score = 0;
        public int highScore = 0;
        private void Start()
        {
            m_lastSpawnedTime = Time.time;
            RefreshDelay();
        }

        private void OnStickHit()
        {
            score++;
            highScore = Mathf.Max(highScore, score);
            Debug.Log($"Score: {score} - High Score: {highScore}");
        }

        private void OnEnable()
        {
            GameEvents.onCollisionStone += GameOver;
            GameEvents.onStickHit += OnStickHit;
        }
        private void OnDisable()
        {
            GameEvents.onCollisionStone -= GameOver;
            GameEvents.onStickHit -= OnStickHit;
        }
        private void GameOver()
        {
            Debug.Log("GAME OVER");
            enabled = false;
        }

        public void RefreshDelay()
        {
            m_delay = UnityEngine.Random.Range(delayMin, delayMax);
            delayMax = Mathf.Max(delayMin, delayMax - delayStep);
        }
        private void Update()
        {
            if (Time.time >= m_lastSpawnedTime + m_delay)
            {
                spawner.Spawn();
                m_lastSpawnedTime = Time.time;

                RefreshDelay();
            }
        }
    }
}
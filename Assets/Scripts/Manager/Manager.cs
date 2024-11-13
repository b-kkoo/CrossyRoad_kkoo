using UnityEngine;
using System;
using System.Collections.Generic;

public class Manager : MonoBehaviour
{
    public int levelCount = 50;
    public Camera camera = null;
    public LevelGenerator levelGenerator = null;

    private int currentCoins = 0;
    private int currentDistance = 0;
    private bool canPlay = false;
    private AudioSource effect;
    private AudioClip clip = null;

    public event Action<int> coins;
    public event Action<int> distance;
    public event Action gameOver;

    private static Manager s_Instance;
    public static Manager instance
    {
        get
        {
            if (s_Instance == null)
            {
                s_Instance = FindObjectOfType(typeof(Manager)) as Manager;
            }

            return s_Instance;
        }
    }

    public PoolManager PoolManager
    {
        get { return _poolManager; }
        set { _poolManager = value; }
    }
    private PoolManager _poolManager;

    private void Start()
    {
        effect = GetComponent<AudioSource>();
        clip = effect.clip;

        for (int i = 0; i < levelCount; i++)
        {
            levelGenerator.RandomGenerator();
        }
    }

    public bool CanPlay()
    {
        return canPlay;
    }

    public void StartPlay()
    {
        canPlay = true;
    }

    public void UpdateCoinCount(int value)
    {
        currentCoins += value;
        effect.PlayOneShot(clip);
        coins?.Invoke(currentCoins);
    }

    public void UpdateDistanceCount()
    {
        currentDistance += 1;
        distance?.Invoke(currentDistance);
        //levelGenerator.RandomGenerator();
    }

    public void GameOver()
    {
        camera.GetComponent<CameraShake>().Shake();
        camera.GetComponent<CameraFollow>().enabled = false;
        gameOver?.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController _player;

    private void Awake()
    {
        _player.enabled = false;
    }

    public void OnPlayerFinish()
    {
        _player.StopCar();
        _player.enabled = false;
    }

    public void OnGameStart()
    {
        _player.enabled = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}

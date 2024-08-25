using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Job : MonoBehaviour
{
    [SerializeField] private GameObject _job;
    [SerializeField] private AudioSource _audio;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _audio.Play();

            _job.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _audio.Play();

            SceneManager.LoadScene(0);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}

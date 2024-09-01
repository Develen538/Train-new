using UnityEngine;
using UnityEngine.SceneManagement;

public class Job : MonoBehaviour
{
    [SerializeField] private GameObject _job;
    [SerializeField] private AudioSource _audio;

    private bool IsOpen = false;

    private void Update()
    {
        Managment();
    }

    private void Managment()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {

            _audio.Play();

            if (IsOpen == false)
            {
                IsOpen = true;

                _job.SetActive(true);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                IsOpen = false;

                _job.SetActive(false);

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
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

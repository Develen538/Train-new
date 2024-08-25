using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private InfoGame _game;
    [SerializeField] private AudioSource _audio;

   public void Play()
   {
        _audio.Play();
        _game.Speed = 0;
        SceneManager.LoadScene(1);
   }

    public void Quit()
    {
        Application.Quit();
    }
}

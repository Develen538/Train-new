using UnityEngine;

public class ManagerJob : MonoBehaviour
{
    [SerializeField] private GameObject _job;
    [SerializeField] private GameObject _hire;
    [SerializeField] private InfoGame _game;
    [SerializeField] private AudioSource[] _audio;

    private bool _time = false;

    public void Hire()
    {
        _audio[0].Play();

        if(_game.Money >= 50)
        {
            _game.Money -= 50;
            _hire.SetActive(true);

            _time = true;
        }

        if (_time == true)
        {
            Invoke("GiveMoney", 60f);
        }
    }

    private void GiveMoney()
    {
        _audio[1].Play();

        _game.Money += 1000;
    }
}

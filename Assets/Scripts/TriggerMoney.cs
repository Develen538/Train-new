using PathCreation.Examples;
using TMPro;
using UnityEngine;

public class TriggerMoney : MonoBehaviour
{
    [SerializeField] private TMP_Text _money;
    [SerializeField] private InfoGame _game;
    [SerializeField] private AudioSource _audio;

    private void FixedUpdate()
    {
        _money.text = _game.Money.ToString() + "$";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Locomotiv>(out Locomotiv locomotiv))
        {
           if(_game.Speed <= 1)
            {
                _audio.Play();
                _game.Money += 10;
                _money.text = _game.Money.ToString() + "$";
            }
        }
    }
}

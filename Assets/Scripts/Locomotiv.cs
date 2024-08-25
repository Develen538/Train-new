using PathCreation.Examples;
using TMPro;
using UnityEngine;

public class Locomotiv : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtSpeed;
    [SerializeField] private InfoGame _game;

    private void FixedUpdate()
    {
        Speed();
    }

    private void Speed()
    {
        _txtSpeed.text = _game.Speed.ToString() + " ед.с";
    }
}

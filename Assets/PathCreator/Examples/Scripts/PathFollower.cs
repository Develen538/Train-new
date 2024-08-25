using UnityEngine;

namespace PathCreation.Examples
{
    public class PathFollower : MonoBehaviour
    {
        [SerializeField] private EndOfPathInstruction _endOfPathInstruction;
        [SerializeField] private float _distanceTravelled;
        [SerializeField] private GameObject _playerFirst;
        [SerializeField] private GameObject _trainFirst;
        [SerializeField] private InfoGame _game;
        [SerializeField] private AudioSource[] _audio;

        private int _number;

        public PathCreator pathCreator;

        void Start() {
            if (pathCreator != null)
            {
                pathCreator.pathUpdated += OnPathChanged;
            }
        }

        void Update()
        {
            if (pathCreator != null)
            {
                _distanceTravelled += _game.Speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(_distanceTravelled, _endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(_distanceTravelled, _endOfPathInstruction);
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + 90);
                transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
            }
            Move();
        }

        void OnPathChanged() {
            _distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }

        private void Move()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                _audio[2].Play();
                _playerFirst.SetActive(false);
                _trainFirst.SetActive(true);
                _number = 1;

            }

            if (_number == 1)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    _game.Speed += 0.01f;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    _audio[1].volume = 1;

                    _game.Speed -= 0.01f;
                }
                if (Input.GetKeyUp(KeyCode.S))
                {
                    _audio[1].volume = 0;
                }

                if (_game.Speed <= 0 && !Input.GetKey(KeyCode.W))
                {
                    _audio[0].volume = 0;
                    _audio[1].volume = 0;

                    _game.Speed = 0;
                }
                if (_game.Speed >= _game.MaxSpeed)
                {
                    _game.Speed = _game.MaxSpeed;
                }
                if (_game.Speed >= 0.01)
                {
                    _audio[0].volume = 1;
                }
            }
        }
    }

}
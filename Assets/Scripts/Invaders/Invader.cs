using UnityEngine;
using PowerUps;

namespace Invaders
{
    public abstract class Invader : MonoBehaviour, IDamagable
    {
        private GameManager _gameManager;
        protected ScoreManager Score;
        private PowerUpGenerator _powerUpGenerator;
        
        private Level _level;
        private Transform _transform;

        private readonly Vector3 _positionBulletSpawn = new Vector3(0, -0.6f, 0);
        private int _bulletRandomness = 3000;

        public GameObject bullet;
        public GameObject explosionPrefab;

        private void Awake()
        {
            _powerUpGenerator = GameObject.FindWithTag("PowerUpGenerator").GetComponent<PowerUpGenerator>();
            _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
            Score = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
        }

        private void Start()
        {
            _transform = GetComponent<Transform>();
            _level = transform.parent.GetComponent<Level>();
        }

        private void FixedUpdate()
        {
            if (Random.Range(0, _bulletRandomness) < 1)
            {
                Instantiate(bullet, _transform.position + _positionBulletSpawn, Quaternion.identity);
            }
        }

        public void SetBulletRandomness(int bulletRandomness)
        {
            _bulletRandomness = bulletRandomness;
        }

        public virtual void ReceiveDamage()
        {
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("PlayerBullet"))
            {
                var level = transform.parent;
                ReceiveDamage();
                if (Random.Range(0, 50) < 1)
                {
                    _powerUpGenerator.GenerateRandomPowerUp(_transform.position);
                }
                level.GetComponent<Level>().KillOne();
                Destroy(col.gameObject);
                Destroy(gameObject);
                Instantiate(explosionPrefab, _transform.position, Quaternion.identity, level);
            }

            if (col.gameObject.CompareTag("LeftBorder"))
            {
                _level.MoveRight();
            }

            if (col.gameObject.CompareTag("RightBorder"))
            {
                _level.MoveLeft();
            }

            if (col.gameObject.CompareTag("DownBorder"))
            {
                _gameManager.EndGame();
            }
        }
    }
}
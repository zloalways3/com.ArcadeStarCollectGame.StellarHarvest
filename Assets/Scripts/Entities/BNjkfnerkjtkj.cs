using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Entities
{
    public class BNjkfnerkjtkj : MonoBehaviour
    {
        [FormerlySerializedAs("player")] [SerializeField] private BNjknkjertjkrt bNjknkjertjkrt;
        [SerializeField] private int prizeCost = 10;
        [SerializeField] private Obj obstaclePrefab;
        [SerializeField] private Obj prizePrefab;
        [SerializeField] private float diamondSpawnChance = .4f;
        [SerializeField] private float[] spawnDurationRange = { .2f, .6f };
        [SerializeField] private RectTransform spawningArea;
        [SerializeField] private int damage = 10;
        [SerializeField] private int baseTime = 60;
        [SerializeField] private int winScore = 300;
        
        private int _score = 0;
        private int _health = 100;
        private float _leftTime = 0f;
        private BNjkernjkvnkert _bNjkernjkvnkert;
        private int _winScore;
        private Coroutine _spawningCoroutine;
        private List<Obj> _objs = new List<Obj>();
        private Coroutine _timeCoroutine;
        private bool _godMod;
        private bool _x10;

        public event Action<int> OnScoreChange;
        public event Action<int> OnDamage;
        public event Action<int> OnTimeChange;
        public event Action OnWin;
        public event Action OnLose;

        public int Score => _score;
        public int LeftTime => (int)_leftTime;
        public int Health => _health;
        public int WinScore => _winScore;

        public void Bootstrap(BNjkernjkvnkert bNjkernjkvnkert, bool godMod, bool x10)
        {
            _leftTime = baseTime;
            _bNjkernjkvnkert = bNjkernjkvnkert;
            _winScore = winScore;
            _godMod = godMod;
            _x10 = x10;
        }

        private void Start()
        {
            bNjknkjertjkrt.OnTrigger += OnBNjknkjertjkrtTrigger;
        }

        public void StartGame()
        {
            foreach (var obj in _objs)
            {
                obj.IsStopped = false;
            }

            bNjknkjertjkrt.IsStopped = false;

            _spawningCoroutine = StartCoroutine(SpawnCoroutine());
            _timeCoroutine = StartCoroutine(TickTime());
        }

        public void StopGame()
        {
            StopCoroutine(_timeCoroutine);
            StopCoroutine(_spawningCoroutine);

            foreach (var obj in _objs)
            {
                obj.IsStopped = true;
            }

            bNjknkjertjkrt.IsStopped = true;
        }

        private void OnBNjknkjertjkrtTrigger(Obj obj)
        {
            if (obj.GetType() == typeof(Obstacle))
            {
                _bNjkernjkvnkert.OnDamage();

                if (_godMod)
                {
                    Destroy(obj.gameObject);
                    return;
                }
                
                _health -= damage;
                OnDamage?.Invoke(_health);

                if (_health <= 0)
                {
                    StopGame();
                    OnLose.Invoke();
                    return;
                }
            }
            else
            {
                _score += prizeCost * (_x10 ? 10 : 1);
                _bNjkernjkvnkert.OnPrizeCollect();
                OnScoreChange?.Invoke(_score);

                if (_score >= _winScore)
                {
                    StopGame();
                    OnWin.Invoke();
                }
            }
            
            Destroy(obj.gameObject);
        }

        private IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                Obj spawningSphere = Random.value <= diamondSpawnChance
                    ? prizePrefab 
                    : obstaclePrefab;

                Obj spawned = Instantiate(
                    spawningSphere,
                    spawningArea
                );
                _objs.Add(spawned);

                spawned.transform.localPosition = Vector3.right * Random.Range(
                    spawningArea.rect.xMin,
                    spawningArea.rect.xMax
                );

                yield return new WaitForSeconds(Random.Range(spawnDurationRange[0], spawnDurationRange[1]));
            }
        }

        private IEnumerator TickTime()
        {
            while (_leftTime > 0)
            {
                _leftTime -= Time.deltaTime;
                OnTimeChange?.Invoke((int)_leftTime);
                
                yield return null;
            }
            
            StopGame();
            OnLose?.Invoke();
        }
    }
}
using System;
using System.Collections;
using Core;
using Entities;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class VBMkrlmelkmly : EOvmtkrylhuy<GamePayload>
    {
        [SerializeField] private Text scoreText;
        [SerializeField] private Text timeText;
        [SerializeField] private Text healthText;
        [SerializeField] private Text levelText;
        [SerializeField] private Transform gamePlace;

        private BNjkfnerkjtkj _bNjkfnerkjtkj;
        private bool _isPaused;
        
        private VBnjernjJKDSfnjk _vBnjernjJkdSfnjk;

        public void Bootstrap(VBnjernjJKDSfnjk vBnjernjJkdSfnjk)
        {
            _vBnjernjJkdSfnjk = vBnjernjJkdSfnjk;
        }

        public override void VBMklremlrkhnjkhyt(GamePayload payload)
        {
            base.VBMklremlrkhnjkhyt(payload);

            levelText.text = $"Level {payload.SelectedLevel + 1}";

            if (_bNjkfnerkjtkj != null)
            {
                _bNjkfnerkjtkj.OnWin -= OnWin;
                _bNjkfnerkjtkj.OnLose -= OnLose;
                _bNjkfnerkjtkj.OnScoreChange -= OnScoreChange;
                _bNjkfnerkjtkj.OnTimeChange -= OnTimeChange;
                _bNjkfnerkjtkj.OnDamage -= OnDamage;
                Destroy(_bNjkfnerkjtkj.gameObject);
            }

            _bNjkfnerkjtkj = Instantiate(
                _vBnjernjJkdSfnjk.GetLevelData(payload.SelectedLevel), 
                gamePlace
            );
            _bNjkfnerkjtkj.OnWin += OnWin;
            _bNjkfnerkjtkj.OnLose += OnLose;
            _bNjkfnerkjtkj.OnScoreChange += OnScoreChange;
            _bNjkfnerkjtkj.OnTimeChange += OnTimeChange;
            _bNjkfnerkjtkj.OnDamage += OnDamage;

            _bNjkfnerkjtkj.Bootstrap(BNjkernjkvnkert, _vBnjernjJkdSfnjk.GodMod, _vBnjernjJkdSfnjk.X10);
            
            scoreText.text = $"{VBnjkdswnfjkewr.BVNjkrfenjkr(0)}/{_bNjkfnerkjtkj.WinScore}";
            timeText.text = $"{VBnjkdswnfjkewr.VNMkrnvwejkrkt(_bNjkfnerkjtkj.LeftTime)}";
            healthText.text = "100HP";
            
            _bNjkfnerkjtkj.StartGame();
        }

        public override void Open()
        {
            base.Open();
            
            if(_bNjkfnerkjtkj != null)
                _bNjkfnerkjtkj.StartGame();
        }

        private void OnWin()
        {
            _vBnjernjJkdSfnjk.IncreasePassedLevels(_payload.SelectedLevel);
            
            var results = _vBnjernjJkdSfnjk.Results;
            results[_payload.SelectedLevel] = _bNjkfnerkjtkj.LeftTime;
            _vBnjernjJkdSfnjk.Results = results;
            
            BNjkernjkvnkert.OnWin();

            StartCoroutine(CallDelayed(() =>
            {
                _canvas.ChangeScreen<VMkrlemklrnhklt, EndPayload>(new EndPayload
                {
                    SelectedLevel = _payload.SelectedLevel,
                    Score = _bNjkfnerkjtkj.Score,
                    Time = _bNjkfnerkjtkj.LeftTime,
                    Health = _bNjkfnerkjtkj.Health
                });
            }));
            
        }

        private void OnLose()
        {
            BNjkernjkvnkert.OnLose();
            
            StartCoroutine(CallDelayed(() =>
            {
                _canvas.ChangeScreen<LoseScreen, EndPayload>(new EndPayload
                {
                    SelectedLevel = _payload.SelectedLevel,
                    Score = _bNjkfnerkjtkj.Score,
                    Time = _bNjkfnerkjtkj.LeftTime,
                    Health = _bNjkfnerkjtkj.Health
                });
            }));
        }

        private void OnScoreChange(int score)
        {
            scoreText.text = $"{VBnjkdswnfjkewr.BVNjkrfenjkr(score)}/{_bNjkfnerkjtkj.WinScore}";
        }

        private void OnDamage(int health)
        {
            healthText.text = $"{VBnjkdswnfjkewr.BVNjkrfenjkr(health)}HP";
        }

        private void OnTimeChange(int time)
        {
            timeText.text = $"{VBnjkdswnfjkewr.VNMkrnvwejkrkt(time)}";
        }

        private IEnumerator CallDelayed(Action callback)
        {
            yield return new WaitForSeconds(1f);
            
            callback.Invoke();
        }
    }

    public class GamePayload
    {
        public int SelectedLevel;
    }

    public class EndPayload
    {
        public int SelectedLevel;
        public int Score;
        public int Time;
        public int Health;
    }
}
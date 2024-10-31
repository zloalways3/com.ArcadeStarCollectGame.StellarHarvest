using Core;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class VMkrlemklrnhklt : EOvmtkrylhuy<EndPayload>
    {
        [SerializeField] private Text scoreText;
        [SerializeField] private Text healthText;
        [SerializeField] private Text timeText;
        
        private VBnjernjJKDSfnjk _vBnjernjJkdSfnjk;

        public void Bootstrap(VBnjernjJKDSfnjk vBnjernjJkdSfnjk)
        {
            _vBnjernjJkdSfnjk = vBnjernjJkdSfnjk;
        }
        
        public override void VBMklremlrkhnjkhyt(EndPayload payload)
        {
            base.VBMklremlrkhnjkhyt(payload);

            scoreText.text = $"{payload.Score}/{payload.Score}";
            healthText.text = $"{VBnjkdswnfjkewr.BVNjkrfenjkr(payload.Health)}HP";
            timeText.text = $"{VBnjkdswnfjkewr.VNMkrnvwejkrkt(payload.Time)}";
        }

        public void NextLvl()
        {
            BNjkernjkvnkert.OnButtonClick();
            
            if (_payload.SelectedLevel >= _vBnjernjJkdSfnjk.LevelsCount)
            {
                _canvas.ChangeScreen<VMklremvLKESRl>();
                return;
            }
            
            _canvas.ChangeScreen<VBMkrlmelkmly, GamePayload>(new GamePayload {SelectedLevel = _payload.SelectedLevel + 1});
        }
    }
}
using Core;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class LoseScreen : EOvmtkrylhuy<EndPayload>
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

        public void Retry()
        {
            BNjkernjkvnkert.OnButtonClick();
            _canvas.ChangeScreen<VBMkrlmelkmly, GamePayload>(new GamePayload {SelectedLevel = _payload.SelectedLevel});
        }
    }
}
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class VMklremvLKESRl : BNMKjntbkrjtkl
    {
        [SerializeField] private Button[] levelButtons;
        
        private VBnjernjJKDSfnjk _vBnjernjJkdSfnjk;

        private void Start()
        {
            for (int i = 0; i < levelButtons.Length; ++i)
            {
                var t = i;
                levelButtons[i].onClick.AddListener(() => StartLevel(t));
            }
        }

        public void Bootstrap(
            VBnjernjJKDSfnjk vBnjernjJkdSfnjk
        )
        {
            _vBnjernjJkdSfnjk = vBnjernjJkdSfnjk;
            UpdateLevelButtons();
        }
        
        public void StartLevel(int levelIndex)
        {
            BNjkernjkvnkert.OnButtonClick();
            _canvas.ChangeScreen<VBMkrlmelkmly, GamePayload>(new GamePayload { SelectedLevel = levelIndex });
        }
        
        public override void Open()
        {
            UpdateLevelButtons();
            
            base.Open();
        }
        
        private void UpdateLevelButtons()
        {
            for (int i = 0; i < levelButtons.Length; ++i)
            {
                levelButtons[i].interactable = i <= _vBnjernjJkdSfnjk.PassedLevels;
            }
        }
    }
}
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class BonusScreen : BNMKjntbkrjtkl
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private GameObject unlockText;
        [SerializeField] private Image godModToggle;
        [SerializeField] private Image x10Toggle;
        [SerializeField] private Sprite enabledToggle;
        [SerializeField] private Sprite disabledToggle;
        
        private VBnjernjJKDSfnjk _vBnjernjJkdSfnjk;
        private bool _isEnabled = false;

        public void Bootstrap(VBnjernjJKDSfnjk vBnjernjJkdSfnjk)
        {
            _vBnjernjJkdSfnjk = vBnjernjJkdSfnjk;
        }

        public override void Open()
        {
            _isEnabled = _vBnjernjJkdSfnjk.PassedLevels > 0;

            canvasGroup.alpha = _isEnabled ? 1f : .2f;
            unlockText.SetActive(!_isEnabled);
            
            godModToggle.sprite = _vBnjernjJkdSfnjk.GodMod ? enabledToggle : disabledToggle;
            x10Toggle.sprite = _vBnjernjJkdSfnjk.X10 ? enabledToggle : disabledToggle;
            
            base.Open();
        }

        public void OnGodModClick()
        {
            if (!_isEnabled)
                return;
            
            BNjkernjkvnkert.OnButtonClick();
            
            var godMod = !_vBnjernjJkdSfnjk.GodMod;
            
            godModToggle.sprite = godMod ? enabledToggle : disabledToggle;

            _vBnjernjJkdSfnjk.GodMod = godMod;
        }

        public void OnX10Click()
        {
            if (!_isEnabled)
                return;
         
            BNjkernjkvnkert.OnButtonClick();
            
            var x10 = !_vBnjernjJkdSfnjk.X10;
            
            x10Toggle.sprite = x10 ? enabledToggle : disabledToggle;
            
            _vBnjernjJkdSfnjk.X10 = x10;
        }
    }
}
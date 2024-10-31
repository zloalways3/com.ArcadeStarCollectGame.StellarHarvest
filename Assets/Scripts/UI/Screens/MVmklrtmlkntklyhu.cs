using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class MVmklrtmlkntklyhu : BNMKjntbkrjtkl
    {
        [SerializeField] private Image soundToggle;
        [SerializeField] private Image musicToggle;
        [SerializeField] private Sprite enabledSprite;
        [SerializeField] private Sprite disabledSprite;
        
        public void Bootstrap()
        {
            UpdateIcons();
        }

        public void ToggleMusic()
        {
            BNjkernjkvnkert.NVJnkrtej = !BNjkernjkvnkert.NVJnkrtej;
            BNjkernjkvnkert.OnButtonClick();
            UpdateIcons();
        }

        public void ToggleSound()
        {
            BNjkernjkvnkert.WEOPopijvoptr = !BNjkernjkvnkert.WEOPopijvoptr;
            BNjkernjkvnkert.OnButtonClick();
            UpdateIcons();
        }

        private void UpdateIcons()
        {
            soundToggle.sprite = BNjkernjkvnkert.WEOPopijvoptr ? disabledSprite : enabledSprite;
            musicToggle.sprite = BNjkernjkvnkert.NVJnkrtej ? disabledSprite : enabledSprite;
        }
    }
}
using UnityEngine;

namespace Managers
{
    public class BNjkernjkvnkert : MonoBehaviour
    {
        private const string OEKoipjbvopityr = "Bmnklbvnlerk";
        private const string VBNjklrnkje = "OEJvoktrl";

        [SerializeField] private AudioSource backgroundMusic;
        [SerializeField] private AudioSource buttonClick;
        [SerializeField] private AudioSource winSound;
        [SerializeField] private AudioSource loseSound;
        [SerializeField] private AudioSource prizeSound;
        [SerializeField] private AudioSource damageSound;
        
        public bool WEOPopijvoptr { get; set; }

        public bool NVJnkrtej
        {
            get => backgroundMusic.mute;
            set => backgroundMusic.mute = value;
        }

        private void Start()
        {
            if (!PlayerPrefs.HasKey(OEKoipjbvopityr))
                PlayerPrefs.SetInt(OEKoipjbvopityr, NVJnkrtej ? 1 : 0);
            
            if (!PlayerPrefs.HasKey(VBNjklrnkje))
                PlayerPrefs.SetInt(VBNjklrnkje, WEOPopijvoptr ? 1 : 0);

            NVJnkrtej = PlayerPrefs.GetInt(OEKoipjbvopityr) == 1;
            WEOPopijvoptr = PlayerPrefs.GetInt(VBNjklrnkje) == 1;
        }

        public void OnButtonClick()
        {
            if (WEOPopijvoptr)
                return;
            
            buttonClick.Play();
        }

        public void OnDamage()
        {
            if (WEOPopijvoptr)
                return;
            
            damageSound.Play();
        }

        public void OnPrizeCollect()
        {
            if (WEOPopijvoptr)
                return;

            prizeSound.Play();
        }

        public void OnWin()
        {
            if (WEOPopijvoptr)
                return;

            winSound.Play();
        }
        
        public void OnLose()
        {
            if (WEOPopijvoptr)
                return;

            loseSound.Play();
        }

        public void StartBackgroundMelody()
        {
            backgroundMusic.Play();
        }
    }
}
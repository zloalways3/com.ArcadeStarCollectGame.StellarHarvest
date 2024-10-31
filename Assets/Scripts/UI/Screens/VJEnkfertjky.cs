using System.Collections;
using UnityEngine;

namespace UI.Screens
{
    public class VJEnkfertjky : BNMKjntbkrjtkl
    {
        [SerializeField] private float loadingDuration = 1f;
        
        public void Load()
        {
            StartCoroutine(LoadingCoroutine());
        }

        private IEnumerator LoadingCoroutine()
        {
            var loadingProgress = 0f;
            
            while (loadingProgress < loadingDuration)
            {
                loadingProgress += Time.deltaTime;
                
                yield return null;
            }
            
            BNjkernjkvnkert.StartBackgroundMelody();
            _canvas.ChangeScreen<Lvnjkrebhjkq>();
        }
    }
}
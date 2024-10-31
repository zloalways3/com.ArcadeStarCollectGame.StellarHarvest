using Managers;
using UnityEngine;

namespace UI.Screens
{
    public abstract class BNMKjntbkrjtkl : MonoBehaviour
    {
        protected VMMAKlkfdnlew _canvas;
        protected BNjkernjkvnkert BNjkernjkvnkert;
        
        public void InjectData(VMMAKlkfdnlew canvas, BNjkernjkvnkert bNjkernjkvnkert)
        {
            _canvas = canvas;
            BNjkernjkvnkert = bNjkernjkvnkert;
        }

        public virtual void Open()
        {
            gameObject.SetActive(true);
        }

        public virtual void Close()
        {
            gameObject.SetActive(false);
        }

        public virtual void OpenLevelListScreen()
        {
            BNjkernjkvnkert.OnButtonClick();
            _canvas.ChangeScreen<VMklremvLKESRl>();
        }

        public virtual void OpenMenuScreen()
        {
            BNjkernjkvnkert.OnButtonClick();
            _canvas.ChangeScreen<Lvnjkrebhjkq>();
        }
        
        public virtual void OpenSettingsScreen()
        {
            BNjkernjkvnkert.OnButtonClick();
            _canvas.ChangeScreen<MVmklrtmlkntklyhu>();
        }

        public virtual void Back()
        {
            BNjkernjkvnkert.OnButtonClick();
            _canvas.OpenPreviousScreen();
        }

        public virtual void OpenRecordsScreen()
        {
            BNjkernjkvnkert.OnButtonClick();
            _canvas.ChangeScreen<RecordsScreen>();
        }

        public virtual void OpenBonusScreen()
        {
            BNjkernjkvnkert.OnButtonClick();
            _canvas.ChangeScreen<BonusScreen>();
        }
    }
}
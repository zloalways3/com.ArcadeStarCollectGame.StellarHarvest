using Core;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class Lvnjkrebhjkq : BNMKjntbkrjtkl
    {
        private VBnjernjJKDSfnjk _vBnjernjJkdSfnjk;

        public void Bootstrap(
            VBnjernjJKDSfnjk vBnjernjJkdSfnjk
        )
        {
            _vBnjernjJkdSfnjk = vBnjernjJkdSfnjk;
        }

        public void StartGame()
        {
            BNjkernjkvnkert.OnButtonClick();
            _canvas.ChangeScreen<VBMkrlmelkmly, GamePayload>(
                new GamePayload() { SelectedLevel = _vBnjernjJkdSfnjk.LastLevelIndex }
            );
        }
        
        public void Exit()
        {
            BNjkernjkvnkert.OnButtonClick();
            Application.Quit();
        }
    }
}
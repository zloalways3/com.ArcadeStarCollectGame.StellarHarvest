using System;
using System.Collections.Generic;
using Managers;
using UI.Screens;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    public class VMMAKlkfdnlew : MonoBehaviour
    {
        [FormerlySerializedAs("menuScreen")] [SerializeField] private Lvnjkrebhjkq lvnjkrebhjkq;
        [FormerlySerializedAs("loadingScreen")] [SerializeField] private VJEnkfertjky vjEnkfertjky;
        [FormerlySerializedAs("gameScreen")] [SerializeField] private VBMkrlmelkmly vbMkrlmelkmly;
        [FormerlySerializedAs("settingsScreen")] [SerializeField] private MVmklrtmlkntklyhu mVmklrtmlkntklyhu;
        [FormerlySerializedAs("levelListScreen")] [SerializeField] private VMklremvLKESRl vMklremvLkesRl;
        [FormerlySerializedAs("winScreen")] [SerializeField] private VMkrlemklrnhklt vMkrlemklrnhklt;
        [SerializeField] private LoseScreen loseScreen;
        [SerializeField] private BonusScreen bonusScreen;
        [SerializeField] private RecordsScreen recordsScreen;

        private Dictionary<Type, BNMKjntbkrjtkl> _screens;
        private BNMKjntbkrjtkl _previousScreen;
        private BNMKjntbkrjtkl _currentScreen;
        private VMKlmkrtlenjklqw _vmKlmkrtlenjklqw;

        private void Start()
        {
            _screens = new Dictionary<Type, BNMKjntbkrjtkl>()
            {
                { typeof(Lvnjkrebhjkq), lvnjkrebhjkq },
                { typeof(VJEnkfertjky), vjEnkfertjky },
                { typeof(VBMkrlmelkmly), vbMkrlmelkmly },
                { typeof(MVmklrtmlkntklyhu), mVmklrtmlkntklyhu },
                { typeof(VMklremvLKESRl), vMklremvLkesRl },
                { typeof(VMkrlemklrnhklt), vMkrlemklrnhklt },
                { typeof(LoseScreen), loseScreen },
                { typeof(BonusScreen), bonusScreen },
                { typeof(RecordsScreen), recordsScreen }
            };
        }

        public void Bootstrap(VMKlmkrtlenjklqw vmKlmkrtlenjklqw)
        {
            _vmKlmkrtlenjklqw = vmKlmkrtlenjklqw;

            var levelSavesManager = vmKlmkrtlenjklqw.Get<VBnjernjJKDSfnjk>();
            var soundManager = vmKlmkrtlenjklqw.Get<BNjkernjkvnkert>();

            foreach (var pair in _screens)
            {
                pair.Value.InjectData(this, soundManager);
            }

            vMklremvLkesRl.Bootstrap(levelSavesManager);
            lvnjkrebhjkq.Bootstrap(levelSavesManager);
            vbMkrlmelkmly.Bootstrap(levelSavesManager);
            mVmklrtmlkntklyhu.Bootstrap();
            vMkrlemklrnhklt.Bootstrap(levelSavesManager);
            loseScreen.Bootstrap(levelSavesManager);
            bonusScreen.Bootstrap(levelSavesManager);
            recordsScreen.Bootstrap(levelSavesManager);
        }

        public void Load()
        {
            ChangeScreen<VJEnkfertjky>();
            vjEnkfertjky.Load();
        }

        public void ChangeScreen<TScreen>() where TScreen : BNMKjntbkrjtkl
        {
            _previousScreen = _currentScreen;
            _previousScreen?.Close();
            _currentScreen = _screens[typeof(TScreen)];
            _currentScreen.Open();
        }

        public void ChangeScreen<TScreen, TPayload>(TPayload payload) where TScreen : BNMKjntbkrjtkl
        {
            ((EOvmtkrylhuy<TPayload>)_screens[typeof(TScreen)]).VBMklremlrkhnjkhyt(payload);
            ChangeScreen<TScreen>();
        }

        public void OpenPreviousScreen()
        {
            if (_previousScreen is null)
                return;

            _currentScreen.Close();
            _previousScreen.Open();

            (_previousScreen, _currentScreen) = (_currentScreen, _previousScreen);
        }
    }
}
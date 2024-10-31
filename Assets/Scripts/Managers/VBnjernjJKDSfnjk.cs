using System;
using System.Linq;
using Content;
using Entities;
using UnityEngine;

namespace Managers
{
    public class VBnjernjJKDSfnjk
    {
        private const string PassedLevelsKey = "VBnmjkwle";
        private const string ResultsKey = "weojrfwiov";
        private const string GodModKey = "vfnmrtjk";
        private const string X10Key = "X10";
        
        private readonly LevelsDatabase _levelsDatabase;

        public int PassedLevels => PlayerPrefs.GetInt(PassedLevelsKey);
        public int LevelsCount => _levelsDatabase.GameFields.Length;

        public bool GodMod
        {
            get => PlayerPrefs.GetInt(GodModKey) == 1;
            set => PlayerPrefs.SetInt(GodModKey, value ? 1 : 0);
        }

        public bool X10
        {
            get => PlayerPrefs.GetInt(X10Key) == 1;
            set => PlayerPrefs.SetInt(X10Key, value ? 1 : 0);
        }

        public int[] Results
        {
            get => PlayerPrefs.GetString(ResultsKey)
                .Split(',')
                .Select(c => int.Parse(c))
                .ToArray();
            set => PlayerPrefs.SetString(ResultsKey, String.Join(",", value));
        }

        public int LastLevelIndex => PlayerPrefs.GetInt(PassedLevelsKey) < _levelsDatabase.GameFields.Length
            ? PlayerPrefs.GetInt(PassedLevelsKey)
            : _levelsDatabase.GameFields.Length - 1;
            
        
        public VBnjernjJKDSfnjk(LevelsDatabase levelsDatabase)
        {
            _levelsDatabase = levelsDatabase;

            if (!PlayerPrefs.HasKey(PassedLevelsKey))
            {
                PlayerPrefs.SetInt(PassedLevelsKey, 0);
            }

            if (!PlayerPrefs.HasKey(GodModKey))
            {
                GodMod = false;
            }

            if (!PlayerPrefs.HasKey(X10Key))
            {
                X10 = false;
            }
            
            if (!PlayerPrefs.HasKey(ResultsKey))
            {
                Results = new int[LevelsCount];
            }
        }

        public BNjkfnerkjtkj GetLevelData(int index) =>
            _levelsDatabase.GameFields[index];

        public void IncreasePassedLevels(int currentLevel)
        {
            if (currentLevel == PassedLevels)
                PlayerPrefs.SetInt(PassedLevelsKey, PassedLevels + 1);
        }
    }
}
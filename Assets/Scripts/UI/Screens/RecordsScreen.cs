using System.Linq;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class RecordsScreen : BNMKjntbkrjtkl
    {
        [SerializeField] private LayoutGroup recordsLayoutGroup;
        [SerializeField] private RecordWrap recordWrapPrefab;
        
        private VBnjernjJKDSfnjk _vBnjernjJkdSfnjk;
        private RecordWrap[] _recordWraps = new RecordWrap[9];
        private int[][] _records = new int[9][];

        public void Bootstrap(VBnjernjJKDSfnjk vBnjernjJkdSfnjk)
        {
            _vBnjernjJkdSfnjk = vBnjernjJkdSfnjk;
            
            _records[0] = new [] { 25, 20, 14, 12 };
            _records[1] = new [] { 15, 13, 7, 6 };
            _records[2] = new [] { 10, 8, 6, 5 };
            _records[3] = new [] { 15, 13, 12, 6 };
            _records[4] = new [] { 13, 12, 11, 10 };
            _records[5] = new [] { 10, 6, 3, 2 };
            _records[6] = new [] { 23, 21, 16, 12 };
            _records[7] = new [] { 25, 21, 20, 15 };
            _records[8] = new [] { 20, 15, 13, 12 };
            
            InstantiateRecords();
        }

        public override void Open()
        {
            UpdateRecords();
            
            base.Open();
        }

        private void InstantiateRecords()
        {
            for (int i = 0; i < _records.Length; ++i)
            {
                var recordWrap = Instantiate(recordWrapPrefab, recordsLayoutGroup.transform);
                recordWrap.SetLevelText(i + 1);
                _recordWraps[i] = recordWrap;

                for (int j = 0; j < _records[i].Length; ++j)
                {
                    recordWrap.SetRecord(_records[i][j], j);
                }
            }
        }

        private void UpdateRecords()
        {
            var playerResults = _vBnjernjJkdSfnjk.Results;
            
            for (int i = 0; i < _records.Length; ++i)
            {
                var orderedRecords = _records[i].Append(playerResults[i])
                    .OrderByDescending(x => x)
                    .Take(4)
                    .ToArray();

                for (int j = 0; j < orderedRecords.Length; ++j)
                {
                    _recordWraps[i].SetRecord(orderedRecords[j], j, playerResults[i] == orderedRecords[j]);
                }
            }
        }
    }
}
using Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class RecordWrap : MonoBehaviour
    {
        [SerializeField] private Text[] recordTexts;
        [SerializeField] private Text levelText;

        public void SetLevelText(int level)
        {
            levelText.text = $"Level {level}";
        }
        
        public void SetRecord(int record, int position, bool isPlayer = false)
        {
            recordTexts[position].text = $"{(isPlayer ? "You" : (position + 1).ToString())}: {VBnjkdswnfjkewr.VNMkrnvwejkrkt(record)}";
        }
    }
}
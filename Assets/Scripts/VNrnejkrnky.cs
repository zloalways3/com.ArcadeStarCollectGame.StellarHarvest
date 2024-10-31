using Content;
using Managers;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

public class VNrnejkrnky : MonoBehaviour
{
        [FormerlySerializedAs("canvas")] [SerializeField] private VMMAKlkfdnlew NVnrjkenjkq;
        [FormerlySerializedAs("levelsDatabase")] [SerializeField] private LevelsDatabase VMawsjeioqw;
        [FormerlySerializedAs("soundManager")] [SerializeField] private BNjkernjkvnkert bNjkernjkvnkert;

        private readonly VMKlmkrtlenjklqw _vmKlmkrtlenjklqw = VMKlmkrtlenjklqw.Instance;

        private void Start()
        {
                Application.targetFrameRate = 60;
                
                DontDestroyOnLoad(this);
                
                _vmKlmkrtlenjklqw.Register(NVnrjkenjkq);
                _vmKlmkrtlenjklqw.Register(VMawsjeioqw);
                _vmKlmkrtlenjklqw.Register(new VBnjernjJKDSfnjk(VMawsjeioqw));
                _vmKlmkrtlenjklqw.Register(bNjkernjkvnkert);
                
                NVnrjkenjkq.Bootstrap(_vmKlmkrtlenjklqw);
                NVnrjkenjkq.Load();
        }
}
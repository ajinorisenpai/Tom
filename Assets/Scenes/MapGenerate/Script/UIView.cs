using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace MapGenerate
{
    public class UIView: MonoBehaviour
    {
        [SerializeField] private Button generateBtn;

        public IObservable<Unit> GenerateBtn()
        {
            return generateBtn.OnClickAsObservable();
        }
    }
}
using System;
using UnityEngine;
using UniRx;
namespace MapGenerate
{
    public class MapGenerateManager : MonoBehaviour
    {
        [SerializeField] private UIView ui;

        private void Awake()
        {
            ui.GenerateBtn().ThrottleFirst(TimeSpan.FromSeconds(10f))
                .Subscribe(_ =>
                {
                    Debug.Log("hello world");
                })
                .AddTo(this);
        }
    }
}

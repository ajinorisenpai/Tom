using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Shootiong
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform root;
        [SerializeField] private Transform player;
        private void LateUpdate()
        {
            root.position =new Vector3(player.position.x,player.position.y,root.position.z);
        }
    }
}
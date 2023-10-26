using UnityEngine;
using Unity.Netcode;

namespace GameChat
{
    public class SceneBoot : MonoBehaviour
    {
        [SerializeField]
        BootMode bootMode;

        void Start()
        {
            var nm = NetworkManager.Singleton;
            switch (bootMode)
            {
                case BootMode.Develop:
                    nm.StartHost();
                    Debug.Log("network started as Host");
                    break;
                case BootMode.ClientBuild:
                    nm.StartClient();
                    Debug.Log("network started as Client");
                    break;
                case BootMode.ServerBuild:
                    Debug.Log("network started as Server");
                    nm.StartServer();
                    break;
                default:
                    throw new System.Exception("unexpected boot type");
            }
        }
    }
}

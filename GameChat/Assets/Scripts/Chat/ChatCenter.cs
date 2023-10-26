using UnityEngine;
using UnityEngine.Assertions;

namespace GameChat
{
    [RequireComponent(typeof(ChatNetworkCenter))]
    public class ChatCenter : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField]
        ChatUIController uiController;

        ChatNetworkCenter chatNetworkCenter;

        void Awake()
        {
            Assert.IsNotNull(uiController);
            chatNetworkCenter = GetComponent<ChatNetworkCenter>();
        }

        public void SendChatMessage(string text) 
        {
            chatNetworkCenter.SendChatMessageServerRpc(text);
        }

        public void ReceiveChatMessage(ChatMessage message)
        {
            uiController.OnReceiveMessage(message);
        }
    }
}
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

        public void SendChatMessage(string text, ChatMessageMode mode) 
        {
            var recieverIds = System.Array.Empty<ulong>();
            switch (mode)
            {
                // not implemented
                case ChatMessageMode.Area:
                case ChatMessageMode.All:
                case ChatMessageMode.Party:
                case ChatMessageMode.Person:
                    break;
                default:
                    break;
            }

            chatNetworkCenter.SendChatMessageServerRpc(ChatMessage.Compose(text, mode, recieverIds));
        }

        public void ReceiveChatMessage(ChatMessage message)
        {
            uiController.OnReceiveMessage(message);
        }
    }
}
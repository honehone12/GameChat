using UnityEngine;
using UnityEngine.Assertions;
using TMPro;

namespace GameChat
{
    public class ChatMessageContainer : MonoBehaviour
    {
        [SerializeField]
        TMP_Text sender;
        [SerializeField]
        TMP_Text text;

        void Awake()
        {
            Assert.IsNotNull(sender);
            Assert.IsNotNull(text);
        }

        public void SetChatMessage(ChatMessage message)
        {
            sender.text = message.sender;
            text.text = message.text;
        }
    }
}
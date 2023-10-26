using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace GameChat
{
    public class ChatMessageList : MonoBehaviour
    {
        [SerializeField]
        GameObject chatMessageContainerPrefab;

        readonly List<ChatMessageContainer> messageContainerList = new();

        void Awake()
        {
            Assert.IsNotNull(chatMessageContainerPrefab);
        }

        public void Add(ChatMessage message)
        {
            var go = Instantiate(chatMessageContainerPrefab, transform);
            var container = go.GetComponent<ChatMessageContainer>();
            container.SetChatMessage(message);
            messageContainerList.Add(container);
        }
    }
}
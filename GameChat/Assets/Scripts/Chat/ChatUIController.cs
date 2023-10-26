using UnityEngine;
using UnityEngine.Assertions;
using TMPro;

namespace GameChat
{
    public class ChatUIController : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField]
        GameObject uiRoot;
        [SerializeField]
        TMP_InputField inputField;        
        [SerializeField]
        ChatMessageList chatMessageList;
        [Header("ChatCenter")]
        [SerializeField]
        ChatCenter chatCenter;

        bool isActive;
        ChatMessageMode chatMode;

        void Awake()
        {
            Assert.IsNotNull(uiRoot);
            Assert.IsNotNull(chatMessageList);
            Assert.IsNotNull(chatCenter);
            Assert.IsNotNull(inputField);
        }

        void OnEnable()
        {
            isActive = uiRoot.activeInHierarchy;
            chatMode = ChatMessageMode.All;
        }

        void Start()
        {
            chatMessageList.Add(new ChatMessage(
                "GameChat Dev",
                "Welcome to GameChat !!"
            ));
        }

        public void OpenOrCloseChatUI()
        {
            isActive = !isActive;
            uiRoot.SetActive(isActive);
        }

        public void OnChatModeChanged(int option)
        {
            switch (option)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    chatMode = (ChatMessageMode)option;
                    break;
                default:
                    break;
            }
        }

        public void OnMessageEdit(string text)
        {
            chatCenter.SendChatMessage(text);
            inputField.text = string.Empty;
        }

        public void OnReceiveMessage(ChatMessage message)
        {
            chatMessageList.Add(message);
        }
    }
}

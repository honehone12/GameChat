using UnityEngine;
using Unity.Netcode;

namespace GameChat
{
    [RequireComponent(typeof(ChatCenter))]
    public class ChatNetworkCenter : NetworkBehaviour
    {
        ChatCenter chatCenter;

        void Awake()
        {
            chatCenter = GetComponent<ChatCenter>();
        }

        string GetUserName(ulong id)
        {
            // dummy implementation
            return $"Player {id}";
        }

        [ServerRpc(Delivery = RpcDelivery.Reliable, RequireOwnership = false)]
        public void SendChatMessageServerRpc(ChatMessage message, ServerRpcParams rpcParams = default)
        {
            var senderId = rpcParams.Receive.SenderClientId;
            message.sender = GetUserName(senderId);
            switch (message.mode)
            {
                // not implemented
                case ChatMessageMode.All:
                case ChatMessageMode.Area:
                case ChatMessageMode.Party:
                case ChatMessageMode.Person:
                    break;
                default:
                    break;
            }

            BroadcastChatMessageClientRpc(message);
        }

        [ClientRpc(Delivery = RpcDelivery.Reliable)]
        public void BroadcastChatMessageClientRpc(ChatMessage message, ClientRpcParams rpcParams = default)
        {
            chatCenter.ReceiveChatMessage(message);
        }
    }
}
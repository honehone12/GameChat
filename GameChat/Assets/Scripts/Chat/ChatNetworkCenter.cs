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

        [ServerRpc(Delivery = RpcDelivery.Reliable, RequireOwnership = true)]
        public void SendChatMessageServerRpc(string message, ServerRpcParams rpcParams = default)
        {
            var senderId = rpcParams.Receive.SenderClientId;
            BroadcastChatMessageClientRpc(new ChatMessage(GetUserName(senderId), message));
        }

        [ClientRpc(Delivery = RpcDelivery.Reliable)]
        public void BroadcastChatMessageClientRpc(ChatMessage message, ClientRpcParams rpcParams = default)
        {
            chatCenter.ReceiveChatMessage(message);
        }
    }
}
using Unity.Netcode;

namespace GameChat
{
    public struct ChatMessage : INetworkSerializable
    {
        public ChatMessageMode mode;
        public ulong[] receiverIds;
        public string sender;
        public string text;

        public ChatMessage(string sender, string text)
        {
            mode = ChatMessageMode.All;
            receiverIds = System.Array.Empty<ulong>();
            this.sender = sender;
            this.text = text;
        }

        public ChatMessage(string sender, string text, ChatMessageMode mode, params ulong[] receiverIds)
        {
            this.mode = mode;
            this.receiverIds = receiverIds;
            this.sender = sender;
            this.text = text;

        }

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref sender);
            serializer.SerializeValue(ref text);
        }
    }
}

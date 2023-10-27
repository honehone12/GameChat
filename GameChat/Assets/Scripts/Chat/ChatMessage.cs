using Unity.Netcode;

namespace GameChat
{
    public class ChatMessage : INetworkSerializable
    {
        public static ChatMessage Compose(string text, ChatMessageMode mode, params ulong[] receiverIds)
        {
            return new ChatMessage("", text, mode, receiverIds);
        }

        public ChatMessageMode mode;
        public ulong[] receiverIds;
        public string sender;
        public string text;

        public ChatMessage()
        {
            mode = default;
            receiverIds = default;
            sender = default;
            text = default;
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
            serializer.SerializeValue(ref mode);
            serializer.SerializeValue(ref receiverIds);
            serializer.SerializeValue(ref sender);
            serializer.SerializeValue(ref text);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp_Shared.Enums
{
    public enum MessageType
    {
        // Authentication
        Login,
        Register,
        Logout,

        // Chat
        PrivateMessage,
        GroupMessage,
        BroadcastMessage,

        ServerBroadcast,
        KickUser,

        // Group
        CreateGroup,
        AddMember,
        RemoveMember,

        // File
        FileTransfer,
        ImageTransfer,

        // Status
        OnlineUsers,
        Typing,
        RecallMessage,

        // Offline Queue
        OfflineMessage,

        // Network
        Reconnect,

        // LAN Discovery
        DiscoveryRequest,
        DiscoveryResponse
    }
}

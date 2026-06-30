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

        //List 
        UserList,
        GroupList,

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
        FileStart,
        FileChunk,
        FileEnd,
        FileAccept,
        FileReject,
        FileTransfer,

        //Media
        ImageTransfer,
        ImageAccept,
        ImageReject,
        ImageChunk,
        ImageEnd,

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
        DiscoveryResponse,
        
    }
}

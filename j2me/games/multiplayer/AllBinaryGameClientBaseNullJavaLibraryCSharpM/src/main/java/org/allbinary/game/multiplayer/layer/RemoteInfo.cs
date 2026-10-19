/*
 * 
 * To change this license header, choose License Headers in Project Properties. 
 * To change this template file, choose Tools | Templates 
 * and open the template in the editor.  
 */
// Generated Code Do Not Modify

using System;
using System.Linq;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.game.multiplayer.layer;

public class RemoteInfo
{
    public static readonly int NEW_PLAYER_ID = 0;
    public static readonly RemoteInfo REMOTE_INFO = new RemoteInfo(StringUtil.getInstance().EMPTY_STRING, -1, -1, RemoteInfo.NEW_PLAYER_ID);
    public RemoteInfo(string username, int actorSessionId, int playerInputId, int id)
    {
    }

}


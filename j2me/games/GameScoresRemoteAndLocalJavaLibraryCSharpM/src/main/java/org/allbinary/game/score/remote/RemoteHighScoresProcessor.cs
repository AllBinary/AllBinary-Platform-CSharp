/*
 *
 * AllBinary Open License Version 1
 * Copyright (c) 2011 AllBinary
 * 
 * By agreeing to this license you and any business entity you represent are
 * legally bound to the AllBinary Open License Version 1 legal agreement.
 * 
 * You may obtain the AllBinary Open License Version 1 legal agreement from
 * AllBinary or the root directory of AllBinary's AllBinary Platform repository.
 * 
 * Created By: Travis Berthelot
 *  
 */
// Generated Code Do Not Modify

using System;
using System.Linq;
using System.Runtime.CompilerServices;
using GameInfo = org.allbinary.game.GameInfo;
using GameInfoData = org.allbinary.game.GameInfoData;
using GameConfigurationCentral = org.allbinary.game.configuration.GameConfigurationCentral;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using XmlRpcAbeClient = org.allbinary.logic.communication.xmlrpc.XmlRpcAbeClient;
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;
using NoCrypt = org.allbinary.logic.system.security.crypt.jcehelper.NoCrypt;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;
using org.allbinary.util;
using HashtableUtil = org.allbinary.util.HashtableUtil;

namespace org.allbinary.game.score.remote;

public class RemoteHighScoresProcessor : RemoteHighScoresProcessorInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly NoCrypt noCrypt = new NoCrypt();
    public RemoteHighScoresProcessor()
    {
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void process(RemoteHighScores remoteHighScores, AbeClientInformationInterface abeClientInformation, GameInfo gameInfo)
    {
        this.logUtil.putF("Begin Remote HighScores Retrieval", this, this.commonStrings.PROCESS);
        GameInfoData gameInfoData = GameInfoData.getInstance();
        ABHashtable<object, object> hashtable = abeClientInformation.toHashtable();
        HashtableUtil.getInstance().putAll(gameInfo.toHashtable(), hashtable);
        hashtable.put(gameInfoData.SOFTWARE_INFORMATION, remoteHighScores.getSoftwareInformation().ToString());
        hashtable.put(remoteHighScores.ASCENDING, remoteHighScores.getAscending().ToString());
        DisplayInfoSingleton displayInfoSingleton = DisplayInfoSingleton.getInstance();
        hashtable.put(displayInfoSingleton.ORIENTATION, BooleanFactory.getInstance().toStringb(displayInfoSingleton.isPortrait()));
        hashtable.put(RemoteHighScoresData.getInstance().GAME_CONFIGURATION, GameConfigurationCentral.getInstance().ToString());
        if (XmlRpcAbeClient.isOnline) {
            ABHashtable<object, object> resultHashtable = ((ABHashtable<object, object>) new XmlRpcRemoteHighScoresClient(abeClientInformation, "highscoresservicessl.php", "HighScoresService.process").get(hashtable, this.noCrypt));
            remoteHighScores.update(resultHashtable);
        }
    }

}


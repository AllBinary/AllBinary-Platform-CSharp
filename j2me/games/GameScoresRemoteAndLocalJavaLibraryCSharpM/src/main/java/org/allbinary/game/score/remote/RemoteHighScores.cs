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
using java.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using GameInfo = org.allbinary.game.GameInfo;
using HighScore = org.allbinary.game.score.HighScore;
using HighScores = org.allbinary.game.score.HighScores;
using RemoteErrorHighScoresSingletonFactory = org.allbinary.game.score.RemoteErrorHighScoresSingletonFactory;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using SoftwareInformation = org.allbinary.logic.system.SoftwareInformation;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStrings = org.allbinary.@string.CommonStrings;
using org.allbinary.util;
using EnumerationUtil = org.allbinary.util.EnumerationUtil;

namespace org.allbinary.game.score.remote;

public class RemoteHighScores : HighScores
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly EnumerationUtil enumerationUtil = EnumerationUtil.getInstance();
    private static readonly ABHashtable<object, object> hashTable = StdUtil.getInstance().createHashtable();
    private readonly AbeClientInformationInterface abeClientInformation;
    private readonly SoftwareInformation softwareInformation;
    private bool? ascending = null;
    public readonly string ASCENDING = "ASCENDING";
    private RemoteHighScores(AbeClientInformationInterface abeClientInformation, SoftwareInformation softwareInformation, GameInfo gameInfo, string heading, string columnTwoHeading, bool? ascending, bool preload) : base(gameInfo.ToString(), heading, columnTwoHeading)
    {
        // base(gameInfo.ToString(), heading, columnTwoHeading) is called from the constructor declaration
        this.abeClientInformation = abeClientInformation;
        this.softwareInformation = softwareInformation;
        this.setAscending(ascending);
        if (preload) {
            RemoteHighScoresProcessorFactory.getInstance().process(this, this.abeClientInformation, gameInfo);
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static HighScores getInstance(AbeClientInformationInterface abeClientInformation, SoftwareInformation softwareInformation, GameInfo gameInfo, string heading, string columnTwoHeading, bool? isAscending)
    {
        return RemoteHighScores.getInstancePreload(abeClientInformation, softwareInformation, gameInfo, heading, columnTwoHeading, isAscending, true);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static HighScores getInstancePreload(AbeClientInformationInterface abeClientInformation, SoftwareInformation softwareInformation, GameInfo gameInfo, string heading, string columnTwoHeading, bool? isAscending, bool preload)
    {
        LogUtil logUtil = LogUtil.getInstance();
        try {
            HighScores highScores = ((HighScores) RemoteHighScores.hashTable.get(gameInfo));
            if (highScores == null) {
                highScores = new RemoteHighScores(abeClientInformation, softwareInformation, gameInfo, heading, columnTwoHeading, isAscending, preload);
                RemoteHighScores.hashTable.put(gameInfo, highScores);
            }
            return highScores;
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            logUtil.put(commonStrings.EXCEPTION, RemoteErrorHighScoresSingletonFactory.getInstance(), commonStrings.GET_INSTANCE, e);
            return RemoteErrorHighScoresSingletonFactory.getInstance();
        }
    }

    public virtual void addHighScore(HighScore newHighScore)
    {
        RemoteHighScoresSubmissionProcessorFactory.getInstance().process(this, this.abeClientInformation, newHighScore);
    }

    public virtual void update(ABHashtable<object, object> hashtable)
    {
        this.getList().clear();
        BasicArrayList vector = ((BasicArrayList) hashtable.get(((object) RemoteHighScoresData.getInstance().HIGH_SCORES)));
        if (vector != null) {
            int size = vector.size();
            for (int index = 0; index < size; index++) {
                BasicArrayList highScoreVector = ((BasicArrayList) vector.get(index));
                string displayName = ((string) highScoreVector.get(0));
                string score = ((string) highScoreVector.get(1));
                long longScore = long.Parse(score);
                HighScore highScore = new HighScore(-1, displayName, null, longScore);
                this.getList().add(highScore);
            }
        } else {
            string NEXT_ELEMENT = new StringMaker().append(CommonLabels.getInstance().NEXT).append("Element: ").ToString();
            CommonStrings commonStrings = CommonStrings.getInstance();
            Enumeration enumeration = hashtable.elements();
            object nextElement = null;
            while (this.enumerationUtil.hasMoreElements(enumeration)) {
                nextElement = this.enumerationUtil.nextElement(enumeration);
                this.logUtil.putF(NEXT_ELEMENT + nextElement, this, commonStrings.PROCESS);
            }
        }
    }

    private void setAscending(bool? ascending)
    {
        this.ascending = ascending;
    }

    public virtual bool? getAscending()
    {
        return this.ascending;
    }

    public virtual SoftwareInformation getSoftwareInformation()
    {
        return this.softwareInformation;
    }

}


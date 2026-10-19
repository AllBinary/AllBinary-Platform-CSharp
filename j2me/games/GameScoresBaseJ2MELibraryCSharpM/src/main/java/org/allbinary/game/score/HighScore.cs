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
//using ByteArrayOutputStream = java.io.ByteArrayOutputStream;
//using DataOutputStream = java.io.DataOutputStream;
using GameInfo = org.allbinary.game.GameInfo;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.game.score;

public class HighScore
{
    private readonly int id;
    private string name;
    private readonly GameInfo gameInfo;
    private readonly long score;
    private readonly string scoreString;
    public HighScore(int id, string name, GameInfo gameInfo, long score)
    {
        this.id = id;
        this.name = name;
        this.gameInfo = gameInfo;
        this.score = score;
        this.scoreString = (this.score).ToString();
    }

    public virtual int getId()
    {
        return this.id;
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual long getScore()
    {
        return this.score;
    }

    // throws Exception
    public virtual sbyte[] getAsBytes()
    {
        System.IO.MemoryStream byteArrayOutputStream = new System.IO.MemoryStream();
        DataOutputStream outputStream = new DataOutputStream(byteArrayOutputStream);
        outputStream.writeUTF(this.getName());
        outputStream.writeLong(this.getScore());
        return ((sbyte[]) (Array) byteArrayOutputStream.ToArray());
    }

    public virtual GameInfo getGameInfo()
    {
        return this.gameInfo;
    }

    public virtual string getScoreString()
    {
        return this.scoreString;
    }

    public virtual void setName(string name)
    {
        this.name = name;
    }

    public override string ToString()
    {
        CommonSeps commonSeps = CommonSeps.getInstance();
        return new StringMaker().append(this.name).append(commonSeps.COLON).appendlong(this.score).append(commonSeps.FORWARD_SLASH).append(this.scoreString).ToString();
    }

}


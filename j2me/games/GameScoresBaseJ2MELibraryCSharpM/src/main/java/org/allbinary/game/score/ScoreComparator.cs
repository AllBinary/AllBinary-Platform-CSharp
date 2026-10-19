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
//using ByteArrayInputStream = java.io.ByteArrayInputStream;
//using DataInputStream = java.io.DataInputStream;
//using EOFException = java.io.EOFException;
//using IOException = java.io.IOException;
//using RecordComparator = javax.microedition.rms.RecordComparator;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.score;

public class ScoreComparator : RecordComparator
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly bool isHighestBest;
    public ScoreComparator(bool isHighestBest)
    {
        this.isHighestBest = isHighestBest;
    }

    public virtual long getBestScore()
    {
        return (this.isHighestBest ? Long.MAX_VALUE : 0);
    }

    public virtual int compare(sbyte[] recordOne, sbyte[] recordTwo)
    {
        ByteArrayInputStream byteArrayInputStreamOne = new ByteArrayInputStream(recordOne);
        DataInputStream inputStreamOne = new DataInputStream(byteArrayInputStreamOne);
        ByteArrayInputStream byteArrayInputStreamTwo = new ByteArrayInputStream(recordTwo);
        DataInputStream inputStreamTwo = new DataInputStream(byteArrayInputStreamTwo);
        long scoreOne = 0L;
        long scoreTwo = 0L;
        try {
            inputStreamOne.readUTF();
            inputStreamTwo.readUTF();
            scoreOne = inputStreamOne.readLong();
            scoreTwo = inputStreamTwo.readLong();
        } catch (EOFException e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, "compare", e);
        } catch (IOException e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, "compare", e);
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, "compare", e);
        }
        if (this.isHighestBest) {
            return this.getHighTooLow(scoreOne, scoreTwo);
        } else {
            return this.getLowTooHigh(scoreOne, scoreTwo);
        }
    }

    public virtual int getHighTooLow(long scoreOne, long scoreTwo)
    {
        if (scoreOne > scoreTwo) {
            return RecordComparator.PRECEDES;
        } else if (scoreOne < scoreTwo) {
            return RecordComparator.FOLLOWS;
        } else {
            return RecordComparator.EQUIVALENT;
        }
    }

    public virtual int getLowTooHigh(long scoreOne, long scoreTwo)
    {
        if (scoreOne < scoreTwo) {
            return RecordComparator.PRECEDES;
        } else if (scoreOne > scoreTwo) {
            return RecordComparator.FOLLOWS;
        } else {
            return RecordComparator.EQUIVALENT;
        }
    }

}


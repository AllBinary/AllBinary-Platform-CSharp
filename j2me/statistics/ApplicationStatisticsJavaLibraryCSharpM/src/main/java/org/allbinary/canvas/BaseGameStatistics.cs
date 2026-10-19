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
using PrimitiveLongSingleton = org.allbinary.logic.math.PrimitiveLongSingleton;
using ScaleFactorFactory = org.allbinary.logic.math.ScaleFactorFactory;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonSeps = org.allbinary.@string.CommonSeps;
using GameTickTimeDelayHelper = org.allbinary.time.GameTickTimeDelayHelper;
using GameTickTimeDelayHelperFactory = org.allbinary.time.GameTickTimeDelayHelperFactory;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;

namespace org.allbinary.canvas;

public class BaseGameStatistics
{
    private readonly TimeDelayHelper timeDelayHelper = new TimeDelayHelper(Integer.MAX_VALUE);
    private readonly TimeDelayHelper updateDelayHelper = new TimeDelayHelper(2000);
    private long totalRefreshes = 0L;
    private long totalFrames = 0L;
    public readonly GameTickTimeDelayHelper gameTickTimeDelayHelper = GameTickTimeDelayHelperFactory.getInstance();
    public BaseGameStatistics()
    {
        this.STRING_ARRAY = new string[] { " Total Time: ", this.EMPTY_STRING, " Total Frames: ", this.EMPTY_STRING, " Frames/10 Sec: ", this.EMPTY_STRING, " Total Paints: ", this.EMPTY_STRING, " Paints/10 Sec: ", this.EMPTY_STRING };
    }

    public virtual void init()
    {
        this.timeDelayHelper.setStartTimeTNT();
        this.totalRefreshes = 0L;
        this.totalFrames = 0L;
    }

    public virtual void add(string @string)
    {
    }

    public virtual void process()
    {
    }

    public virtual void nextFrame()
    {
        this.totalFrames++;
    }

    public virtual void nextRefresh()
    {
        this.totalRefreshes++;
    }

    private readonly int DEFAULT_SCALE_FACTOR = ScaleFactorFactory.getInstance().DEFAULT_SCALE_FACTOR;
    public virtual short getRefreshRate()
    {
        long elapsed = this.timeDelayHelper.getElapsed(this.gameTickTimeDelayHelper.startTime);
        if (elapsed > 1L) {
            short time = ((short) (this.totalRefreshes / (elapsed >> this.DEFAULT_SCALE_FACTOR)));
            return time;
        } else {
            return 0;
        }
    }

    protected virtual TimeDelayHelper getTimeDelayHelper()
    {
        return this.timeDelayHelper;
    }

    public readonly string NOT = "Not enough Time to Calculate";
    private readonly string EMPTY_STRING = StringUtil.getInstance().EMPTY_STRING;
    private readonly string[] STRING_ARRAY;
    private readonly char SPACE_CHAR = ' ';
    private readonly char PLUS_CHAR = '+';
    private readonly char X_CHAR = 'X';
    private readonly char[][] CHAR_ARRAY = new char[][] { new char[] { 'F', 'r', 'a', 'm', 'e', 's', '/', '1', '0', ' ', 'S', 'e', 'c', ':' }, new char[] { 'X', 'X' }, new char[] { 'P', 'a', 'i', 'n', 't', 's', '/', '1', '0', ' ', 'S', 'e', 'c', ':' }, new char[] { 'X', 'X' } };
    private readonly PrimitiveLongSingleton primitiveLongSingleton = PrimitiveLongSingleton.getInstance();
    public virtual char[][] to2DCharArray()
    {
        long totalTime = this.timeDelayHelper.getElapsed(this.gameTickTimeDelayHelper.startTime);
        totalTime = (totalTime >> this.DEFAULT_SCALE_FACTOR);
        if (totalTime > 0L && this.updateDelayHelper.isTime(this.gameTickTimeDelayHelper.startTime)) {
            int framesPerSec = ((int) (this.totalFrames / totalTime));
            if (framesPerSec < 10) {
                this.CHAR_ARRAY[1][0] = this.SPACE_CHAR;
                this.CHAR_ARRAY[1][1] = this.primitiveLongSingleton.NUMBER_CHAR_ARRAY[framesPerSec];
            } else if (framesPerSec < 100) {
                int tens = framesPerSec / 10;
                int removeTens = tens * 10;
                this.CHAR_ARRAY[1][0] = this.primitiveLongSingleton.NUMBER_CHAR_ARRAY[tens];
                this.CHAR_ARRAY[1][1] = this.primitiveLongSingleton.NUMBER_CHAR_ARRAY[framesPerSec - removeTens];
            } else {
                this.CHAR_ARRAY[1][0] = this.PLUS_CHAR;
                this.CHAR_ARRAY[1][1] = this.PLUS_CHAR;
            }
            int refreshesPerSec = ((int) (this.totalRefreshes / totalTime));
            if (refreshesPerSec < 10) {
                this.CHAR_ARRAY[3][0] = this.X_CHAR;
                this.CHAR_ARRAY[3][1] = this.primitiveLongSingleton.NUMBER_CHAR_ARRAY[refreshesPerSec];
            } else if (refreshesPerSec < 100) {
                int tens = refreshesPerSec / 10;
                int removeTens = tens * 10;
                this.CHAR_ARRAY[3][0] = this.primitiveLongSingleton.NUMBER_CHAR_ARRAY[refreshesPerSec / 10];
                this.CHAR_ARRAY[3][1] = this.primitiveLongSingleton.NUMBER_CHAR_ARRAY[refreshesPerSec - removeTens];
            } else {
                this.CHAR_ARRAY[3][0] = this.PLUS_CHAR;
                this.CHAR_ARRAY[3][1] = this.PLUS_CHAR;
            }
        }
        return this.CHAR_ARRAY;
    }

    public virtual string[] toStringArray()
    {
        long totalTime = this.timeDelayHelper.getElapsed(this.gameTickTimeDelayHelper.startTime);
        totalTime = (totalTime / 10000L);
        if (totalTime > 0L) {
            this.STRING_ARRAY[1] = (totalTime).ToString();
            this.STRING_ARRAY[3] = (this.totalFrames).ToString();
            this.STRING_ARRAY[5] = (this.totalFrames / totalTime).ToString();
            this.STRING_ARRAY[7] = (this.totalRefreshes).ToString();
            this.STRING_ARRAY[9] = (this.totalRefreshes / totalTime).ToString();
        } else {
            string @string = this.EMPTY_STRING;
            this.STRING_ARRAY[1] = @string;
            this.STRING_ARRAY[3] = @string;
            this.STRING_ARRAY[5] = @string;
            this.STRING_ARRAY[7] = @string;
            this.STRING_ARRAY[9] = @string;
        }
        return this.STRING_ARRAY;
    }

    public virtual string toStringAt(long totalTime)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.STRING_ARRAY[0]);
        stringBuffer.appendlong(totalTime);
        stringBuffer.append(this.STRING_ARRAY[2]);
        stringBuffer.appendlong(this.totalFrames);
        stringBuffer.append(this.STRING_ARRAY[4]);
        stringBuffer.appendlong(this.totalFrames / totalTime);
        if (this.totalRefreshes > 0L) {
            stringBuffer.append(this.STRING_ARRAY[6]);
            stringBuffer.appendlong(this.totalRefreshes);
            stringBuffer.append(this.STRING_ARRAY[8]);
            stringBuffer.appendlong(this.totalRefreshes / totalTime);
            stringBuffer.append(CommonSeps.getInstance().NEW_LINE);
        }
        return stringBuffer.ToString();
    }

    public override string ToString()
    {
        long totalTime = this.timeDelayHelper.getElapsed(this.gameTickTimeDelayHelper.startTime);
        totalTime = (totalTime / 1000L);
        if (totalTime > 0L) {
            return this.toStringAt(totalTime);
        } else {
            return this.NOT;
        }
    }

}


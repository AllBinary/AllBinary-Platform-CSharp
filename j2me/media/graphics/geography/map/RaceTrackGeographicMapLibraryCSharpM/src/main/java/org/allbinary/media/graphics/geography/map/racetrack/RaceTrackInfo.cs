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
using BasicColor = org.allbinary.graphics.color.BasicColor;

namespace org.allbinary.media.graphics.geography.map.racetrack;

public class RaceTrackInfo
{
    private int? id;
    private string name;
    private RaceTrackFrictionProperties raceTrackFrictionProperties;
    private BasicColor foregroundBasicColor;
    private BasicColor backgroundBasicColor;
    private int qualifyTime;
    private int worstContinuePosition;
    private int totalLaps;
    public RaceTrackInfo(int? id, string name, RaceTrackFrictionProperties raceTrackFrictionProperties, BasicColor foregroundBasicColor, BasicColor backgroundBasicColor, int qualifyTime, int worstContinuePosition, int totalLaps)
    {
        this.id = id;
        this.name = name;
        this.raceTrackFrictionProperties = raceTrackFrictionProperties;
        this.backgroundBasicColor = backgroundBasicColor;
        this.foregroundBasicColor = foregroundBasicColor;
        this.qualifyTime = qualifyTime;
        this.worstContinuePosition = worstContinuePosition;
        this.totalLaps = totalLaps;
    }

    public virtual int? getId()
    {
        return this.id;
    }

    private void setId(int? id)
    {
        this.id = id;
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual void setName(string name)
    {
        this.name = name;
    }

    public virtual int getQualifyTime()
    {
        return this.qualifyTime;
    }

    public virtual void setQualifyTime(int qualifyTime)
    {
        this.qualifyTime = qualifyTime;
    }

    public virtual int getWorstContinuePosition()
    {
        return this.worstContinuePosition;
    }

    public virtual void setWorstContinuePosition(int worstContinuePosition)
    {
        this.worstContinuePosition = worstContinuePosition;
    }

    public virtual int getTotalLaps()
    {
        return this.totalLaps;
    }

    public virtual void setTotalLaps(int totalLaps)
    {
        this.totalLaps = totalLaps;
    }

    public virtual BasicColor getForegroundBasicColor()
    {
        return this.foregroundBasicColor;
    }

    public virtual void setForegroundBasicColor(BasicColor foregroundBasicColor)
    {
        this.foregroundBasicColor = foregroundBasicColor;
    }

    public virtual BasicColor getBackgroundBasicColor()
    {
        return this.backgroundBasicColor;
    }

    public virtual void setBackgroundBasicColor(BasicColor backgroundBasicColor)
    {
        this.backgroundBasicColor = backgroundBasicColor;
    }

    public virtual RaceTrackFrictionProperties getRaceTrackFrictionProperties()
    {
        return this.raceTrackFrictionProperties;
    }

    public virtual void setRaceTrackFrictionProperties(RaceTrackFrictionProperties raceTrackFrictionProperties)
    {
        this.raceTrackFrictionProperties = raceTrackFrictionProperties;
    }

}


/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
using CommonLabels = org.allbinary.@string.CommonLabels;

namespace org.allbinary.game.layer.unit;

public class UnitWaypointStrings
{
    private static readonly UnitWaypointStrings instance = new UnitWaypointStrings();
    public static UnitWaypointStrings getInstance()
    {
        return UnitWaypointStrings.instance;
    }

    public readonly string WANDERING = "Order?";
    public readonly string THINKING = "Thinking";
    public readonly string THINKING_ABOUT_TARGET = "Hmmm";
    public readonly string TARGET = "Target";
    public readonly string KILL = "Kill!";
    public readonly string STOP = "Stop";
    public readonly string WAYPOINT_DESTROYED_SHORT = "Uh Oh";
    public readonly string WAYPOINT_DESTROYED = "Waypoint Destroyed";
    public readonly string ALL_VISITED_SHORT = "Arrived";
    public readonly string ALL_VISITED = "All Visited";
    public readonly string ALREADY_THERE_SHORT = "Again?";
    public readonly string ALREADY_THERE = "Already There";
    public readonly string NEXT_PATH_NODE = CommonLabels.getInstance().NEXT + " Path Node";
}


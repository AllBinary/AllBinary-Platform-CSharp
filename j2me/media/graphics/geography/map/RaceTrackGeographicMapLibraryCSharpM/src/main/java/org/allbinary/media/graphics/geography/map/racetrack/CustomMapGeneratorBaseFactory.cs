/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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

namespace org.allbinary.media.graphics.geography.map.racetrack;

public class CustomMapGeneratorBaseFactory
{
    private static readonly CustomMapGeneratorBaseFactory instance = new CustomMapGeneratorBaseFactory();
    public static CustomMapGeneratorBaseFactory getInstance()
    {
        return CustomMapGeneratorBaseFactory.instance;
    }

    public CustomMapGeneratorBaseFactory()
    {
    }

    // throws Exception
    public virtual CustomMapGeneratorBase create(RaceTrackGeographicMap raceTrackGeographicMap)
    {
        return new CustomMapGeneratorBase();
    }

}


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
//using JsType = jsinterop.annotations.JsType;
//using JsProperty = jsinterop.annotations.JsProperty;
//using JsConstructor = jsinterop.annotations.JsConstructor;

namespace org.allbinary.math;

public class NamedAngle : Angle
{
    public readonly string name;
    public NamedAngle(short angle, string name) : base(angle)
    {
        // base(angle) is called from the constructor declaration
        this.name = name;
    }

}


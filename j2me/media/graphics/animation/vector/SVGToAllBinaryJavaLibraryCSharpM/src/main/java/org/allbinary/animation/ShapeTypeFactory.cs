/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2026 AllBinary 
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

namespace org.allbinary.animation;

public class ShapeTypeFactory
{
    private static readonly ShapeTypeFactory instance = new ShapeTypeFactory();
    public static ShapeTypeFactory getInstance()
    {
        return ShapeTypeFactory.instance;
    }

    public readonly string KEY_LINE = "line";
    public readonly string KEY_CIRCLE = "circle";
    public readonly string KEY_RECTANGLE = "rectangle";
    public readonly string KEY_RECT = "rect";
    public readonly ShapeType LINE = new ShapeType(KEY_LINE);
    public readonly ShapeType CIRCLE = new ShapeType(KEY_CIRCLE);
    public readonly ShapeType RECTANGLE = new ShapeType(KEY_RECTANGLE);
}


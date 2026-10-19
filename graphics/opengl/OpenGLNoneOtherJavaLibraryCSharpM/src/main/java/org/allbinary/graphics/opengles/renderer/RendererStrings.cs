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

namespace org.allbinary.graphics.opengles.renderer;

public class RendererStrings
{
    private static readonly RendererStrings instance = new RendererStrings();
    public static RendererStrings getInstance()
    {
        return RendererStrings.instance;
    }

    public readonly string ON_SURFACE_CREATED = "onSurfaceCreated";
    public readonly string ON_SURFACE_CHANGED = "onSurfaceChanged";
    public readonly string ON_DRAW_FRAME = "onDrawFrame";
    public readonly string ON_DRAW_FRAME_THREED = "onDrawFrameThreed";
    public readonly string ON_DRAW_FRAME_2D = "onDrawFrame2d";
}


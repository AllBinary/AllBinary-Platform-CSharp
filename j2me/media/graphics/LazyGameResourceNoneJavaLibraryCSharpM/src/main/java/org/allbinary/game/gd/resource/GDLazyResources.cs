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

namespace org.allbinary.game.gd.resource;

public class GDLazyResources
{
    private static readonly GDLazyResources instance = new GDLazyResources();
    public static GDLazyResources getInstance()
    {
        return GDLazyResources.instance;
    }

    public readonly int[] imageResourceWidthArray = new int[] {  };
    public readonly int[] imageResourceHeightArray = new int[] {  };
    public readonly string[] requiredResourcesBeforeLoadingArray = new string[] {  };
}


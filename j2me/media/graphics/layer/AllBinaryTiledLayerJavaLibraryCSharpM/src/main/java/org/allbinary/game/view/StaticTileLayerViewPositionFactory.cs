/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2006 AllBinary 
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
using ViewPositionBase = org.allbinary.view.ViewPositionBase;
using ViewPositionFactoryInterface = org.allbinary.view.ViewPositionFactoryInterface;

namespace org.allbinary.game.view;

public class StaticTileLayerViewPositionFactory : ViewPositionFactoryInterface
{
    // throws Exception
    public virtual ViewPositionBase getInstance()
    {
        return new StaticTileLayerIntoPositionViewPosition();
    }

}


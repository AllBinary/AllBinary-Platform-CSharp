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
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerFactoryInterface = org.allbinary.layer.AllBinaryLayerFactoryInterface;
using ViewPositionFactoryInterface = org.allbinary.view.ViewPositionFactoryInterface;

namespace org.allbinary.game.ag.layer.weapon.mine;

public class MineLayerFactory : AllBinaryLayerFactoryInterface
{
    private ViewPositionFactoryInterface viewPositionFactoryInterface;
    public MineLayerFactory(ViewPositionFactoryInterface viewPositionFactoryInterface)
    {
        this.viewPositionFactoryInterface = viewPositionFactoryInterface;
    }

    // throws Exception
    public virtual AllBinaryLayer getInstance()
    {
        return new MineLayer(this.viewPositionFactoryInterface.getInstance());
    }

}


/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2003 AllBinary 
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
using Visitor = org.allbinary.logic.util.visitor.Visitor;

namespace org.allbinary.game.input;

public class SelectRTSLayerVisitorFactory : SelectRTSLayerVisitorFactoryInterface
{
    private static readonly SelectRTSLayerVisitorFactory instance = new SelectRTSLayerVisitorFactory();
    public static SelectRTSLayerVisitorFactory getInstance()
    {
        return SelectRTSLayerVisitorFactory.instance;
    }

    private SelectRTSLayerVisitorFactory()
    {
    }

    public virtual Visitor create(SelectedRTSLayersPlayerGameInput selectedRTSLayersPlayerGameInput)
    {
        return new SelectRTSLayerVisitor();
    }

}


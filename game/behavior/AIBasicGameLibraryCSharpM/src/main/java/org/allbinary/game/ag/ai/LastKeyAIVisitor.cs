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
using BasicAI = org.allbinary.game.ai.BasicAI;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;
using Visitor = org.allbinary.logic.util.visitor.Visitor;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.ag.ai;

public class LastKeyAIVisitor : Visitor
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly bool? TRUE = BooleanFactory.getInstance().TRUE;
    public LastKeyAIVisitor()
    {
    }

    public override object visit(object anyType)
    {
        try {
            BasicAI basicAI = ((BasicAI) anyType);
            int key = basicAI.getLastKey();
            if (key != -1) {
                basicAI.processKeyAI(key);
            }
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.VISIT, e);
        }
        return this.TRUE;
    }

}


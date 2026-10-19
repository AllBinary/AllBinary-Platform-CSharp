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
using MyRandomFactory = org.allbinary.game.rand.MyRandomFactory;
using AngleFactory = org.allbinary.math.AngleFactory;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.graphics.pipeline;

public class RandomRotationFactory
{
    private static readonly RandomRotationFactory instance = new RandomRotationFactory();
    public static RandomRotationFactory getInstance()
    {
        return RandomRotationFactory.instance;
    }

    private readonly MyRandomFactory myRandomFactory = MyRandomFactory.getInstance();
    private readonly AngleFactory angleFactory = AngleFactory.getInstance();
    // throws Exception
    public virtual BasicArrayList getInstanceList(BasicArrayList vector, int howMuch)
    {
        BasicGraphicsPipeline graphicsPipe = new BasicGraphicsPipeline(vector);
        graphicsPipe.createMatrix();
        graphicsPipe.rotateToAngle(this.angleFactory.getAt(this.getNextRandomAngle(howMuch)));
        return graphicsPipe.getMatrix();
    }

    public virtual int getNextRandomAngle(int howMuch)
    {
        return this.myRandomFactory.getNextInt(howMuch * 10);
    }

}


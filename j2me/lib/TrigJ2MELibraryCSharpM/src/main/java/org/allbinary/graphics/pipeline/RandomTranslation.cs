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
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.graphics.pipeline;

public class RandomTranslation
{
    // throws Exception
    public static BasicArrayList getInstance(BasicArrayList vector, int howMuch)
    {
        MyRandomFactory myRandomFactory = MyRandomFactory.getInstance();
        int x = -myRandomFactory.getNextInt(howMuch);
        int y = myRandomFactory.getNextInt(howMuch);
        BasicGraphicsPipeline graphicsPipe = new BasicGraphicsPipeline(vector);
        graphicsPipe.createMatrix();
        graphicsPipe.translate(x, y);
        return graphicsPipe.getMatrix();
    }

}


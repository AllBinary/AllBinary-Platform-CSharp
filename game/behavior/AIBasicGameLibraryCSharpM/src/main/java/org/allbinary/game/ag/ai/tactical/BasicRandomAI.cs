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
//using Canvas = javax.microedition.lcdui.Canvas;
using BasicAI = org.allbinary.game.ai.BasicAI;
using InputProbability = org.allbinary.game.ag.ai.InputProbability;
using GameInput = org.allbinary.game.input.GameInput;
using MyRandomFactory = org.allbinary.game.rand.MyRandomFactory;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using Visitor = org.allbinary.logic.util.visitor.Visitor;
using GameTickTimeDelayHelperFactory = org.allbinary.time.GameTickTimeDelayHelperFactory;

namespace org.allbinary.game.ag.ai.tactical;

public class BasicRandomAI : BasicAI
{
    private int i_random = 0;
    private readonly InputProbability inputProbability;
    private readonly Visitor visitor;
    private readonly int[] keyArray = new int[] { Canvas.UP, Canvas.DOWN, Canvas.LEFT, Canvas.RIGHT, Canvas.KEY_NUM1, Canvas.KEY_NUM7, Canvas.KEY_NUM9 };
    public BasicRandomAI(AllBinaryLayer ownerLayerInterface, GameInput gameInput, InputProbability inputProbability, Visitor visitor) : base(ownerLayerInterface, gameInput)
    {
        // base(ownerLayerInterface, gameInput) is called from the constructor declaration
        this.inputProbability = inputProbability;
        this.visitor = visitor;
    }

    private readonly MyRandomFactory myRandomFactory = MyRandomFactory.getInstance();
    // throws Exception
    public override void processAI(AllBinaryLayerManager allBinaryLayerManager)
    {
        if (this.inputProbability.getTimeDelayHelper().isTime(GameTickTimeDelayHelperFactory.getInstance().startTime)) {
            this.i_random = this.myRandomFactory.getAbsoluteNextInt(this.inputProbability.getMax());
            bool repeat = false;
            int?[] repeatLikelyhoodIntegerArray = this.inputProbability.getRepeatLikelyhoodIntegerArray();
            if (this.getLastKey() != -1 && ((int) repeatLikelyhoodIntegerArray[this.getLastKey()]) >= this.i_random) {
                repeat = true;
            }
            if (!repeat) {
                int?[][] likelyhoodIntegerArray = this.inputProbability.getLikelyhoodIntegerArray();
                this.i_random = this.myRandomFactory.getAbsoluteNextInt(this.inputProbability.getMax());
                int size = this.keyArray.Length;
                int?[] likelyhoodIntegerKeyArray = null;
                for (int index = 0; index < size; index++) {
                    int key = this.keyArray[index];
                    likelyhoodIntegerKeyArray = likelyhoodIntegerArray[key];
                    if (likelyhoodIntegerArray.Length >= key && likelyhoodIntegerKeyArray[0] != null) {
                        if (this.i_random >= ((int) likelyhoodIntegerKeyArray[0]) && this.i_random < ((int) likelyhoodIntegerKeyArray[1])) {
                            this.setLastKey(key);
                            break;
                        }
                    }
                }
            }
            this.visitor.visit(this);
        }
    }

}


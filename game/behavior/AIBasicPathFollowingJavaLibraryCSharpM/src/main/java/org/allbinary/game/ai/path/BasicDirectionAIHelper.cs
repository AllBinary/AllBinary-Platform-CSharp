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
using Direction = org.allbinary.direction.Direction;
using DirectionFactory = org.allbinary.direction.DirectionFactory;
using AngleIncrementInfo = org.allbinary.math.AngleIncrementInfo;
using AngleInfo = org.allbinary.math.AngleInfo;

namespace org.allbinary.game.ai.path;

public class BasicDirectionAIHelper
{
    private string name;
    private AngleInfo angleInfo;
    public BasicDirectionAIHelper(string name, AngleInfo angleInfo)
    {
        this.name = name;
        this.angleInfo = angleInfo;
    }

    private int turnAI(int frame)
    {
        int keyDirection = -1;
        int directionAngle = this.angleInfo.getAngleIncrementInfo().getFrameAngle(frame);
        short angle = this.angleInfo.getAngle();
        int degrees = Math.Abs(directionAngle - ((int) angle));
        if (degrees < 180) {
            if (((int) angle) > directionAngle) {
                keyDirection = Canvas.LEFT;
            } else if (((int) angle) < directionAngle) {
                keyDirection = Canvas.RIGHT;
            }
        } else {
            if (((int) angle) > directionAngle) {
                keyDirection = Canvas.RIGHT;
            } else if (((int) angle) < directionAngle) {
                keyDirection = Canvas.LEFT;
            }
        }
        return keyDirection;
    }

    private int getAIKeyPressed(int? frame)
    {
        short angle = ((short) this.angleInfo.getAngleIncrementInfo().getFrameAngle(((int) frame)));
        if (this.angleInfo.getAngle() != angle) {
            return this.turnAI(((int) frame));
        } else {
            return Canvas.UP;
        }
    }

    public virtual int getAIKeyPressedFromDirection(Direction geographicMapDirectionData)
    {
        int keyDirection = -1;
        AngleIncrementInfo angleIncrementInfo = this.angleInfo.getAngleIncrementInfo();
        DirectionFactory directionFactory = DirectionFactory.getInstance();
        if (geographicMapDirectionData == directionFactory.DOWN) {
            keyDirection = this.getAIKeyPressed(angleIncrementInfo.DOWN_FRAME);
        } else if (geographicMapDirectionData == directionFactory.UP) {
            keyDirection = this.getAIKeyPressed(angleIncrementInfo.UP_FRAME);
        } else if (geographicMapDirectionData == directionFactory.LEFT) {
            keyDirection = this.getAIKeyPressed(angleIncrementInfo.LEFT_FRAME);
        } else if (geographicMapDirectionData == directionFactory.RIGHT) {
            keyDirection = this.getAIKeyPressed(angleIncrementInfo.RIGHT_FRAME);
        }
        return keyDirection;
    }

    protected virtual AngleInfo getAngleInfoP()
    {
        return this.angleInfo;
    }

    public virtual string getName()
    {
        return this.name;
    }

}


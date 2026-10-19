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
//using Graphics = javax.microedition.lcdui.Graphics;
using IndexedAnimation = org.allbinary.animation.IndexedAnimation;
using CanvasStrings = org.allbinary.graphics.displayable.CanvasStrings;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using CircularIndexUtil = org.allbinary.util.CircularIndexUtil;
using ViewPosition = org.allbinary.view.ViewPosition;
using ViewPositionBase = org.allbinary.view.ViewPositionBase;

namespace org.allbinary.game.combat.damage;

public class AnimationDamageFloaters : DamageFloaters
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private AllBinaryLayer layerInterface;
    private IndexedAnimation[] animationInterfaceArray;
    private readonly CircularIndexUtil circularIndexUtil;
    private int dx;
    private int dy;
    public AnimationDamageFloaters(AllBinaryLayer layerInterface, IndexedAnimation[] animationInterfaceArray, int dx, int dy)
    {
        this.animationInterfaceArray = animationInterfaceArray;
        for (int index = this.animationInterfaceArray.Length - 1; index >= 0; index--) {
            this.animationInterfaceArray[index].setFrame(this.animationInterfaceArray[index].getSize() - 1);
        }
        this.layerInterface = layerInterface;
        this.circularIndexUtil = CircularIndexUtil.createInstance(this.animationInterfaceArray.Length);
        this.dx = dx;
        this.dy = dy;
    }

    public override void add(int damage)
    {
        int i = this.circularIndexUtil.getIndex();
        this.animationInterfaceArray[i].setFrame(0);
        this.circularIndexUtil.next();
    }

    public override void paint(Graphics graphics)
    {
        try {
            ViewPositionBase viewPosition = this.layerInterface.getViewPosition();
            int x = viewPosition.getX();
            int y = viewPosition.getY();
            for (int index = 0; index < this.animationInterfaceArray.Length; index++) {
                IndexedAnimation animationInterface = this.animationInterfaceArray[index];
                if (animationInterface.getFrame() < animationInterface.getAnimationSize() - 1) {
                    int delta = animationInterface.getFrame() * 20;
                    animationInterface.paintXY(graphics, x + this.dx, y - delta + this.dy);
                    animationInterface.nextFrame();
                }
            }
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            CanvasStrings canvasStrings = CanvasStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, canvasStrings.PAINT, e);
        }
    }

}


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
using MyRandomFactory = org.allbinary.game.rand.MyRandomFactory;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorArrayIndexer = org.allbinary.graphics.color.BasicColorArrayIndexer;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using BasicColorSetUtil = org.allbinary.graphics.color.BasicColorSetUtil;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using CharArrayFactory = org.allbinary.logic.java.character.CharArrayFactory;
using PrimitiveLongUtil = org.allbinary.logic.math.PrimitiveLongUtil;
using CircularIndexUtil = org.allbinary.util.CircularIndexUtil;
using ViewPosition = org.allbinary.view.ViewPosition;
using ViewPositionBase = org.allbinary.view.ViewPositionBase;

namespace org.allbinary.game.combat.damage;

public class PtsDamageFloaters : DamageFloaters
{
    public readonly BasicColorSetUtil basicSetColorUtil = BasicColorSetUtil.getInstance();
    private AllBinaryLayer layerInterface;
    private int[] lastDamage = new int[5];
    private char[][] lastDamageString = System.Linq.Enumerable.Range(0, 5).Select(_ => new char[0]).ToArray();
    private int[] lastDamageStringSizeArray = new int[5];
    private CircularIndexUtil circularIndexUtil = CircularIndexUtil.createInstance(5);
    private readonly PrimitiveLongUtil primitiveLongUtil;
    private static readonly BasicColorArrayIndexer basicColorArrayIndexer = new BasicColorArrayIndexer(new BasicColor[] { BasicColorFactory.getInstance().WHITE, BasicColorFactory.getInstance().RED, BasicColorFactory.getInstance().YELLOW, BasicColorFactory.getInstance().BLUE });
    public PtsDamageFloaters(AllBinaryLayer layerInterface)
    {
        this.primitiveLongUtil = PrimitiveLongUtil.createPowerOfTen(100000);
        this.layerInterface = layerInterface;
        char[] CHAR_ARRAY = CharArrayFactory.getInstance().getZeroCharArray();
        for (int index = this.lastDamageString.Length - 1; index >= 0; index--) {
            this.lastDamageString[index] = CHAR_ARRAY;
        }
    }

    public override void add(int damage)
    {
        int index = this.circularIndexUtil.getIndex();
        this.lastDamage[index] = damage;
        this.lastDamageString[index] = this.primitiveLongUtil.getCharArray(this.lastDamage[index]);
        this.lastDamageStringSizeArray[index] = this.primitiveLongUtil.getCurrentTotalDigits();
        this.circularIndexUtil.next();
    }

    private readonly MyRandomFactory myRandomFactory = MyRandomFactory.getInstance();
    public override void paint(Graphics graphics)
    {
        ViewPositionBase viewPosition = this.layerInterface.getViewPosition();
        int x = viewPosition.getX();
        int y = viewPosition.getY();
        for (int index = this.lastDamage.Length - 1; index >= 0; index--) {
            if (this.lastDamage[index] != 0) {
                int delta = 10 * (index + 2);
                this.basicSetColorUtil.setBasicColorP(graphics, PtsDamageFloaters.basicColorArrayIndexer.get());
                graphics.drawChars(this.lastDamageString[index], 0, this.lastDamageStringSizeArray[index], x - this.myRandomFactory.getNextInt(delta), y - delta, 0);
                PtsDamageFloaters.basicColorArrayIndexer.next();
            }
            this.lastDamage[index] = 0;
        }
    }

}


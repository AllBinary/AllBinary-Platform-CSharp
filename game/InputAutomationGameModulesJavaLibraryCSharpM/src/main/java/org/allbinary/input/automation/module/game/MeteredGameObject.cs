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
//using BufferedImage = java.awt.image.BufferedImage;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.input.automation.module.game;

public class MeteredGameObject : MeteredGameObjectInterface
{
    private double?[] ratios = null;
    private bool good = false;
    private bool dropping = false;
    private int? minX = null;
    private int? maxX = null;
    private int? y = null;
    private int? size = null;
    private readonly string RATIOS_LABEL = "Ratios: ";
    private readonly string IS_GOOD_LABEL = "isGood: ";
    private readonly string IS_DROPPPING_LABEL = "isDropping: ";
    public MeteredGameObject(BufferedImage[] bufferedImage, int? minX, int? maxX, int? y)
    {
        this.setRatios(new double?[bufferedImage.Length]);
        this.setMinX(minX);
        this.setMaxX(maxX);
        this.setY(y);
        this.setSize(maxX - minX);
        for (int index = 0; index < bufferedImage.Length; index++) {
            double nominator = GraphicsAnalysisUtil.getNominator(bufferedImage[index], this.getMinX(), this.getMaxX(), this.getY());
            this.getRatios()[index] = nominator / this.getSize();
        }
        if (((double) this.getRatios()[bufferedImage.Length - 1]) > 0.93F) {
            this.setGood(true);
        } else {
            this.setGood(false);
        }
        if (((double) this.getRatios()[bufferedImage.Length - 1]) < ((double) this.getRatios()[0])) {
            this.setDropping(true);
        } else {
            this.setDropping(false);
        }
    }

    public virtual bool isGood()
    {
        return this.good;
    }

    protected virtual void setGood(bool good)
    {
        this.good = good;
    }

    public virtual bool isDropping()
    {
        return this.dropping;
    }

    protected virtual void setDropping(bool dropping)
    {
        this.dropping = dropping;
    }

    public virtual double?[] getRatios()
    {
        return this.ratios;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        CommonSeps commonSeps = CommonSeps.getInstance();
        stringBuffer.append(commonSeps.NEW_LINE);
        stringBuffer.append(this.RATIOS_LABEL);
        for (int index = 0; index < this.getRatios().Length; index++) {
            stringBuffer.append(this.getRatios()[index].ToString());
            if (index < this.getRatios().Length - 1) {
                stringBuffer.append(commonSeps.COMMA_SEP);
            }
        }
        stringBuffer.append(commonSeps.NEW_LINE);
        stringBuffer.append(this.IS_GOOD_LABEL);
        stringBuffer.appendboolean(this.isGood());
        stringBuffer.append(commonSeps.NEW_LINE);
        stringBuffer.append(this.IS_DROPPPING_LABEL);
        stringBuffer.appendboolean(this.isDropping());
        return stringBuffer.ToString();
    }

    public virtual void setRatios(double?[] ratios)
    {
        this.ratios = ratios;
    }

    public virtual int? getMinX()
    {
        return this.minX;
    }

    public virtual void setMinX(int? minX)
    {
        this.minX = minX;
    }

    public virtual int? getMaxX()
    {
        return this.maxX;
    }

    public virtual void setMaxX(int? maxX)
    {
        this.maxX = maxX;
    }

    public virtual int? getY()
    {
        return this.y;
    }

    public virtual void setY(int? y)
    {
        this.y = y;
    }

    public virtual int? getSize()
    {
        return this.size;
    }

    public virtual void setSize(int? size)
    {
        this.size = size;
    }

}


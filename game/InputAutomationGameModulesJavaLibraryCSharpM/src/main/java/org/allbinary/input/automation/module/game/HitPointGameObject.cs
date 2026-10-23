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

public class HitPointGameObject : MeteredGameObject, HitPointGameObjectInterface
{
    private bool damaged = false;
    private bool closeDeath = false;
    private readonly string HP_LABEL = "HP: ";
    private readonly string IS_DAMAGED_LABEL = "isDamaged: ";
    private readonly string IS_CLOSE_DEATH_LABEL = "isCloseDeath: ";
    public HitPointGameObject(BufferedImage[] bufferedImage, int? minX, int? maxX, int? y) : base(bufferedImage, minX, maxX, y)
    {
        // base(bufferedImage, minX, maxX, y) is called from the constructor declaration
        if (((double) this.getRatios()[bufferedImage.Length - 1]) < 1.0F) {
            this.setDamaged(true);
        } else {
            this.setDamaged(false);
        }
        if (((double) this.getRatios()[bufferedImage.Length - 1]) > 0.25F) {
            this.closeDeath = false;
        } else {
            this.closeDeath = true;
        }
    }

    public virtual bool isMoreThan(float aFloat)
    {
        if (((double) this.getRatios()[this.getRatios().Length - 1]) > aFloat) {
            return true;
        } else {
            return false;
        }
    }

    public virtual bool isCloseDeath()
    {
        return this.closeDeath;
    }

    public virtual void setCloseDeath(bool closeDeath)
    {
        this.closeDeath = closeDeath;
    }

    public virtual bool isDamaged()
    {
        return this.damaged;
    }

    public virtual void setDamaged(bool damaged)
    {
        this.damaged = damaged;
    }

    public override string ToString()
    {
        CommonSeps commonSeps = CommonSeps.getInstance();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.HP_LABEL);
        stringBuffer.append(base.ToString());
        stringBuffer.append(commonSeps.NEW_LINE);
        stringBuffer.append(this.IS_DAMAGED_LABEL);
        stringBuffer.appendboolean(this.isDamaged());
        stringBuffer.append(commonSeps.NEW_LINE);
        stringBuffer.append(this.IS_CLOSE_DEATH_LABEL);
        stringBuffer.appendboolean(this.isCloseDeath());
        return stringBuffer.ToString();
    }

}


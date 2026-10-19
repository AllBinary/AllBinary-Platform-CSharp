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
//using Displayable = javax.microedition.lcdui.Displayable;
using AndroidUtil = org.allbinary.AndroidUtil;
using Features = org.allbinary.game.configuration.feature.Features;
using DisplayChangeEvent = org.allbinary.graphics.displayable.@event.DisplayChangeEvent;
using DisplayChangeEventHandler = org.allbinary.graphics.displayable.@event.DisplayChangeEventHandler;
using LastDisplayChangeEventHandler = org.allbinary.graphics.displayable.@event.LastDisplayChangeEventHandler;
using OpenGLFeatureFactory = org.allbinary.graphics.opengles.OpenGLFeatureFactory;
using SWTJOGLProcessor = org.allbinary.graphics.threed.SWTJOGLProcessor;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using GenericOperatingSystem = org.allbinary.logic.system.os.GenericOperatingSystem;
using OperatingSystemFactory = org.allbinary.logic.system.os.OperatingSystemFactory;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.graphics.displayable;

public class DisplayInfoSingleton
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly DisplayInfoSingleton SINGLETON = new DisplayInfoSingleton();
    public static DisplayInfoSingleton getInstance()
    {
        return DisplayInfoSingleton.SINGLETON;
    }

    private readonly CommonLabels commonLabels = CommonLabels.getInstance();
    private readonly CommonSeps commonSeps = CommonSeps.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly string ORIENTATION = "ORIENTATION";
    public readonly string ADJUSTING_FOR_SCALING_IN_PORTRAIT = "Adjusting for Scaling in portrait display ratio: ";
    public readonly string ADJUSTING_FOR_SCALING_IN_LANDSCAPE = "Adjusting for Scaling in landscape display ratio: ";
    private int[] last = new int[4];
    private int[] lastHalf = new int[4];
    private int[] full = new int[4];
    private int top = 0;
    private int left = 0;
    private int xOffset = 0;
    private int yOffset = 0;
    private float scaleLargestTo = 0f;
    public readonly int WIDTH = 0;
    public readonly int HEIGHT = 1;
    public readonly int CUSTOM_WIDTH = 2;
    public readonly int CUSTOM_HEIGHT = 3;
    private BaseScalable scalableListener = new BaseScalable();
    private float displayRatio = 0f;
    private float ratio = 1.0f;
    private DisplayInfoSingleton()
    {
        this.displayChangeEvent = new DisplayChangeEvent(this);
        int size = this.last.Length;
        for (int index = 0; index < size; index++) {
            this.last[index] = 0;
            this.lastHalf[index] = 0;
            this.full[index] = 0;
        }
        if (AndroidUtil.isAndroid()) {
            this.scaleLargestTo = 640f;
        } else {
            this.scaleLargestTo = 1080f;
        }
    }

    public virtual int[] getLastHalf()
    {
        return this.lastHalf;
    }

    public virtual int[] getLast()
    {
        return this.last;
    }

    public virtual int[] getFull()
    {
        return this.full;
    }

    public virtual float getScaleLargestTo()
    {
        return this.scaleLargestTo;
    }

    public virtual void setScaleLargestTo(int scaleLargestTo)
    {
        this.scaleLargestTo = ((float) scaleLargestTo);
    }

    private readonly string SET_LAST_SIZE_METHOD_NAME = "setLastSize";
    private readonly string FULL_WIDTH = " FullWidth: ";
    private readonly string FULL_HEIGHT = " FullHeight: ";
    private readonly string LAST_WIDTH = "LastWidth: ";
    private readonly string LAST_HEIGHT = " LastHeight: ";
    private readonly string PORTRAIT = "Portrait";
    private readonly string LANDSCAPE = "Landscape";
    public virtual void setLastSize(int aLastWidth, int aLastHeight, string reason)
    {
        if (this.full[this.WIDTH] != aLastWidth || this.full[this.HEIGHT] != aLastHeight) {
            this.setLastSizeForce(aLastWidth, aLastHeight, reason);
        }
    }

    private void setLastSizeForce(int aLastWidth, int aLastHeight, string reason)
    {
        StringMaker stringMaker = new StringMaker();
        this.logUtil.putF(stringMaker.append(CommonLabels.getInstance().START_LABEL).append(reason).ToString(), this, this.SET_LAST_SIZE_METHOD_NAME);
        int aFullWidth = aLastWidth;
        int aFullHeight = aLastHeight;
        stringMaker.delete(0, stringMaker.length());
        this.logUtil.putF(stringMaker.append(this.FULL_WIDTH).appendint(aFullWidth).append(this.FULL_HEIGHT).appendint(aFullHeight).append(this.ToString()).ToString(), this, this.SET_LAST_SIZE_METHOD_NAME);
        GenericOperatingSystem operatingSystemInterface = OperatingSystemFactory.getInstance().getOperatingSystemInstance();
        if (operatingSystemInterface.isOverScan()) {
            aLastWidth = aLastWidth * operatingSystemInterface.getOverScanXPercent() / 100;
            aLastHeight = aLastHeight * operatingSystemInterface.getOverScanYPercent() / 100;
        }
        if (operatingSystemInterface.isScalable()) {
            if (this.isPortraitWH(aLastWidth, aLastHeight)) {
                if (((float) aLastHeight) > this.scaleLargestTo) {
                    this.displayRatio = this.scaleLargestTo / ((float) aLastHeight);
                    this.ratio = ((float) aLastHeight) / this.scaleLargestTo;
                    stringMaker.delete(0, stringMaker.length());
                    this.logUtil.putF(stringMaker.append(this.ADJUSTING_FOR_SCALING_IN_PORTRAIT).appendfloat(this.displayRatio).ToString(), this, this.SET_LAST_SIZE_METHOD_NAME);
                    aLastWidth = ((int) (((float) aLastWidth) * this.displayRatio));
                    aLastHeight = ((int) (((float) aLastHeight) * this.displayRatio));
                    this.scalableListener.scale(this.ratio);
                } else {
                    this.ratio = 1.0f;
                    this.scalableListener.scale(this.ratio);
                }
            } else {
                if (((float) aLastWidth) > this.scaleLargestTo) {
                    this.displayRatio = this.scaleLargestTo / ((float) aLastWidth);
                    this.ratio = ((float) aLastWidth) / this.scaleLargestTo;
                    stringMaker.delete(0, stringMaker.length());
                    this.logUtil.putF(stringMaker.append(this.ADJUSTING_FOR_SCALING_IN_LANDSCAPE).appendfloat(this.displayRatio).ToString(), this, this.SET_LAST_SIZE_METHOD_NAME);
                    aLastWidth = ((int) (((float) aLastWidth) * this.displayRatio));
                    aLastHeight = ((int) (((float) aLastHeight) * this.displayRatio));
                    this.scalableListener.scale(this.ratio);
                } else {
                    this.ratio = 1.0f;
                    this.scalableListener.scale(this.ratio);
                }
            }
        }
        stringMaker.delete(0, stringMaker.length());
        this.logUtil.putF(stringMaker.append(this.LAST_WIDTH).appendint(aLastWidth).append(this.LAST_HEIGHT).appendint(aLastHeight).ToString(), this, this.SET_LAST_SIZE_METHOD_NAME);
        this.xOffset = aFullWidth - aLastWidth;
        this.yOffset = aFullHeight - aLastHeight;
        this.left = this.scalableListener.getLeft(this.xOffset);
        this.top = this.scalableListener.getTop(this.yOffset);
        this.full[this.WIDTH] = aFullWidth;
        this.full[this.HEIGHT] = aFullHeight;
        this.last[this.WIDTH] = aLastWidth;
        this.lastHalf[this.WIDTH] = (this.last[this.WIDTH] >> 1);
        this.last[this.HEIGHT] = aLastHeight;
        this.lastHalf[this.HEIGHT] = (this.last[this.HEIGHT] >> 1);
        SWTJOGLProcessor.getInstance().setCustom(aLastWidth, aLastHeight, this.ratio);
        this.add(this.SET_LAST_SIZE_METHOD_NAME);
    }

    public virtual bool isPortraitWH(int lastWidth, int lastHeight)
    {
        if (lastHeight > lastWidth) {
            return true;
        } else {
            return false;
        }
    }

    public virtual bool isPortrait()
    {
        return this.isPortraitWH(this.last[this.WIDTH], this.last[this.HEIGHT]);
    }

    public readonly DisplayChangeEvent displayChangeEvent;
    private readonly string FIRE_METHOD_NAME = "fire";
    private readonly string REASON = "reason: ";
    private readonly string UPDATE_FROM_ORIENTATION_CHANGE = "Updating from Orientation Change ";
    private readonly BasicArrayList list = new BasicArrayListD();
    public virtual void add(string reason)
    {
        StringMaker stringMaker = new StringMaker();
        this.logUtil.putF(stringMaker.append(this.REASON).append(reason).ToString(), this, this.FIRE_METHOD_NAME);
        stringMaker.delete(0, stringMaker.length());
        this.logUtil.putF(this.toStringAppend(stringMaker), this, this.FIRE_METHOD_NAME);
        this.list.add(reason);
    }

    public virtual void process()
    {
        try {
            if (this.list.size() > 0) {
                this.processForced();
            }
            this.list.clear();
        } catch (Exception e) {
            PreLogUtil.putOE(this.commonStrings.EXCEPTION, this, this.FIRE_METHOD_NAME, e);
        }
    }

    public virtual void processForced()
    {
        try {
            SWTJOGLProcessor swtJOGLProcessor = SWTJOGLProcessor.getInstance();
            swtJOGLProcessor.clear();
            DisplayChangeEventHandler.getInstance().fireEvent(this.displayChangeEvent);
            LastDisplayChangeEventHandler.getInstance().fireEvent(this.displayChangeEvent);
            swtJOGLProcessor.onSurfaceChanged();
        } catch (Exception e) {
            PreLogUtil.putOE(this.commonStrings.EXCEPTION, this, this.FIRE_METHOD_NAME, e);
        }
    }

    public virtual void update(Displayable displayable, string reason)
    {
        int aLastWidth = displayable.getWidth();
        int aLastHeight = displayable.getHeight();
        int aFullWidth = aLastWidth;
        int aFullHeight = aLastHeight;
        StringMaker stringMaker = new StringMaker();
        this.logUtil.putF(stringMaker.append(CommonLabels.getInstance().START_LABEL).append(reason).append(this.LAST_WIDTH).appendint(aLastWidth).append(this.LAST_HEIGHT).appendint(aLastHeight).append(this.commonSeps.SPACE).append(this.ToString()).ToString(), this, this.commonStrings.UPDATE);
        if (aLastWidth > 0 && aLastHeight > 0) {
            Features features = Features.getInstance();
            OpenGLFeatureFactory openGLFeatureFactory = OpenGLFeatureFactory.getInstance();
            if (!features.isDefault(openGLFeatureFactory.OPENGL) || this.last[this.WIDTH] != aLastWidth || this.last[this.HEIGHT] != aLastHeight) {
                stringMaker.delete(0, stringMaker.length());
                this.logUtil.putF(stringMaker.append(this.UPDATE_FROM_ORIENTATION_CHANGE).ToString(), this, this.commonStrings.UPDATE);
                GenericOperatingSystem operatingSystemInterface = OperatingSystemFactory.getInstance().getOperatingSystemInstance();
                if (operatingSystemInterface.isOverScan()) {
                    aLastWidth = aLastWidth * operatingSystemInterface.getOverScanXPercent() / 100;
                    aLastHeight = aLastHeight * operatingSystemInterface.getOverScanYPercent() / 100;
                }
                if (operatingSystemInterface.isScalable()) {
                    if (this.isPortraitWH(aLastWidth, aLastHeight)) {
                        if (((float) aLastHeight) > this.scaleLargestTo) {
                            this.displayRatio = this.scaleLargestTo / ((float) aLastHeight);
                            this.ratio = ((float) aLastHeight) / this.scaleLargestTo;
                            stringMaker.delete(0, stringMaker.length());
                            this.logUtil.putF(stringMaker.append(this.ADJUSTING_FOR_SCALING_IN_PORTRAIT).appendfloat(this.displayRatio).ToString(), this, this.commonStrings.UPDATE);
                            aLastWidth = ((int) (((float) aLastWidth) * this.displayRatio));
                            aLastHeight = ((int) (((float) aLastHeight) * this.displayRatio));
                            this.scalableListener.scale(this.ratio);
                        } else {
                            this.ratio = 1.0f;
                            this.scalableListener.scale(this.ratio);
                        }
                    } else {
                        if (((float) aLastWidth) > this.scaleLargestTo) {
                            this.displayRatio = this.scaleLargestTo / ((float) aLastWidth);
                            this.ratio = ((float) aLastWidth) / this.scaleLargestTo;
                            stringMaker.delete(0, stringMaker.length());
                            this.logUtil.putF(stringMaker.append(this.ADJUSTING_FOR_SCALING_IN_LANDSCAPE).appendfloat(this.displayRatio).ToString(), this, this.commonStrings.UPDATE);
                            aLastWidth = ((int) (((float) aLastWidth) * this.displayRatio));
                            aLastHeight = ((int) (((float) aLastHeight) * this.displayRatio));
                            this.scalableListener.scale(this.ratio);
                        } else {
                            this.ratio = 1.0f;
                            this.scalableListener.scale(this.ratio);
                        }
                    }
                }
                stringMaker.delete(0, stringMaker.length());
                this.logUtil.putF(stringMaker.append(this.UPDATE_FROM_ORIENTATION_CHANGE).append(this.LAST_WIDTH).appendint(aLastWidth).append(this.LAST_HEIGHT).appendint(aLastHeight).ToString(), this, this.commonStrings.UPDATE);
                this.xOffset = aFullWidth - aLastWidth;
                this.yOffset = aFullHeight - aLastHeight;
                this.left = this.scalableListener.getLeft(this.xOffset);
                this.top = this.scalableListener.getTop(this.yOffset);
                this.full[this.WIDTH] = aFullWidth;
                this.full[this.HEIGHT] = aFullHeight;
                this.last[this.WIDTH] = aLastWidth;
                this.lastHalf[this.WIDTH] = (this.last[this.WIDTH] >> 1);
                this.last[this.HEIGHT] = aLastHeight;
                this.lastHalf[this.HEIGHT] = (this.last[this.HEIGHT] >> 1);
                SWTJOGLProcessor.getInstance().setCustom(aLastWidth, aLastHeight, this.ratio);
                this.add(this.commonStrings.UPDATE);
            }
        }
    }

    private readonly string DISPLAY_INFO = "Display Info: ";
    private readonly string FULL = "full";
    private readonly string LAST = "last";
    private readonly string LAST_HALF = "lastHalf";
    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        return this.toStringAppend(stringBuffer);
    }

    public virtual string toStringAppend(StringMaker stringBuffer)
    {
        stringBuffer.append(this.DISPLAY_INFO);
        stringBuffer.append(this.FULL);
        stringBuffer.append(this.commonLabels.WIDTH_LABEL);
        stringBuffer.appendint(this.full[this.WIDTH]);
        stringBuffer.append(this.commonSeps.SPACE);
        stringBuffer.append(this.FULL);
        stringBuffer.append(this.commonLabels.HEIGHT_LABEL);
        stringBuffer.appendint(this.full[this.HEIGHT]);
        stringBuffer.append(this.commonSeps.SPACE);
        stringBuffer.append(this.LAST);
        stringBuffer.append(this.commonLabels.WIDTH_LABEL);
        stringBuffer.appendint(this.last[this.WIDTH]);
        stringBuffer.append(this.commonSeps.SPACE);
        stringBuffer.append(this.LAST);
        stringBuffer.append(this.commonLabels.HEIGHT_LABEL);
        stringBuffer.appendint(this.last[this.HEIGHT]);
        stringBuffer.append(this.commonSeps.SPACE);
        stringBuffer.append(this.LAST_HALF);
        stringBuffer.append(this.commonLabels.WIDTH_LABEL);
        stringBuffer.appendint(this.lastHalf[this.WIDTH]);
        stringBuffer.append(this.commonSeps.SPACE);
        stringBuffer.append(this.LAST_HALF);
        stringBuffer.append(this.commonLabels.HEIGHT_LABEL);
        stringBuffer.appendint(this.lastHalf[this.HEIGHT]);
        stringBuffer.append(this.commonSeps.SPACE);
        stringBuffer.append((this.isPortrait() ? this.PORTRAIT : this.LANDSCAPE));
        return stringBuffer.ToString();
    }

    public virtual int getTop()
    {
        return this.top;
    }

    public virtual int getLeft()
    {
        return this.left;
    }

    public virtual int getLastWidth()
    {
        return this.last[this.WIDTH];
    }

    public virtual int getLastHeight()
    {
        return this.last[this.HEIGHT];
    }

    public virtual int getLastHalfWidth()
    {
        return this.lastHalf[this.WIDTH];
    }

    public virtual int getLastHalfHeight()
    {
        return this.lastHalf[this.HEIGHT];
    }

    public virtual int getCustomLastWidth()
    {
        return this.last[this.CUSTOM_WIDTH];
    }

    public virtual int getCustomLastHeight()
    {
        return this.last[this.CUSTOM_HEIGHT];
    }

    public virtual int getRawLastWidth()
    {
        return this.last[this.WIDTH];
    }

    public virtual int getRawLastHeight()
    {
        return this.last[this.HEIGHT];
    }

    public virtual void setCustom(int width, int height)
    {
        this.last[this.CUSTOM_WIDTH] = width;
        this.lastHalf[this.CUSTOM_WIDTH] = (this.last[this.CUSTOM_WIDTH] >> 1);
        this.last[this.CUSTOM_HEIGHT] = height;
        this.lastHalf[this.CUSTOM_HEIGHT] = (this.last[this.CUSTOM_HEIGHT] >> 1);
    }

    public virtual void setScalableListener(BaseScalable scalableListener)
    {
        this.scalableListener = scalableListener;
    }

    public virtual ScalableListener getScalableListener()
    {
        return this.scalableListener;
    }

    public virtual float getRatio()
    {
        return this.ratio;
    }

    public virtual float getDisplayRatio()
    {
        return this.displayRatio;
    }

    public virtual void setOffset(int left, int top)
    {
        this.left = left;
    }

    public virtual int getxOffset()
    {
        return this.xOffset;
    }

    public virtual int getyOffset()
    {
        return this.yOffset;
    }

}


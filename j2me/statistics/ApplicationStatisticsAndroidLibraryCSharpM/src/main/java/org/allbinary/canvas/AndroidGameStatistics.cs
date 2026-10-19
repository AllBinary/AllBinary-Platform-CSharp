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
using View = android.view.View;
using BaseViewWrapper = org.allbinary.android.view.BaseViewWrapper;
using ViewWrapper = org.allbinary.android.view.ViewWrapper;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.canvas;

public class AndroidGameStatistics : BaseGameStatistics
{
    private BaseViewWrapper view = BaseViewWrapper.NULL_VIEW_WRAPPER;
    private long totalOnDraws = 0L;
    private readonly string[] ANDROID_STRING_ARRAY = new string[14];
    public AndroidGameStatistics()
    {
        StringUtil stringUtil = StringUtil.getInstance();
        for (int index = 0; index < this.ANDROID_STRING_ARRAY.Length; index++) {
            this.ANDROID_STRING_ARRAY[index] = stringUtil.EMPTY_STRING;
        }
    }

    public virtual void initView(View view)
    {
        base.init();
        this.view = new ViewWrapper(view);
        this.totalOnDraws = 0L;
    }

    public override void process()
    {
        this.view.postInvalidate();
    }

    public virtual void nextOnDraw()
    {
        this.totalOnDraws++;
    }

    private readonly string TOTAL_ONDRAWS = " Total onDraws: ";
    private readonly string ONDRAWS_RATE = " onDraws(/10) Sec: ";
    public override string[] toStringArray()
    {
        string[] stringArray = base.toStringArray();
        for (int index = 0; index < stringArray.Length; index++) {
            this.ANDROID_STRING_ARRAY[index] = stringArray[index];
        }
        long totalTime = this.getTimeDelayHelper().getElapsed(this.gameTickTimeDelayHelper.startTime);
        totalTime = (totalTime / 10000L);
        this.ANDROID_STRING_ARRAY[10] = this.TOTAL_ONDRAWS;
        this.ANDROID_STRING_ARRAY[11] = (this.totalOnDraws).ToString();
        this.ANDROID_STRING_ARRAY[12] = this.ONDRAWS_RATE;
        this.ANDROID_STRING_ARRAY[13] = (this.totalOnDraws / totalTime).ToString();
        return this.ANDROID_STRING_ARRAY;
    }

    public override string ToString()
    {
        long totalTime = this.getTimeDelayHelper().getElapsed(this.gameTickTimeDelayHelper.startTime);
        totalTime = (totalTime / 1000L);
        if (totalTime > 0L) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(base.toStringAt(totalTime));
            if (this.totalOnDraws > 0L) {
                stringBuffer.append(this.TOTAL_ONDRAWS);
                stringBuffer.append((this.totalOnDraws).ToString());
                stringBuffer.append(this.ONDRAWS_RATE);
                string drawsOverTime = (this.totalOnDraws / totalTime).ToString();
                stringBuffer.append(drawsOverTime);
            }
            return stringBuffer.ToString();
        } else {
            return this.NOT;
        }
    }

}


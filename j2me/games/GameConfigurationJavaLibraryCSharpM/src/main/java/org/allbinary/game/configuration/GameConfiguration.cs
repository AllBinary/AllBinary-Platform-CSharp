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
using GameFeatureEvent = org.allbinary.game.configuration.@event.GameFeatureEvent;
using GameFeatureEventHandler = org.allbinary.game.configuration.@event.GameFeatureEventHandler;
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.game.configuration;

public class GameConfiguration
{
    private static readonly int? MIN_VALUE = int.MinValue;
    private string name = StringUtil.getInstance().EMPTY_STRING;
    private int? defaultValue = SmallIntegerSingletonFactory.getInstance().getAt(0);
    private int? value = GameConfiguration.MIN_VALUE;
    private int? minValue;
    private int? maxValue;
    private bool? modifiable = BooleanFactory.getInstance().TRUE;
    public GameConfiguration(string name, int? defaultValue, int? minValue, int? maxValue)
    {
        this.minValue = this.defaultValue;
        this.maxValue = this.defaultValue;
        this.setName(name);
        this.setDefaultValue(defaultValue);
        this.value = this.getDefaultValue();
        this.setMinValue(minValue);
        this.setMaxValue(maxValue);
        GameConfigurationSingleton.getInstance().getHashtable().put(this.getName(), this);
    }

    // throws Exception
    public virtual void setValue(int? value)
    {
        if (this.value != value) {
            int? oldValue = this.value;
            this.value = value;
            GameFeatureEventHandler.getInstance().fireEvent(new GameFeatureEvent(this, new StringMaker().append(this.name).append(" value: from: ").appendint(((int) ((int) oldValue))).append(" to ").appendint(((int) ((int) this.value))).ToString()));
        }
    }

    public virtual int? getValue()
    {
        return this.value;
    }

    public virtual void setMaxValue(int? maxValue)
    {
        this.maxValue = maxValue;
    }

    public virtual int? getMaxValue()
    {
        return this.maxValue;
    }

    public virtual void setMinValue(int? minValue)
    {
        this.minValue = minValue;
    }

    public virtual int? getMinValue()
    {
        return this.minValue;
    }

    public virtual void setName(string name)
    {
        this.name = name;
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual void setDefaultValue(int? defaultValue)
    {
        this.defaultValue = defaultValue;
    }

    protected virtual int? getDefaultValue()
    {
        return this.defaultValue;
    }

    // throws Exception
    public virtual void setDefault()
    {
        this.setValue(this.getDefaultValue());
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("Name: ");
        stringBuffer.append(this.name);
        stringBuffer.append(" Min: ");
        stringBuffer.appendint(((int) ((int) this.getMinValue())));
        stringBuffer.append(" Max: ");
        stringBuffer.appendint(((int) ((int) this.getMaxValue())));
        stringBuffer.append(" Value: ");
        stringBuffer.appendint(((int) ((int) this.getValue())));
        stringBuffer.append(" Default: ");
        stringBuffer.appendint(((int) ((int) this.getDefaultValue())));
        stringBuffer.append(" Modifiable: ");
        stringBuffer.appendboolean(this.isModifiable());
        return stringBuffer.ToString();
    }

    public virtual void setModifiable(bool? modifiable)
    {
        this.modifiable = modifiable;
    }

    public virtual bool? isModifiable()
    {
        return this.modifiable;
    }

}


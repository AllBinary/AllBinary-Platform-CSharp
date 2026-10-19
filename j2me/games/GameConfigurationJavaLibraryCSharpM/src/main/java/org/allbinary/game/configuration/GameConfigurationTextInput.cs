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
//using TextField = javax.microedition.lcdui.TextField;
using StdUtil = org.allbinary.logic.StdUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using org.allbinary.util;

namespace org.allbinary.game.configuration;

public class GameConfigurationTextInput
{
    private static ABHashtable<object, object> hashtable = StdUtil.getInstance().createHashtable();
    public static GameConfigurationTextInput SIMULATOR_IP = new GameConfigurationTextInput("IP: ", "192.168.1.3");
    public static GameConfigurationTextInput SIMULATOR_PORT = new GameConfigurationTextInput("Port: ", "8010");
    private string label = StringUtil.getInstance().EMPTY_STRING;
    private string text = StringUtil.getInstance().EMPTY_STRING;
    public GameConfigurationTextInput(string label, string text)
    {
        this.setText(text);
        this.setLabel(label);
        GameConfigurationTextInput.hashtable.put(this.getLabel(), this);
    }

    public static void update(TextField textField)
    {
        object anyType = ((object) textField.getLabel());
        GameConfigurationTextInput gameConfigurationTextInput = ((GameConfigurationTextInput) GameConfigurationTextInput.hashtable.get(anyType));
        gameConfigurationTextInput.setText(textField.getString());
    }

    public virtual void setText(string text)
    {
        this.text = text;
    }

    public virtual string getText()
    {
        return this.text;
    }

    public virtual void setLabel(string label)
    {
        this.label = label;
    }

    public virtual string getLabel()
    {
        return this.label;
    }

    public static ABHashtable<object, object> getHashtable()
    {
        return GameConfigurationTextInput.hashtable;
    }

}


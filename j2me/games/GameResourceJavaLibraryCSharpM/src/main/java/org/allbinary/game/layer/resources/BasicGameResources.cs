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
using GameConfigurationCentral = org.allbinary.game.configuration.GameConfigurationCentral;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.layer.resources;

public class BasicGameResources
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public static readonly StringMaker stringBuffer = new StringMaker();
    public string RESOURCE = StringUtil.getInstance().EMPTY_STRING;
    public string RESOURCE_DESTROY = StringUtil.getInstance().EMPTY_STRING;
    protected BasicGameResources()
    {
    }

    public virtual void init(string ROOT, string[] SIZE)
    {
        try {
            int scale = ((int) GameConfigurationCentral.getInstance().SCALE.getValue());
            if (scale > 1 && scale - 1 < SIZE.Length) {
                this.append(ROOT, SIZE[scale - 1]);
            } else {
                throw new Exception(new StringMaker().append("Invalid Value: ").appendint(scale).ToString());
            }
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.INIT, e);
        }
    }

    // throws Exception
    protected virtual void append(string ROOT, string sizeString)
    {
        string DESTROY = "_destroy";
        string @string = this.getString();
        BasicGameResources.stringBuffer.delete(0, BasicGameResources.stringBuffer.length());
        BasicGameResources.stringBuffer.append(ROOT);
        BasicGameResources.stringBuffer.append(@string);
        BasicGameResources.stringBuffer.append(sizeString);
        this.RESOURCE = BasicGameResources.stringBuffer.ToString();
        BasicGameResources.stringBuffer.delete(0, BasicGameResources.stringBuffer.length());
        BasicGameResources.stringBuffer.append(ROOT);
        BasicGameResources.stringBuffer.append(DESTROY);
        BasicGameResources.stringBuffer.append(@string);
        BasicGameResources.stringBuffer.append(sizeString);
        this.RESOURCE_DESTROY = BasicGameResources.stringBuffer.ToString();
    }

    // throws Exception
    protected virtual string getString()
    {
        return GameGraphicsResourceUtil.getInstance().getName();
    }

}


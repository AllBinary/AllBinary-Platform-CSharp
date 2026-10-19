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
using NullUtil = org.allbinary.logic.NullUtil;

namespace org.allbinary.game.identification;

public class BasicGroupFactory
{
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static BasicGroupFactory getInstance()
    {
        if (BasicGroupFactory.instance == NullUtil.getInstance().NULL_OBJECT) {
            BasicGroupFactory.instance = new BasicGroupFactory();
        }
        return ((BasicGroupFactory) BasicGroupFactory.instance);
    }

    public readonly string NAME = "GROUP_NAME";
    public readonly string NO_SUCH_GROUP = "No Such Group: ";
    public readonly Group GOOD = new Group("Good Guys", ((short) 0));
    public readonly Group ENEMY = new Group("Bad Guys", ((short) 1));
    public readonly Group ENEMY_ON_LEVEL = new Group("Bad Guys on Level", ((short) 2));
    public readonly Group NONE = new Group("Not On A Team", ((short) 3));
    public readonly Group[] GOOD_ARRAY;
    public readonly Group[] ENEMY_ARRAY;
    public readonly Group[] ENEMY_ON_LEVEL_ARRAY;
    public readonly Group[] NONE_ARRAY;
    public BasicGroupFactory()
    {
        this.GOOD_ARRAY = new Group[] { this.GOOD };
        this.ENEMY_ARRAY = new Group[] { this.ENEMY };
        this.ENEMY_ON_LEVEL_ARRAY = new Group[] { this.ENEMY, this.ENEMY_ON_LEVEL };
        this.NONE_ARRAY = new Group[] { this.NONE };
    }

}


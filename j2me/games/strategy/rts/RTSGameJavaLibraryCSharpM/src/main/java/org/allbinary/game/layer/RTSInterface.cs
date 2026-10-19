/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2003 AllBinary 
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

namespace org.allbinary.game.layer;

public interface RTSInterface
{
    bool isSelfUpgradeable();

    bool isCompleted();

    int getPercentComplete();

    int getLevel();

    int getMaxLevel();

    int getCost();

    void downgrade();

    int getDowngradeCost();

    bool isDowngradeable();

    int getUpgradeCost();

    bool isUpgradeable();

    void upgrade();

}


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
//using java.awt;

namespace org.allbinary.media.image.analysis;

public interface ColorRangeInterface
{
    int getMinRed();

    void setMinRed(int minRed);

    int getMaxRed();

    void setMaxRed(int maxRed);

    int getMinGreen();

    void setMinGreen(int minGreen);

    int getMaxGreen();

    void setMaxGreen(int maxGreen);

    int getMinBlue();

    void setMinBlue(int minBlue);

    int getMaxBlue();

    void setMaxBlue(int maxBlue);

    bool isInRange(Color color);

}


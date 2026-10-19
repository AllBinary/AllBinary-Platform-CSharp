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
using Document = org.w3c.dom.Document;

namespace org.allbinary.graphics.j2me.workarea;

public interface WorkAreaJPanelInterface : java.awt.event.KeyListener
{
    string getName();

    void deselect();

    void select();

    void changeZoom(int factor);

    void explodeAll();

    // throws Exception
    void autoRotate(int increments, int totalAngle);

    // throws Exception
    void autoExplode(int numberOfFrames, int explodeType);

    // throws Exception
    void autoMirror();

    void play();

    void stop();

    bool isPlaying();

    // throws Exception
    Document toDocument();

}


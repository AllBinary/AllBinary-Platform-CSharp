// Generated Code Do Not Modify

using System;
using System.Linq;
using GameInitializedListenerInterface = org.allbinary.game.configuration.@event.GameInitializedListenerInterface;
using DemoGameMidletEventListener = org.allbinary.game.midlet.DemoGameMidletEventListener;
using MidletCompositeInterface = org.allbinary.midlet.MidletCompositeInterface;

namespace org.allbinary.view;

public interface AllBinaryMidletViewInterface : MidletCompositeInterface, EmulatorViewInterface, DemoGameMidletEventListener, GameInitializedListenerInterface
{
    void onResume();

    void onPause();

    void onDestroy();

}


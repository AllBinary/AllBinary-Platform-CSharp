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
//using URL = java.net.URL;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
//using HelpSet = javax.help.HelpSet;

namespace org.allbinary.logic.java.help;

public class JavaHelpSetNotifier
{
    private static BasicArrayList vector = new BasicArrayListD();
    private JavaHelpSetNotifier()
    {
    }

    private static BasicArrayList get()
    {
        return JavaHelpSetNotifier.vector;
    }

    public static bool isNotified(HelpSet helpSet)
    {
        bool isNotified = false;
        URL url = helpSet.getHelpSetURL();
        int size = JavaHelpSetNotifier.vector.size();
        object[] urlArray = JavaHelpSetNotifier.vector.toArray();
        for (int i = 0; i < size; i++) {
            URL nextURL = ((URL) urlArray[i]);
            if (string.CompareOrdinal(url.ToString(), nextURL.ToString()) == 0) {
                isNotified = true;
            }
        }
        JavaHelpSetNotifier.vector.add(url);
        return isNotified;
    }

}


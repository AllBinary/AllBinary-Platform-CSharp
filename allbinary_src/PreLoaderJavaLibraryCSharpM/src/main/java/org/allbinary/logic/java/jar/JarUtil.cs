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
//using IOException = java.io.IOException;
//using URL = java.net.URL;
//using URLConnection = java.net.URLConnection;
//using JarEntry = java.util.jar.JarEntry;
//using JarInputStream = java.util.jar.JarInputStream;

namespace org.allbinary.logic.java.jar;

public class JarUtil
{
    private URL jarURL;
    public JarUtil(URL jarURL)
    {
        this.jarURL = jarURL;
    }

    public virtual void show()
    {
        sbyte[] cache = new sbyte[1024];
        try {
            URLConnection conn = this.jarURL.openConnection();
            JarInputStream jis = new JarInputStream(conn.getInputStream());
            while (true) {
                JarEntry entry = jis.getNextJarEntry();
                if (entry != null) {
                    if (!entry.isDirectory()) {
                        int offset = 0;
                        int i = 0;
                        while (((i = jis.read(cache, offset, cache.Length - offset))) != -1) {
                            offset += i;
                            if (offset >= cache.Length) {
                                sbyte[] newcache = new sbyte[cache.Length + 1024];
                                Array.Copy((Array) cache, 0, (Array) newcache, 0, cache.Length);
                                cache = newcache;
                            }
                        }
                        sbyte[] tmp = new sbyte[offset];
                        Array.Copy((Array) cache, 0, (Array) tmp, 0, offset);
                        Console.WriteLine(entry.getName());
                    }
                } else {
                    break;
                }
            }
        } catch (IOException ex) {
            Console.WriteLine(ex);
            Console.WriteLine(ex);
        }
    }

    // throws Exception
    public static void main(string[] args)
    {
        new JarUtil(new URL("file:///G:/mnt/bc/mydev/working/j2me/MiniSpaceWars/MiniSpaceWars/dist/MiniSpaceWars.jar")).show();
    }

}


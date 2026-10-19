// Generated Code Do Not Modify

using System;
using System.Linq;
using BaseBasicArrayListCache = org.allbinary.logic.util.cache.BaseBasicArrayListCache;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListS = org.allbinary.util.BasicArrayListS;

namespace org.allbinary.media.graphics.geography.pathfinding;

public class BasicGeographicMapExtractedPathCacheFactory : BaseBasicArrayListCache
{
    private static readonly BasicGeographicMapExtractedPathCacheFactory instance = new BasicGeographicMapExtractedPathCacheFactory();
    public static BasicGeographicMapExtractedPathCacheFactory getInstance()
    {
        return BasicGeographicMapExtractedPathCacheFactory.instance;
    }

    private int maxConcurrentPaths = 0;
    private int maxPaths = 0;
    private BasicGeographicMapExtractedPathCacheFactory()
    {
    }

    public virtual void init(int maxConcurrentPaths, int maxPaths)
    {
        if (maxConcurrentPaths != this.maxConcurrentPaths) {
            for (int index = maxConcurrentPaths; index >= this.maxConcurrentPaths; index--) {
                this.list.add(new BasicArrayListS(maxPaths));
            }
            this.maxConcurrentPaths = maxConcurrentPaths;
        }
        this.maxPaths = maxPaths;
    }

    public virtual BasicArrayList getPath()
    {
        if (this.list.size() > 0) {
            return ((BasicArrayList) this.list.removeAt(0));
        } else {
            return new BasicArrayListS(this.maxPaths);
        }
    }

    public virtual void release(BasicArrayList list)
    {
        list.clear();
        this.list.add(list);
    }

}


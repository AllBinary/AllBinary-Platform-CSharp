// Generated Code Do Not Modify

using System;
using System.Linq;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BaseBasicArrayListCache = org.allbinary.logic.util.cache.BaseBasicArrayListCache;
using BasicArrayListS = org.allbinary.util.BasicArrayListS;

namespace org.allbinary.media.graphics.geography.pathfinding;

public class BasicGeographicMapExtractedPathsCacheFactory : BaseBasicArrayListCache
{
    private static readonly BasicGeographicMapExtractedPathsCacheFactory instance = new BasicGeographicMapExtractedPathsCacheFactory();
    public static BasicGeographicMapExtractedPathsCacheFactory getInstance()
    {
        return BasicGeographicMapExtractedPathsCacheFactory.instance;
    }

    private int maxConcurrentPaths = 0;
    private int maxPaths = 0;
    private BasicGeographicMapExtractedPathsCacheFactory()
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

    public virtual BasicArrayList getPaths()
    {
        if (this.list.size() > 0) {
            return ((BasicArrayList) this.list.removeAt(0));
        } else {
            return new BasicArrayListS(this.maxPaths);
        }
    }

    public virtual void release(BasicArrayList list)
    {
        for (int index = list.size() - 1; index >= 0; index--) {
            BasicGeographicMapExtractedPathCacheFactory.getInstance().release(((BasicArrayList) list.get(index)));
        }
        list.clear();
        this.list.add(list);
    }

}


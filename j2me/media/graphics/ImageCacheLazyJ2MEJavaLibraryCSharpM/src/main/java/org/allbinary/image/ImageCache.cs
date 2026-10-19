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
//using InputStream = java.io.InputStream;
//using Image = javax.microedition.lcdui.Image;
//using NullImage = javax.microedition.lcdui.NullImage;
using J2MEUtil = org.allbinary.J2MEUtil;
using TsUtil = org.allbinary.TsUtil;
using LazyImageRotationAnimation = org.allbinary.animation.image.LazyImageRotationAnimation;
using GameGlobalsFactory = org.allbinary.canvas.GameGlobalsFactory;
using Processor = org.allbinary.canvas.Processor;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using ResourceUtil = org.allbinary.data.resource.ResourceUtil;
using ABToGBUtil = org.allbinary.game.canvas.ABToGBUtil;
using AllBinaryGameCanvas = org.allbinary.game.displayable.canvas.AllBinaryGameCanvas;
using GDLazyResources = org.allbinary.game.gd.resource.GDLazyResources;
using GDResources = org.allbinary.game.gd.resource.GDResources;
using ProgressCanvas = org.allbinary.graphics.canvas.transition.progress.ProgressCanvas;
using ProgressCanvasFactory = org.allbinary.graphics.canvas.transition.progress.ProgressCanvasFactory;
using CommonSeps = org.allbinary.@string.CommonSeps;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using Memory = org.allbinary.system.Memory;
using BaseImageLoadingProcessor = org.allbinary.thread.BaseImageLoadingProcessor;
using ConcurrentImageLoadingProcessor = org.allbinary.thread.ConcurrentImageLoadingProcessor;
using SynchObject = org.allbinary.thread.SynchObject;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using ABSystemWrapper = org.allbinary.logic.ABSystemWrapper;

namespace org.allbinary.image;

public class ImageCache : ImageCacheBase
{
    public static readonly ImageCache NULL_IMAGE_CACHE = new ImageCache();
    private readonly TsUtil tsUtil = TsUtil.getInstance();
    private readonly BaseImageLoadingProcessor concurrentImageLoadingProcessor;
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly CommonSeps commonSeps = CommonSeps.getInstance();
    public readonly ResourceUtil resourceUtil = ResourceUtil.getInstance();
    private readonly GameGlobalsFactory gameGlobalsFactory = GameGlobalsFactory.getInstance();
    private readonly GDResources gdResources = GDResources.getInstance();
    public readonly BasicArrayList loadNowList = new BasicArrayListD();
    public readonly BasicArrayList loadSoonList = new BasicArrayListD();
    public readonly BasicArrayList loadList = new BasicArrayListD();
    public readonly BasicArrayList loadAfterList = new BasicArrayListD();
    private readonly SynchObject @lock = new SynchObject();
    private bool firstTime = true;
    private int totalLoaded = 0;
    public bool progressEnded = false;
    public bool hasAnyLazyAnimationFactories = false;
    private class NotHTMLProcessor : Processor
    {
        public override void process()
        {
            concurrentImageLoadingProcessor.runTask();
        }

    }
    private class NotHTMLEndProcessor : Processor
    {
        public override void process()
        {
            ProgressCanvas progressCanvas = ProgressCanvasFactory.getInstance();
            progressCanvas.endIfPaintedSinceStart();
        }

    }
    private class HTMLEndProcessor : Processor
    {
        public override void process()
        {
            int size = gdResources.currentLayoutRequiredTotal;
            if (size == 0) {
                ProgressCanvas progressCanvas = ProgressCanvasFactory.getInstance();
                progressCanvas.endIfPaintedSinceStart();
            } else if (totalLoaded > size / 12) {
                ProgressCanvas progressCanvas = ProgressCanvasFactory.getInstance();
                progressCanvas.endIfPaintedSinceStart();
                endProcessor = new NotHTMLEndProcessor();
            }
        }

    }
    private class FirstProcessor : Processor
    {
        public override void process()
        {
            this.firstProcess();
        }

    }
    private Processor processor = new FirstProcessor();
    private Processor endProcessor = Processor.getInstance();
    public ImageCache()
    {
        this.concurrentImageLoadingProcessor = new ConcurrentImageLoadingProcessor(this);
    }

    public virtual void firstProcess()
    {
        LogUtil logUtil = LogUtil.getInstance();
        bool isHTML = J2MEUtil.isHTML();
        if (isHTML) {
            this.processor = Processor.getInstance();
            this.endProcessor = new HTMLEndProcessor();
        } else {
            this.processor = new NotHTMLProcessor();
            this.endProcessor = new NotHTMLEndProcessor();
            try {
                this.runTask();
            } catch (Exception e) {
                logUtil.putF(this.commonStrings.EXCEPTION, this, this.commonStrings.END_METHOD_NAME);
            }
        }
    }

    public virtual void addListener(object renderer)
    {
    }

    // throws Exception
    public virtual void waitForLoadNow()
    {
        if (this.firstTime) {
            ABToGBUtil abToGBUtil = ABToGBUtil.getInstance();
            AllBinaryGameCanvas abCanvas = ((AllBinaryGameCanvas) abToGBUtil.abCanvas);
            while (this.loadNowList.isEmpty() && (!abCanvas.isInitialized() || (abCanvas.isInitialized() && this.hasAnyLazyAnimationFactories)) && !this.progressEnded) {
                System.Threading.Thread.Sleep((int) (120));
            }
            this.firstTime = false;
        }
    }

    private readonly string LOAD_IMAGE_FOR_ANIMATION = "Load Image Animation";
    // throws Exception
    public virtual void loadImageForAnimation()
    {
        LazyImageRotationAnimation lazyImageRotationAnimation = null;
        lock (this.@lock) {
            if (this.loadNowList.isEmpty()) {
                this.endProcessor.process();
                if (this.loadSoonList.isEmpty()) {
                    if (this.loadAfterList.isEmpty()) {
                        if (this.firstTime) {
                        } else if (this.gameGlobalsFactory.newCanvas) {
                        } else {
                            this.loadNextImage();
                        }
                        return;
                    } else {
                        lazyImageRotationAnimation = ((LazyImageRotationAnimation) this.loadAfterList.get(0));
                        if (this.loadImageForLazyAnimation(lazyImageRotationAnimation)) {
                            this.loadAfterList.remove(lazyImageRotationAnimation);
                        }
                    }
                } else {
                    lazyImageRotationAnimation = ((LazyImageRotationAnimation) this.loadSoonList.get(0));
                    if (this.loadImageForLazyAnimation(lazyImageRotationAnimation)) {
                        this.loadSoonList.remove(lazyImageRotationAnimation);
                    }
                }
                return;
            }
            lazyImageRotationAnimation = ((LazyImageRotationAnimation) this.loadNowList.get(0));
        }
        if (this.loadImageForLazyAnimation(lazyImageRotationAnimation)) {
            lock (this.@lock) {
                this.loadNowList.remove(lazyImageRotationAnimation);
            }
            if (lazyImageRotationAnimation.layoutIndex != 0) {
                BasicArrayList list = this.getAssociated(lazyImageRotationAnimation);
                lock (this.@lock) {
                    int size = list.size();
                    if (size > 0) {
                        this.loadSoonList.addAllList(list);
                    }
                }
            }
            ProgressCanvas progressCanvas = ProgressCanvasFactory.getInstance();
            bool isHTML = J2MEUtil.isHTML();
            if (this.loadNowList.isEmpty() && (!isHTML || this.firstTime)) {
                progressCanvas.endFromInitialLazyLoadingComplete();
            } else {
                if (this.totalLoaded % 10 == 0) {
                    progressCanvas.addNormalPortion(1, this.LOAD_IMAGE_FOR_ANIMATION);
                }
            }
        }
    }

    // throws Exception
    public virtual void loadImages()
    {
        while (!this.loadList.isEmpty() || !this.loadNowList.isEmpty()) {
            this.loadImageForAnimations();
            this.loadNextImage();
        }
    }

    // throws Exception
    public virtual void loadImageForAnimations()
    {
        while (!this.loadNowList.isEmpty()) {
            this.loadImageForAnimation();
        }
    }

    // throws Exception
    public virtual void loadRemainingAnimations()
    {
        while (!this.loadAfterList.isEmpty() || !this.loadNowList.isEmpty()) {
            while (!this.loadNowList.isEmpty()) {
                this.loadImageForAnimation();
            }
            LazyImageRotationAnimation lazyImageRotationAnimation = null;
            lock (this.@lock) {
                if (!this.loadAfterList.isEmpty()) {
                    lazyImageRotationAnimation = ((LazyImageRotationAnimation) this.loadAfterList.removeAt(0));
                }
            }
            if (lazyImageRotationAnimation != null) {
                this.loadImageForLazyAnimation(lazyImageRotationAnimation);
            }
        }
    }

    // throws Exception
    private bool loadImageForLazyAnimation(LazyImageRotationAnimation lazyImageRotationAnimation)
    {
        Image image = lazyImageRotationAnimation.animationInterfaceFactoryInterface.getImage();
        if (this.loadImage(image)) {
            lazyImageRotationAnimation.setRealAnimation();
            return true;
        }
        return false;
    }

    // throws Exception
    private void loadNextImage()
    {
        Image image = null;
        lock (this.@lock) {
            if (this.loadList.size() == 0) {
                return;
            }
            image = ((Image) this.loadList.removeAt(0));
        }
        this.loadImage(image);
    }

    // throws Exception
    private bool loadImage(Image image)
    {
        if (image.isReady()) {
            return true;
        } else {
            if (image.getImage() != null) {
                if (image.setReady()) {
                    if (image.isReady()) {
                        this.totalLoaded++;
                        return true;
                    }
                }
            } else {
                string key = image.getName();
                Image image2 = this.creatImage(key);
                if (image2.isReady()) {
                    this.init(image, image2);
                    return true;
                } else {
                    image.setImage(image2.getImage());
                }
            }
        }
        return false;
    }

    // throws Exception
    protected virtual void init(Image image, Image image2)
    {
        image.init(image2.getImage());
    }

    // throws Exception
    protected virtual Image creatImage(string key)
    {
        InputStream inputStream = this.resourceUtil.getResourceAsStream(key);
        Image image = ImageFactory.getInstance().createImageFromInputStream(inputStream);
        image.setName(key);
        return image;
    }

    // throws Exception
    public override Image get(string caller, int width, int height)
    {
        int foundIndex = this.getIndexWH(width, height);
        Image image = this.getFromAvailable(foundIndex, width, height);
        if (image == NullImage.NULL_IMAGE) {
            this.volume += width * height;
            if (this.volume > 32000) {
                this.tsUtil.gc();
                this.volume = 0;
            }
            image = this.createImage(caller, width, height);
            if (this.nextIndex > this.widths.Length - 1) {
                if (foundIndex == -1) {
                    foundIndex = this.nextIndex;
                    this.widths[this.nextIndex] = width;
                    this.heights[this.nextIndex] = height;
                    this.nextIndex++;
                }
                this.listOfList[foundIndex].add(image);
            }
        }
        return image;
    }

    // throws Exception
    public override Image getWithKey(object key)
    {
        Image image = this.getImage(key);
        if (image == NullImage.NULL_IMAGE) {
            InputStream inputStream = null;
            try {
                image = this.createImageFromInputStream(key, inputStream);
            } catch (Exception e) {
                this.logUtil.put("Exception: Trying Again After GC", this, this.commonStrings.GET, e);
                this.logUtil.putF(new StringMaker().append("InputStream: ").append(StringUtil.getInstance().toString(inputStream)).ToString(), this, this.commonStrings.GET);
                this.tsUtil.gc();
                this.tsUtil.gc();
                this.logUtil.putF(Memory.getInfo(), this, this.commonStrings.GET);
                System.Threading.Thread.Sleep((int) (100));
                image = this.createImageFromInputStream(key, inputStream);
            }
            this.hashtable.put(key, image);
        }
        return image;
    }

    public virtual int getIndex(object key)
    {
        GDResources gdResources = GDResources.getInstance();
        string[] resourceStringArray = gdResources.resourceStringArray;
        int size = resourceStringArray.Length;
        for (int index = 0; index < size; index++) {
            if (resourceStringArray[index] == key) {
                return index;
            }
        }
        this.logUtil.putF(new StringMaker().append("unable to find key: ").append(StringUtil.getInstance().toString(key)).ToString(), this, this.commonStrings.RUN);
        throw new SystemException();
    }

    // throws Exception
    protected override Image createImageFromInputStream(object key, InputStream inputStream)
    {
        GDLazyResources gdLazyResources = GDLazyResources.getInstance();
        string[] resourceStringArray = gdLazyResources.requiredResourcesBeforeLoadingArray;
        int size = resourceStringArray.Length;
        for (int index = 0; index < size; index++) {
            if (key == resourceStringArray[index]) {
                return this.creatImage(((string) key));
            }
        }
        this.runTask();
        int index = this.getIndex(key);
        int width = gdLazyResources.imageResourceWidthArray[index];
        int height = gdLazyResources.imageResourceHeightArray[index];
        Image image = this.createImageLater(((string) key), width, height);
        lock (this.@lock) {
            this.loadList.add(image);
        }
        return image;
    }

    // throws Exception
    protected virtual Image createImageLater(string key, int width, int height)
    {
        return Image.createImageLater(key, width, height);
    }

    public virtual BasicArrayList getAssociated(LazyImageRotationAnimation lazyImageRotationAnimation)
    {
        BasicArrayList list = new BasicArrayListD();
        lock (this.@lock) {
            LazyImageRotationAnimation lazyImageRotationAnimation2 = null;
            int size = this.loadAfterList.size();
            for (int index = 0; index < size; index++) {
                lazyImageRotationAnimation2 = ((LazyImageRotationAnimation) this.loadAfterList.get(index));
                if (lazyImageRotationAnimation2.instanceId == lazyImageRotationAnimation.instanceId) {
                    list.add(lazyImageRotationAnimation2);
                }
            }
            int size2 = list.size();
            for (int index = 0; index < size2; index++) {
                this.loadAfterList.remove(list.get(index));
            }
        }
        return list;
    }

    public virtual void add(LazyImageRotationAnimation lazyImageRotationAnimation)
    {
        lock (this.@lock) {
            this.loadAfterList.add(lazyImageRotationAnimation);
        }
    }

    // throws Exception
    public virtual void insertFirst(LazyImageRotationAnimation lazyImageRotationAnimation)
    {
        if (this.loadNowList.contains(lazyImageRotationAnimation)) {
        } else {
            lock (this.@lock) {
                this.loadNowList.add(lazyImageRotationAnimation);
                this.loadAfterList.remove(lazyImageRotationAnimation);
            }
        }
        this.runTask();
    }

    public virtual void progressEnded()
    {
        this.progressEnded = true;
    }

    // throws Exception
    public virtual void runTask()
    {
        this.processor.process();
    }

    public override void initProgress()
    {
        if (this.firstTime) {
            this.firstTime = false;
        }
    }

    public virtual bool isLazy()
    {
        return true;
    }

}


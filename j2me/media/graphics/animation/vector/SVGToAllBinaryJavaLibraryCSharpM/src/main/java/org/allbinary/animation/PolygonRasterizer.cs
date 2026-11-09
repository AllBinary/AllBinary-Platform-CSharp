// Generated Code Do Not Modify

using System;
using System.Linq;

namespace org.allbinary.animation;

public class PolygonRasterizer
{
    private static readonly PolygonRasterizer instance = new PolygonRasterizer();
    public static PolygonRasterizer getInstance()
    {
        return PolygonRasterizer.instance;
    }

    public virtual int[] getPixelBuffer(string svgPath, int[] pathX, int[] pathY, int[] pixelBuffer, int width, int height)
    {
        int pointCount = PathParser.parsePath(svgPath, pathX, pathY, pathX.Length);
        for (int i = 0; i < pixelBuffer.Length; i++) {
            pixelBuffer[i] = unchecked((int) 0xFFFFFFFF);
        }
        PolygonRasterizer.getInstance().fillPolygon(pathX, pathY, pointCount, pixelBuffer, width, height, unchecked((int) 0xFFFF00FF));
        return pixelBuffer;
    }

    public virtual void fillPolygon(int[] polyX, int[] polyY, int numPoints, int[] buffer, int width, int height, int colorRGB)
    {
        if (numPoints < 3) {
            return;
        }
        FixedPoint fixedPoint = FixedPoint.getInstance();
        int[] x = new int[numPoints];
        int[] y = new int[numPoints];
        int minY = height;
        int maxY = 0;
        for (int i_1 = 0; i_1 < numPoints; i_1++) {
            x[i_1] = fixedPoint.toInt(polyX[i_1]);
            y[i_1] = fixedPoint.toInt(polyY[i_1]);
            if (y[i_1] < minY) {
                minY = y[i_1];
            }
            if (y[i_1] > maxY) {
                maxY = y[i_1];
            }
        }
        if (minY < 0) {
            minY = 0;
        }
        if (maxY >= height) {
            maxY = height - 1;
        }
        int[] scanlineX = new int[numPoints];
        for (int scanY = minY; scanY <= maxY; scanY++) {
            int intersectCount = 0;
            for (int i_2 = 0; i_2 < numPoints; i_2++) {
                int next = (i_2 + 1) % numPoints;
                int x1 = x[i_2];
                int y1 = y[i_2];
                int x2 = x[next];
                int y2 = y[next];
                if ((y1 < scanY && y2 >= scanY) || (y2 < scanY && y1 >= scanY)) {
                    if (y2 != y1) {
                        int interX = x1 + (scanY - y1) * (x2 - x1) / (y2 - y1);
                        scanlineX[intersectCount++] = interX;
                    }
                }
            }
            for (int i_3 = 0; i_3 < intersectCount - 1; i_3++) {
                for (int j = i_3 + 1; j < intersectCount; j++) {
                    if (scanlineX[i_3] > scanlineX[j]) {
                        int temp = scanlineX[i_3];
                        scanlineX[i_3] = scanlineX[j];
                        scanlineX[j] = temp;
                    }
                }
            }
            for (int i_5 = 0; i_5 < intersectCount; i_5 += 2) {
                if (i_5 + 1 >= intersectCount) {
                    break;
                }
                int startX = scanlineX[i_5];
                int endX = scanlineX[i_5 + 1];
                if (startX < 0) {
                    startX = 0;
                }
                if (endX >= width) {
                    endX = width - 1;
                }
                int rowOffset = scanY * width;
                for (int pixelX = startX; pixelX <= endX; pixelX++) {
                    buffer[rowOffset + pixelX] = colorRGB;
                }
            }
        }
    }

    public virtual void main(string[] args)
    {
        int width = 100;
        int height = 100;
        int[] pathX = new int[200];
        int[] pathY = new int[200];
        int[] pixelBuffer = new int[width * height];
        string svgPath = "M 32.139812,81.554575 14.450128,74.294372 V 50.000034 25.705697 l 17.73231,-7.268329 C 41.935209,14.439788 49.953112,11.168898 50,11.168723 c 0.04689,-1.74e-4 8.064791,3.270238 17.817562,7.267583 l 17.73231,7.267899 V 50 74.295795 l -17.73231,7.2679 c -9.752771,3.997344 -17.789855,7.264116 -17.860188,7.259492 -0.07033,-0.0046 -8.088235,-3.275499 -17.817562,-7.268612 z";
        PolygonRasterizer.getInstance().getPixelBuffer(svgPath, pathX, pathY, pixelBuffer, width, height);
    }

}


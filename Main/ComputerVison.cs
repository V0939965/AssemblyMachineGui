using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Drawing;

namespace Main
{
    class ComputerVison
    {
        
        public static T TestRoi<T>(T scr,Rectangle roi)
        {
            CvInvoke.Rectangle((IInputOutputArray)scr, roi, new MCvScalar(255, 0, 255), 2);
            return scr;
        }
        public static Image<Gray, byte> RoiImage(Image<Gray, byte> scr, Rectangle roi)
        {
            scr.ROI = Rectangle.Empty;
            scr.ROI = roi;
            return scr;
        }
        public static void RotationImage(ref Image<Gray, byte> scr,System.Drawing.Point Center,float Angle)
        {
            using (Bitmap a = scr.ToBitmap())
            {
                using (Bitmap Ro_Images = new Bitmap(scr.Width, scr.Height))
                {
                    using (Graphics gfx = Graphics.FromImage(Ro_Images))
                    {
                        gfx.TranslateTransform((float)Center.X, (float)Center.Y);
                        gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        gfx.RotateTransform(Angle);
                        gfx.TranslateTransform(-(float)Center.X, -(float)Center.Y);
                        gfx.DrawImage(a, new System.Drawing.Point(0, 0));
                        scr = new Image<Gray, byte>(Ro_Images);
                    }

                }
            }
            
        }
        public static void TransformImage(ref Image<Gray, byte> scr, int X,int Y)
        {
            float[,] translationArray = { { 1, 0, X }, { 0, 1, Y } };
            Matrix<float> translationMatrix = new Matrix<float>(translationArray);
            CvInvoke.WarpAffine(scr, scr, translationMatrix, scr.Size);
        }
        public static VectorOfPoint FindContours(Image<Gray, byte> scr, int Threshold_Value)
        {
            if (null != scr)
            {
                using (Image<Gray, byte> Threshold_Image = new Image<Gray, byte>(scr.Size))
                {
                    CvInvoke.Threshold(scr, Threshold_Image, Threshold_Value, 255, ThresholdType.Binary);
                    VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                    CvInvoke.FindContours(Threshold_Image, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
                    switch (contours.Size)
                    {
                        case 0:
                            return null;
                        case 1:
                            return contours[0];
                        default:
                        {
                            double area = 0;
                            int index = 0;
                            for (int i = 0; i < contours.Size; i++)
                            {
                                double s = CvInvoke.ContourArea(contours[i], false);
                                if (area < s)
                                {
                                    area = s;
                                    index = i;
                                }
                            }
                            return contours[index];
                        }
                    }
                    
                }
            }
            else
                return null;
        }

        public static System.Drawing.Point[] Search2Tip(VectorOfPoint cnt)
        {
            if (null != cnt)
            {
                RotatedRect Rou = CvInvoke.MinAreaRect(cnt);
                System.Drawing.PointF[] pF = Rou.GetVertices();
                System.Drawing.Point[] p = new System.Drawing.Point[pF.Length];
                for (int i = 0; i < p.Length; i++)
                    p[i] = System.Drawing.Point.Round(pF[i]);
                var a = p.OrderBy(item => (Math.Pow(item.X, 2) + Math.Pow(item.Y, 2)));
                var b = p.OrderBy(item => item.X);
                //clear p
                p = null;
                p = new System.Drawing.Point[2];
                p[0] = a.ElementAt(0);
                
                foreach (var item in b)
                {
                    if (item == a.ElementAt(0))
                        continue;
                    else
                    {
                        p[1] = item;
                        break;
                    }
                }
                return p;
            }
            else
                return null;
            
        }
        public static void RouPoint(System.Drawing.Point RouCenter, ref System.Drawing.Point point, double angle)
        {
            System.Drawing.Point p = new System.Drawing.Point();
            int x = (point.X - RouCenter.X);
            int y = (point.Y - RouCenter.Y);
            angle = angle * Math.PI / 180.0;
            int x1 = (int)Math.Round(x * Math.Cos(angle) - y * Math.Sin(angle));
            int y1 = (int)Math.Round(x * Math.Sin(angle) + y * Math.Cos(angle));
            p.X = x1 + RouCenter.X;
            p.Y = y1 + RouCenter.Y;
            point = p;
        }
        public static void Calculator(ref Response Socurce, System.Drawing.Point A,System.Drawing.Point B,System.Drawing.Point A1, System.Drawing.Point B1, int HeightLable,bool mode)
        {
            Vector org = new Vector(B.X - A.X, B.Y - A.Y);
            Vector v = new Vector(B1.X - A1.X, B1.Y - A1.Y);
            if (mode == true)
            {
                double tile = (double)org.Length / v.Length;
                double Pixel_Per_Mm = Math.Abs(A1.Y - B1.Y) / HeightLable;
                Socurce.X = (((A1.X - A.X) * tile) + ((B1.X - B.X) * tile) )/ (2*Pixel_Per_Mm);
                Socurce.Y = (((A1.Y - A.Y) * tile)+ ((B1.Y - B.Y) * tile)) / (2*Pixel_Per_Mm);
            }
            else
            {
                Socurce.ANGLE = Vector.AngleBetween(v, org);
            }
        }

    }
}

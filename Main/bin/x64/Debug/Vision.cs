using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Drawing;
using System.Windows.Forms;

namespace Main
{
    class Vision
    {
        public static double Threshold_Value = 180;



        public static int x = 860;
        public static int y = 735;
        public static int width = 1330;
        public static int height = 665;
        public static Image<Bgr, Byte> TestRoi(Image<Bgr, Byte> scr)
        {
            Rectangle roi = new Rectangle(x, y, width, height);
            CvInvoke.Rectangle(scr, roi, new MCvScalar(0, 255, 0), 2);
            return scr;
        }
        public static Image<Bgr, Byte> RoiImage(Image<Bgr, Byte> scr)
        {
            Image<Bgr, Byte> dst = scr;
            dst.ROI = Rectangle.Empty;
            Rectangle roi = new Rectangle(x, y, width, height); // set the roi
            dst.ROI = roi;
            return dst;
        }
        public static VectorOfVectorOfPoint FindContours(Image<Bgr,Byte> scr)
        {
            using (Image<Gray, byte> Gray_Image = scr.Convert<Gray, byte>())
            {
                using (Image<Gray, byte> Threshold_Image = new Image<Gray, byte>(Gray_Image.Size))
                {
                    CvInvoke.Threshold(Gray_Image, Threshold_Image, Threshold_Value, 255, ThresholdType.BinaryInv);
                    VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                    CvInvoke.FindContours(Threshold_Image, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
                    return contours;
                }
            }
        }
        public static VectorOfVectorOfPoint TwoContoursNearest(VectorOfVectorOfPoint contours)
        {
            double[] s = new double[contours.Size];
            int[] id = new int[contours.Size];
            double smax = s[0], smin = s[0];
            int idmax = id[0], idmin = id[0];
            for (int i = 0; i < contours.Size; i++)
            {
                double s_contours = CvInvoke.ContourArea(contours[i]);
                s[i] = s_contours;
                id[i] = i;
            }
            //sort area of contours
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i + 1; j < s.Length; j++)
                    if (s[i] > s[j])
                    {
                        s[i] = s[i] + s[j];
                        s[j] = s[i] - s[j];
                        s[i] = s[i] - s[j];
                        id[i] = id[i] + id[j];
                        id[j] = id[i] - id[j];
                        id[i] = id[i] - id[j];
                    }
            }
            //check range of area
            for (int i = 0; i < s.Length; i++)
            {
                if ((s[i] - smin) > (smax * 5) / 100)
                {
                    smin = smax;
                    idmin = idmax;
                }
                smax = s[i];
                idmax = i;
            }
            return null;
        }
        public static Point[] GetCenter(VectorOfVectorOfPoint contours)
        {
            double[] s = new double[contours.Size];
            int[] id = new int[contours.Size];
            double smax = s[0], smin = s[0];
            int idmax = id[0], idmin = id[0];
            for (int i=0;i<contours.Size;i++)
            {
                double s_contours = CvInvoke.ContourArea(contours[i]);
                s[i] = s_contours;
                id[i] = i;
            }
            //sort area of contours
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i + 1; j < s.Length; j++)
                    if (s[i] > s[j])
                    {
                        s[i] = s[i] + s[j];
                        s[j] = s[i] - s[j];
                        s[i] = s[i] - s[j];
                        id[i] = id[i] + id[j];
                        id[j] = id[i] - id[j];
                        id[i] = id[i] - id[j];
                    }
            }
            //check range of area
            for (int i = 0; i < s.Length; i++)
            {
                if((s[i] - smin) > (smax*5)/100)
                {
                    smin = smax;
                    idmin = idmax;
                }
                smax = s[i];
                idmax = i;
            }
            Point[] Center = new Point[idmax + 1 - idmin];
            for (int i = idmin; i<=idmax; i++)
            {
                var M = CvInvoke.Moments(contours[id[i]]);
                Center[i-idmin].X = (int) M.GravityCenter.X;
                Center[i-idmin].Y = (int) M.GravityCenter.Y;
            }
            if (Center.Length > 2)
            {
                Point[] TwoCenter = new Point[2];
                var C = Center.OrderBy(item => item.Y);
                TwoCenter[0] = C.ElementAt(0);
                TwoCenter[1] = C.ElementAt(1);
                return TwoCenter;
            }
            else
                return Center;
        }


        public static int CalculatorDistance(Point[] P)
        {
            if (P.Length == 2)
            {
                return Math.Abs(P[0].Y - P[1].Y); ;
            }
            else
                return -1;
        }

        public static int GetTimeWait(int Distance, double iSpeed)
        {
            return (int)(Distance*1000 / iSpeed);
        }
    }
}

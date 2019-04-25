using System;
using System.Drawing;
using System.Windows.Forms;
using MvCamCtrl.NET;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace Main
{
    class HIKVision
    {
        private MyCamera.MV_CC_DEVICE_INFO_LIST pDeviceList;
        private MyCamera pCamera;
        private UInt32 m_nBufSizeForDriver = 3072 * 2048 * 3;
        private byte[] m_pBufForDriver = new byte[3072 * 2048 * 3];
        public const int HIK_OK = 0;
        private const int HIK_ER = -1;
        // Buffer for saving image
        private UInt32 m_nBufSizeForSaveImage = 3072 * 2048 * 3 * 3 + 2048;
        private byte[] m_pBufForSaveImage = new byte[3072 * 2048 * 3 * 3 + 2048];
        private UInt32 nPayloadSize = 0;
        private Bitmap bmp;
        /// <summary>
        /// Search all device run on your computer with usb type or ethernet.
        /// </summary>
        /// <returns>string[]</returns>
        public string[] SearchDevice()
        {
            string[] _ListDevice;
            int nRet;
            GC.Collect();
            nRet = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref pDeviceList);
            if (0 != nRet)
                return null;
            _ListDevice = new string[pDeviceList.nDeviceNum];
            for (int i = 0; i < pDeviceList.nDeviceNum; i++)
            {
                MyCamera.MV_CC_DEVICE_INFO device = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(pDeviceList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));
                if (device.nTLayerType == MyCamera.MV_GIGE_DEVICE)
                {
                    IntPtr buffer = Marshal.UnsafeAddrOfPinnedArrayElement(device.SpecialInfo.stGigEInfo, 0);
                    MyCamera.MV_GIGE_DEVICE_INFO gigeInfo = (MyCamera.MV_GIGE_DEVICE_INFO)Marshal.PtrToStructure(buffer, typeof(MyCamera.MV_GIGE_DEVICE_INFO));
                    _ListDevice[i] = (gigeInfo.chSerialNumber);
                }
                else if (device.nTLayerType == MyCamera.MV_USB_DEVICE)
                {
                    IntPtr buffer = Marshal.UnsafeAddrOfPinnedArrayElement(device.SpecialInfo.stUsb3VInfo, 0);
                    MyCamera.MV_USB3_DEVICE_INFO usbInfo = (MyCamera.MV_USB3_DEVICE_INFO)Marshal.PtrToStructure(buffer, typeof(MyCamera.MV_USB3_DEVICE_INFO));
                    _ListDevice[i] = (usbInfo.chSerialNumber);
                }
            }
            return _ListDevice;
        }

        public int OpenDevice(int index)
        {
            int nRet = HIK_ER;
            if (nRet == index)
                return HIK_ER;
            MyCamera.MV_CC_DEVICE_INFO device = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(pDeviceList.pDeviceInfo[index], typeof(MyCamera.MV_CC_DEVICE_INFO));
            if (null == pCamera)
            {
                pCamera = new MyCamera();
                if (null == pCamera)
                {
                    return HIK_ER;
                }
            }
            nRet = pCamera.MV_CC_CreateDevice_NET(ref device);
            if (MyCamera.MV_OK != nRet)
            {
                return HIK_ER;
            }
            nRet = pCamera.MV_CC_OpenDevice_NET();
            if (MyCamera.MV_OK != nRet)
            {
                pCamera.MV_CC_DestroyDevice_NET();
                return HIK_ER;
            }
            pCamera.MV_CC_SetEnumValue_NET("AcquisitionMode", 2);
            pCamera.MV_CC_SetEnumValue_NET("TriggerMode", 0);
            nRet = pCamera.MV_CC_StartGrabbing_NET();
            if (MyCamera.MV_OK != nRet)
            {
                return HIK_ER;
            }
            return HIK_OK;
        }
        public int CloseDevice()
        {
            int nRet;
            if(pCamera != null)
            {
                nRet = pCamera.MV_CC_CloseDevice_NET();
                if (MyCamera.MV_OK != nRet)
                {
                    return HIK_ER;
                }

                nRet = pCamera.MV_CC_DestroyDevice_NET();
                if (MyCamera.MV_OK != nRet)
                {
                    return HIK_ER;
                }
            }
            return HIK_OK;
        }

        public Bitmap GetFrame()
        {
            int nRet;
            bmp = null;
            MyCamera.MVCC_INTVALUE stParam = new MyCamera.MVCC_INTVALUE();
            nRet = pCamera.MV_CC_GetIntValue_NET("PayloadSize", ref stParam);
            if (MyCamera.MV_OK != nRet)
            {
                return null;
            }
            nPayloadSize = stParam.nCurValue;
            if (nPayloadSize > m_nBufSizeForDriver)
            {
                m_nBufSizeForDriver = nPayloadSize;
                m_pBufForDriver = new byte[m_nBufSizeForDriver];

                // Determine the buffer size to save image
                // BMP image size: width * height * 3 + 2048 (Reserved for BMP header)
                m_nBufSizeForSaveImage = m_nBufSizeForDriver * 3 + 2048;
                m_pBufForSaveImage = new byte[m_nBufSizeForSaveImage];
            }

            IntPtr pData = Marshal.UnsafeAddrOfPinnedArrayElement(m_pBufForDriver, 0);
            MyCamera.MV_FRAME_OUT_INFO_EX stFrameInfo = new MyCamera.MV_FRAME_OUT_INFO_EX();
            //Get one frame timeout, timeout is 1 sec
            nRet = pCamera.MV_CC_GetOneFrameTimeout_NET(pData, m_nBufSizeForDriver, ref stFrameInfo, 1000);
            if (MyCamera.MV_OK != nRet)
            {
                return null;
            }

            MyCamera.MvGvspPixelType enDstPixelType;
            if (IsMonoData(stFrameInfo.enPixelType))
            {
                enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8;
            }
            else if (IsColorData(stFrameInfo.enPixelType))
            {
                enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed;
            }
            else
            {
                return null;
            }

            IntPtr pImage = Marshal.UnsafeAddrOfPinnedArrayElement(m_pBufForSaveImage, 0);
            MyCamera.MV_PIXEL_CONVERT_PARAM stConverPixelParam = new MyCamera.MV_PIXEL_CONVERT_PARAM();
            stConverPixelParam.nWidth = stFrameInfo.nWidth;
            stConverPixelParam.nHeight = stFrameInfo.nHeight;
            stConverPixelParam.pSrcData = pData;
            stConverPixelParam.nSrcDataLen = stFrameInfo.nFrameLen;
            stConverPixelParam.enSrcPixelType = stFrameInfo.enPixelType;
            stConverPixelParam.enDstPixelType = enDstPixelType;
            stConverPixelParam.pDstBuffer = pImage;
            stConverPixelParam.nDstBufferSize = m_nBufSizeForSaveImage;
            nRet = pCamera.MV_CC_ConvertPixelType_NET(ref stConverPixelParam);
            if (MyCamera.MV_OK != nRet)
            {
                return null;
            }
            
            if (enDstPixelType == MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8)
            {
                //************************Mono8 转 Bitmap*******************************
                bmp = new Bitmap(stFrameInfo.nWidth, stFrameInfo.nHeight, stFrameInfo.nWidth * 1, PixelFormat.Format8bppIndexed, pImage);

                ColorPalette cp = bmp.Palette;
                // init palette
                for (int i = 0; i < 256; i++)
                {
                    cp.Entries[i] = Color.FromArgb(i, i, i);
                }
                // set palette back
                bmp.Palette = cp;
            }
            else
            {
                //*********************RGB8 转 Bitmap**************************
                for (int i = 0; i < stFrameInfo.nHeight; i++)
                {
                    for (int j = 0; j < stFrameInfo.nWidth; j++)
                    {
                        byte chRed = m_pBufForSaveImage[i * stFrameInfo.nWidth * 3 + j * 3];
                        m_pBufForSaveImage[i * stFrameInfo.nWidth * 3 + j * 3] = m_pBufForSaveImage[i * stFrameInfo.nWidth * 3 + j * 3 + 2];
                        m_pBufForSaveImage[i * stFrameInfo.nWidth * 3 + j * 3 + 2] = chRed;
                    }
                }
                try
                {
                    bmp = new Bitmap(stFrameInfo.nWidth, stFrameInfo.nHeight, stFrameInfo.nWidth * 3, PixelFormat.Format24bppRgb, pImage);
                    
                }
                catch
                {
                }
            }
            return bmp;
        }

        public float GetExposureTime()
        {
            MyCamera.MVCC_FLOATVALUE ExposureValue = new MyCamera.MVCC_FLOATVALUE();
            int nRet = pCamera.MV_CC_GetFloatValue_NET("ExposureTime", ref ExposureValue);
            if (MyCamera.MV_OK == nRet)
            {
                return ExposureValue.fCurValue;
            }
            return HIK_ER;
        }
        public int SetExposureTime(float value)
        {
            int nRet;
            nRet = pCamera.MV_CC_SetFloatValue_NET("ExposureTime", value);
            if (nRet != MyCamera.MV_OK)
            {
                return HIK_ER;
            }
            return HIK_OK;
        }


        private Boolean IsMonoData(MyCamera.MvGvspPixelType enGvspPixelType)
        {
            switch (enGvspPixelType)
            {
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono12_Packed:
                    return true;

                default:
                    return false;
            }
        }
        private Boolean IsColorData(MyCamera.MvGvspPixelType enGvspPixelType)
        {
            switch (enGvspPixelType)
            {
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_YUV422_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_YUV422_YUYV_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_YCBCR411_8_CBYYCRYY:
                    return true;

                default:
                    return false;
            }
        }
    }
}

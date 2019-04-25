using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;
using System.Net.NetworkInformation;
namespace PLCController
{
    class PLCController
    {
        System.Text.Encoding utf8 = System.Text.Encoding.UTF8;
        private int _port;
        private string _ip;
        private string _SubHeader;
        private string _Network;
        private string _Station;
        private string _Moduleio;
        private string _Multidrop;
        private string _reserved;
        private string _write;
        private string _read;
        private string _bit;
        private string _word;
        private string _Listsp = "MYZDLFVBSW";
        //TcpClient client;// = new TcpClient();
        //NetworkStream stream;
        
        public PLCController(string ip, int port)
        {
            this._ip = ip;
            this._port = port;
            this._SubHeader = "5000";
            this._Network = "00";
            this._Station = "FF";
            this._Moduleio = "03FF";
            this._Multidrop = "00";
            this._reserved = "0010";
            this._write = "1401";
            this._read = "0401";
            this._bit = "0001";
            this._word = "0000";
        }
        public bool Open(int timeout=5000)
        {
            Stopwatch sw = new Stopwatch();
            sw.Reset();
            sw.Start();
            while (sw.ElapsedMilliseconds < timeout && Ping() == false) ;
            sw.Stop();
            if (sw.ElapsedMilliseconds < timeout)
                return true;
            else
                return false;
        }
        public bool Ping()
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;
            PingReply reply = pingSender.Send(_ip, timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
                return true;
            else
                return false;
        }
        private string SendCommand(string command)
        {
            Thread.Sleep(5);
            byte[] commandBytes = System.Text.Encoding.UTF8.GetBytes(command);
            byte[] buff = new byte[1024];
            string result = string.Empty;
            Open();
            {
                TcpClient client = new TcpClient(_ip, _port);
                NetworkStream stream = client.GetStream();
                stream.Write(commandBytes, 0, commandBytes.Length);
                stream.Read(buff, 0, 1024);
                stream.Close();
                client.Close();
                result = System.Text.Encoding.UTF8.GetString(buff);
                int index = 0;
                while (result.Substring(index, 1) != "\0")
                {
                    index++;
                }
                result = result.Substring(0, index);
            }
            return result;
            //byte[] commandBytes = System.Text.Encoding.UTF8.GetBytes(command);
            //stream.Write(commandBytes, 0, commandBytes.Length);
            //byte[] buff = new byte[1024];
            //stream.Read(buff, 0, 1024);
            //Thread.Sleep(1);
            //string result = System.Text.Encoding.UTF8.GetString(buff);
            //Int16 index = 0;
            //while(result.Substring(index,1) != "\0")
            //{
            //    index++;
            //}
            //result = result.Substring(0, index);
            //return result;
        }


        public Int16 SetDevice(string device, Int16 value)
        {
            string acommand = string.Empty;
            string ccommand = string.Empty;
            string bcommand = string.Empty;
            if (_Listsp.Contains(device.Substring(0, 1).ToUpper()))
            {
                acommand = _SubHeader + _Network + _Station + _Moduleio + _Multidrop;
                ccommand = "D000" + _Network + _Station + _Moduleio + _Multidrop;
                Int16 length = 24;
                if ((device.Substring(0, 1).ToUpper() == "D") || (device.Substring(0, 1).ToUpper() == "W"))
                {
                    length += 4;
                    bcommand = acommand + length.ToString("X4") + _reserved + _write
                        + _word + device.Substring(0, 1).ToUpper() + (char)0x2A
                        + Convert.ToInt16(device.Substring(1).ToUpper()).ToString("D6")
                        + "0001" + value.ToString("X4");

                }
                else
                {
                    if ((value == 1) || (value == 0))
                    {
                        length += 1;
                        bcommand = acommand + length.ToString("X4") + _reserved + _write
                            + _bit + device.Substring(0, 1).ToUpper() + (char)0x2A
                            + Convert.ToInt16(device.Substring(1).ToUpper()).ToString("D6")
                            + "0001" + value.ToString("X1");
                    }
                    else
                        return -1;
                }

                try
                {
                    string result = SendCommand(bcommand);
                    if (Convert.ToInt16(result.Substring(ccommand.Length + 4)) == 0)
                        return 1;
                    else
                        return -1;
                }catch (Exception)
                {
                    return -1;
                }


            }else
            {
                return -1;
            }
        }

        public Int16 GetDevice(string device)
        {
            Int16 value = -1;
            string acommand = string.Empty;
            string ccommand = string.Empty;
            string bcommand = string.Empty;
            if (_Listsp.Contains(device.Substring(0, 1).ToUpper()))
            {
                acommand = _SubHeader + _Network + _Station + _Moduleio + _Multidrop;
                ccommand = "D000" + _Network + _Station + _Moduleio + _Multidrop;
                Int16 length = 24;
                if ((device.Substring(0, 1).ToUpper() == "D") || (device.Substring(0, 1).ToUpper() == "W"))
                {
                    bcommand = acommand + length.ToString("X4") + _reserved +
                        _read + _word + device.Substring(0, 1).ToUpper() + (char)0x2A 
                        + Convert.ToInt16(device.Substring(1).ToUpper()).ToString("D6") + "0001";

                }
                else
                {
                    bcommand = acommand + length.ToString("X4") + _reserved +
                       _read + _bit + device.Substring(0, 1).ToUpper() + (char)0x2A
                       + Convert.ToInt16(device.Substring(1).ToUpper()).ToString("D6") + "0001";
                }


                try
                {
                    string result = SendCommand(bcommand);
                    if (Convert.ToInt16(result.Substring(ccommand.Length + 4, 4), 16) == 0)
                       value = Convert.ToInt16(result.Substring(ccommand.Length + 8), 16);
                   
                }
                catch (Exception)
                {
                    
                }
              
            }

            return value;


        }

    }
}

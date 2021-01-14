using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System;

public static class CTimeUtile 
{

    /// <summary>
    /// 분을 초로 변경
    /// </summary>
    /// <param name="_Minute"></param>
    /// <returns></returns>
    public static float MinuteToSecond(float _Minute)
    {
        return _Minute * 60f;
    }


    #region NTP서버에서 시간가져와서 HotTime 적용
    //*******************************
    //NTP 서버에서 시간 가져오는 소스
    //https://stackoverflow.com/questions/1193955/how-to-query-an-ntp-server-using-c
    //********************************
    public static DateTime GetNetworkTime()
    {
        try
        {
            //default Windows time server
            const string ntpServer = "time3.google.com";//"time.windows.com";//차선

            // NTP message size - 16 bytes of the digest (RFC 2030)
            var ntpData = new byte[48];

            //Setting the Leap Indicator, Version Number and Mode values
            ntpData[0] = 0x1B; //LI = 0 (no warning), VN = 3 (IPv4 only), Mode = 3 (Client Mode)

            var addresses = Dns.GetHostEntry(ntpServer).AddressList;

            //The UDP port number assigned to NTP is 123
            var ipEndPoint = new IPEndPoint(addresses[0], 123);
            //NTP uses UDP

            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                socket.Connect(ipEndPoint);

                //Stops code hang if NTP is blocked
                socket.ReceiveTimeout = 3000;

                socket.Send(ntpData);
                socket.Receive(ntpData);
                socket.Close();
            }

            //Offset to get to the "Transmit Timestamp" field (time at which the reply 
            //departed the server for the client, in 64-bit timestamp format."
            const byte serverReplyTime = 40;

            //Get the seconds part
            ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);

            //Get the seconds fraction
            ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);

            //Convert From big-endian to little-endian
            intPart = SwapEndianness(intPart);
            fractPart = SwapEndianness(fractPart);

            var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);

            //**UTC** time
            var networkDateTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((long)milliseconds);

            //return networkDateTime.ToLocalTime();
            return networkDateTime;
        }
        catch (Exception)
        {
            Debug.Log("인터넷이 안돼서 시간못가져옴");
            return new DateTime(0);
        }
    }

    // stackoverflow.com/a/3294698/162671
    static uint SwapEndianness(ulong x)
    {
        return (uint)(((x & 0x000000ff) << 24) +
                       ((x & 0x0000ff00) << 8) +
                       ((x & 0x00ff0000) >> 8) +
                       ((x & 0xff000000) >> 24));
    }


    #endregion
}

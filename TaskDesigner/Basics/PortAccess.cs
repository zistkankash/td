using System;
using System.IO.Ports;
using System.Runtime.InteropServices;

namespace Basics
{
    public class PortAccess
    {
        //inpout.dll

        [DllImport("inpout32.dll")]
        static extern UInt32 IsInpOutDriverOpen();

        [DllImport("inpout32.dll")]
        static extern void Out32(short PortAddress, short Data);

        [DllImport("inpout32.dll")]
        static extern char Inp32(short PortAddress);

        [DllImport("inpout32.dll")]
        static extern void DlPortWritePortUshort(short PortAddress, ushort Data);

        [DllImport("inpout32.dll")]
        static extern ushort DlPortReadPortUshort(short PortAddress);

        [DllImport("inpout32.dll")]
        static extern void DlPortWritePortUlong(int PortAddress, uint Data);

        [DllImport("inpout32.dll")]
        static extern uint DlPortReadPortUlong(int PortAddress);

        [DllImport("inpoutx64.dll")]
        static extern bool GetPhysLong(ref int PortAddress, ref uint Data);

        [DllImport("inpoutx64.dll")]
        static extern bool SetPhysLong(ref int PortAddress, ref uint Data);

        //inpoutx64.dll

        [DllImport("inpoutx64.dll", EntryPoint = "IsInpOutDriverOpen")]
        static extern UInt32 IsInpOutDriverOpen_x64();

        [DllImport("inpoutx64.dll", EntryPoint = "Out32")]
        static extern void Out32_x64(short PortAddress, short Data);

        [DllImport("inpoutx64.dll", EntryPoint = "Inp32")]
        static extern char Inp32_x64(short PortAddress);

        [DllImport("inpoutx64.dll", EntryPoint = "DlPortWritePortUshort")]
        static extern void DlPortWritePortUshort_x64(short PortAddress, ushort Data);

        [DllImport("inpoutx64.dll", EntryPoint = "DlPortReadPortUshort")]
        static extern ushort DlPortReadPortUshort_x64(short PortAddress);

        [DllImport("inpoutx64.dll", EntryPoint = "DlPortWritePortUlong")]
        static extern void DlPortWritePortUlong_x64(int PortAddress, uint Data);

        [DllImport("inpoutx64.dll", EntryPoint = "DlPortReadPortUlong")]
        static extern uint DlPortReadPortUlong_x64(int PortAddress);

        [DllImport("inpoutx64.dll", EntryPoint = "GetPhysLong")]
        static extern bool GetPhysLong_x64(ref int PortAddress, ref uint Data);

        [DllImport("inpoutx64.dll", EntryPoint = "SetPhysLong")]
        static extern bool SetPhysLong_x64(ref int PortAddress, ref uint Data);

        bool _parPort , _COMPort, _X64;
        short _PortAddress;
        string _COMPortAddress;
        SerialPort _seri;

        void Parallel(short address)
        {
            _X64 = false;
            _PortAddress = address;

            try
            {
                uint nResult = 0;
                try
                {
                    nResult = IsInpOutDriverOpen();
                }
                catch (BadImageFormatException)
                {
                    nResult = IsInpOutDriverOpen_x64();
                    if (nResult != 0)
                        _X64 = true;

                }
                _parPort = true;
                if (nResult == 0)
                {
                    throw new ArgumentException("Unable to open InpOut32 driver");
                }
            }
            catch (DllNotFoundException)
            {
                throw new ArgumentException("Unable to find InpOut32.dll");
            }
        }

        public PortAccess(short PortAddress)
        {
            Parallel(PortAddress);
        }

        public PortAccess(string COMAddress)
        {
            _seri = new SerialPort(COMAddress);
            _COMPort = true;
        }

        public PortAccess(RunConfig InitConfig)
        {
            if (InitConfig.useParOut)
            {
                Parallel((short)InitConfig.ParAddress);
                return;
            }
            if(InitConfig._useCOMPort)
            {
                _seri = new SerialPort(InitConfig._COMAddress);
                _COMPort = true;
            }
        }

        //Public Methods
        public void Write(short Data)
        {
            if (_parPort)
            {
                if (_X64)
                {
                    Out32_x64(_PortAddress, Data);
                }
                else
                {
                    Out32(_PortAddress, Data);
                }
            }
            else
            {
                _seri.Open();
                Byte[] ar = BitConverter.GetBytes(Data);
                _seri.Write(ar, 0, ar.Length);
                _seri.Close();
            }
        }

        public byte Read()
        {
            if (_X64)
            {
                return (byte)Inp32_x64(_PortAddress);
            }
            else
            {
                return (byte)Inp32(_PortAddress);
            }
        }
    }
}
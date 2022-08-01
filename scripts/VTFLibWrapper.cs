/*
 * VTFLibWrapper
 *
 * Handles literally everything relating to VTF Support in Chisel
 *
 * Made by the amazing SCell555
 */
using System;
using System.Runtime.InteropServices;

namespace VTFLibWrapper
{
    public enum VTFImageFormat
    {
        IMAGE_FORMAT_RGBA8888 = 0,              //!<  = Red, Green, Blue, Alpha - 32 bpp
        IMAGE_FORMAT_ABGR8888,                  //!<  = Alpha, Blue, Green, Red - 32 bpp
        IMAGE_FORMAT_RGB888,                    //!<  = Red, Green, Blue - 24 bpp
        IMAGE_FORMAT_BGR888,                    //!<  = Blue, Green, Red - 24 bpp
        IMAGE_FORMAT_RGB565,                    //!<  = Red, Green, Blue - 16 bpp
        IMAGE_FORMAT_I8,                        //!<  = Luminance - 8 bpp
        IMAGE_FORMAT_IA88,                      //!<  = Luminance, Alpha - 16 bpp
        IMAGE_FORMAT_P8,                        //!<  = Paletted - 8 bpp
        IMAGE_FORMAT_A8,                        //!<  = Alpha- 8 bpp
        IMAGE_FORMAT_RGB888_BLUESCREEN,         //!<  = Red, Green, Blue, "BlueScreen" Alpha - 24 bpp
        IMAGE_FORMAT_BGR888_BLUESCREEN,         //!<  = Red, Green, Blue, "BlueScreen" Alpha - 24 bpp
        IMAGE_FORMAT_ARGB8888,                  //!<  = Alpha, Red, Green, Blue - 32 bpp
        IMAGE_FORMAT_BGRA8888,                  //!<  = Blue, Green, Red, Alpha - 32 bpp
        IMAGE_FORMAT_DXT1,                      //!<  = DXT1 compressed format - 4 bpp
        IMAGE_FORMAT_DXT3,                      //!<  = DXT3 compressed format - 8 bpp
        IMAGE_FORMAT_DXT5,                      //!<  = DXT5 compressed format - 8 bpp
        IMAGE_FORMAT_BGRX8888,                  //!<  = Blue, Green, Red, Unused - 32 bpp
        IMAGE_FORMAT_BGR565,                    //!<  = Blue, Green, Red - 16 bpp
        IMAGE_FORMAT_BGRX5551,                  //!<  = Blue, Green, Red, Unused - 16 bpp
        IMAGE_FORMAT_BGRA4444,                  //!<  = Red, Green, Blue, Alpha - 16 bpp
        IMAGE_FORMAT_DXT1_ONEBITALPHA,          //!<  = DXT1 compressed format with 1-bit alpha - 4 bpp
        IMAGE_FORMAT_BGRA5551,                  //!<  = Blue, Green, Red, Alpha - 16 bpp
        IMAGE_FORMAT_UV88,                      //!<  = 2 channel format for DuDv/Normal maps - 16 bpp
        IMAGE_FORMAT_UVWQ8888,                  //!<  = 4 channel format for DuDv/Normal maps - 32 bpp
        IMAGE_FORMAT_RGBA16161616F,             //!<  = Red, Green, Blue, Alpha - 64 bpp
        IMAGE_FORMAT_RGBA16161616,              //!<  = Red, Green, Blue, Alpha signed with mantissa - 64 bpp
        IMAGE_FORMAT_UVLX8888,                  //!<  = 4 channel format for DuDv/Normal maps - 32 bpp
        IMAGE_FORMAT_R32F,                      //!<  = Luminance - 32 bpp
        IMAGE_FORMAT_RGB323232F,                //!<  = Red, Green, Blue - 96 bpp
        IMAGE_FORMAT_RGBA32323232F,             //!<  = Red, Green, Blue, Alpha - 128 bpp
        IMAGE_FORMAT_NV_DST16,
        IMAGE_FORMAT_NV_DST24,
        IMAGE_FORMAT_NV_INTZ,
        IMAGE_FORMAT_NV_RAWZ,
        IMAGE_FORMAT_ATI_DST16,
        IMAGE_FORMAT_ATI_DST24,
        IMAGE_FORMAT_NV_NULL,
        IMAGE_FORMAT_ATI2N,
        IMAGE_FORMAT_ATI1N,
        IMAGE_FORMAT_COUNT,
        IMAGE_FORMAT_NONE = -1
    };

    public sealed class VTFFile : IDisposable
    {
        private const string DLL_NAME = "vtflib.dll";
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.ThisCall, EntryPoint = "??0CVTFFile@VTFLib@@QEAA@XZ")]
        private static extern void Ctor(IntPtr ptr);
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.ThisCall, EntryPoint = "??1CVTFFile@VTFLib@@QEAA@XZ")]
        private static extern void Dtor(IntPtr ptr);
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.ThisCall, EntryPoint = "?Load@CVTFFile@VTFLib@@QEAAEPEBDE@Z")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool Load(IntPtr ptr, [MarshalAs(UnmanagedType.LPStr)] string path, [MarshalAs(UnmanagedType.U1)] bool headerOnly);
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.ThisCall, EntryPoint = "?Load@CVTFFile@VTFLib@@QEAAEPEBDE@Z")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool LoadMem(IntPtr ptr, IntPtr data, uint size, [MarshalAs(UnmanagedType.U1)] bool headerOnly);
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.ThisCall, EntryPoint = "?GetData@CVTFFile@VTFLib@@QEBAPEAEIIII@Z")]
        private static extern IntPtr GetData(IntPtr ptr, uint frame, uint face, uint slice, uint mipmap);
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.ThisCall, EntryPoint = "?GetFormat@CVTFFile@VTFLib@@QEBA?AW4tagVTFImageFormat@@XZ")]
        [return: MarshalAs(UnmanagedType.I4)]
        private static extern VTFImageFormat GetFormat(IntPtr ptr);
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.ThisCall, EntryPoint = "?GetHeight@CVTFFile@VTFLib@@QEBAIXZ")]
        private static extern uint GetHeight(IntPtr ptr);
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.ThisCall, EntryPoint = "?GetWidth@CVTFFile@VTFLib@@QEBAIXZ")]
        private static extern uint GetWidth(IntPtr ptr);
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.ThisCall, EntryPoint = "?GetDepth@CVTFFile@VTFLib@@QEBAIXZ")]
        private static extern uint GetDepth(IntPtr ptr);
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.ThisCall, EntryPoint = "?GetFrameCount@CVTFFile@VTFLib@@QEBAIXZ")]
        private static extern uint GetFrameCount(IntPtr ptr);
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.ThisCall, EntryPoint = "?GetFaceCount@CVTFFile@VTFLib@@QEBAIXZ")]
        private static extern uint GetFaceCount(IntPtr ptr);
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.ThisCall, EntryPoint = "?GetHasImage@CVTFFile@VTFLib@@QEBAEXZ")]
        [return: MarshalAs (UnmanagedType.U1)]
        private static extern bool GetHasImage(IntPtr ptr);
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.ThisCall, EntryPoint = "?IsLoaded@CVTFFile@VTFLib@@QEBAEXZ")]
        [return: MarshalAs (UnmanagedType.U1)]
        private static extern bool IsLoaded(IntPtr ptr);
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "?ComputeMipmapSize@CVTFFile@VTFLib@@SAIIIIIW4tagVTFImageFormat@@@Z")]
        private static extern uint ComputeMipmapSize(uint width, uint height, uint depth, uint mip, [MarshalAs(UnmanagedType.I4)] VTFImageFormat format);
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "?ConvertToRGBA8888@CVTFFile@VTFLib@@SAEPEAE0IIW4tagVTFImageFormat@@@Z")]
        [return : MarshalAs (UnmanagedType.U1)]
        private static extern bool ConvertToRGBA8888(IntPtr source, IntPtr dest, uint width, uint height, [MarshalAs(UnmanagedType.I4)] VTFImageFormat format);
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "?ComputeMipmapDimensions@CVTFFile@VTFLib@@SAXIIIIAEAI00@Z")]
        private static extern void ComputeMipmapDimensions(uint width, uint height, uint depth, uint mipLevel, ref uint mipWidth, ref uint mipHeight, ref uint mipDepth);

        private readonly IntPtr _instance;

        public VTFFile()
        {
            _instance = Marshal.AllocHGlobal(40);
            Ctor(_instance);
        }

        public void Dispose()
        {
            Dtor(_instance);
            Marshal.FreeHGlobal(_instance);
            GC.SuppressFinalize(this);
        }

        public bool Load(string path, bool headerOnly = false)
        {
            return Load(_instance, path, headerOnly);
        }

        public bool Load(byte[] data, bool headerOnly = false)
        {
            var mem = Marshal.AllocHGlobal(data.Length);
            Marshal.Copy(data, 0, mem, data.Length);
            var res = LoadMem(_instance, mem, (uint)data.Length, headerOnly);
            Marshal.FreeHGlobal(mem);
            return res;
        }

        public VTFImageFormat GetFormat()
        {
            return GetFormat(_instance);
        }

        public uint GetHeight()
        {
            return GetHeight(_instance);
        }

        public uint GetWidth()
        {
            return GetWidth(_instance);
        }

        public uint GetDepth()
        {
            return GetDepth(_instance);
        }

        public uint GetFrameCount()
        {
            return GetFrameCount(_instance);
        }

        public uint GetFaceCount()
        {
            return GetFaceCount(_instance);
        }

        public bool GetHasImage()
        {
            return GetHasImage(_instance);
        }

        public bool IsLoaded()
        {
            return IsLoaded(_instance);
        }

        public byte[] GetData(uint frame = 0, uint face = 0, uint slice = 0, uint mipmap = 0)
        {
            var size = ComputeMipmapSize(GetWidth(), GetHeight(), GetDepth(), mipmap, GetFormat());
            var data = GetData(_instance, frame, face, slice, mipmap);
            var res = new byte[size];
            Marshal.Copy(data, res, 0, (int)size);
            return res;
        }

        public byte[] GetDataRGBA8888(uint frame = 0, uint face = 0, uint slice = 0, uint mipmap = 0)
        {
            var size = (int)ComputeMipmapSize(GetWidth(), GetHeight(), 1, mipmap, GetFormat());
            var rgbaSizeSingle = (int)ComputeMipmapSize(GetWidth(), GetHeight(), 1, mipmap, VTFImageFormat.IMAGE_FORMAT_RGBA8888);
            var rgbaSize = ComputeMipmapSize(GetWidth(), GetHeight(), GetDepth(), mipmap, VTFImageFormat.IMAGE_FORMAT_RGBA8888);
            var data = GetData(_instance, frame, face, slice, mipmap);
            var rgbaData = Marshal.AllocHGlobal((int)rgbaSize);
            uint mipWidth = 0, mipHeight = 0, mipDepth = 0;
            ComputeMipmapDimensions(GetWidth(), GetHeight(), 1, mipmap, ref mipWidth, ref mipHeight, ref mipDepth);
            for (int i = 0, c = (int)GetDepth(); i < c; i++)
                ConvertToRGBA8888(IntPtr.Add(data, size * i), IntPtr.Add(rgbaData, rgbaSizeSingle * i), mipWidth, mipHeight, GetFormat());
            var res = new byte[rgbaSize];
            Marshal.Copy(rgbaData, res, 0, (int)rgbaSize);
            return res;
        }
    }
}

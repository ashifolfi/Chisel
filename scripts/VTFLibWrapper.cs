/*
 * VTFLibWrapper
 *
 * Look ma! Still BSD-2!
 * The solution to VTFLib being GPL and Chisel BSD-2
 *
 * Support is not perfect and a lot of formats are missing support
 * But it works enough that we can implement this to at least have basic
 * Valve Texture File support
 *
 * Special thanks to SCell555#4853 for this wonderful masterpiece!
 * Conversion functions were written by K. "ashifolfi" J.
 */
using System;
using System.Runtime.InteropServices;
using Godot;

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

    public class VTFFile
    {
        private const string DLL_NAME = "vtflib.dll";
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.ThisCall, EntryPoint = "??0CVTFFile@VTFLib@@QEAA@XZ")]
        private static extern void Ctor(IntPtr ptr);
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.ThisCall, EntryPoint = "??1CVTFFile@VTFLib@@QEAA@XZ")]
        private static extern void Dtor(IntPtr ptr);
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.ThisCall, EntryPoint = "?Load@CVTFFile@VTFLib@@QEAAEPEBDE@Z")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool LoadNat(IntPtr ptr, [MarshalAs(UnmanagedType.LPStr)] string path, [MarshalAs(UnmanagedType.U1)] bool headerOnly);
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.ThisCall, EntryPoint = "?Load@CVTFFile@VTFLib@@QEAAEPEBDE@Z")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool LoadMemNat(IntPtr ptr, IntPtr data, uint size, [MarshalAs(UnmanagedType.U1)] bool headerOnly);
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.ThisCall, EntryPoint = "?GetData@CVTFFile@VTFLib@@QEBAPEAEIIII@Z")]
        private static extern IntPtr GetDataNat(IntPtr ptr, uint frame, uint face, uint slice, uint mipmap);
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.ThisCall, EntryPoint = "?GetFormat@CVTFFile@VTFLib@@QEBA?AW4tagVTFImageFormat@@XZ")]
        [return: MarshalAs(UnmanagedType.I4)]
        private static extern VTFImageFormat GetFormatNat(IntPtr ptr);
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.ThisCall, EntryPoint = "?GetHeight@CVTFFile@VTFLib@@QEBAIXZ")]
        private static extern uint GetHeightNat(IntPtr ptr);
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.ThisCall, EntryPoint = "?GetWidth@CVTFFile@VTFLib@@QEBAIXZ")]
        private static extern uint GetWidthNat(IntPtr ptr);
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.ThisCall, EntryPoint = "?GetDepth@CVTFFile@VTFLib@@QEBAIXZ")]
        private static extern uint GetDepthNat(IntPtr ptr);
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "?ComputeMipmapSize@CVTFFile@VTFLib@@SAIIIIIW4tagVTFImageFormat@@@Z")]
        private static extern uint ComputeMipmapSizeNat(uint width, uint height, uint depth, uint mip, VTFImageFormat format);

        private readonly IntPtr _instance;

        public VTFFile()
        {
            _instance = Marshal.AllocHGlobal(40);
            Ctor(_instance);
        }

        ~VTFFile()
        {
            Dtor(_instance);
            Marshal.FreeHGlobal(_instance);
        }

        public bool Load(string path, bool headerOnly)
        {
            return LoadNat(_instance, path, headerOnly);
        }

        public bool Load(byte[] data, bool headerOnly)
        {
            var mem = Marshal.AllocHGlobal(data.Length);
            Marshal.Copy(data, 0, mem, data.Length);
            var res = LoadMemNat(_instance, mem, (uint)data.Length, headerOnly);
            Marshal.FreeHGlobal(mem);
            return res;
        }

        public VTFImageFormat GetFormat()
        {
            return GetFormatNat(_instance);
        }

        public uint GetHeight()
        {
            return GetHeightNat(_instance);
        }

        public uint GetWidth()
        {
            return GetWidthNat(_instance);
        }

        public uint GetDepth()
        {
            return GetDepthNat(_instance);
        }

        public byte[] GetData(uint frame, uint face, uint slice, uint mipmap)
        {
            var size = ComputeMipmapSizeNat(GetWidth(), GetHeight(), GetDepth(), mipmap, GetFormat());
            var data = GetDataNat(_instance, frame, face, slice, mipmap);
            var res = new byte[size];
            Marshal.Copy(data, res, 0, (int)size);
            return res;
        }
    }

    public class Converts
    {
        public static Image.Format FromVTFFormat(VTFImageFormat Format)
        {
            switch (Format)
            {
                case VTFImageFormat.IMAGE_FORMAT_DXT1:
                    return Image.Format.Dxt1;
                case VTFImageFormat.IMAGE_FORMAT_DXT3:
                    return Image.Format.Dxt3;
                case VTFImageFormat.IMAGE_FORMAT_DXT5:
                    return Image.Format.Dxt5;
                case VTFImageFormat.IMAGE_FORMAT_RGBA32323232F:
                    return Image.Format.Rgbaf;
            }
            // If all else assume Rgb8 (Horrible idea but what else are we going to do?)
            return Image.Format.Rgb8;
        }
    }
}

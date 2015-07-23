using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace ConfigurationSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var ac = ApplicationConfig.GetInstanse();
            var display = new Display(ac);
            display.NumberField.DisplayString = "number";
            display.TrialField.DisplayString = "trial";
            display.RecordField.DisplayString = "record";

            using (var grp = new DisplayGraphics(ac.BackgroundField.Size.Width, ac.BackgroundField.Size.Height))
            {
                grp.DrawField(display.NumberField);
                grp.DrawField(display.TrialField);
                grp.DrawField(display.RecordField);
                grp.DrawField(display.ResultField);

                byte[] data = grp.GetBytes();
                //grp.Save(@"c:\sample.bmp");

                if(BitmapTest(data))
                {
                    Console.WriteLine("True");
                }
                else
                {
                    Console.WriteLine("False");
                }
            }
        }

        static bool BitmapTest(byte[] data)
        {
            bool result = false;
            using (var ms = new MemoryStream())
            using (Bitmap bmp = new Bitmap(@"c:\sample.bmp"))
            {
                bmp.Save(ms, ImageFormat.Bmp);
                result = ByteArrayCompare(data, ms.ToArray());
            }
            return result;
        }

        [System.Runtime.InteropServices.DllImport("msvcrt.dll",
            CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        private static extern int memcmp(byte[] b1, byte[] b2, UIntPtr count);

        public static bool ByteArrayCompare(byte[] a, byte[] b)
        {
            if (object.ReferenceEquals(a, b))
            {
                return true;
            }
            if (a == null || b == null || a.Length != b.Length)
            {
                return false;
            }

            BytesToFile(a, @"c:\c.log");
            BytesToFile(b, @"c:\d.log");
            return memcmp(a, b, new UIntPtr((uint)a.Length)) == 0;
        }

        static void BytesToFile(byte[] data, string filename)
        {
            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                byte[] buf;
                for(int i = 0; i < data.Length; i++)
                {
                    buf = Encoding.ASCII.GetBytes("[" + i.ToString() + "] = " + data[i].ToString() + "\n");
                    fs.Write(buf, 0, buf.Length);
                }
            }
        }
    }
}


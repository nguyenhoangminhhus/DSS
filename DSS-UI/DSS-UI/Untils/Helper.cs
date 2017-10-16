using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSS_UI.Untils
{
    public static class Helper
    {
        public static byte[] converseToByte(String sourceParth)
        {
            FileInfo fileInfo = new FileInfo(sourceParth);
            long sizeByte = fileInfo.Length;

            //doc file su dung file stream
            FileStream fs = new FileStream(sourceParth, FileMode.Open, FileAccess.Read);
            // doc lai su dung binary
            BinaryReader binaryReader = new BinaryReader(fs);

            byte[] data = binaryReader.ReadBytes((int)sizeByte);
            return data;
        }
    }
}

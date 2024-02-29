using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Application.Common.Response
{
    public class ExportExcelDto
    {
        public string FileName { get; set; }
        public byte[] data { get; set; }
    }
}

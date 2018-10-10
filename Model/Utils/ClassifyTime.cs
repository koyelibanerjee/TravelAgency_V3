using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Model.Utils
{
    public class ClassifyTime
    {
        public long RecogTime;
        public long UploadPicTime;
        public long DbopTime;
        public long AllTime => RecogTime + UploadPicTime + DbopTime + AllTime;
    }
}

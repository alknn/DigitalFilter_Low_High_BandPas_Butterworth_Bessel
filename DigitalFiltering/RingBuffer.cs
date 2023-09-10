using DevExpress.CodeParser;
using DevExpress.XtraSpreadsheet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalFiltering
{
    public sealed class RingBuffer<T>
    {
        public int BufferSize { get { return _buffersize; }  }
        int _buffersize;
        public T[] Data;    
        public RingBuffer(int buffersize)
        {
            _buffersize = buffersize;
            Data = new T[_buffersize];            
        }

    }
}

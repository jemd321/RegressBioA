using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegressBioA.WPF.Utilities
{
    public class AsyncCommandErrorHandler : IErrorHandler
    {
        public void HandleError(Exception ex)
        {
            // TODO Implement error handling for any async commands - ie handle expected EXs gracefully and crash if truly unexpected
            throw new NotImplementedException();
        }
    }
}

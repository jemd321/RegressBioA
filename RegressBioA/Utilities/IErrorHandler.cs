using System;

namespace RegressBioA.Utilities
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}
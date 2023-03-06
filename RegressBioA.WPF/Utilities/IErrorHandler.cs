using System;

namespace RegressBioA.WPF.Utilities
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}
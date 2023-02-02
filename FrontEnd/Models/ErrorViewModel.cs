using System;

namespace FrontEndCafeteria.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string errorMessage { get; set; }
    }
}

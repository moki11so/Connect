//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.11.3.0 (NJsonSchema v10.4.4.0 (Newtonsoft.Json v11.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

using Moki11so.Shared.Essentials;
using Moki11so.Shared.Dto;
using Moki11so.Shared.Dto.Order;
using Moki11so.Shared.Workers;
using Moki11so.Shared.Drives;

#pragma warning disable 108 // Disable "CS0108 '{derivedDto}.ToJson()' hides inherited member '{dtoBase}.ToJson()'. Use the new keyword if hiding was intended."
#pragma warning disable 114 // Disable "CS0114 '{derivedDto}.RaisePropertyChanged(String)' hides inherited member 'dtoBase.RaisePropertyChanged(String)'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword."
#pragma warning disable 472 // Disable "CS0472 The result of the expression is always 'false' since a value of type 'Int32' is never equal to 'null' of type 'Int32?'
#pragma warning disable 1573 // Disable "CS1573 Parameter '...' has no matching param tag in the XML comment for ...
#pragma warning disable 1591 // Disable "CS1591 Missing XML comment for publicly visible type or member ..."
#pragma warning disable 8073 // Disable "CS8073 The result of the expression is always 'false' since a value of type 'T' is never equal to 'null' of type 'T?'"

namespace MoSo.Connect.Service
{
    using System = global::System;

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.11.3.0 (NJsonSchema v10.4.4.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial interface IClient
    {
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Collections.Generic.ICollection<ImportOrder>> ApiImportordersAsync(Platform platform);
    
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Collections.Generic.ICollection<ImportOrder> ApiImportorders(Platform platform);
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Collections.Generic.ICollection<ImportOrder>> ApiImportordersAsync(Platform platform, System.Threading.CancellationToken cancellationToken);
    
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Collections.Generic.ICollection<string>> ApiImportordersDownloadedGetAsync(Platform platform);
    
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Collections.Generic.ICollection<string> ApiImportordersDownloadedGet(Platform platform);
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Collections.Generic.ICollection<string>> ApiImportordersDownloadedGetAsync(Platform platform, System.Threading.CancellationToken cancellationToken);
    
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiImportordersDownloadedPutAsync(ImportOrderUpdate body);
    
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        void ApiImportordersDownloadedPut(ImportOrderUpdate body);
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiImportordersDownloadedPutAsync(ImportOrderUpdate body, System.Threading.CancellationToken cancellationToken);
    
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiImportordersCancelAsync(ImportOrderCancellation body);
    
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        void ApiImportordersCancel(ImportOrderCancellation body);
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiImportordersCancelAsync(ImportOrderCancellation body, System.Threading.CancellationToken cancellationToken);
    
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiImportordersShippingAsync(System.Collections.Generic.IEnumerable<ShippingInfo> body);
    
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        void ApiImportordersShipping(System.Collections.Generic.IEnumerable<ShippingInfo> body);
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiImportordersShippingAsync(System.Collections.Generic.IEnumerable<ShippingInfo> body, System.Threading.CancellationToken cancellationToken);
    
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Collections.Generic.ICollection<ImportPayment>> ApiImportpaymentsAsync(Platform platform);
    
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Collections.Generic.ICollection<ImportPayment> ApiImportpayments(Platform platform);
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Collections.Generic.ICollection<ImportPayment>> ApiImportpaymentsAsync(Platform platform, System.Threading.CancellationToken cancellationToken);
    
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiImportpaymentsDownloadedAsync(ImportPayment body);
    
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        void ApiImportpaymentsDownloaded(ImportPayment body);
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiImportpaymentsDownloadedAsync(ImportPayment body, System.Threading.CancellationToken cancellationToken);
    
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Platform>> ApiPlatformsSyncAsync();
    
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Collections.Generic.ICollection<Platform> ApiPlatformsSync();
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Platform>> ApiPlatformsSyncAsync(System.Threading.CancellationToken cancellationToken);
    
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiReportingInternalAsync(InternalWorkerInfo body);
    
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        void ApiReportingInternal(InternalWorkerInfo body);
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiReportingInternalAsync(InternalWorkerInfo body, System.Threading.CancellationToken cancellationToken);
    
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiReportingWawiAsync(WawiWorkerInfo body);
    
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        void ApiReportingWawi(WawiWorkerInfo body);
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiReportingWawiAsync(WawiWorkerInfo body, System.Threading.CancellationToken cancellationToken);
    
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiReportingMetaAsync(MetaInfo body);
    
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        void ApiReportingMeta(MetaInfo body);
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiReportingMetaAsync(MetaInfo body, System.Threading.CancellationToken cancellationToken);
    
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiReportingDrivesAsync(System.Collections.Generic.IEnumerable<Drive> body);
    
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        void ApiReportingDrives(System.Collections.Generic.IEnumerable<Drive> body);
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiReportingDrivesAsync(System.Collections.Generic.IEnumerable<Drive> body, System.Threading.CancellationToken cancellationToken);
    
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<SessionInformation> ApiSessionsAsync();
    
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        SessionInformation ApiSessions();
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<SessionInformation> ApiSessionsAsync(System.Threading.CancellationToken cancellationToken);
    
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiSyncsPutAsync(Platform platform);
    
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        void ApiSyncsPut(Platform platform);
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ApiSyncsPutAsync(Platform platform, System.Threading.CancellationToken cancellationToken);
    
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PlatformSyncInformation> ApiSyncsGetAsync(Platform platform);
    
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        PlatformSyncInformation ApiSyncsGet(Platform platform);
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PlatformSyncInformation> ApiSyncsGetAsync(Platform platform, System.Threading.CancellationToken cancellationToken);
    
    }

    

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.11.3.0 (NJsonSchema v10.4.4.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial class ApiException : System.Exception
    {
        public int StatusCode { get; private set; }

        public string Response { get; private set; }

        public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }

        public ApiException(string message, int statusCode, string response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Exception innerException)
            : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + ((response == null) ? "(null)" : response.Substring(0, response.Length >= 512 ? 512 : response.Length)), innerException)
        {
            StatusCode = statusCode;
            Response = response;
            Headers = headers;
        }

        public override string ToString()
        {
            return string.Format("HTTP Response: \n\n{0}\n\n{1}", Response, base.ToString());
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.11.3.0 (NJsonSchema v10.4.4.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial class ApiException<TResult> : ApiException
    {
        public TResult Result { get; private set; }

        public ApiException(string message, int statusCode, string response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, TResult result, System.Exception innerException)
            : base(message, statusCode, response, headers, innerException)
        {
            Result = result;
        }
    }

}

#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore  472
#pragma warning restore  114
#pragma warning restore  108
﻿using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Catrobat.IDE.Core.Services;
using Catrobat.IDE.Core.Utilities.Helpers;
using Catrobat.IDE.Core.Utilities.JSON;
using Catrobat.IDE.Core.CatrobatObjects;
using Catrobat.IDE.Core.Tests.SampleData;
using System.IO;

namespace Catrobat.IDE.Core.Tests.Services.Common
{
    public class WebCommunicationTest : IWebCommunicationService
    {
        public int UploadsPending { get; set; }

        public async Task<List<OnlineProgramHeader>> LoadOnlineProgramsAsync(
            string filterText, int offset, int count,
            CancellationToken taskCancellationToken)
        {
            List<OnlineProgramHeader> projects = SampleLoader.GetSampleOnlineProjectHeaderList(count);
            return projects;
        }


        public async Task<Stream> DownloadAsync(string downloadUrl, string projectName)
        {
            //TODO return a project as stream
            //return await httpResponse.Content.ReadAsStreamAsync();
            return null;
        }

        public Task DownloadAsyncAlternativ(string downloadUrl, string projectName)
        {
            throw new NotImplementedException();
        }

        public async Task<JSONStatusResponse> CheckTokenAsync(string username, 
            string token, string language = "en")
        {
            JSONStatusResponse statusResponse = new JSONStatusResponse
            {
                preHeaderMessages = "",
                answer = "answer generated by test-system",
                statusCode = StatusCodes.ServerResponseOk
            };
            return statusResponse;
        }

        public async Task<JSONStatusResponse> LoginOrRegisterAsync(string username, 
            string password, string userEmail,
                string language = "en", string country = "AT")
        {
            JSONStatusResponse statusResponse = new JSONStatusResponse
            {
                preHeaderMessages = "",
                answer = "answer generated by test-system",
                token = "TestTokenFromTestSystem_" + language,
                statusCode = StatusCodes.ServerResponseOk
            };
            return statusResponse;
        }

        public async Task<JSONStatusResponse> UploadProgramAsync(string projectTitle, 
            string username, string token, string language = "en")
        {
            JSONStatusResponse statusResponse = new JSONStatusResponse
            {
                preHeaderMessages = "",
                answer = "answer generated by test-system",
                statusCode = StatusCodes.ServerResponseOk
            };
            return statusResponse;
        }

        public async Task<JSONStatusResponse> ReportAsInappropriateAsync(string projectId, 
            string flagReason, string language = "en")
        {
            JSONStatusResponse statusResponse = new JSONStatusResponse
            {
                preHeaderMessages = "",
                answer = "answer generated by test-system",
                statusCode = StatusCodes.ServerResponseOk
            };
            return statusResponse;
        }

        public async Task<JSONStatusResponse> RecoverPasswordAsync(
            string recoveryUserData, string language = "en")
        {
            JSONStatusResponse statusResponse = new JSONStatusResponse
            {
                preHeaderMessages = "",
                answer = "answer generated by test-system?c=TestHashFromTestSystem",
                statusCode = StatusCodes.ServerResponseOk
            };
            return statusResponse;
        }

        public async Task<JSONStatusResponse> ChangePasswordAsync(string newPassword, 
            string newPasswortRepeated, string hash, string language = "en")
        {
            JSONStatusResponse statusResponse = new JSONStatusResponse
            {
                preHeaderMessages = "",
                answer = "answer generated by test-system",
                statusCode = StatusCodes.ServerResponseOk
            };
            return statusResponse;
        }

        public bool NoUploadsPending()
        {
            return UploadsPending == 0;
        }

        public DateTime ConvertUnixTimeStamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }

        public event DownloadProgressUpdatedEventHandler DownloadProgressChanged;
    }
}

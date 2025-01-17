﻿using System.Net.Http;
using System.Threading.Tasks;
using Bit.Core;
using Bit.Core.Jobs;
using Microsoft.Extensions.Logging;
using Quartz;

namespace Bit.Admin.Jobs
{
    public class AliveJob : BaseJob
    {
        private readonly GlobalSettings _globalSettings;
        private HttpClient _httpClient = new HttpClient();

        public AliveJob(
            GlobalSettings globalSettings,
            ILogger<AliveJob> logger)
            : base(logger)
        {
            _globalSettings = globalSettings;
        }

        protected async override Task ExecuteJobAsync(IJobExecutionContext context)
        {
            await _httpClient.GetAsync(_globalSettings.BaseServiceUri.Admin);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using Nekara.Models;

namespace Orleans.Runtime.TestHooks
{
    internal interface ITestHooks
    {
        Task<SiloAddress> GetConsistentRingPrimaryTargetSilo(uint key);
        Task<string> GetConsistentRingProviderDiagnosticInfo();
        Task<string> GetServiceId();
        Task<ICollection<string>> GetStorageProviderNames();
        Task<ICollection<string>> GetStreamProviderNames();
        Task<ICollection<string>> GetAllSiloProviderNames();
        Task<bool> HasStorageProvider(string providerName);
        Task<bool> HasStreamProvider(string providerName);
        Task<int> UnregisterGrainForTesting(GrainId grain);
        Task LatchIsOverloaded(bool overloaded, TimeSpan latchPeriod);
        Task<Dictionary<SiloAddress, SiloStatus>> GetApproximateSiloStatuses();
    }

    internal interface ITestHooksSystemTarget : ITestHooks, ISystemTarget
    {
    }
}

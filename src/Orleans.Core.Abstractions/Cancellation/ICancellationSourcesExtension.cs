using System;
using Nekara.Models;
using Orleans.Concurrency;

namespace Orleans.Runtime
{
    internal interface ICancellationSourcesExtension : IGrainExtension
    {
        [AlwaysInterleave]
        Task CancelRemoteToken(Guid tokenId);
    }
}
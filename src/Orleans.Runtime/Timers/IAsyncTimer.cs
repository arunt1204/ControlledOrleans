﻿using System;
using Nekara.Models;

namespace Orleans.Runtime
{
    internal interface IAsyncTimer : IDisposable, IHealthCheckable
    {
        Task<bool> NextTick(TimeSpan? overrideDelay = default);
    }
}

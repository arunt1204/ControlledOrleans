using System.Collections.Generic;
using Nekara.Models;

namespace Orleans.Runtime
{
    public interface IClusterMembershipService
    {
        ClusterMembershipSnapshot CurrentSnapshot { get; }

        IAsyncEnumerable<ClusterMembershipSnapshot> MembershipUpdates { get; }

        System.Threading.Tasks.ValueTask Refresh(MembershipVersion minimumVersion = default);
    }
}

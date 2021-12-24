using System;
using System.Threading.Tasks;

namespace ExplorER
{
    public interface ISynchronizationHelper
    {
        Task InvokeAsync(Action action);
    }
}
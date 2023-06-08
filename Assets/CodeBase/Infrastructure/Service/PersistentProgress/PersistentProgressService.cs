using CodeBase.Data;
using UnityEngine;

namespace CodeBase.Infrastructure.Service.PersistentProgress
{
    public class PersistentProgressService : IPersistentProgressService
    {
        public PlayerProgress Progress { get; set; }
    }
}
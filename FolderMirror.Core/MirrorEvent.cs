using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderMirror.Core
{
    public class EventOutput
    {
        public Event Event { get; set; }
        public string Path { get; set; }
        public string ChangedFullPath { get; set; }
        public string ChangedName { get; set; }
        public string OldChangedFullPath { get; set; }
        public string OldChangedName { get; set; }

        public EventOutput(Event Event, string Path, string ChangedFullPath, string ChangedName, string OldChangedFullPath, string OldChangedName)
        {
            this.Event = Event;
            this.Path = Path;
            this.ChangedFullPath = ChangedFullPath;
            this.ChangedName = ChangedName;
            this.OldChangedFullPath = OldChangedFullPath;
            this.OldChangedName = OldChangedName;
        }

        public EventOutput(Event Event, string Path, string ChangedFullPath, string ChangedName)
            : this(Event, Path, ChangedFullPath, ChangedName, null, null)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace FolderMirror.Core
{
    public delegate void MirrorFileSystemEventHandler(object sender, EventOutput e);
    public class MirrorFileSystemWatcher
    {
        public event MirrorFileSystemEventHandler Trigger = delegate { };

        FileSystemWatcher fsw;
        public MirrorFileSystemWatcher(string path)
        {
            fsw = new FileSystemWatcher(path);
            fsw.IncludeSubdirectories = true;
            fsw.EnableRaisingEvents = true;

            fsw.Changed += new FileSystemEventHandler(delegate (object sender, FileSystemEventArgs e)
            {
                Trigger(sender, new EventOutput(Event.Changed, path, e.FullPath, e.Name));
            });

            fsw.Created += new FileSystemEventHandler(delegate (object sender, FileSystemEventArgs e)
            {
                Trigger(sender, new EventOutput(Event.Created, path, e.FullPath, e.Name));
            });

            fsw.Deleted += new FileSystemEventHandler(delegate (object sender, FileSystemEventArgs e)
            {
                Trigger(sender, new EventOutput(Event.Deleted, path, e.FullPath, e.Name));
            });

            fsw.Renamed += new RenamedEventHandler(delegate (object sender, RenamedEventArgs e)
            {
                Trigger(sender, new EventOutput(Event.Renamed, path, e.FullPath, e.Name, e.OldFullPath, e.OldName));
            });
        }
    }
}

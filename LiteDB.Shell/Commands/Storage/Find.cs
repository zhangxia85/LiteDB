﻿using System;
using System.Linq;

namespace LiteDB.Shell.Commands
{
    internal class FileFind : BaseStorage, IShellCommand
    {
        public bool IsCommand(StringScanner s)
        {
            return this.IsFileCommand(s, "find");
        }

        public BsonValue Execute(LiteEngine engine, StringScanner s)
        {
            var fs = new LiteStorage(engine);

            if (s.HasTerminated)
            {
                var files = fs.FindAll().Select(x => x.AsDocument);

                return new BsonArray(files);
            }
            else
            {
                var id = this.ReadId(s);

                var files = fs.Find(id).Select(x => x.AsDocument);

                return new BsonArray(files);
            }
        }
    }
}
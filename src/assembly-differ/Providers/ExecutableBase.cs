﻿using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Differ.Providers
{
	public class ExecutableBase
	{
		protected static bool IsWindows { get; } = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

		protected static string FindExecutable(string name)
		{
			var path = Environment.GetEnvironmentVariable("PATH");

			if (string.IsNullOrEmpty(path))
				throw new Exception("PATH environment variable is null or empty");

			foreach (var p in path.Split(';'))
			{
				var exe = Path.Combine(Environment.ExpandEnvironmentVariables(p), name);
				if (File.Exists(exe))
					return exe;
			}

			throw new Exception($"Cannot find {name} in PATH environment variable. Add {name} to PATH or use specific environment variable");
		}
	}
}
